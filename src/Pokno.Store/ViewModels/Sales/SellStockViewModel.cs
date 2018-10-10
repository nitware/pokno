using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Linq;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Model.Model;
using System.ComponentModel;
using Pokno.Model;
using System.Collections.ObjectModel;
using Pokno.Store.Interfaces;
using Pokno.Infratructure.Services;
using Prism.Events;
using Prism.Commands;
using System.Collections.Generic;
using System.Windows.Data;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel.Popups;
using Pokno.Infrastructure.View.Popups;
using Pokno.Service;
using Pokno.Infrastructure.Events;
using System.Windows.Media.Imaging;
using Pokno.Infrastructure.ViewModels;

namespace Pokno.Store.ViewModels
{
    public class SellStockViewModel : ObservableCollectionManagerBase<StockForSale>
    {
        private Dispatcher _dispatcher;
        private IEventAggregator _eventAggregator;

        private decimal _netTotal;
        private decimal _discount;
        private int _cartItemCount;
        private decimal _subTotal;
        private decimal _balance;
        private decimal _amountPaid;
        private ListCollectionView _paymentDetails;
        private PaymentDetail _paymentDetail;
        private ObservableCollection<Person> _customers;
        private Person _customer;
        private ObservableCollection<PaymentType> _paymentTypes;
        private PaymentType _paymentType;
        private int _cartDataGridSelectedIndex;
        private bool _isItemInCart;
        private bool _canPaymentBeAdded;
        private bool _cartItemIsSelected;
        private Shelf _shelf;
        private DateTime _dateSold;
        private bool _isDateSoldEnabled;
        private BitmapImage _searchIcon;
        private bool _isStockPriceChangeable;
        private bool _isBusy;

        private IPosService _service;
        private StockForSale _stockForSale;
        private ISellStockService _stockSaleService;
        private ISetupService<Person> _personService;
        private ISetupService<PaymentType> _paymentTypeService;
        private ListCollectionView _stocksForSale;

        private ObservableCollection<StockOnShelfAtHand> _stocksOnShelfAtHand;
        private ObservableCollection<StockOnShelfAtHand> _stocksOnShelfAtHandBackUp;
        private ObservableCollectionManager<PaymentDetail> _paymentCollectionManager;
        private StockPricePopUpViewModel _stockPriceVM;

        private Window PopUp;
        //private Window ChangePricePopUp;
        private BackgroundWorker _worker;
        private readonly IBusinessFacade _businessFacade;

        public SellStockViewModel(StockPricePopUpViewModel stockPriceVM, IBusinessFacade businessFacade, IEventAggregator eventAggregator, ISetupService<PaymentType> paymentTypeService, ISetupService<Person> personService, IPosService service, ISellStockService stockSaleService)
        {
            _service = service;
            _stockPriceVM = stockPriceVM;
            _eventAggregator = eventAggregator;
            _stockSaleService = stockSaleService;
            _paymentTypeService = paymentTypeService;
            _personService = personService;
            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;

            PaymentDetail = new PaymentDetail();
            PaymentDetail.Payment = new Payment();
            PaymentDetail.Payment.DatePaid = Utility.GetDate();
            PaymentDetail.PaymentDate = Utility.GetDate();
            _paymentCollectionManager = new ObservableCollectionManager<PaymentDetail>();

            DateSold = Utility.GetDate();
            ChangePriceCommand = new DelegateCommand(OnChangePriceCommand, CanChangeStockPrice);
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChangedCommand);
            TreeViewSelectedItemChangedCommand = new DelegateCommand<object>(OnTreeViewSelectedItemChangedCommand, CanSelectItem);
            ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
            RemoveCommand = new DelegateCommand(OnRemoveCommand, CanRemove);
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
            AddCommand = new DelegateCommand(OnAddCommand, CanAdd);
            RemoveCartItemCommand = new DelegateCommand(OnRemoveCartItemCommand, CanRemoveCartItem);
            ClearCartCommand = new DelegateCommand(OnClearCartCommand, CanClearCart);
            AddPaymentCommand = new DelegateCommand(OnAddPaymentCommand, CanAddPayment);
            ReloadCommand = new DelegateCommand(OnReloadCommand);

            //IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSellStock;

            SetUserViewRight();

            SearchIcon = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\search.jpg");
            eventAggregator.GetEvent<SalesEvent>().Subscribe(Oninitialise, ThreadOption.UIThread, false, IsView);
            Oninitialise(UI.Sales.SellStock);
        }
                  
