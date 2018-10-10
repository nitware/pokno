using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Infrastructure.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows;
using Pokno.Service;
using Prism.Commands;
using System.Windows.Data;
using Pokno.Infrastructure.View.Popups;
using Pokno.Infrastructure.ViewModels;

namespace Pokno.Store.ViewModels
{
    public class BasePurchasedStock : ObservableCollectionManagerBase<StockPurchased>
    {
        protected Window PopUp;

        
        private bool _isBusy;
        private Stock _stock;
        private decimal _unitCost;
        private int _totalQuantity;
        private decimal _totalUnitCost;
        private decimal _totalCost;
        private decimal _amountPaid;
        private decimal _balance;
        private bool _paymentCanBeAdded;
        private bool _paymentCanBeRemoved;
        private bool _purchasedStocksCanBeCleared;
        private ObservableCollection<Stock> _stocks;
        private ObservableCollection<StockPackage> _stockPackages;
        private bool _isStockPriceChangeable;
        private decimal _supplierExpenses;
        private StockPackage _stockPackage;
        protected Dispatcher _dispatcher;
        

        protected BackgroundWorker _worker;
        protected IBusinessFacade _businessFacade;
        protected StockPurchaseBatchViewModel _purchaseBatchViewModel;

        private StockPricePopUpViewModel _stockPriceVM;

        public BasePurchasedStock(StockPricePopUpViewModel stockPriceVM, IBusinessFacade businessFacade, StockPurchaseBatchViewModel purchaseBatchViewModel)
        {
            Initialize();
            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;
            _stockPriceVM = stockPriceVM;

            PurchaseBatchViewModel = purchaseBatchViewModel;
            IsStockPriceChangeable = Utility.LoggedInUser.Role.PersonRight.CanChangeStockPrice;
        }

        public DelegateCommand ChangePriceCommand { get; private set; }
        public DelegateCommand AddPaymentCommand { get; private set; }
        public DelegateCommand RemovePaymentCommand { get; private set; }
        public DelegateCommand ClearPurchasedStocksCommand { get; private set; }
                
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
        public StockPurchaseBatchViewModel PurchaseBatchViewModel
        {
            get { return _purchaseBatchViewModel; }
            set
            {
                _purchaseBatchViewModel = value;
                base.OnPropertyChanged("PurchaseBatchViewModel");
            }
        }
        public decimal SupplierExpenses 
        {
            get { return _supplierExpenses; }
            set
            {
                _supplierExpenses = value;
                base.OnPropertyChanged("SupplierExpenses");
                if (PurchaseBatchViewModel != null)
                {
                    if (PurchaseBatchViewModel.Payment != null)
                    {
                        PurchaseBatchViewModel.Payment.AmountPayable = _supplierExpenses + TotalCost;
                    }

                    if (PurchaseBatchViewModel.StockPurchaseBatch != null)
                    {
                        PurchaseBatchViewModel.StockPurchaseBatch.SupplierExpenses = _supplierExpenses;
                    }
                }
            }
        }
        public int TotalQuantity
        {
            get { return _totalQuantity; }
            set
            {
                _totalQuantity = value;
                base.OnPropertyChanged("TotalQuantity");
            }
        }
        public decimal TotalCost
        {
            get { return _totalCost; }
            set
            {
                _totalCost = value;
                base.OnPropertyChanged("TotalCost");
            }
        }

