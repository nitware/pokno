using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Service;
using Pokno.Store.Interfaces;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Interfaces;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Pokno.Store.ViewModels
{
    public abstract class BaseSoldStockViewModel : PaymentDetailViewModelBase
    {
        private SoldStock _outgoingStock;
        private ObservableCollection<SoldStock> _outgoingStocks;
        private ObservableCollection<SoldStockBatch> _outgoingStockBatches;
        private SoldStockBatch _outgoingStockBatch;
        private ObservableCollection<Person> _customers;
        private Person _customer;

        private decimal _discount;
        private decimal _amountPayable;
        private decimal _transactionDiscount;
        private decimal _totalSellingPrice;
        private string _invoiceNoDisplay;
        private string _invoiceNo;
        private decimal _balance;
        private bool _isItemSavable;
        private BitmapImage _searchIcon;

        protected readonly ISoldStockService _service;
        private readonly ISetupService<Person> _personService;
        protected BackgroundWorker _worker;

        public BaseSoldStockViewModel(IBusinessFacade businessFacade, ISoldStockService service, ISetupService<Person> personService, ISetupService<PaymentType> paymentTypeService, IPaymentService paymentService)
            : base(businessFacade, paymentTypeService, paymentService)
        {
            _service = service;
            _personService = personService;
            _dispatcher = Application.Current.Dispatcher;

            Payment = new Payment();
            TargetModel = new PaymentDetail();
            TargetModel.PaymentDate = Utility.GetDate();

            SearchIcon = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\search.jpg");
            SearchCommand = new DelegateCommand(OnSearchCommand);
        }

        protected List<SoldStock> StocksToRemove { get; set; }
        public DelegateCommand SearchCommand { get; protected set; }
        public int OutgoingStocksCount { get; set; }

        //protected abstract void UpdateButtons(Edit.Mode viewState);

        public BitmapImage SearchIcon
        {
            get { return _searchIcon; }
            set
            {
                _searchIcon = value;
                base.OnPropertyChanged("SearchIcon");
            }
        }
        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set
            {
                _invoiceNo = value;
                OnPropertyChanged("InvoiceNo");
            }
        }
        public string InvoiceNoDisplay
        {
            get { return _invoiceNoDisplay; }
            set
            {
                _invoiceNoDisplay = value;
                OnPropertyChanged("InvoiceNoDisplay");
            }
        }
        public decimal AmountPayable
        {
            get { return _amountPayable; }
            set
            {
                _amountPayable = value;
                OnPropertyChanged("AmountPayable");
            }
        }
        public decimal TransactionDiscount
        {
            get { return _transactionDiscount; }
            set
            {
                _transactionDiscount = value;
                base.OnPropertyChanged("TransactionDiscount");
            }
        }
        public decimal Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                base.OnPropertyChanged("Discount");
            }
        }
        public decimal TotalSellingPrice
        {
            get { return _totalSellingPrice; }
            set
            {
                _totalSellingPrice = value;
                base.OnPropertyChanged("TotalSellingPrice");
            }
        }
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                base.OnPropertyChanged("Balance");
            }
        }
        public ObservableCollection<SoldStockBatch> OutgoingStockBatches
        {
            get { return _outgoingStockBatches; }
            set
            {
                _outgoingStockBatches = value;
                OnPropertyChanged("OutgoingStockBatches");
            }
        }
        public SoldStockBatch OutgoingStockBatch
        {
            get { return _outgoingStockBatch; }
            set
            {
                _outgoingStockBatch = value;
                OnPropertyChanged("OutgoingStockBatch");

                GetAllSoldStocksBy(_outgoingStockBatch);
            }
        }
        private bool IsItemSavable
        {
            get { return _isItemSavable; }
            set
            {
                _isItemSavable = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<SoldStock> OutgoingStocks
        {
            get { return _outgoingStocks; }
            set
            {
                _outgoingStocks = value;
                OnPropertyChanged("OutgoingStocks");
            }
        }
        public SoldStock OutgoingStock
        {
            get { return _outgoingStock; }
            set
            {
                _outgoingStock = value;
                OnPropertyChanged("OutgoingStock");

                //UpdateButtons(Edit.Mode.Selected);
                UpdateViewState(Edit.Mode.Selected);
            }
        }
        public ObservableCollection<Person> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                base.OnPropertyChanged("Customers");
            }
        }
        public Person Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                base.OnPropertyChanged("Customer");
            }
        }

        private bool IsView(UI.Sales ui)
        {
            return ui == UI.Sales.EditSoldItems;
        }
        protected void OnInitialise(UI.Sales ui)
        {
            try
            {
                RefreshUi();

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _service.LoadAllOutgoingStockBatch();
                            //LoadAllSoldStockBatch();
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnInitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    List<SoldStockBatch> soldStockBatches = e.Result as List<SoldStockBatch>;
                    PopulateSoldStockBatch(soldStockBatches);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        
        private void GetAllSoldStocksBy(SoldStockBatch soldStockBatch)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.DoWork += (s, e) =>
                    {
                        if (soldStockBatch != null && soldStockBatch.Id > 0)
                        {
                            //ReceiptNumberDisplay = _outgoingStockBatch.Id;
                            
                            if (soldStockBatch.Payment != null)
                            {
                                Payment = soldStockBatch.Payment;
                                AmountPayable = soldStockBatch.Payment.AmountPayable;
                                InvoiceNoDisplay = _outgoingStockBatch.Payment.InvoiceNumber;
                                InvoiceNo = _outgoingStockBatch.Payment.InvoiceNumber;
                            }
                            else
                            {
                                InvoiceNo = null;
                                AmountPayable = 0;
                                InvoiceNoDisplay = null;
                                Payment = new Payment();
                            }

                            LoadAllOutgoingStockBy(soldStockBatch);
                        }
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                List<Person> people = _personService.LoadAll();
                LoadCustomersHelper(people);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadCustomersHelper(List<Person> people)
        {
            try
            {
                if (people != null && people.Count > 0)
                {
                    _dispatcher.Invoke(() =>
                    {
                        List<Person> customers = people.Where(s => s.Type.Id == (int)PoknoPersonType.Customer).ToList();
                        if (customers != null)
                        {
                            if (customers.Count > 0)
                            {
                                customers.Insert(0, new Person() { FullName = "<< Select Customer >>" });
                            }

                            Customers = new ObservableCollection<Person>(customers);
                            Customer = Customers.FirstOrDefault();

                            if (OutgoingStockBatch != null && OutgoingStockBatch.Customer != null)
                            {
                                Person customer = customers.Where(c => c.Id == OutgoingStockBatch.Customer.Id).SingleOrDefault();
                                if (customer != null)
                                {
                                    Customer = customer;
                                }
                            }
                            else
                            {
                                if (OutgoingStocks != null)
                                {
                                    ObservableCollection<SoldStock> soldStocks = OutgoingStocks;
                                    if (soldStocks.Count > 0)
                                    {
                                        if (soldStocks[0].Batch != null && soldStocks[0].Batch.Customer != null)
                                        {
                                            Person customer = customers.Where(c => c.Id == soldStocks[0].Batch.Customer.Id).SingleOrDefault();
                                            if (customer != null)
                                            {
                                                Customer = customer;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSearchCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(InvoiceNo))
                {
                    Utility.DisplayMessage("Invalid invoice no. entered!");
                    return;
                }
                
                if (OutgoingStockBatches != null && OutgoingStockBatches.Count > 0)
                {
                    OutgoingStockBatch = OutgoingStockBatches.FirstOrDefault();
                }

                LoadAllOutgoingStockByInvoiceNo(InvoiceNo);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllOutgoingStockByInvoiceNo(string invoiceNo)
        {
            try
            {
                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllOutgoingStockByReceiptNumberCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            //List<SoldStock> soldStocks = _service.LoadOutgoingStockByBatchId(receiptNumber);

                            List<SoldStock> soldStocks = _businessFacade.GetSoldStockByInvoiceNo(invoiceNo);
                            e.Result = LoadSoldStockHelper(soldStocks);
                        };
                    _worker.RunWorkerAsync();
                }
                
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private Dictionary<string, object> LoadSoldStockHelper(List<SoldStock> soldStocks)
        {
            try
            {
                Dictionary<string, object> dictionary = null;
                if (soldStocks != null && soldStocks.Count > 0)
                {
                    List<PaymentDetail> paymentDetails = null;
                    List<Person> people = _personService.LoadAll();
                    List<PaymentType> paymentTypes = _businessFacade.GetAllPaymentTypes();

                    if (soldStocks[0].Batch != null && soldStocks[0].Batch.Id > 0 && soldStocks[0].Batch.Payment != null && soldStocks[0].Batch.Payment.Id > 0)
                    {
                        paymentDetails = _paymentService.LoadPaymentDetailByPayment(soldStocks[0].Batch.Payment);
                    }

                    dictionary = new Dictionary<string, object>();
                    dictionary["paymentDetails"] = paymentDetails;
                    dictionary["paymentTypes"] = paymentTypes;
                    dictionary["soldStocks"] = soldStocks;
                    dictionary["people"] = people;

                    //e.Result = dictionary;
                }

                return dictionary;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void OnLoadAllOutgoingStockByReceiptNumberCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result == null)
                {
                    RefreshUi();
                    Utility.DisplayMessage("No sales transaction found for invoice no. '" + InvoiceNo + "' entered!");

                    return;
                }
                

                List<Person> people = null;
                List<SoldStock> soldStocks = null;
                List<PaymentType> paymentTypes = null;
                List<PaymentDetail> paymentDetails = null;

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    paymentDetails = (List<PaymentDetail>)dictionary["paymentDetails"];
                    paymentTypes = (List<PaymentType>)dictionary["paymentTypes"];
                    soldStocks = (List<SoldStock>)dictionary["soldStocks"];
                    people = (List<Person>)dictionary["people"];
                }

                if (soldStocks != null && soldStocks.Count > 0)
                {
                    _dispatcher.Invoke(() =>
                    {
                        OutgoingStocks = new ObservableCollection<SoldStock>(soldStocks);
                        OutgoingStockBatch = soldStocks[0].Batch;

                        //ReceiptNumberDisplay = OutgoingStockBatch.Id;
                        if (OutgoingStockBatch.Payment != null)
                        {
                            Payment = OutgoingStockBatch.Payment;
                            AmountPayable = OutgoingStockBatch.Payment.AmountPayable;
                            InvoiceNoDisplay = OutgoingStockBatch.Payment.InvoiceNumber;
                            InvoiceNo = OutgoingStockBatch.Payment.InvoiceNumber;
                        }
                        else
                        {
                            InvoiceNo = null;
                            AmountPayable = 0;
                            InvoiceNoDisplay = null;
                            Payment = new Payment();
                        }

                        foreach (SoldStock soldStock in OutgoingStocks)
                        {
                            soldStock.PropertyChanged += OutgoingStock_PropertyChanged;
                        }

                        OutgoingStock = null;
                        StocksToRemove = new List<SoldStock>();

                        //LoadAllOutgoingStockHelper(soldStocks.Count);
                        LoadAllOutgoingStockHelper(paymentDetails, paymentTypes, soldStocks.Count, people);
                    });
                }
                else
                {
                    RefreshUi();
                    Utility.DisplayMessage("No sales transaction found for invoice no. '" + InvoiceNo + "' entered!");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadAllOutgoingStockHelper(List<PaymentDetail> paymentDetails, List<PaymentType> paymentTypes, int totalSoldStocks, List<Person> people)
        {
            try
            {
                OutgoingStocksCount = totalSoldStocks;
                LoadAllPaymentTypeHelper(paymentTypes);

                if (Payment != null && Payment.Id > 0)
                {
                    LoadPaymentDetailsByPaymentHelper(paymentDetails);
                }

                LoadCustomersHelper(people);

                ComputeBalance();
                UpdateViewState(Edit.Mode.Adding);
                //UpdateButtons(Edit.Mode.Adding);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdateCartSummary()
        {
            try
            {
                if (OutgoingStocks == null)
                {
                    return;
                }

                ObservableCollection<SoldStock> outgoingStocks = OutgoingStocks;
                if (outgoingStocks != null && outgoingStocks.Count > 0)
                {
                    TotalSellingPrice = outgoingStocks.Sum(ogs => ogs.Price.SellingPrice);
                    Discount = (decimal)outgoingStocks.Sum(ogs => ogs.Discount);

                    if (OutgoingStockBatch != null)
                    {
                        TransactionDiscount = OutgoingStockBatch.TotalDiscount;
                    }

                    AmountPayable = TotalSellingPrice - (TransactionDiscount + Discount);
                    Balance = AmountPayable - TotalAmount;

                    if (TargetModel != null)
                    {
                        TargetModel.AmountPaid = AmountPayable;
                    }
                }
                else
                {
                    TotalAmount = 0;
                    AmountPayable = 0;
                    TotalSellingPrice = 0;
                    Balance = AmountPayable - TotalAmount;

                    if (TargetModel != null)
                    {
                        TargetModel.AmountPaid = AmountPayable;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void ComputeBalance()
        {
            try
            {
                base.ComputeBalance();
                UpdateCartSummary();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void PopulateSoldStockBatch(List<SoldStockBatch> soldStockBatches)
        {
            try
            {
                if (soldStockBatches != null )
                {
                    if (soldStockBatches.Count > 0)
                    {
                        soldStockBatches.Insert(0, new SoldStockBatch() { Customer = new Person() { Name = "<< Select Sales Batch >>" } });
                    }

                    _dispatcher.Invoke(() =>
                    {
                        OutgoingStockBatches = new ObservableCollection<SoldStockBatch>(soldStockBatches);
                        OutgoingStockBatch = OutgoingStockBatches.FirstOrDefault();

                        foreach (SoldStockBatch soldStockBatch in OutgoingStockBatches)
                        {
                            soldStockBatch.PropertyChanged += soldStockBatch_PropertyChanged;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllSoldStockBatch()
        {
            try
            {
                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllSoldStockBatchCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _service.LoadAllOutgoingStockBatch();
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadAllSoldStockBatchCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    List<SoldStockBatch> soldStockBatches = e.Result as List<SoldStockBatch>;
                    PopulateSoldStockBatch(soldStockBatches);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void soldStockBatch_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "TotalDiscount")
                {
                    //UpdateButtons(Edit.Mode.Editing);
                    UpdateViewState(Edit.Mode.Editing);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadAllOutgoingStockBy(SoldStockBatch soldStockBatch)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllOutgoingStockByCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<SoldStock> soldStocks = _service.LoadOutgoingStockByBatch(soldStockBatch);
                        e.Result = LoadSoldStockHelper(soldStocks);
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadAllOutgoingStockByCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                const string NO_TRANSACTION_MESSAGE = "No sales transaction found for the selected sales batch!";

                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result == null)
                {
                    RefreshUi();
                    Utility.DisplayMessage(NO_TRANSACTION_MESSAGE);

                    return;
                }

                Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                List<PaymentDetail> paymentDetails = (List<PaymentDetail>)dictionary["paymentDetails"];
                List<PaymentType> paymentTypes = (List<PaymentType>)dictionary["paymentTypes"];
                List<SoldStock> soldStocks = (List<SoldStock>)dictionary["soldStocks"];
                List<Person> people = (List<Person>)dictionary["people"];

                if (soldStocks != null)
                {
                    soldStocks = soldStocks.OrderBy(s => s.ShelfStock.StockPackage.Stock.Name).ToList();

                    _dispatcher.Invoke(() =>
                    {
                        OutgoingStocks = new ObservableCollection<SoldStock>(soldStocks);
                        foreach (SoldStock soldStock in OutgoingStocks)
                        {
                            soldStock.PropertyChanged += OutgoingStock_PropertyChanged;
                        }

                        OutgoingStock = null;
                        StocksToRemove = new List<SoldStock>();

                        //LoadAllOutgoingStockHelper(soldStocks.Count);
                        LoadAllOutgoingStockHelper(paymentDetails, paymentTypes, soldStocks.Count, people);
                    });
                }
                else
                {
                    RefreshUi();
                    Utility.DisplayMessage(NO_TRANSACTION_MESSAGE);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OutgoingStock_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Returned")
            {
                //UpdateButtons(Edit.Mode.Selected);
                UpdateViewState(Edit.Mode.Selected);
            }
        }

        //private void LoadAllOutgoingStockHelper(int totalStocks)
        //{
        //    try
        //    {
        //        OutgoingStocksCount = totalStocks;

        //        LoadAllPaymentType();
        //        if (Payment != null && Payment.Id > 0)
        //        {
        //            LoadPaymentDetailsByPayment(Payment);
        //        }

        //        LoadCustomers();
        //        ComputeBalance();
        //        UpdateButtons(Edit.Mode.Adding);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        protected void RefreshUi()
        {
            try
            {
                base.Clear();
                ClearSummary();
                ClearCustomer();

                //ReceiptNumberDisplay = 0;

                InvoiceNo = null;
                InvoiceNoDisplay = null;
                OutgoingStocks = new ObservableCollection<SoldStock>();
                if (OutgoingStockBatches != null && OutgoingStockBatches.Count > 0)
                {
                    OutgoingStockBatch = OutgoingStockBatches.FirstOrDefault();
                }

                UpdateViewState(Edit.Mode.Loaded);
                //UpdateButtons(Edit.Mode.Loaded);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void ClearPaymentTypes()
        {
            try
            {
                PaymentTypes = new ObservableCollection<PaymentType>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //protected override void Clear()
        //{
        //    try
        //    {
        //        base.Clear();
        //        PaymentTypes = new ObservableCollection<PaymentType>();
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        protected virtual void ClearCustomer()
        {
            try
            {
                if (Customers != null && Customers.Count > 0)
                {
                    Customers = new ObservableCollection<Person>();
                }

                //if (Customers != null && Customers.Count > 0)
                //{
                //    Customer = Customers.FirstOrDefault();
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearSummary()
        {
            Discount = 0;
            TotalSellingPrice = 0;
            TransactionDiscount = 0;
            AmountPayable = 0;
            AmountPaid = 0;
            Balance = 0;

            if (TargetModel != null)
            {
                TargetModel.AmountPaid = 0;
            }
        }


        

       

        
    }


}
