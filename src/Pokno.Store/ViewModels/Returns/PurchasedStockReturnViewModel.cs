using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model.Model;
using Pokno.Infrastructure.Models;
using Pokno.Infratructure.Services;
using Pokno.Store.Interfaces;
using Pokno.Store.Services;
using Pokno.Infrastructure.Interfaces;
using Pokno.Model;
using System.ComponentModel;
using System.Windows.Threading;
using Pokno.Service;
using System.Collections.ObjectModel;
using Prism.Events;
using System.Windows;
using Prism.Commands;
using System.Windows.Data;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class PurchasedStockReturnViewModel : ObservableCollectionManagerBase<PurchasedStockReturn>
    {
        protected Dispatcher _dispatcher;

        private readonly StockService _stockService;
        protected readonly IRegisterPurchasedStockService _service;
        private readonly StockPackageService _stockPackageService;
        private readonly StockPriceService _stockPriceService;
        private readonly IStockPurchaseBatchService _purchaseBatchService;
        private ObservableCollection<StockPurchased> _purchasedStocks;
        private ObservableCollection<StockState> _stockStates;
        private StockState _stockState;

        private Stock _stock;
        private ObservableCollection<Stock> _stocks;
        private ObservableCollection<StockPackage> _stockPackages;
        private StockPackage _stockPackage;
        private bool _purchasedStocksCanBeCleared;
        private decimal _purchasedStockTotalCost;
        private decimal _purchasedStockTotalUnitCost;
        private int _purchasedStockTotalQuantity;

        private int _purchasedStockItemCount;
        private int _totalQuantity;
        private decimal _totalUnitCost;
        private decimal _totalCost;
        private decimal _amountPaid;
        private decimal _balance;
        private decimal _unitCost;
        private bool _isBusy;

        private StockPurchaseBatch _purchaseStockBatch;
        private ObservableCollection<StockPurchaseBatch> _purchaseStockBatches;
        private BackgroundWorker _worker;

        private readonly IBusinessFacade _businessFacade;
        private IEventAggregator _eventAggregator;

        public PurchasedStockReturnViewModel(IBusinessFacade businessFacade, StockPurchaseBatchViewModel purchaseBatchViewModel, IStockPurchaseBatchService purchaseBatchService, IRegisterPurchasedStockService service, StockService stockService, StockPackageService stockPackageService, StockPriceService stockPriceService, IEventAggregator eventAggregator)
        {
            _service = service;
            _stockService = stockService;
            _businessFacade = businessFacade;
            _stockPackageService = stockPackageService;
            _purchaseBatchService = purchaseBatchService;
            _stockPriceService = stockPriceService;
            _eventAggregator = eventAggregator;

            Initialize();
            eventAggregator.GetEvent<ReturnEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public DelegateCommand ClearPurchasedStocksToReturnCommand { get; private set; }
        public List<PurchasedStockReturn> OldPurchasedStocksToReturn { get; private set; }
        
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

        public string TabCaption
        {
            get { return "Return Purchased Stock"; }
        }

        public int PurchasedStockItemCount
        {
            get { return _purchasedStockItemCount; }
            set
            {
                _purchasedStockItemCount = value;
                base.OnPropertyChanged("PurchasedStockItemCount");
            }
        }
        public int PurchasedStockTotalQuantity
        {
            get { return _purchasedStockTotalQuantity; }
            set
            {
                _purchasedStockTotalQuantity = value;
                base.OnPropertyChanged("PurchasedStockTotalQuantity");
            }
        }
        public decimal PurchasedStockTotalUnitCost
        {
            get { return _purchasedStockTotalUnitCost; }
            set
            {
                _purchasedStockTotalUnitCost = value;
                base.OnPropertyChanged("PurchasedStockTotalUnitCost");
            }
        }
        public decimal PurchasedStockTotalCost
        {
            get { return _purchasedStockTotalCost; }
            set
            {
                _purchasedStockTotalCost = value;
                base.OnPropertyChanged("PurchasedStockTotalCost");
            }
        }
      
        public ObservableCollection<StockPurchaseBatch> PurchaseStockBatches
        {
            get { return _purchaseStockBatches; }
            set
            {
                _purchaseStockBatches = value;
                base.OnPropertyChanged("PurchaseStockBatches");
            }
        }
        public StockPurchaseBatch PurchaseStockBatch
        {
            get { return _purchaseStockBatch; }
            set
            {
                _purchaseStockBatch = value;
                base.OnPropertyChanged("PurchaseStockBatch");

                GetPurchasedStockDetailByBatch(_purchaseStockBatch);
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

        public decimal UnitCost
        {
            get { return _unitCost; }
            set
            {
                _unitCost = value;
                base.OnPropertyChanged("UnitCost");
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

                SetUnitPrice(_stockPackage);
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

        private void LoadStockPackageBy(Stock stock)
        {
            try
            {
                if (stock != null && stock.Id > 0)
                {
                    TargetModel.UnitCost = 0;
                    TargetModel.Quantity = 0;
                    TargetModel.Cost = 0;

                    if (stock != null && stock.Id > 0)
                    {
                        LoadStockPackageByHelper(stock);
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
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
        public ObservableCollection<StockPurchased> PurchasedStocks
        {
            get { return _purchasedStocks; }
            set
            {
                _purchasedStocks = value;
                base.OnPropertyChanged("PurchasedStocks");
            }
        }

        public bool PurchasedStocksCanBeCleared
        {
            get { return _purchasedStocksCanBeCleared; }
            set
            {
                _purchasedStocksCanBeCleared = value;
                base.OnPropertyChanged("PurchasedStocksCanBeCleared");
                ClearPurchasedStocksToReturnCommand.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<StockState> StockStates
        {
            get { return _stockStates; }
            set
            {
                _stockStates = value;
                base.OnPropertyChanged("StockStates");
            }
        }
        public StockState StockState
        {
            get { return _stockState; }
            set
            {
                _stockState = value;
                base.OnPropertyChanged("StockState");
            }
        }


        private void SetUnitPrice(StockPackage stockPackage)
        {
            try
            {
                if (stockPackage != null && stockPackage.Id > 0)
                {
                    TargetModel.StockPackage = stockPackage;

                    GetStockPriceByStockPackage(stockPackage);
                    TargetModel.PropertyChanged += new PropertyChangedEventHandler(TargetModel_PropertyChanged);

                    decimal unitCost = TargetModel.UnitCost;
                    UnitCost = TargetModel.UnitCost;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private bool IsView(UI.Returns ui)
        {
            return ui == UI.Returns.PurchaseReturn;
        }
        public void OnInitialise(UI.Returns ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<StockState> stockStates = _businessFacade.GetAllStockStates();
                        List<StockPurchaseBatch> stockPurchaseBatches = _businessFacade.GetAllStockPurchaseBatches();
                        List<Stock> stocks = _stockService.LoadAllWithPackageQuantity();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stockPurchaseBatches"] = stockPurchaseBatches;
                        dictionary["stockStates"] = stockStates;
                        dictionary["stocks"] = stocks;

                        e.Result = dictionary;
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

                List<Stock> stocks = null;
                List<StockState> stockStates = null;
                List<StockPurchaseBatch> stockPurchaseBatches = null;
               
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    stockPurchaseBatches = (List<StockPurchaseBatch>)dictionary["stockPurchaseBatches"];
                    stockStates = (List<StockState>)dictionary["stockStates"];
                    stocks = (List<Stock>)dictionary["stocks"];
                }

                PopulateStockStates(stockStates);
                LoadAllStockPurchaseBatch(stockPurchaseBatches);
                LoadAllStocks(stocks);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void Initialize()
        {
            try
            {
                _dispatcher = Application.Current.Dispatcher;
                collectionManager = new ObservableCollectionManager<PurchasedStockReturn>();

                ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
                ClearPurchasedStocksToReturnCommand = new DelegateCommand(OnClearPurchasedStocksToReturnCommand, CanClearPurchasedStocks);
                RemoveCommand = new DelegateCommand(OnRemoveCommand, CanRemove);
                SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
                AddCommand = new DelegateCommand(OnAddCommand, CanAdd);

                TargetModel = new PurchasedStockReturn();
                TargetModel.StockPackage = new StockPackage();
                TargetModel.StockPackage.Package = new Package();

                UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetPurchasedStockDetailByBatch(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                if (purchaseBatch != null && purchaseBatch.Id > 0)
                {
                    using (_worker = new BackgroundWorker())
                    {
                        _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetPurchasedStockDetailByBatchCompleted);
                        _worker.DoWork += (s, e) =>
                            {
                                List<StockPurchased> stockPurchases = _service.LoadStockPurchasedByBatch(purchaseBatch);
                                List<PurchasedStockReturn> stocksPurchasedToReturn = _businessFacade.GetReturnBoundPurchasedStockBy(purchaseBatch);

                                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                                dictionary["stocksPurchasedToReturn"] = stocksPurchasedToReturn;
                                dictionary["stockPurchases"] = stockPurchases;

                                e.Result = dictionary;
                            };
                        _worker.RunWorkerAsync(purchaseBatch);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetPurchasedStockDetailByBatchCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<StockPurchased> stockPurchases = null;
                List<PurchasedStockReturn> stocksPurchasedToReturn = null;

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    stocksPurchasedToReturn = (List<PurchasedStockReturn>)dictionary["stocksPurchasedToReturn"];
                    stockPurchases = (List<StockPurchased>)dictionary["stockPurchases"];
                }
                               
                LoadStockPurchasedByBatch(stockPurchases, stocksPurchasedToReturn);

                UpdateSummary();
                UpdatePurchasedStockSummary();
                UpdateViewState(Edit.Mode.ChangeBound);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadStockPurchasedByBatch(List<StockPurchased> stockPurchases, List<PurchasedStockReturn> stocksPurchasedToReturn)
        {
            try
            {
                _dispatcher.Invoke(() =>
                    {
                        if (stockPurchases == null)
                        {
                            PurchasedStocks = new ObservableCollection<StockPurchased>();
                        }
                        if (stocksPurchasedToReturn == null)
                        {
                            stocksPurchasedToReturn = new List<PurchasedStockReturn>();
                        }

                        OldPurchasedStocksToReturn = stocksPurchasedToReturn;
                        PurchasedStocks = new ObservableCollection<StockPurchased>(stockPurchases);
                        
                        //if (stockPurchases != null)
                        //{
                        //    PurchasedStocks = new ObservableCollection<StockPurchased>(stockPurchases);
                        //}

                        IsModelExist(new ObservableCollection<PurchasedStockReturn>(stocksPurchasedToReturn));
                        TargetCollection = new ListCollectionView(new ObservableCollection<PurchasedStockReturn>());
                        collectionManager.Collection = new ObservableCollection<PurchasedStockReturn>();

                        if (stocksPurchasedToReturn != null && stocksPurchasedToReturn.Count > 0)
                        {
                            foreach (PurchasedStockReturn stockPurchasedToReturn in stocksPurchasedToReturn)
                            {
                                stockPurchasedToReturn.OldStockState = stockPurchasedToReturn.StockState;
                                stockPurchasedToReturn.OldReturnReason = stockPurchasedToReturn.ReturnReason;

                                if (StockStates != null && StockStates.Count > 0)
                                {
                                    stockPurchasedToReturn.StockStates = StockStates;
                                    stockPurchasedToReturn.StockState = stockPurchasedToReturn.StockStates.Where(s => s.Id == stockPurchasedToReturn.StockState.Id).SingleOrDefault();
                                }

                                stockPurchasedToReturn.PropertyChanged += purchasedStockToReturn_PropertyChanged;
                            }

                            TargetCollection = new ListCollectionView(new ObservableCollection<PurchasedStockReturn>(stocksPurchasedToReturn));
                            collectionManager.Collection = new ObservableCollection<PurchasedStockReturn>(stocksPurchasedToReturn);
                            base.RefreshModelCollection();
                        }
                    });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStockStates(List<StockState> stockStates)
        {
            try
            {
                if (stockStates == null)
                {
                    stockStates = new List<StockState>();
                }

                StockStates = new ObservableCollection<StockState>(stockStates);
                StockState = StockStates.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected void LoadAllStockPurchaseBatch(List<StockPurchaseBatch> stockPurchaseBatches)
        {
            try
            {
                if (stockPurchaseBatches == null)
                {
                    stockPurchaseBatches = new List<StockPurchaseBatch>();
                }

                if (stockPurchaseBatches.Count > 0)
                {
                    stockPurchaseBatches.Insert(0, new StockPurchaseBatch() { Id = 0, Buyer = new Person() { Name = "<< Select Purchase Batch >>" }, Supplier = new Person() });
                }

                _dispatcher.Invoke(() =>
                {
                    PurchaseStockBatches = new ObservableCollection<StockPurchaseBatch>(stockPurchaseBatches);
                    PurchaseStockBatch = PurchaseStockBatches.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private bool CanClearPurchasedStocks()
        {
            return PurchasedStocksCanBeCleared;
        }
      
        private void OnClearPurchasedStocksToReturnCommand()
        {
            try
            {
                collectionManager.Collection.Clear();
                TargetCollection = new ListCollectionView(new ObservableCollection<PurchasedStockReturn>());

                UpdateSummary();
                UpdateViewState(Edit.Mode.Adding);
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
                if (Stocks != null)
                {
                    Stock = Stocks.FirstOrDefault();
                }

                if (StockPackages != null)
                {
                    StockPackages = new ObservableCollection<StockPackage>();
                    StockPackage = new StockPackage();
                }
                
                collectionManager.Collection.Clear();
                TargetModel = new PurchasedStockReturn();
                TargetCollection = new ListCollectionView(new ObservableCollection<PurchasedStockReturn>());

                if (PurchaseStockBatches != null && PurchaseStockBatches.Count > 0)
                {
                    PurchaseStockBatch = PurchaseStockBatches.FirstOrDefault();
                }
                if (PurchasedStocks != null)
                {
                    PurchasedStocks = new ObservableCollection<StockPurchased>();
                }

                UpdateSummary();
                UpdatePurchasedStockSummary();
                UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadAllStocks(List<Stock> stocks)
        {
            try
            {
                if (stocks == null)
                {
                    stocks = new List<Stock>();
                }

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
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
      
        protected void LoadStockPackageByHelper(Stock stock)
        {
            try
            {
                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LoadStockPackageByHelperCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _stockPackageService.LoadByStock(stock);
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadStockPackageByHelperCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                    StockPackages = new ObservableCollection<StockPackage>(new List<StockPackage>());
                    if (stockPackages != null)
                    {
                        _dispatcher.Invoke
                                   (() =>
                                   {
                                       stockPackages = stockPackages.Where(sp => sp.Package.Id != 0).ToList();
                                       if (stockPackages.Count > 0)
                                       {
                                           stockPackages.Insert(0, new StockPackage() { Package = new Package() { Name = "<< Select Package >>" } });

                                           StockPackages = new ObservableCollection<Model.StockPackage>(stockPackages);
                                           StockPackage = StockPackages.FirstOrDefault();
                                       }

                                       TargetModel.UnitCost = 0;
                                       TargetModel.Quantity = 0;
                                       TargetModel.Cost = 0;
                                   });
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetStockPriceByStockPackage(StockPackage stockPackage)
        {
            try
            {
                StockPrice stockprice = _stockPriceService.GetByStockPackage(stockPackage);
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
        
        protected override PurchasedStockReturn GetNewModel()
        {
            try
            {
                Stock stock = new Stock();
                PurchasedStockReturn purchasedStockToReturn = new PurchasedStockReturn();
                StockPurchaseBatch stockPurchaseBatch = new StockPurchaseBatch();
                StockPackage stockPackage = new StockPackage();
                stockPackage.Package = new Package();
                stockPackage.Stock = new Stock();

                stockPurchaseBatch.Id = PurchaseStockBatch.Id;

                stockPackage.Id = StockPackage.Id;
                stockPackage.Package = TargetModel.StockPackage.Package;
                stockPackage.Stock = TargetModel.StockPackage.Stock;

                purchasedStockToReturn.Batch = stockPurchaseBatch;
                purchasedStockToReturn.StockPackage = stockPackage;
                purchasedStockToReturn.Id = TargetModel.Id;
                purchasedStockToReturn.Quantity = TargetModel.Quantity;
                purchasedStockToReturn.UnitCost = TargetModel.UnitCost;
                purchasedStockToReturn.Cost = TargetModel.Cost;
                purchasedStockToReturn.StockStates = StockStates;
                purchasedStockToReturn.OldReturnReason = TargetModel.ReturnReason;
                purchasedStockToReturn.ReturnReason = TargetModel.ReturnReason;

                purchasedStockToReturn.PropertyChanged += purchasedStockToReturn_PropertyChanged;

                if (StockStates != null && StockStates.Count > 0)
                {
                    purchasedStockToReturn.StockState = StockStates.LastOrDefault();
                    purchasedStockToReturn.OldStockState = StockStates.LastOrDefault();
                }

                return purchasedStockToReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void purchasedStockToReturn_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "ReturnReason" || e.PropertyName == "StockState")
                {
                    UpdateViewState(Edit.Mode.Editing);
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
                    UpdateViewState(Edit.Mode.Adding);
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

        private void UpdateSummary()
        {
            try
            {
                TotalCost = 0;
                TotalQuantity = 0;
                TotalUnitCost = 0;

                if (TargetCollection != null)
                {
                    IEnumerable<PurchasedStockReturn> purchasedStocksToReturn = (IEnumerable<PurchasedStockReturn>)TargetCollection.SourceCollection;
                    if (purchasedStocksToReturn != null)
                    {
                        TotalQuantity = purchasedStocksToReturn.Sum(a => (int)a.Quantity);
                        TotalUnitCost = purchasedStocksToReturn.Sum(a => a.UnitCost);
                        TotalCost = purchasedStocksToReturn.Sum(a => a.Cost);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdatePurchasedStockSummary()
        {
            try
            {
                if (PurchasedStocks != null)
                {
                    PurchasedStockTotalQuantity = PurchasedStocks.Sum(a => (int)a.Quantity);
                    PurchasedStockTotalUnitCost = PurchasedStocks.Sum(a => a.UnitCost);
                    PurchasedStockTotalCost = PurchasedStocks.Sum(a => a.Cost);
                    PurchasedStockItemCount = PurchasedStocks.Count();
                }
                else
                {
                    PurchasedStockItemCount = 0;
                    PurchasedStockTotalCost = 0;
                    PurchasedStockTotalQuantity = 0;
                    PurchasedStockTotalUnitCost = 0;
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
                ClearView();
                UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private bool InvalidEntry(List<PurchasedStockReturn> returnBoundStocks)
        {
            try
            {
                if (PurchaseStockBatch == null || PurchaseStockBatch.Id <= 0)
                {
                    Utility.DisplayMessage("No purchased transaction selected!");
                    return true;
                }
                else if (returnBoundStocks == null || returnBoundStocks.Count <= 0)
                {
                    Utility.DisplayMessage("Purchased item to return not found!");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void OnSaveCommand()
        {
            try
            {
                List<PurchasedStockReturn> purchasedStocksToReturn = new List<PurchasedStockReturn>((IEnumerable<PurchasedStockReturn>)TargetCollection.SourceCollection);
                if (InvalidEntry(purchasedStocksToReturn))
                {
                    return;
                }

                foreach (PurchasedStockReturn purchasedStockToReturn in purchasedStocksToReturn)
                {
                    purchasedStockToReturn.Batch = PurchaseStockBatch;
                    purchasedStockToReturn.Action = new ReplacedStockAction() { Id = 1 };
                    purchasedStockToReturn.ReturnedBy = Utility.LoggedInUser;
                    purchasedStockToReturn.DateReturnd = Utility.GetDate();
                   

                    //purchasedStockToReturn.EnteredBy = Utility.LoggedInUser;
                    //purchasedStockToReturn.DateEntered = Utility.GetDate();

                    if (string.IsNullOrWhiteSpace(purchasedStockToReturn.ReturnReason))
                    {
                        Utility.DisplayMessage("Reason for Return was not entered for " + purchasedStockToReturn.StockPackage.Package.Name + " of " + purchasedStockToReturn.StockPackage.Stock.Name + "! Return Reason must be specified for all return item.");
                        return;
                    }
                }

                OnSaveCommandHelper(purchasedStocksToReturn);
            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Utility.DisplayMessage(message);
            }
        }

        private void OnSaveCommandHelper(List<PurchasedStockReturn> purchasedStocksToReturn)
        {
            try
            {
                IsBusy = true;

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        bool done = false;
                        if (ModelExist)
                        {
                            done = _businessFacade.ModifyReturnBoundPurchasedStocks(purchasedStocksToReturn);
                        }
                        else
                        {
                            done = _businessFacade.AddReturnBoundPurchasedStock(purchasedStocksToReturn);
                        }

                        e.Result = done;
                    };
                    _worker.RunWorkerAsync();

                }
            }
            catch(Exception ex)
            {
                IsBusy = false;
                ModelCanBeSaved = true;
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Utility.DisplayMessage(message);
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

                if (e.Result != null)
                {
                    bool done = (bool)e.Result;
                    _dispatcher.Invoke(() =>
                    {
                        if (done)
                        {
                            ClearView();
                            Utility.DisplayMessage("Purchased stocks to be returned have been successfully saved");
                        }
                        else
                        {
                            Utility.DisplayMessage("Purchased stocks to be returned save operation failed! Please try again");
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Utility.DisplayMessage(message);
            }
        }

        private bool IsRequiredDetailsEntered()
        {
            try
            {
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
                    ObservableCollection<PurchasedStockReturn> purchasedStocksToReturn = (ObservableCollection<PurchasedStockReturn>)TargetCollection.SourceCollection;

                    foreach (PurchasedStockReturn purchasedStockToReturn in TargetCollection)
                    {
                        if ((purchasedStockToReturn.StockPackage.Stock.Name == Stock.Name) && (purchasedStockToReturn.StockPackage.Package.Name == StockPackage.Package.Name))
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

        private void ClearView()
        {
            try
            {
                ClearPurchasedStockView();

                if (PurchaseStockBatches != null && PurchaseStockBatches.Count > 0)
                {
                    PurchaseStockBatch = PurchaseStockBatches.FirstOrDefault();
                }

                UpdateViewState(Edit.Mode.Loaded);
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
                int purchasedStocksCount = 0;
                ObservableCollection<PurchasedStockReturn> purchasedStocksToReturn = null;

                if (TargetCollection != null)
                {
                    purchasedStocksToReturn = (ObservableCollection<PurchasedStockReturn>)TargetCollection.SourceCollection;
                }
                if (purchasedStocksToReturn != null)
                {
                    purchasedStocksCount = purchasedStocksToReturn.Count;
                }
               
                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            ModelCanBeAdded = false;
                            ModelCanBeRemoved = false;
                            ModelCanBeCleared = false;
                            PurchasedStocksCanBeCleared = false;

                            break;
                        }
                    case Edit.Mode.Adding:
                    case Edit.Mode.ChangeBound:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;
                            ModelCanBeCleared = true;

                            UpdateViewStateHelper(purchasedStocksCount);
                            
                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            ModelCanBeRemoved = true;
                            ModelCanBeCleared = true;
                            ModelCanBeCleared = true;

                            UpdateViewStateHelper(purchasedStocksCount);

                            break;
                        }
                    case Edit.Mode.Editing:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;
                            ModelCanBeCleared = true;

                            UpdateViewStateHelper(purchasedStocksCount);
                           
                            break;
                        }
                }

                ModelCanBeSaved = IsSavable() ? true : false;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdateViewStateHelper(int purchasedStocksCount)
        {
            try
            {
                if (purchasedStocksCount > 0)
                {
                    PurchasedStocksCanBeCleared = true;
                }
                else if (purchasedStocksCount <= 0 )
                {
                    PurchasedStocksCanBeCleared = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsSavable()
        {
            int noReturnReason = 0;
            int changesOccurred = 0;
            bool isEqualRecordCount = false;
            bool canSave = false;

            try
            {
                if (TargetCollection != null)
                {
                    ObservableCollection<PurchasedStockReturn> returnBoundPurchasedStocks = (ObservableCollection<PurchasedStockReturn>)TargetCollection.SourceCollection;
                    if (returnBoundPurchasedStocks != null && returnBoundPurchasedStocks.Count > 0)
                    {
                        foreach (PurchasedStockReturn returnBoundPurchasedStock in returnBoundPurchasedStocks)
                        {
                            if (string.IsNullOrWhiteSpace(returnBoundPurchasedStock.ReturnReason))
                            {
                                noReturnReason++;
                            }

                            if ((returnBoundPurchasedStock.OldReturnReason != returnBoundPurchasedStock.ReturnReason || returnBoundPurchasedStock.OldStockState.Id != returnBoundPurchasedStock.StockState.Id))
                            {
                                changesOccurred++;
                            }
                        }
                    }

                    if (OldPurchasedStocksToReturn != null && OldPurchasedStocksToReturn.Count > 0)
                    {
                        isEqualRecordCount = (OldPurchasedStocksToReturn.Count == returnBoundPurchasedStocks.Count);
                    }

                    if (noReturnReason > 0)
                    {
                        canSave = false;
                    }
                    else if (changesOccurred > 0)
                    {
                        canSave = true;
                    }
                    else if (isEqualRecordCount == false)
                    {
                        canSave = true;
                    }
                    else
                    {
                        canSave = false;
                    }
                    
                    if (returnBoundPurchasedStocks == null || returnBoundPurchasedStocks.Count <= 0)
                    {
                        canSave = false;
                    }
                }

                return canSave;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }




}