        public decimal TotalUnitCost
        {
            get { return _totalUnitCost; }
            set
            {
                _totalUnitCost = value;
                base.OnPropertyChanged("TotalUnitCost");
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
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                base.OnPropertyChanged("Balance");
            }
        }
        public decimal UnitCost
        {
            get { return _unitCost; }
            set
            {
                _unitCost = value;
                base.OnPropertyChanged("UnitCost");
            }
        }
        public ObservableCollection<StockPackage> StockPackages
        {
            get { return _stockPackages; }
            set
            {
                _stockPackages = value;
                base.OnPropertyChanged("StockPackages");
            }
        }
        public StockPackage StockPackage
        {
            get { return _stockPackage; }
            set
            {
                _stockPackage = value;
                base.OnPropertyChanged("StockPackage");

                if (_stockPackage != null && _stockPackage.Id > 0)
                {
                    TargetModel.StockPackage = _stockPackage;
                    GetStockPriceByStockPackage(_stockPackage);
                    TargetModel.PropertyChanged += new PropertyChangedEventHandler(TargetModel_PropertyChanged);
                    decimal unitCost = TargetModel.UnitCost;
                    UnitCost = TargetModel.UnitCost;
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
        public Stock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                base.OnPropertyChanged("Stock");

                LoadStockPackageBy(_stock);
            }
        }
        public bool PaymentCanBeAdded
        {
            get { return _paymentCanBeAdded; }
            set
            {
                _paymentCanBeAdded = value;
                base.OnPropertyChanged("PaymentCanBeAdded");
                AddPaymentCommand.RaiseCanExecuteChanged();
            }
        }
        public bool PaymentCanBeRemoved
        {
            get { return _paymentCanBeRemoved; }
            set
            {
                _paymentCanBeRemoved = value;
                base.OnPropertyChanged("PaymentCanBeRemoved");
                RemovePaymentCommand.RaiseCanExecuteChanged();
            }
        }
        public bool PurchasedStocksCanBeCleared
        {
            get { return _purchasedStocksCanBeCleared; }
            set
            {
                _purchasedStocksCanBeCleared = value;
                base.OnPropertyChanged("PurchasedStocksCanBeCleared");
                ClearPurchasedStocksCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanChangeStockPrice()
        {
            return IsStockPriceChangeable;
        }
        private bool CanClearPurchasedStocks()
        {
            return PurchasedStocksCanBeCleared;
        }
        private bool CanAddPayment()
        {
            return PaymentCanBeAdded;
        }
        private bool CanRemovePayment()
        {
            return PaymentCanBeRemoved;
        }

        public virtual void OnInitialise(UI.Store ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = LoadInitializationData();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual Dictionary<string, object> LoadInitializationData()
        {
            try
            {
                List<Stock> stocks = _businessFacade.GetAllStocksWithPackageQuantity();
                List<PaymentType> paymentTypes = _businessFacade.GetAllPaymentTypes();
                List<Person> people = _businessFacade.GetAllPeople();

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary["paymentTypes"] = paymentTypes;
                dictionary["stocks"] = stocks;
                dictionary["people"] = people;

                return dictionary;
            }
            catch(Exception)
            {
                throw;
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
                    Dictionary<string, object> obj = e.Result as Dictionary<string, object>;
                    PopulateInitializationData(obj);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void PopulateInitializationData(Dictionary<string, object> obj)
        {
            try
            {
                List<PaymentType> paymentTypes = (List<PaymentType>)obj["paymentTypes"];
                List<Person> people = (List<Person>)obj["people"];
                List<Stock> stocks = (List<Stock>)obj["stocks"];

                PopulateStocks(stocks);
                _purchaseBatchViewModel.PopulatePaymentType(paymentTypes);
                _purchaseBatchViewModel.PopulateSuppliers(people);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool IsRequiredDetailsEntered()
        {
            try
            {
                ObservableCollection<StockPurchased> stockPurchases = GetStockPurchases();
                if (Stock == null)
                {
                    Utility.DisplayMessage("Please select stock!");
                    return false;
                }
                else if (StockPackage == null)
                {
                    Utility.DisplayMessage("Please select package!");
                    return false;
                }
                else if (TargetModel.Quantity == 0)
                {
                    Utility.DisplayMessage("Please enter quantity!");
                    return false;
                }
                else if (TargetModel.UnitCost == 0)
                {
                    Utility.DisplayMessage("Please enter unit cost!");
                    return false;
                }
                else if (TargetModel.Cost == 0)
                {
                    Utility.DisplayMessage("Please enter cost!");
                    return false;
                }
                else if (StockPurchasedAlreadyExist())
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool StockPurchasedAlreadyExist()
        {
            try
            {
                if (TargetCollection != null)
                {
                    ObservableCollection<StockPurchased> stockPurchases = (ObservableCollection<StockPurchased>)TargetCollection.SourceCollection;
                    foreach (StockPurchased stockPurchased in TargetCollection)
                    {
                        if ((stockPurchased.Stock.Name == Stock.Name) && (stockPurchased.StockPackage.Package.Name == StockPackage.Package.Name))
                        {
                            Utility.DisplayMessage(Stock.Name + " and " + StockPackage.Package.Name + " already exist! Please change stock or package to continue");
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

        private void Initialize()
        {
            try
            {
                _dispatcher = Application.Current.Dispatcher;
                collectionManager = new ObservableCollectionManager<StockPurchased>();

                ChangePriceCommand = new DelegateCommand(OnChangePriceCommand, CanChangeStockPrice);
                ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
                ClearPurchasedStocksCommand = new DelegateCommand(OnClearPurchasedStocksCommand, CanClearPurchasedStocks);
                RemoveCommand = new DelegateCommand(OnRemoveCommand, CanRemove);
                SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
                AddCommand = new DelegateCommand(OnAddCommand, CanAdd);

                AddPaymentCommand = new DelegateCommand(OnAddPaymentCommand, CanAddPayment);
                RemovePaymentCommand = new DelegateCommand(OnDeletePaymentCommand, CanRemovePayment);

                TargetModel = new StockPurchased();
                TargetModel.Stock = new Stock();
                TargetModel.StockPackage = new StockPackage();
                TargetModel.StockPackage.Package = new Package();

                UpdateViewState(Edit.Mode.Loaded);
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
                PopUp.Closed += new EventHandler(PopUpView_Closed);

                PopUp.ShowDialog();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
       
        protected virtual void OnClearPurchasedStocksCommand()
        {
            try
            {
                collectionManager.Collection.Clear();
                ObservableCollection<StockPurchased> stockPurchases = GetStockPurchases();

                stockPurchases.Clear();
                TargetCollection = new ListCollectionView(stockPurchases);

                UpdateSummary();
                UpdateViewState(Edit.Mode.Editing);

                ModelCanBeSaved = false;
                PaymentCanBeAdded = false;
                PurchasedStocksCanBeCleared = false;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected ObservableCollection<StockPurchased> GetStockPurchases()
        {
            try
            {
                ObservableCollection<StockPurchased> stockPurchases = null;
                if (TargetCollection != null)
                {
                    stockPurchases = (ObservableCollection<StockPurchased>)TargetCollection.SourceCollection;
                }

                return stockPurchases;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void TargetModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName.Equals("Quantity"))
                {
                    ComputeCost();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected override StockPurchased GetNewModel()
        {
            try
            {
                Stock stock = new Stock();
                StockPurchased newStockPurchased = new StockPurchased();
                StockPurchaseBatch stockPurchaseBatch = new StockPurchaseBatch();
                StockPackage stockPackage = new StockPackage();
                stockPackage.Package = new Package();

                //stockPurchaseBatch.Id = StockPurchaseBatch.Id;
                stock.Id = TargetModel.Stock.Id;
                stock.Name = TargetModel.Stock.Name;

                stockPackage.Id = StockPackage.Id;
                stockPackage.Package.Name = TargetModel.StockPackage.Package.Name;

                newStockPurchased.Stock = stock;
                newStockPurchased.Batch = stockPurchaseBatch;
                newStockPurchased.StockPackage = stockPackage;
                newStockPurchased.Id = TargetModel.Id;
                newStockPurchased.Quantity = TargetModel.Quantity;
                newStockPurchased.UnitCost = TargetModel.UnitCost;
                newStockPurchased.Cost = TargetModel.Cost;
                //newStockPurchased.StockPackageRelationship = TargetModel.StockPackageRelationship;

                return newStockPurchased;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoadStockPackageBy(Stock stock)
        {
            try
            {
                if (stock != null)
                {
                    TargetModel.Stock = stock;
                    TargetModel.UnitCost = 0;
                    TargetModel.Quantity = 0;
                    TargetModel.Cost = 0;

                    if (stock.Id > 0)
                    {
                        LoadAllStockPackageBy(stock);
                    }
                    else
                    {
                        StockPackages = new ObservableCollection<StockPackage>();
                        StockPackage = new StockPackage();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void GetStockPriceByStockPackage(StockPackage stockPackage)
        {
            try
            {
                //StockPrice stockprice = _stockPriceService.GetByStockPackage(stockPackage);
                StockPrice stockprice = _businessFacade.GetStockPriceByStockPackage(stockPackage);
                _dispatcher.Invoke
                           (() =>
                           {
                               if (stockprice != null)
                               {
                                   TargetModel.UnitCost = stockprice.CostPrice;
                               }
                               else
                               {
                                   TargetModel.UnitCost = 0;
                               }

                               ComputeCost();
                           });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void ComputeCost()
        {
            try
            {
                TargetModel.Cost = TargetModel.UnitCost * TargetModel.Quantity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void PopulateStocks(List<Stock> stocks)
        {
            try
            {
                if (stocks != null)
                {
                    if (stocks.Count > 0)
                    {
                        stocks.Insert(0, new Stock() { Name = "<< Select Stock >>" });
                    }

                    _dispatcher.Invoke
                               (() =>
                               {
                                   Stocks = new ObservableCollection<Stock>(stocks);
                                   Stock = Stocks.FirstOrDefault();
                               });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllStockPackageBy(Stock stock)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllStockPackageByCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _businessFacade.GetStockPackages(stock);
                        //e.Result = _stockPackageService.LoadByStock(stock);
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadAllStockPackageByCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    List<StockPackage> stockPackages = e.Result as List<StockPackage>;
                    stockPackages = stockPackages.Where(sp => sp.Package.Id != 0).ToList();
                    if (stockPackages.Count > 0)
                    {
                        stockPackages.Insert(0, new StockPackage() { Package = new Package() { Name = "<< Select Package >>" } });
                    }

                    StockPackages = new ObservableCollection<StockPackage>(stockPackages);
                    StockPackage = StockPackages.FirstOrDefault();

                    TargetModel.UnitCost = 0;
                    TargetModel.Quantity = 0;
                    TargetModel.Cost = 0;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private bool StockPurchasesIsEmpty()
        {
            if (TargetCollection == null)
            {
                Utility.DisplayMessage("No StockPurchased to remove");
                return true;
            }

            return false;
        }
        protected void OnRemoveCommand()
        {
            try
            {
                if (StockPurchasesIsEmpty())
                {
                    return;
                }

                int index = TargetCollection.CurrentPosition;
                if (index > -1)
                {
                    collectionManager.Collection.RemoveAt(index);
                    RefreshModelCollection();

                    UpdateSummary();

                    if (collectionManager.Collection.Count <= 0)
                    {
                        ModelCanBeSaved = true;
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

        protected virtual void OnAddCommand()
        {
            try
            {
                if (!IsRequiredDetailsEntered())
                {
                    return;
                }

                UpdateModels();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage("Error Occurred! " + ex.Message);
            }
        }

        protected void UpdateSummary()
        {
            try
            {
                if (TargetCollection != null)
                {
                    IEnumerable<StockPurchased> stockPurchases = null;
                    ObservableCollection<PaymentDetail> paymentDetails = null;

                    if (TargetCollection != null)
                    {
                        stockPurchases = (IEnumerable<StockPurchased>)TargetCollection.SourceCollection;
                        if (stockPurchases != null)
                        {
                            TotalQuantity = stockPurchases.Sum(a => (int)a.Quantity);
                            TotalUnitCost = stockPurchases.Sum(a => a.UnitCost);
                            TotalCost = stockPurchases.Sum(a => a.Cost);

                            PurchaseBatchViewModel.Payment.AmountPayable = (decimal)PurchaseBatchViewModel.StockPurchaseBatch.SupplierExpenses.GetValueOrDefault() + TotalCost;

                            //PurchaseBatchViewModel.Payment.AmountPayable = TotalCost;
                        }
                    }

                    if (PurchaseBatchViewModel != null && PurchaseBatchViewModel.TargetCollection != null)
                    {
                        paymentDetails = (ObservableCollection<PaymentDetail>)PurchaseBatchViewModel.TargetCollection.SourceCollection;
                        if (paymentDetails != null)
                        {
                            PurchaseBatchViewModel.Payment.AmountPaid = paymentDetails.Sum(p => p.AmountPaid);
                        }
                    }

                    PurchaseBatchViewModel.Balance = PurchaseBatchViewModel.Payment.AmountPayable - PurchaseBatchViewModel.Payment.AmountPaid;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected virtual void ClearView()
        {
            try
            {
                ClearPurchasedStockView();
                PurchaseBatchViewModel.ClearView();

                UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected virtual void OnClearCommand()
        {
            try
            {
                ClearView();
                UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommand()
        {
            try
            {
                List<StockPurchased> purchasedStocks = new List<StockPurchased>((IEnumerable<StockPurchased>)TargetCollection.SourceCollection);
                if (InvalidEntry(purchasedStocks))
                {
                    return;
                }

                PurchaseBatchViewModel.StockPurchaseBatch.Supplier = PurchaseBatchViewModel.Supplier;
                PurchaseBatchViewModel.StockPurchaseBatch.Payment = PurchaseBatchViewModel.Payment;
                PurchaseBatchViewModel.StockPurchaseBatch.Buyer = PurchaseBatchViewModel.Buyer;
                PurchaseBatchViewModel.StockPurchaseBatch.DatePurchased = Utility.GetDate();
                PurchaseBatchViewModel.StockPurchaseBatch.Payment.Details = new List<PaymentDetail>((IEnumerable<PaymentDetail>)PurchaseBatchViewModel.TargetCollection.SourceCollection);
                PurchaseBatchViewModel.StockPurchaseBatch.Payment.TransactionType = new Model.Model.TransactionType() { Id = (int)Payment.Transaction.Purchase };
                PurchaseBatchViewModel.StockPurchaseBatch.Payment.DatePaid = Utility.GetDate();

                if (PurchaseBatchViewModel.InvalidEntry())
                {
                    return;
                }

                IsBusy = true;
                PurchaseBatchViewModel.StockPurchaseBatch.StockPurchases = purchasedStocks;
                                
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = Save();
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

        private void OnSaveCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                
                bool done = e.Result != null ? (bool)e.Result : false;
                OnSaveCommandHelper(done);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual bool Save()
        {
            try
            {
                return _businessFacade.AddStockPurchaseBatch(PurchaseBatchViewModel.StockPurchaseBatch);
            }
            catch(Exception)
            {
                throw;
            }
        }

        protected virtual void OnSaveCommandHelper(bool done)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (done)
                    {
                        ClearView();
                        Utility.DisplayMessage("Purchased stocks have been successfully saved");
                    }
                    else
                    {
                        Utility.DisplayMessage("Purchased stocks has not been saved successfully! Please try again");
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void ClearPurchasedStockView()
        {
            try
            {
                collectionManager.Collection.Clear();
                ObservableCollection<StockPurchased> stockPurchases = GetStockPurchases();

                stockPurchases.Clear();
                TargetCollection = new ListCollectionView(stockPurchases);

                if (Stocks != null)
                {
                    Stock = Stocks.FirstOrDefault();
                    //Stocks.MoveCurrentToPosition(0);
                }
                TargetModel = new StockPurchased();

                if (StockPackages != null)
                {
                    StockPackage = StockPackages.FirstOrDefault();
                    //StockPackages.MoveCurrentToPosition(0);
                }

                UpdateSummary();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected virtual void OnAddPaymentCommand()
        {
            try
            {
                PurchaseBatchViewModel.OnAddDetailCommand();
                UpdateViewState(Edit.Mode.Adding);

                UpdateSummary();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void OnDeletePaymentCommand()
        {
            try
            {
                PurchaseBatchViewModel.collectionManager.Collection.Clear();
                PurchaseBatchViewModel.RefreshModelCollection();
                UpdateViewState(Edit.Mode.Editing);

                UpdateSummary();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        
        protected bool InvalidEntry(List<StockPurchased> stockPurchases)
        {
            try
            {
                if (PurchaseBatchViewModel.StockPurchaseBatch == null)
                {
                    Utility.DisplayMessage("No purchased batch found! Please select a batch");
                    return true;
                }
                else if (stockPurchases == null)
                {
                    Utility.DisplayMessage("No purchased item to save!");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<StockPrice> UpdatedPrices
        //{
        //    get;
        //    set;
        //}
        protected void PopUpView_Closed(object sender, EventArgs e)
        {
            try
            {
                if (PopUp.DialogResult != null)
                {
                    //UpdatedPrices = new List<StockPrice>();

                    bool result = (PopUp.DialogResult != null) ? Convert.ToBoolean(PopUp.DialogResult) : false;
                    StockPricePopUpViewModel popupDialogViewModel = (StockPricePopUpViewModel)PopUp.DataContext;

                    if (result)
                    {
                        //UpdatedPrices = popupDialogViewModel.UpdatedPrices;

                        List<StockPrice> updatedPrices = popupDialogViewModel.UpdatedPrices;
                        if (updatedPrices == null || updatedPrices.Count <= 0)
                        {
                            return;
                        }

                        if (Stock != null && Stock.Id > 0 && StockPackage != null && StockPackage.Id > 0)
                        {
                            StockPrice price = updatedPrices.Where(s => s.StockPackage.Stock.Id == Stock.Id && s.StockPackage.Id == StockPackage.Id).SingleOrDefault();
                            if (price != null)
                            {
                                TargetModel.UnitCost = price.CostPrice;
                                TargetModel.Cost = TargetModel.Quantity * price.CostPrice;
                            }
                        }

                        if (TargetCollection != null)
                        {
                            foreach (StockPurchased purchasedStock in TargetCollection)
                            {
                                StockPrice price = updatedPrices.Where(s => s.StockPackage.Id == purchasedStock.StockPackage.Id).SingleOrDefault();
                                if (price != null)
                                {
                                    purchasedStock.UnitCost = price.CostPrice;
                                    purchasedStock.Cost = purchasedStock.UnitCost * purchasedStock.Quantity;
                                }
                            }

                            UpdateSummary();
                        }

                        

                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
       





    }
    

}