        public DelegateCommand ChangePriceCommand { get; private set; }
        public DelegateCommand AddPaymentCommand { get; private set; }
        public DelegateCommand ClearCartCommand { get; private set; }
        public DelegateCommand RemoveCartItemCommand { get; private set; }
        public ICommand TreeViewSelectedItemChangedCommand { get; private set; }
        public ICommand SelectionChangedCommand { get; private set; }
        public DelegateCommand ReloadCommand { get; private set; }
                
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy)
                {
                    ModelCanBeSaved = false;
                }

                base.OnPropertyChanged("IsBusy");
            }
        }

        private bool IsView(UI.Sales ui)
        {
            return ui == UI.Sales.SellStock;
        }
        public bool IsStockPriceChangeable
        {
            get { return _isStockPriceChangeable; }
            set
            {
                _isStockPriceChangeable = value;
                base.OnPropertyChanged("IsStockPriceChangeable");
                ChangePriceCommand.RaiseCanExecuteChanged();
            }
        }
        private void Oninitialise(UI.Sales ui)
        {
            try
            {
                SetUserViewRight();
                
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) => 
                    {
                        List<StockOnShelfAtHand> stocksOnShelfAtHand = _service.LoadStocksOnShelfAtHand();
                        List<Stock> stocks = _businessFacade.GetAllStocks();
                        List<PaymentType> paymentTypes = _paymentTypeService.LoadAll();
                        List<Person> people = _personService.LoadAll();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stocksOnShelfAtHand"] = stocksOnShelfAtHand;
                        dictionary["paymentTypes"] = paymentTypes;
                        dictionary["people"] = people;
                        dictionary["stocks"] = stocks;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }

                
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void LoadStocksOnShelfAtHand()
        //{
        //    try
        //    {
        //        List<StockOnShelfAtHand> stocksOnShelfAtHand = _service.LoadStocksOnShelfAtHand();
        //        PopulateStockOnShelfAthand(stocksOnShelfAtHand);


        //        //using (_worker = new BackgroundWorker())
        //        //{
        //        //    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadStocksOnShelfAtHandCompleted);
        //        //    _worker.DoWork += (s, e) =>
        //        //    {
        //        //        e.Result = _service.LoadStocksOnShelfAtHand();
        //        //    };
        //        //    _worker.RunWorkerAsync();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        //private void OnLoadStocksOnShelfAtHandCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Error != null)
        //        {
        //            Utility.DisplayMessage(e.Error.Message);
        //        }

        //        if (e.Result != null)
        //        {
        //            List<StockOnShelfAtHand> stocksOnShelfAtHand = (List<StockOnShelfAtHand>)e.Result;
        //            PopulateStockOnShelfAthand(stocksOnShelfAtHand);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

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
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    List<StockOnShelfAtHand> stocksOnShelfAtHand = (List<StockOnShelfAtHand>)dictionary["stocksOnShelfAtHand"];
                    List<PaymentType> paymentTypes = (List<PaymentType>)dictionary["paymentTypes"];
                    List<Person> people = (List<Person>)dictionary["people"];
                    List<Stock> stocks = (List<Stock>)dictionary["stocks"];

                    PopulateStock(stocks);
                    PopulatePaymentType(paymentTypes);
                    PopulateStockOnShelfAthand(stocksOnShelfAtHand);
                    PopulatedCustomers(people);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStock(List<Stock> stocks)
        {
            try
            {
                if (stocks != null)
                {
                    Stocks = new ObservableCollection<Stock>(stocks);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
               
        public string TabCaption
        {
            get { return "Sell Stock"; }
        }
        public BitmapImage SearchIcon
        {
            get { return _searchIcon; }
            set
            {
                _searchIcon = value;
                base.OnPropertyChanged("SearchIcon");
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
        public int CartItemCount
        {
            get { return _cartItemCount; }
            set
            {
                _cartItemCount = value;
                base.OnPropertyChanged("CartItemCount");
            }
        }
        public decimal Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;

                NetTotal = SubTotal - _discount;
                AmountPaid = NetTotal;
                GetBalance();


                ClearPaymentDetails();
                UpdateViewState(Edit.Mode.Adding);

                base.OnPropertyChanged("Discount");
            }
        }
        public bool IsDateSoldEnabled
        {
            get { return _isDateSoldEnabled; }
            set
            {
                _isDateSoldEnabled = value;
                base.OnPropertyChanged("IsDateSoldEnabled");
            }
        }
        public DateTime DateSold
        {
            get { return _dateSold; }
            set
            {
                _dateSold = value;
                base.OnPropertyChanged("DateSold");
            }
        }
        public decimal SubTotal
        {
            get { return _subTotal; }
            set
            {
                _subTotal = value;
                base.OnPropertyChanged("SubTotal");
            }
        }
        public decimal NetTotal
        {
            get { return _netTotal; }
            set
            {
                _netTotal = value;
                base.OnPropertyChanged("NetTotal");
            }
        }

        public ObservableCollection<StockOnShelfAtHand> StocksOnShelfAtHand
        {
            get { return _stocksOnShelfAtHand; }
            set
            {
                _stocksOnShelfAtHand = value;
                OnPropertyChanged("StocksOnShelfAtHand");
            }
        }
        public ObservableCollection<StockOnShelfAtHand> StocksOnShelfAtHandBackUp
        {
            get { return _stocksOnShelfAtHandBackUp; }
            set
            {
                _stocksOnShelfAtHandBackUp = value;
                OnPropertyChanged("StocksOnShelfAtHandBackUp");
            }
        }

        public Shelf Shelf
        {
            get { return _shelf; }
            set
            {
                _shelf = value;
                base.OnPropertyChanged("Shelf");
            }
        }

        public ListCollectionView StocksForSale
        {
            get { return _stocksForSale; }
            set
            {
                _stocksForSale = value;
                base.OnPropertyChanged("StocksForSale");
            }
        }

        //public ObservableCollection<StockForSale> StocksForSale
        //{
        //    get { return _stocksForSale; }
        //    set
        //    {
        //        _stocksForSale = value;
        //        base.OnPropertyChanged("StocksForSale");
        //    }
        //}
        public StockForSale StockForSale
        {
            get { return _stockForSale; }
            set
            {
                _stockForSale = value;
                base.OnPropertyChanged("StockForSale");
            }
        }

        public decimal AmountPaid
        {
            get { return _amountPaid; }
            set
            {
                _amountPaid = value;
                base.OnPropertyChanged("AmountPaid");
            }
        }
        public ListCollectionView PaymentDetails
        {
            get { return _paymentDetails; }
            set
            {
                _paymentDetails = value;
                base.OnPropertyChanged("PaymentDetails");
            }
        }
        public PaymentDetail PaymentDetail
        {
            get { return _paymentDetail; }
            set
            {
                _paymentDetail = value;
                base.OnPropertyChanged("PaymentDetail");
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

        //public ICollectionView Customers
        //{
        //    get { return _customers; }
        //    set
        //    {
        //        _customers = value;
        //        base.OnPropertyChanged("Customers");
        //    }
        //}

        public Person Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                base.OnPropertyChanged("Customer");
            }
        }

        public ObservableCollection<PaymentType> PaymentTypes
        {
            get { return _paymentTypes; }
            set
            {
                _paymentTypes = value;
                base.OnPropertyChanged("PaymentTypes");
            }
        }

        //public ICollectionView PaymentTypes
        //{
        //    get { return _paymentTypes; }
        //    set
        //    {
        //        _paymentTypes = value;
        //        base.OnPropertyChanged("PaymentTypes");
        //    }
        //}

        public PaymentType PaymentType
        {
            get { return _paymentType; }
            set
            {
                _paymentType = value;
                base.OnPropertyChanged("PaymentType");

                PaymentDetail.PaymentType = _paymentType;
            }
        }

        public int CartDataGridSelectedIndex
        {
            get { return _cartDataGridSelectedIndex; }
            set
            {
                _cartDataGridSelectedIndex = value;
                base.OnPropertyChanged("CartDataGridSelectedIndex");
            }
        }

        private bool CanPaymentBeAdded
        {
            get { return _canPaymentBeAdded; }
            set
            {
                _canPaymentBeAdded = value;
                AddPaymentCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsItemInCart
        {
            get { return _isItemInCart; }
            set
            {
                _isItemInCart = value;
                base.OnPropertyChanged("IsItemInCart");
                ClearCartCommand.RaiseCanExecuteChanged();

            }
        }
        public bool CartItemIsSelected
        {
            get { return _cartItemIsSelected; }
            set
            {
                _cartItemIsSelected = value;
                base.OnPropertyChanged("CartItemIsSelected");
                RemoveCartItemCommand.RaiseCanExecuteChanged();
            }
        }

        private void PopulatePaymentType(List<PaymentType> paymentTypes)
        {
            try
            {
                if (paymentTypes != null)
                {
                    if (paymentTypes.Count > 0)
                    {
                        paymentTypes.Insert(0, new PaymentType() { Name = "<< Select >>" });
                    }

                    _dispatcher.Invoke(() =>
                    {
                        PaymentTypes = new ObservableCollection<PaymentType>(paymentTypes);
                        PaymentType = PaymentTypes.FirstOrDefault();
                        PaymentDetail.PaymentType = PaymentType;
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void LoadAllPaymentType()
        //{
        //    try
        //    {
        //        List<PaymentType> paymentTypes = _paymentTypeService.LoadAll();
        //        if (paymentTypes != null)
        //        {
        //            if (paymentTypes.Count > 0)
        //            {
        //                paymentTypes.Insert(0, new PaymentType() { Name = "<< Select >>" });
        //            }

        //            _dispatcher.Invoke(() =>
        //            {
        //                PaymentTypes = new CollectionView(paymentTypes);
        //                if (PaymentTypes != null)
        //                {
        //                    PaymentTypes.CurrentChanged += (s, e) =>
        //                    {
        //                        if (PaymentTypes.CurrentItem != null)
        //                        {
        //                            PaymentType = PaymentTypes.CurrentItem as PaymentType;
        //                            PaymentDetail.PaymentType = PaymentType;
        //                        }
        //                    };
        //                }
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void PopulateStockOnShelfAthand(List<StockOnShelfAtHand> stocksOnShelfAtHand)
        {
            try
            {
                if (stocksOnShelfAtHand != null)
                {
                    _dispatcher.Invoke(() =>
                    {
                        StocksOnShelfAtHand = new ObservableCollection<StockOnShelfAtHand>(stocksOnShelfAtHand);
                        ObservableCollection<StockOnShelfAtHand> backUpOfStocksOnShelf = new ObservableCollection<StockOnShelfAtHand>();
                        StocksOnShelfAtHandBackUp = backUpOfStocksOnShelf;

                        RawStocksOnShelfAtHand = StocksOnShelfAtHand;
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void LoadStockOnShelfAthand()
        //{
        //    try
        //    {
        //        List<StockOnShelfAtHand> stocksOnShelfAtHand = _service.LoadStocksOnShelfAtHand();
        //        if (stocksOnShelfAtHand != null)
        //        {
        //            _dispatcher.Invoke(() =>
        //            {
        //                StocksOnShelfAtHand = new ObservableCollection<StockOnShelfAtHand>(stocksOnShelfAtHand);
        //                ObservableCollection<StockOnShelfAtHand> backUpOfStocksOnShelf = new ObservableCollection<StockOnShelfAtHand>();
        //                StocksOnShelfAtHandBackUp = backUpOfStocksOnShelf;

        //                RawStocksOnShelfAtHand = StocksOnShelfAtHand;
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void OnAddCommand()
        {

        }
        private bool CanChangeStockPrice()
        {
            return IsStockPriceChangeable;
        }
        private bool CanAddPayment()
        {
            return CanPaymentBeAdded;
        }
        private bool CanClearCart()
        {
            return IsItemInCart;
        }

        private bool CanSelectItem(object param)
        {
            return true;
        }
        private bool CanRemoveCartItem()
        {
            return CartItemIsSelected;
        }
        private void OnSelectionChangedCommand(object param)
        {
            try
            {
                if (param != null)
                {
                    if (typeof(StockForSale) == param.GetType())
                    {
                        StockForSale = (StockForSale)param;
                        if (StockForSale != null)
                        {
                            UpdateViewState(Edit.Mode.Selected);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulatedCustomers(List<Person> people)
        {
            try
            {
                if (people != null && people.Count > 0)
                {
                    List<Person> customers = people.Where(s => s.Type.Id == (int)PoknoPersonType.Customer).ToList();
                    if (customers != null && customers.Count > 0)
                    {
                        customers.Insert(0, new Person() { FullName = "<< Select Customer >>" });
                        _dispatcher.Invoke(() =>
                        {
                            Customers = new ObservableCollection<Person>(customers);
                            Customer = Customers.FirstOrDefault();
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void LoadCustomers()
        //{
        //    try
        //    {
        //        List<Person> people = _personService.LoadAll();
        //        if (people != null && people.Count > 0)
        //        {
        //            List<Person> customers = people.Where(s => s.Type.Id == (int)PoknoPersonType.Customer).ToList();
        //            if (customers != null && customers.Count > 0)
        //            {
        //                customers.Insert(0, new Person() { FullName = "<< Select Customer >>" });
        //                _dispatcher.Invoke(() =>
        //                {
        //                    Customers = new CollectionView(customers);
        //                    Customers.CurrentChanged += (s, e) =>
        //                    {
        //                        Customer = Customers.CurrentItem as Person;
        //                    };
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private bool IsPaymentTypeSelected()
        {
            try
            {
                if (PaymentType == null || PaymentType.Id <= 0)
                {
                    Utility.DisplayMessage("Please select Payment Type!");
                    return true;
                }
                else if (PaymentType.Name != "Credit" && AmountPaid == 0)
                {
                    Utility.DisplayMessage("Amount Paid must be greater than zero when selected Payment Type is not Credit! Please modify");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void PopUpView_Closed(object sender, EventArgs e)
        {
            try
            {
                if (PopUp.DialogResult != null)
                {
                    bool result = (PopUp.DialogResult != null) ? Convert.ToBoolean(PopUp.DialogResult) : false;
                    BankAccountDetailPopUpViewModel popupDialogViewModel = (BankAccountDetailPopUpViewModel)PopUp.DataContext;

                    if (result)
                    {
                        PaymentDetail.Cheque = popupDialogViewModel.Cheque;
                        UpdatePaymentDetails(PaymentDetail.Cheque);
                        ComputeBalance();
                    }
                }

                SetUserViewRight();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SetUserViewRight()
        {
            try
            {
                if (Utility.LoggedInUser != null && Utility.LoggedInUser.Role != null && Utility.LoggedInUser.Role.PersonRight != null)
                {
                    IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSellStock;
                    IsStockPriceChangeable = Utility.LoggedInUser.Role.PersonRight.CanChangeStockPrice;
                    IsDateSoldEnabled = Utility.LoggedInUser.Role.PersonRight.CanSelectSoldDateOnSellStockPage;
                }
                else
                {
                    IsStockPriceChangeable = false;
                    IsLoggedInUserHasRight = false;
                    IsDateSoldEnabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnAddPaymentCommand()
        {
            try
            {
                if (IsPaymentTypeSelected())
                {
                    return;
                }

                PaymentDetail.Cheque = null;
                if (PaymentType.Id == (int)PoknoPaymentType.Cheque)
                {
                    PopUp = new BankAccountDetailPopUpView(_businessFacade);
                    PopUp.Closed += new EventHandler(PopUpView_Closed);

                    PopUp.ShowDialog();
                }
                else if (PaymentType.Id == (int)PoknoPaymentType.Cash || PaymentType.Id == (int)PoknoPaymentType.POS || PaymentType.Id == (int)PoknoPaymentType.BankTransfer)
                {
                    UpdatePaymentDetails(null);
                }
                else if (PaymentType.Id == (int)PoknoPaymentType.Credit)
                {
                    if (_paymentCollectionManager.Collection != null)
                    {
                        if (_paymentCollectionManager.Collection.Count > 0)
                        {
                            Utility.DisplayMessage("You cannot add payment type ( Credit ) to the payment details at this time. If you still want to continue, then clear all Payments before adding a Credit payment type.");
                            return;
                        }
                        else
                        {
                            AmountPaid = 0;
                            UpdatePaymentDetails(null);
                        }
                    }
                }

                ComputeBalance();
                UpdateViewState(Edit.Mode.Adding);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void ComputeBalance()
        {
            try
            {
                if (PaymentDetails != null)
                {
                    ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)PaymentDetails.SourceCollection;
                    decimal totalAmountPaid = paymentDetails.Sum(a => a.AmountPaid);
                    PaymentDetail.AmountPaid = totalAmountPaid;

                    GetBalance();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdatePaymentDetails(Cheque cheque)
        {
            try
            {
                _paymentCollectionManager.Collection.Add(GetNewPaymentDetail(cheque));
                RefreshPaymentDetailsCollection();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private PaymentDetail GetNewPaymentDetail(Cheque cheque)
        {
            try
            {
                PaymentDetail newPaymentDetail = new PaymentDetail();
                Payment payment = new Payment();

                Cheque newCheque = null;
                if (cheque != null)
                {
                    Bank bank = new Bank();
                    bank.Id = cheque.Bank.Id;
                    bank.Name = cheque.Bank.Name;

                    newCheque = new Cheque();
                    newCheque.Id = cheque.Id;
                    newCheque.Bank = cheque.Bank;
                    newCheque.ChequeNumber = cheque.ChequeNumber;
                    newCheque.AccountNumber = cheque.AccountNumber;
                }

                newPaymentDetail.Cheque = newCheque;
                payment.AmountPayable = PaymentDetail.Payment.AmountPayable;
                newPaymentDetail.Payment = payment;
                newPaymentDetail.Id = PaymentDetail.Id;

                newPaymentDetail.AmountPaid = AmountPaid;
                newPaymentDetail.PaymentDate = PaymentDetail.PaymentDate;
                newPaymentDetail.PaymentType = PaymentDetail.PaymentType;

                return newPaymentDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void RefreshPaymentDetailsCollection()
        {
            try
            {
                ObservableCollection<PaymentDetail> currentPaymentDetails = _paymentCollectionManager.Collection;
                ObservableCollection<PaymentDetail> refreshedPaymentDetails = _paymentCollectionManager.Refresh(currentPaymentDetails);

                PaymentDetails = new ListCollectionView(refreshedPaymentDetails);
                PaymentDetails.MoveCurrentTo(null);
                PaymentDetails.CurrentChanged += (s, e) =>
                {
                    ModelCanBeRemoved = true;
                    ModelCanBeCleared = false;
                };

                SetPaymentDetailViewState(refreshedPaymentDetails);



                //if (refreshedPaymentDetails.Count == 1)
                //{
                //    ModelCanBeCleared = true;
                //    ModelCanBeRemoved = false;
                //    //UpdateViewState(Edit.Mode.Selected);
                //}
                //else if (refreshedPaymentDetails.Count > 0)
                //{
                //    //UpdateViewState(Edit.Mode.Adding);
                //}
                //else
                //{
                //    ModelCanBeCleared = false;
                //    ModelCanBeRemoved = false;

                //    //UpdateViewState(Edit.Mode.Loaded);
                //}
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void OnSaveCommand()
        {
            try
            {
                if (PaymentDetails == null)
                {
                    Utility.DisplayMessage("No payment information found! Please try again.");
                    return;
                }

                List<PaymentDetail> paymentDetails = new List<PaymentDetail>((IEnumerable<PaymentDetail>)PaymentDetails.SourceCollection);

                if (StocksForSale == null)
                {
                    Utility.DisplayMessage("There is no item in cart! Add item to cart");
                    return;
                }
                else if ((paymentDetails == null || paymentDetails.Count == 0) && PaymentType.Name != "Credit")
                {
                    Utility.DisplayMessage("No payment made! Please select Credit as payment type if this customer will pay later, else enter the payment details.");
                    return;
                }
                else if (Customer == null || Customer.Id <= 0)
                {
                    decimal totalAmountPaid = paymentDetails.Sum(am => am.AmountPaid);
                    if (NetTotal > totalAmountPaid)
                    {
                        Utility.DisplayMessage("You must select a customer! Only known customer is allowed to make payment (" + String.Format("{0:n}", totalAmountPaid) + ") less than Amount Payable (" + String.Format("{0:n}", NetTotal) + "). Please select a customer");
                        return;
                    }
                }

                Payment payment = new Payment();
                payment.TransactionType = new TransactionType() { Id = (int)Payment.Transaction.Sale };
                payment.Details = paymentDetails;
                payment.AmountPayable = NetTotal;
                payment.DatePaid = Utility.GetDate();
                //payment.DatePaid = DateSold;

                SoldStockBatch outgoingStockBatch = new SoldStockBatch();
                outgoingStockBatch.Customer = Customer;
                outgoingStockBatch.DateSold = Utility.GetDate();
                //outgoingStockBatch.DateSold = DateSold;
                outgoingStockBatch.Payment = payment;
                outgoingStockBatch.Seller = Utility.LoggedInUser;
                outgoingStockBatch.TotalDiscount = Discount;
                outgoingStockBatch.SoldStocks = GetOutGoingStocks();

                OnSaveCommandHelper(outgoingStockBatch);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommandHelper(SoldStockBatch soldStockBatch)
        {
            try
            {
                if (soldStockBatch == null || soldStockBatch.SoldStocks == null || soldStockBatch.SoldStocks.Count <= 0)
                {
                    throw new Exception("Sold Stock cannot be empty! Please try again.");
                }

                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandHelperCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            SoldStockBatch newSoldStockBatch = _stockSaleService.Sell(soldStockBatch);
                            List<StockOnShelfAtHand> stocksOnShelfAtHand = _service.LoadStocksOnShelfAtHand();

                            Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            dictionary["stocksOnShelfAtHand"] = stocksOnShelfAtHand;
                            dictionary["newSoldStockBatch"] = newSoldStockBatch;

                            e.Result = dictionary;
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ModelCanBeSaved = true;
                Utility.DisplayMessage(ex.Message);
            }
        }
       
        private void OnSaveCommandHelperCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    ModelCanBeSaved = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                SoldStockBatch soldStockBatch = null;
                List<StockOnShelfAtHand> stocksOnShelfAtHand = null;
                Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                
                if (dictionary != null)
                {
                    soldStockBatch = (SoldStockBatch)dictionary["newSoldStockBatch"];
                    stocksOnShelfAtHand = (List<StockOnShelfAtHand>)dictionary["stocksOnShelfAtHand"];

                    _dispatcher.Invoke(() =>
                    {
                        if (soldStockBatch != null && soldStockBatch.Id > 0)
                        {
                            ClearCart();
                            PopulateStockOnShelfAthand(stocksOnShelfAtHand);
                            Utility.DisplayMessage(soldStockBatch.SoldStocks.Sum(sfs => sfs.Quantity) + " items has been sold successfully");
                        }
                        else
                        {
                            Utility.DisplayMessage("Sell stock operation failed!");
                        }
                    });
                }
                else
                {
                    Utility.DisplayMessage("Error occurred during stock sales operation! Please try again.");
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private List<SoldStock> GetOutGoingStocks()
        {
            try
            {
                List<SoldStock> outgoingStocks = null;
                if (StocksForSale != null)
                {
                    outgoingStocks = new List<SoldStock>();
                    foreach (StockForSale stockForSale in StocksForSale)
                    {
                        //outgoingStock.StockPackage = stockForSale.StockPackage;

                        SoldStock outgoingStock = new SoldStock();
                        outgoingStock.ShelfStock = new Shelf();
                        outgoingStock.ShelfStock.StockPackage = stockForSale.StockPackage;
                        outgoingStock.ShelfStock.StockPackageRelationship = new StockPackageRelationship() { Id = stockForSale.StockPackageRelationshipId };
                        outgoingStock.Price = stockForSale.StockPrice;
                        outgoingStock.Quantity = stockForSale.Quantity;
                        outgoingStock.Discount = stockForSale.Discount;
                        outgoingStock.Returned = false;

                        //if (stockForSale.ActualSellingPrice > 0)
                        //{
                        //    outgoingStock.ActualSellingPrice = stockForSale.ActualSellingPrice;
                        //}
                        //else
                        //{
                        //    outgoingStock.ActualSellingPrice = stockForSale.StockPrice.SellingPrice * stockForSale.Quantity;
                        //}

                        outgoingStocks.Add(outgoingStock);
                    }
                }

                return outgoingStocks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnRemoveCartItemCommand()
        {
            try
            {
                if (CartDataGridSelectedIndex > -1)
                {
                    StockForSale stockForSaleToRemove = collectionManager.Collection.ElementAt(CartDataGridSelectedIndex);
                    Shelf shelf = GetCorrespondingStockOnShelf(stockForSaleToRemove);
                    shelf.Quantity = shelf.FakeQuantityOnShelf;
                    shelf.ReorderLevel = shelf.FakeQuantityOnShelf - shelf.StockPackage.ReOrderLevel;

                    collectionManager.Collection.RemoveAt(CartDataGridSelectedIndex);
                    RefreshModelCollection();

                    if (StocksForSale != null)
                    {
                        StocksForSale.MoveCurrentTo(null);
                    }

                    UpdateCartSummary();
                    SetCartViewState();

                    if (collectionManager.Collection.Count == 0)
                    {
                        ClearCart();
                    }
                }
                else
                {
                    Utility.DisplayMessage("No selection made! Please select a row for removal");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool IsPaymentTrayEmpty()
        {
            try
            {
                if (PaymentDetails == null)
                {
                    Utility.DisplayMessage("No payment found to be removed!");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void OnRemoveCommand()
        {
            try
            {
                if (IsPaymentTrayEmpty())
                {
                    return;
                }

                int index = PaymentDetails.CurrentPosition;
                if (index > -1)
                {
                    _paymentCollectionManager.Collection.RemoveAt(index);
                    RefreshPaymentDetailsCollection();
                    ComputeBalance();
                }
                else
                {
                    Utility.DisplayMessage("No selection made! Please select a row for removal");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnClearCommand()
        {
            try
            {
                if (IsPaymentTrayEmpty())
                {
                    return;
                }

                ClearPaymentDetails();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearPaymentDetails()
        {
            try
            {
                if (_paymentCollectionManager != null)
                {
                    if (_paymentCollectionManager.Collection != null)
                    {
                        _paymentCollectionManager.Collection.Clear();
                        RefreshPaymentDetailsCollection();
                        ComputeBalance();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearCartSummary()
        {
            try
            {
                CartItemCount = 0;
                SubTotal = Math.Round(0M, 2);
                NetTotal = Math.Round(0M, 2);
                Discount = Math.Round(0M, 2);
                Balance = Math.Round(0M, 2);
                AmountPaid = Math.Round(0M, 2);

                if (Customers != null)
                {
                    Customer = Customers.FirstOrDefault();
                }

                if (PaymentTypes != null)
                {
                    PaymentType = PaymentTypes.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnClearCartCommand()
        {
            try
            {
                if (StocksForSale != null)
                {
                    foreach (StockForSale stockForSaleToRemove in StocksForSale)
                    {
                        Shelf shelf = GetCorrespondingStockOnShelf(stockForSaleToRemove);
                        shelf.Quantity = shelf.FakeQuantityOnShelf;
                        shelf.ReorderLevel = shelf.FakeQuantityOnShelf - shelf.StockPackage.ReOrderLevel;
                    }

                    ClearCart();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearCart()
        {
            try
            {
                if (StocksForSale != null)
                {
                    ObservableCollection<StockForSale> stocksForSale = (ObservableCollection<StockForSale>)StocksForSale.SourceCollection;
                    stocksForSale.Clear();
                    StocksForSale = new ListCollectionView(stocksForSale);
                }

                SetCartViewState();

                ClearCartSummary();
                ClearPaymentDetails();

                StockForSale = new StockForSale();
                UpdateViewState(Edit.Mode.Adding);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override StockForSale GetNewModel()
        {
            return StockForSale;
        }

        //private void OnTreeViewSelectedItemChangedCommand(object param)
        //{
        //    try
        //    {
        //        if (param != null)
        //        {
        //            if (typeof(Shelf) == param.GetType())
        //            {
        //                Shelf = (Shelf)param;
        //                if (Shelf.Quantity == 0)
        //                {
        //                    Utility.DisplayMessage("No remaining " + Shelf.StockPackage.Package.Name + " of " + Shelf.StockPackage.Stock.Name + " on shelf");
        //                    return;
        //                }
        //                else if (StockPackageAlreadyExistInCart(Shelf.StockPackage))
        //                {
        //                    UpdateViewState(Edit.Mode.Adding);
        //                    return;
        //                }

        //                OnTreeViewSelectedItemChangedCommandHelper(Shelf.StockPackage);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void OnTreeViewSelectedItemChangedCommand(object param)
        {
            try
            {
                if (param != null)
                {
                    if (typeof(Shelf) == param.GetType())
                    {
                        Shelf = (Shelf)param;
                        if (Shelf.Quantity == 0)
                        {
                            Utility.DisplayMessage("No remaining " + Shelf.StockPackage.Package.Name + " of " + Shelf.StockPackage.Stock.Name + " on shelf");
                            return;
                        }
                        else if (StockPackageAlreadyExistInCart(Shelf))
                        {
                            UpdateViewState(Edit.Mode.Adding);
                            return;
                        }

                        //OnTreeViewSelectedItemChangedCommandHelper(Shelf.StockPackage);

                        OnTreeViewSelectedItemChangedCommandHelper(Shelf);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnTreeViewSelectedItemChangedCommandHelper(Shelf shelfStock)
        {
            try
            {
                //StockForSale stockForSale = _stockSaleService.LoadStockForSaleByStockPackage(stockPackage);

                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnTreeViewSelectedItemChangedCommandHelperCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _stockSaleService.LoadStockForSaleBy(shelfStock.StockPackage, (int)shelfStock.StockPackageRelationship.Id);
                        };
                    _worker.RunWorkerAsync();
                }

                //StockForSale stockForSale = _stockSaleService.LoadStockForSaleBy(shelfStock.StockPackage, (int)shelfStock.StockPackageRelationship.Id);
                //if (stockForSale != null)
                //{
                //    _dispatcher.Invoke(() =>
                //    {
                //        StockForSale = stockForSale;
                //        StockForSale.PropertyChanged += new PropertyChangedEventHandler(stockForSale_PropertyChanged);

                //        Shelf.Quantity -= 1;

                //        UpdateModels();
                //        StocksForSale = new ListCollectionView(collectionManager.Collection);
                //        StocksForSale.MoveCurrentTo(null);

                //        SetCartViewState();
                //        UpdateCartSummary();

                //    });
                //}
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnTreeViewSelectedItemChangedCommandHelperCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    StockForSale stockForSale = e.Result as StockForSale;
                    if (stockForSale != null)
                    {
                        _dispatcher.Invoke(() =>
                        {
                            StockForSale = stockForSale;
                            StockForSale.PropertyChanged += new PropertyChangedEventHandler(stockForSale_PropertyChanged);

                            Shelf.Quantity -= 1;
                            Shelf.ReorderLevel = Shelf.Quantity - Shelf.StockPackage.ReOrderLevel;

                            UpdateModels();
                            StocksForSale = new ListCollectionView(collectionManager.Collection);
                            StocksForSale.MoveCurrentTo(null);

                            SetCartViewState();
                            UpdateCartSummary();
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void OnTreeViewSelectedItemChangedCommandHelper(Shelf shelfStock)
        //{
        //    try
        //    {
        //        //StockForSale stockForSale = _stockSaleService.LoadStockForSaleByStockPackage(stockPackage);

        //        StockForSale stockForSale = _stockSaleService.LoadStockForSaleBy(shelfStock.StockPackage, (int)shelfStock.StockPackageRelationship.Id);
                
                
        //        if (stockForSale != null)
        //        {
        //            _dispatcher.Invoke(() =>
        //            {
        //                StockForSale = stockForSale;
        //                StockForSale.PropertyChanged += new PropertyChangedEventHandler(stockForSale_PropertyChanged);

        //                Shelf.Quantity -= 1;

        //                UpdateModels();
        //                StocksForSale = new ListCollectionView(collectionManager.Collection);
        //                StocksForSale.MoveCurrentTo(null);

        //                SetCartViewState();
        //                UpdateCartSummary();

        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private bool StockPackageAlreadyExistInCart(Shelf shelfStock)
        {
            try
            {
                StockForSale stockForSale = collectionManager.Collection.Where(sp => sp.StockPackage.Id == shelfStock.StockPackage.Id && sp.StockPackageRelationshipId == shelfStock.StockPackageRelationship.Id).SingleOrDefault();
                if (stockForSale != null)
                {
                    foreach (StockForSale stockForSaleInCart in collectionManager.Collection)
                    {
                        if (stockForSaleInCart.StockPackage.Id == shelfStock.StockPackage.Id && stockForSaleInCart.StockPackageRelationshipId == shelfStock.StockPackageRelationship.Id)
                        {
                            stockForSaleInCart.Quantity += 1;
                            stockForSale.OriginalQuantity = stockForSaleInCart.Quantity;
                            Shelf.Quantity = Shelf.FakeQuantityOnShelf - stockForSaleInCart.Quantity;
                            Shelf.ReorderLevel = Shelf.Quantity - Shelf.StockPackage.ReOrderLevel;

                            ReComputeTotalSellingPrice(stockForSaleInCart);
                            UpdateCartSummary();
                            StocksForSale = new ListCollectionView(collectionManager.Collection);
                            StocksForSale.MoveCurrentTo(null);

                            return true;
                        }
                    }


                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private bool StockPackageAlreadyExistInCart(StockPackage stockPackage)
        //{
        //    try
        //    {
        //        StockForSale stockForSale = collectionManager.Collection.Where(sp => sp.StockPackage.Id == stockPackage.Id).SingleOrDefault();
        //        if (stockForSale != null)
        //        {
        //            foreach (StockForSale stockForSaleInCart in collectionManager.Collection)
        //            {
        //                if (stockForSaleInCart.StockPackage.Id == stockPackage.Id)
        //                {
        //                    stockForSaleInCart.Quantity += 1;
        //                    stockForSale.OriginalQuantity = stockForSaleInCart.Quantity;
        //                    Shelf.Quantity = Shelf.FakeQuantityOnShelf - stockForSaleInCart.Quantity;

        //                    ReComputeTotalSellingPrice(stockForSaleInCart);
        //                    UpdateCartSummary();
        //                    StocksForSale = new CollectionView(collectionManager.Collection);
        //                    StocksForSale.MoveCurrentTo(null);

        //                    return true;
        //                }
        //            }


        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void SetCartViewState()
        {
            try
            {
                if (StocksForSale != null)
                {
                    List<StockForSale> stocksForSale = new List<StockForSale>((IEnumerable<StockForSale>)StocksForSale.SourceCollection);
                    if (stocksForSale != null && stocksForSale.Count > 0)
                    {
                        UpdateViewState(Edit.Mode.Adding);
                    }
                    else
                    {
                        UpdateViewState(Edit.Mode.Loaded);
                    }
                }
                else
                {
                    UpdateViewState(Edit.Mode.Loaded);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }



            //if (StocksForSale != null && StocksForSale.Count > 0)
            //{
            //    UpdateViewState(Edit.Mode.Adding);
            //}
            //else
            //{
            //    UpdateViewState(Edit.Mode.Loaded);
            //}
        }

        private void UpdateCartSummary()
        {
            try
            {
                ObservableCollection<StockForSale> stocksForSale = collectionManager.Collection;
                if (stocksForSale != null)
                {
                    decimal subTotal = stocksForSale.Sum(sfs => sfs.TotalSellingPrice);
                    int itemCount = stocksForSale.Sum(sfs => sfs.Quantity);

                    CartItemCount = itemCount;
                    SubTotal = Math.Round(subTotal, 2);
                    NetTotal = Math.Round(subTotal - Discount, 2);
                    AmountPaid = NetTotal;
                    GetBalance();

                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetBalance()
        {
            Balance = NetTotal - PaymentDetail.AmountPaid;
        }

        private bool QuantityEnteredIsGreater(StockForSale stockToSell)
        {
            try
            {
                Shelf currentStockOnShelf = GetCorrespondingStockOnShelf(stockToSell);

                if (currentStockOnShelf.FakeQuantityOnShelf < stockToSell.Quantity)
                {
                    Utility.DisplayMessage("Quantity entered '" + stockToSell.Quantity + "' for " + stockToSell.StockPackage.Package.Name + " of " + stockToSell.StockPackage.Stock.Name + " cannot be greater than quantity on shelf '" + currentStockOnShelf.FakeQuantityOnShelf + "'!");
                    stockToSell.Quantity = stockToSell.OriginalQuantity;

                    return true;
                }
                else
                {
                    currentStockOnShelf.Quantity = currentStockOnShelf.FakeQuantityOnShelf - stockToSell.Quantity;
                    currentStockOnShelf.ReorderLevel = currentStockOnShelf.Quantity - currentStockOnShelf.StockPackage.ReOrderLevel;
                    ReComputeTotalSellingPrice(stockToSell);
                    stockToSell.OriginalQuantity = stockToSell.Quantity;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Shelf GetCorrespondingStockOnShelf(StockForSale stockToSell)
        {
            try
            {
                StockOnShelfAtHand stockOnShelfForSale = StocksOnShelfAtHand.Where(sos => sos.StockType.Id == stockToSell.StockType.Id).SingleOrDefault();
                UnsoldStockPackage unsoldStockPackage = stockOnShelfForSale.UnsoldStockPackages.Where(usp => usp.Stock.Id == stockToSell.StockPackage.Stock.Id).SingleOrDefault();
                Shelf currentStockOnShelf = unsoldStockPackage.Shelfs.Where(s => s.StockPackage.Id == stockToSell.StockPackage.Id && s.StockPackageRelationship.Id == stockToSell.StockPackageRelationshipId).SingleOrDefault();

                return currentStockOnShelf;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private Shelf GetCorrespondingStockOnShelf(StockForSale stockToSell)
        //{
        //    try
        //    {
        //        StockOnShelfAtHand stockOnShelfForSale = StocksOnShelfAtHand.Where(sos => sos.StockType.Id == stockToSell.StockType.Id).SingleOrDefault();
        //        UnsoldStockPackage unsoldStockPackage = stockOnShelfForSale.UnsoldStockPackages.Where(usp => usp.Stock.Id == stockToSell.StockPackage.Stock.Id).SingleOrDefault();
        //        Shelf currentStockOnShelf = unsoldStockPackage.Shelfs.Where(s => s.StockPackage.Id == stockToSell.StockPackage.Id).SingleOrDefault();

        //        return currentStockOnShelf;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void stockForSale_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName.Equals("ActualSellingPrice") || e.PropertyName.Equals("Discount"))
                {
                    foreach (StockForSale stockOnCart in StocksForSale)
                    {
                        if (stockOnCart.ActualSellingPrice > 0 && stockOnCart.Discount > stockOnCart.ActualSellingPrice)
                        {
                            Utility.DisplayMessage("Discount [ " + stockOnCart.Discount + " ] cannot be greater than actual selling price [ " + stockOnCart.ActualSellingPrice + " ]!");
                            stockOnCart.Discount = 0;
                            return;
                        }
                        else if (stockOnCart.ActualSellingPrice == 0 && stockOnCart.Discount > stockOnCart.StockPrice.SellingPrice)
                        {
                            Utility.DisplayMessage("Discount [ " + stockOnCart.Discount + " ] cannot be greater than stock selling price [ " + stockOnCart.StockPrice.SellingPrice + " ]!");
                            stockOnCart.Discount = 0;
                            return;
                        }

                        ReComputeTotalSellingPrice(stockOnCart);
                    }
                }
                else if (e.PropertyName.Equals("Quantity"))
                {
                    foreach (StockForSale stockOnCart in StocksForSale)
                    {
                        if (QuantityEnteredIsGreater(stockOnCart))
                        {
                            return;
                        }

                        ReComputeTotalSellingPrice(stockOnCart);
                    }
                }

                UpdateCartSummary();
                RefreshModelCollection();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private static void ReComputeTotalSellingPrice(StockForSale stockOnCart)
        {
            try
            {
                if (stockOnCart.ActualSellingPrice > 0)
                {
                    if (stockOnCart.Quantity != stockOnCart.OriginalQuantity)
                    {
                        stockOnCart.ActualSellingPrice = stockOnCart.OriginalActualSellingPrice * stockOnCart.Quantity;
                    }

                    stockOnCart.TotalSellingPrice = Math.Round(stockOnCart.ActualSellingPrice - stockOnCart.Discount, 2);
                }
                else
                {
                    stockOnCart.TotalSellingPrice = Math.Round((stockOnCart.OriginalStockPrice.SellingPrice * stockOnCart.Quantity) - stockOnCart.Discount, 2);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void UpdateViewState(Edit.Mode uiState)
        {
            try
            {
                ObservableCollection<PaymentDetail> paymentDetails = null;
                if (PaymentDetails != null)
                {
                    paymentDetails = (ObservableCollection<PaymentDetail>)PaymentDetails.SourceCollection;
                }

                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            IsItemInCart = false;
                            CartItemIsSelected = false;
                            CanPaymentBeAdded = false;
                            IsDateSoldEnabled = false;

                            SetPaymentDetailViewState(paymentDetails);
                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            base.UpdateViewState(Edit.Mode.Adding);

                            if (StocksForSale != null)
                            {
                                ObservableCollection<StockForSale> stocksForSale = (ObservableCollection<StockForSale>)StocksForSale.SourceCollection;
                                if (stocksForSale != null && stocksForSale.Count > 0)
                                {
                                    CanPaymentBeAdded = true;
                                    CartItemIsSelected = false;
                                    IsItemInCart = true;

                                    if (Utility.LoggedInUser.Role != null)
                                    {
                                        if (Utility.LoggedInUser.Role.PersonRight.CanSelectSoldDateOnSellStockPage)
                                        {
                                            IsDateSoldEnabled = true;
                                        }
                                        else
                                        {
                                            IsDateSoldEnabled = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                CartItemIsSelected = false;
                                CanPaymentBeAdded = false;
                                IsItemInCart = false;
                                IsDateSoldEnabled = false;
                            }

                            SetPaymentDetailViewState(paymentDetails);
                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            IsItemInCart = true;
                            CartItemIsSelected = true;

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SetPaymentDetailViewState(ObservableCollection<PaymentDetail> paymentDetails)
        {
            try
            {
                if (paymentDetails != null)
                {
                    if (paymentDetails.Count > 0)
                    {
                        //ModelCanBeRemoved = true;
                        //ModelCanBeCleared = true;
                        //ModelCanBeSaved = true;

                        ModelCanBeRemoved = false;
                        ModelCanBeCleared = true;
                        ModelCanBeSaved = true;
                    }
                    else
                    {
                        ModelCanBeRemoved = false;
                        ModelCanBeCleared = false;
                        ModelCanBeSaved = false;
                    }
                }
                else
                {
                    ModelCanBeRemoved = false;
                    ModelCanBeCleared = false;
                    ModelCanBeSaved = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }





        private ObservableCollection<Stock> _stocks;
        private ObservableCollection<StockOnShelfAtHand> _rawStocksOnShelfAtHand;
        private Stock _stock;

        public Stock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                base.OnPropertyChanged("Stock");
                if (_stock != null)
                {
                    FilterTreeViewDataBy(_stock);
                }
            }
        }
        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                base.OnPropertyChanged("Stocks");
            }
        }
        public ObservableCollection<StockOnShelfAtHand> RawStocksOnShelfAtHand
        {
            get { return _rawStocksOnShelfAtHand; }
            set
            {
                _rawStocksOnShelfAtHand = value;
                OnPropertyChanged("RawStocksOnShelfAtHand");
            }
        }

        private void OnReloadCommand()
        {
            try
            {
                StocksOnShelfAtHand = RawStocksOnShelfAtHand;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void FilterTreeViewDataBy(Stock stock)
        {
            try
            {
                if (RawStocksOnShelfAtHand == null || RawStocksOnShelfAtHand.Count <= 0)
                {
                    return;
                }

                ObservableCollection<StockOnShelfAtHand> rawStocksOnShelfAtHand = RawStocksOnShelfAtHand;
                ObservableCollection<StockOnShelfAtHand> filteredStocksAtHand = new ObservableCollection<StockOnShelfAtHand>();

                foreach (StockOnShelfAtHand stockOnShelfAtHand in rawStocksOnShelfAtHand)
                {
                    List<UnsoldStockPackage> unsoldStockPackages = stockOnShelfAtHand.UnsoldStockPackages.Where(x => x.Stock.Id == stock.Id).ToList();
                    if (unsoldStockPackages != null && unsoldStockPackages.Count > 0)
                    {
                        StockOnShelfAtHand filteredStock = new StockOnShelfAtHand();
                        filteredStock.UnsoldStockPackages = unsoldStockPackages;
                        filteredStock.StockType = stockOnShelfAtHand.StockType;
                        filteredStocksAtHand.Add(filteredStock);
                    }
                }

                StocksOnShelfAtHand = filteredStocksAtHand;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnChangePriceCommand()
        {
            try
            {
                //clear popup
                _stockPriceVM.ResetStockList();
                _stockPriceVM.ClearViewHelper();
                _stockPriceVM.UpdatedPrices = new List<StockPrice>();

                PopUp = new StockPricePopUpView(_stockPriceVM);
                PopUp.Closed += new EventHandler(ChangePricePopUp_Closed);

                PopUp.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ChangePricePopUp_Closed(object sender, EventArgs e)
        {
            try
            {
                if (PopUp.DialogResult != null)
                {
                    bool result = (PopUp.DialogResult != null) ? Convert.ToBoolean(PopUp.DialogResult) : false;
                    StockPricePopUpViewModel popupDialogViewModel = (StockPricePopUpViewModel)PopUp.DataContext;

                    if (result)
                    {
                        List<StockPrice> updatedPrices = popupDialogViewModel.UpdatedPrices;
                        if (updatedPrices == null || updatedPrices.Count <= 0)
                        {
                            return;
                        }

                        if (StocksForSale != null)
                        {
                            foreach (StockForSale stockForSale in StocksForSale)
                            {
                                StockPrice price = updatedPrices.Where(s => s.StockPackage.Id == stockForSale.StockPackage.Id).SingleOrDefault();
                                if (price != null)
                                {
                                    stockForSale.StockPrice = price;
                                    stockForSale.TotalSellingPrice = stockForSale.Quantity * price.SellingPrice;
                                }
                            }

                            UpdateCartSummary();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }




        //private void OnChangePriceCommand()
        //{
        //    try
        //    {
        //        //clear popup
        //        _stockPriceVM.ResetStockList();
        //        _stockPriceVM.ClearViewHelper();
        //        _stockPriceVM.UpdatedPrices = new List<StockPrice>();

        //        ChangePricePopUp = new StockPricePopUpView(_stockPriceVM);
        //        ChangePricePopUp.Closed += new EventHandler(ChangePricePopUp_Closed);

        //        ChangePricePopUp.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        //private void ChangePricePopUp_Closed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ChangePricePopUp.DialogResult != null)
        //        {
        //            bool result = (ChangePricePopUp.DialogResult != null) ? Convert.ToBoolean(ChangePricePopUp.DialogResult) : false;
        //            StockPricePopUpViewModel popupDialogViewModel = (StockPricePopUpViewModel)ChangePricePopUp.DataContext;

        //            if (result)
        //            {
        //                List<StockPrice> updatedPrices = popupDialogViewModel.UpdatedPrices;
        //                if (updatedPrices == null || updatedPrices.Count <= 0)
        //                {
        //                    return;
        //                }
                                              
        //                if (StocksForSale != null)
        //                {
        //                    foreach (StockForSale stockForSale in StocksForSale)
        //                    {
        //                        StockPrice price = updatedPrices.Where(s => s.StockPackage.Id == stockForSale.StockPackage.Id).SingleOrDefault();
        //                        if (price != null)
        //                        {
        //                            stockForSale.StockPrice = price;
        //                            stockForSale.TotalSellingPrice = stockForSale.Quantity * price.SellingPrice;
        //                        }
        //                    }

        //                    UpdateCartSummary();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}




     
    }


}
