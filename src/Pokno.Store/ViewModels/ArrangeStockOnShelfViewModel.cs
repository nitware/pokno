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
using Pokno.Infrastructure.ViewModel;
using Prism.Events;
using System.Windows.Threading;
using System.ComponentModel;
using Pokno.Model;
using Pokno.Model.Model;
using System.Collections.ObjectModel;
using Pokno.Store.Interfaces;
using Pokno.Store.Services;
using Prism.Commands;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using System.Collections.Generic;
using System.Windows.Data;
using Pokno.Service;
using System.Windows.Media.Imaging;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModels;
using Pokno.Infrastructure.View.Popups;

namespace Pokno.Store.ViewModels
{
    public class ArrangeStockOnShelfViewModel : BaseViewModel
    {
        protected Window PopUp;

        protected Dispatcher _dispatcher;
        private BackgroundWorker _worker;

        private readonly IShelfService _stockOnShelfService;
        private readonly ICollectibleService<StockPackage> _stockPackageService;
        private readonly IRegisterPurchasedStockService _stockPurchasedService;
        private readonly IPosService _posService;

        private ICollectionView _stocksOnShelf;
        //private ICollectionView _stockPackages;
        private ObservableCollection<StockPackage> _stockPackages;
        private ICollectionView _stockPurchaseBatches;
        private BitmapImage _searchIcon;

        private StockPackage _stockPackage;
        private StockPurchased _stockPurchased;
        private StockPurchaseBatch _stockPurchaseBatch;
        private StockPurchasedPool _stockPurchasedPool;
        private ObservableCollection<StoreStock> _remainingStocksOnShelf;
        private ObservableCollection<StockPurchasedAtHand> _stockPurchasesAtHand;
        private ObservableCollection<StockPurchasedAtHand> _rawStockPurchasesAtHand;
        private StockPackageRelationship _stockPackageRelationship;
        private ObservableCollection<Stock> _stocks;
        private bool _isStockPriceChangeable;
        private bool _canBeAddedToShelf;
        private Stock _selectedStock;
        private Stock _stock;
        private Shelf _shelf;
        private bool _isBusy;

        private readonly IBusinessFacade _businessFacade;
        private StockPricePopUpViewModel _stockPriceVM; 

        public ArrangeStockOnShelfViewModel(StockPricePopUpViewModel stockPriceVM, IBusinessFacade businessFacade, IShelfService stockOnShelfService, IPosService posService, ICollectibleService<StockPackage> stockPackageService, IRegisterPurchasedStockService stockPurchasedService, IEventAggregator eventAggregator)
        {
            _posService = posService;
            _businessFacade = businessFacade;
            _stockPurchasedService = stockPurchasedService;
            _stockOnShelfService = stockOnShelfService;
            _stockPackageService = stockPackageService;
            _stockPriceVM = stockPriceVM;
           
            _dispatcher = Application.Current.Dispatcher;
            SelectedItemChangedCommand = new DelegateCommand<object>(OnSelectedItemChangedCommand, CanSelectItem);
            AddToShelfCommand = new DelegateCommand(OnAddToShelfCommand, CanAddToShelf);
            ChangePriceCommand = new DelegateCommand(OnChangePriceCommand, CanChangeStockPrice);
            ReloadCommand = new DelegateCommand(OnReloadCommand);
                        
            Shelf = new Shelf();
            Shelf.ExpiryDate = null;
            CanBeAddedToShelf = false;

            IsStockPriceChangeable = Utility.LoggedInUser.Role.PersonRight.CanChangeStockPrice;
            SearchIcon = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\search.jpg");
            eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public ICommand SelectedItemChangedCommand { get; private set; }
        public DelegateCommand AddToShelfCommand { get; private set; }
        public DelegateCommand ReloadCommand {get; private set;}
        public DelegateCommand ChangePriceCommand { get; private set; }

        public string TabCaption
        {
            //get { return "Arrange Stock On Shelf"; }
            get { return "Put Stock On Shelf"; }
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
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy)
                {
                    CanBeAddedToShelf = false;
                }

                base.OnPropertyChanged("IsBusy");
            }
        }
        public StockPurchasedPool StockPurchasedPool
        {
            get { return _stockPurchasedPool; }
            set
            {
                _stockPurchasedPool = value;
                base.OnPropertyChanged("StockPurchasedPool");
            }
        }
        public ObservableCollection<StoreStock> RemainingStocksOnShelf
        {
            get { return _remainingStocksOnShelf; }
            set
            {
                _remainingStocksOnShelf = value;
                base.OnPropertyChanged("RemainingStocksOnShelf");
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
        public ObservableCollection<StockPurchasedAtHand> StockPurchasesAtHand
        {
            get { return _stockPurchasesAtHand; }
            set
            {
                _stockPurchasesAtHand = value;
                base.OnPropertyChanged("StockPurchasesAtHand");
            }
        }
        public ObservableCollection<StockPurchasedAtHand> RawStockPurchasesAtHand
        {
            get { return _rawStockPurchasesAtHand; }
            set
            {
                _rawStockPurchasesAtHand = value;
                base.OnPropertyChanged("RawStockPurchasesAtHand");
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
            }
        }

        //public ICollectionView StockPackages
        //{
        //    get { return _stockPackages; }
        //    set
        //    {
        //        _stockPackages = value;
        //        base.OnPropertyChanged("StockPackages");
        //    }
        //}
        //public StockPackage StockPackage
        //{
        //    get { return _stockPackage; }
        //    set
        //    {
        //        _stockPackage = value;
        //        base.OnPropertyChanged("StockPackage");
        //    }
        //}
        public ICollectionView StockPurchaseBatches
        {
            get { return _stockPurchaseBatches; }
            set
            {
                _stockPurchaseBatches = value;
                base.OnPropertyChanged("StockPurchaseBatches");
            }
        }
        public StockPurchaseBatch StockPurchaseBatch
        {
            get { return _stockPurchaseBatch; }
            set
            {
                _stockPurchaseBatch = value;
                base.OnPropertyChanged("StockPurchaseBatch");
            }
        }
        public ICollectionView StocksOnShelf
        {
            get { return _stocksOnShelf; }
            set
            {
                _stocksOnShelf = value;
                base.OnPropertyChanged("StocksOnShelf");
            }
        }
        public StockPurchased StockPurchased
        {
            get { return _stockPurchased; }
            set
            {
                _stockPurchased = value;
                base.OnPropertyChanged("StockPurchased");
            }
        }
        public bool CanBeAddedToShelf
        {
            get { return _canBeAddedToShelf; }
            set
            {
                _canBeAddedToShelf = value;
                AddToShelfCommand.RaiseCanExecuteChanged();
            }
        }
        public StockPackageRelationship StockPackageRelationship
        {
            get { return _stockPackageRelationship; }
            set
            {
                _stockPackageRelationship = value;
                base.OnPropertyChanged("StockPackageRelationship");
            }
        }
        public Stock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                base.OnPropertyChanged("Stock");

                if (_stock != null)
                {
                    FilterStockPurchasesAtHand(_stock);
                }
            }
        }
        public Stock SelectedStock
        {
            get { return _selectedStock; }
            set
            {
                _selectedStock = value;
                base.OnPropertyChanged("SelectedStock");
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
               
        private bool IsView(UI.Store ui)
        {
            return ui == UI.Store.ArrangeStockOnShelf;
        }
        private bool CanChangeStockPrice()
        {
            return IsStockPriceChangeable;
        }
        private bool CanSelectItem(object param)
        {
            return true;
        }
        private bool CanAddToShelf()
        {
            return CanBeAddedToShelf;
        }

        private void OnReloadCommand()
        {
            StockPurchasesAtHand = RawStockPurchasesAtHand;
        }

        public void OnInitialise(UI.Store ui)
        {
            try
            {
                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            List<Stock> stocks = _businessFacade.GetAllStocks();
                            List<StockPurchasedAtHand> stocksPurchasedAtHand = _stockPurchasedService.LoadStockPurchasedAtHand();
                            List<StoreStock> storeStocks = _posService.LoadRemainingStocksOnShelf();

                            Dictionary<string, object> results = new Dictionary<string, object>();
                            results["stocksPurchasedAtHand"] = stocksPurchasedAtHand;
                            results["storeStocks"] = storeStocks;
                            results["stocks"] = stocks;

                            e.Result = results;
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
                List<StoreStock> storeStocks = null;
                List<StockPurchasedAtHand> stocksPurchasedAtHand = null;

                if (e.Result != null)
                {
                    Dictionary<string, object> results = e.Result as Dictionary<string, object>;
                    stocksPurchasedAtHand = (List<StockPurchasedAtHand>)results["stocksPurchasedAtHand"];
                    storeStocks = (List<StoreStock>)results["storeStocks"];
                    stocks = (List<Stock>)results["stocks"];
                }

                PopulateStocks(stocks);
                PopulateStockPurchasesAthand(stocksPurchasedAtHand);
                PopulateRemainingStocksOnShelf(storeStocks);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStocks(List<Stock> stocks)
        {
            try
            {
                if (stocks == null)
                {
                    stocks = new List<Stock>();
                }

                Stocks = new ObservableCollection<Stock>(stocks);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }


       
        //public void LoadInitializationData()
        //{
        //    try
        //    {
        //        List<Stock> stocks = _businessFacade.GetAllStocks();
        //        Stocks = new ObservableCollection<Stock>(stocks);

        //        LoadStockPurchasesAthand();
        //        LoadRemainingStocksOnShelf();
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}
        
        private void FilterStockPurchasesAtHand(Stock stock)
        {
            try
            {
                List<StockPurchasedAtHand> spahs = RawStockPurchasesAtHand.Where(s => s.Stock.Id == stock.Id).ToList();
                StockPurchasesAtHand = new ObservableCollection<StockPurchasedAtHand>(spahs);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateRemainingStocksOnShelf(List<StoreStock> storeStocks)
        {
            try
            {
                if (storeStocks == null)
                {
                    storeStocks = new List<StoreStock>();
                }

                _dispatcher.Invoke(() =>
                {
                    RemainingStocksOnShelf = new ObservableCollection<StoreStock>(storeStocks);
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void LoadRemainingStocksOnShelf()
        //{
        //    try
        //    {
        //        using (_worker = new BackgroundWorker())
        //        {
        //            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadRemainingStocksOnShelfCompleted);
        //            _worker.DoWork += (s, e) =>
        //                {
        //                    e.Result = _posService.LoadRemainingStocksOnShelf();
        //                };
        //            _worker.RunWorkerAsync();
        //        }
        //        //List<StoreStock> storeStocks = _posService.LoadRemainingStocksOnShelf();
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        //private void OnLoadRemainingStocksOnShelfCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Error != null)
        //        {
        //            Utility.DisplayMessage(e.Error.Message);
        //            return;
        //        }

        //        if (e.Result != null)
        //        {
        //            List<StoreStock> storeStocks = e.Result as List<StoreStock>;
        //            PopulateRemainingStocksOnShelf(storeStocks);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void OnAddToShelfCommand()
        {
            try
            {
                if (InValidUserInput())
                {
                    return;
                }

                Func<StockPurchasedAtHand, bool> selector = apah => apah.Stock.Id == StockPurchased.Stock.Id && apah.StockPurchasedPool.StockPackageRelationship.Id == StockPackageRelationship.Id;
                StockPurchasedAtHand stockAtHand = StockPurchasesAtHand.Where(selector).SingleOrDefault();
                                
                Shelf.StockPackage = StockPackage;
                Shelf.DateEntered = Utility.GetDate();
                Shelf.EnteredBy = Utility.LoggedInUser;
                Shelf.Location = Utility.LoggedInUser.Location;
                Shelf.StockPackageRelationship = StockPackageRelationship;

                OnAddToShelfCommandHelper(Shelf);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void OnAddToShelfCommandHelper(Shelf shelf)
        {
            try
            {
                IsBusy = true;

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnAddToShelfCommandHelperCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<StoreStock> stocks = null;
                        List<StockPurchasedAtHand> stocksPurchasedAtHand = null;
                                               
                        int totalItemsAdded = _businessFacade.ArrangeStockOnShelf(shelf);
                        if (totalItemsAdded > 0)
                        {
                            stocksPurchasedAtHand = _stockPurchasedService.LoadStockPurchasedAtHand();
                            stocks = _posService.LoadRemainingStocksOnShelf();
                        }

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stocksPurchasedAtHand"] = stocksPurchasedAtHand;
                        dictionary["totalItemsAdded"] = totalItemsAdded;
                        dictionary["stocks"] = stocks;
                        dictionary["shelf"] = shelf;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                CanBeAddedToShelf = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnAddToShelfCommandHelperCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    CanBeAddedToShelf = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }
                

                Shelf shelf = null;
                int totalItemsAdded = 0;
                List<StoreStock> stocks = null;
                List<StockPurchasedAtHand> stocksPurchasedAtHand = null;

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    stocksPurchasedAtHand = (List<StockPurchasedAtHand>)dictionary["stocksPurchasedAtHand"];
                    totalItemsAdded = (int)dictionary["totalItemsAdded"];
                    stocks = (List<StoreStock>)dictionary["stocks"];
                    shelf = (Shelf)dictionary["shelf"];

                    CanBeAddedToShelf = false;
                }

                StockPackage stockPackage = StockPackage;
                if (totalItemsAdded > 0)
                {
                    ClearInputSection(true);

                    PopulateRemainingStocksOnShelf(stocks);
                    PopulateStockPurchasesAthand(stocksPurchasedAtHand);

                    Utility.DisplayMessage(totalItemsAdded + " " + stockPackage.Package.Name + " of " + stockPackage.Stock.Name + " has been successfully put on the shelf.");
                }
                else
                {
                    Utility.DisplayMessage(totalItemsAdded + " " + stockPackage.Package.Name + " of " + stockPackage.Stock.Name + " was put on the shelf, " + shelf.Quantity + " was intended. Please cross check and fix if discrepancy exist");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearInputSection(bool clearAll)
        {
            try
            {
                if (Shelf != null)
                {
                    Shelf = new Shelf();
                }

                if (SelectedStock != null)
                {
                    SelectedStock = new Stock();
                }

                if (clearAll)
                {
                    if (StockPurchased != null && StockPurchased.Stock != null)
                    {
                        StockPurchased.Stock.Name = null;
                    }
                }

                if (StockPackages != null)
                {
                    StockPackages = new ObservableCollection<StockPackage>();
                    StockPackage = new StockPackage();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InValidUserInput()
        {
            try
            {
                if (StockPurchased == null)
                {
                    Utility.DisplayMessage("No Purchased stock found! Please select a Package in Purchased Stock At Hand pane.");
                    return true;
                }
                else if (StockPurchasesAtHand == null || StockPurchasesAtHand.Count <= 0)
                {
                    Utility.DisplayMessage("No Purchased stock at hand!");
                    return true;
                }
                else if (StockPackage == null || StockPackage.Id <= 0)
                {
                    Utility.DisplayMessage("Please select package!");
                    return true;
                }
                else if (Shelf.Quantity <= 0)
                {
                    Utility.DisplayMessage("Please enter Quantity!");
                    return true;
                }
                else if (Shelf.ExpiryDate != null)
                {
                    TimeSpan timeExpired = (DateTime)Shelf.ExpiryDate - Utility.GetDate();
                    if (timeExpired.Days <= 0)
                    {
                        if (timeExpired.Days == -1)
                        {
                            Utility.DisplayMessage("Items to be shelved expired yesterday!");
                        }
                        else if (timeExpired.Days == -2)
                        {
                            Utility.DisplayMessage("Items to be shelved has expired day before yesterday!");
                        }
                        else
                        {
                            Utility.DisplayMessage("Items to be shelved has expired " + Math.Abs(timeExpired.Days) + " days ago!");
                        }

                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnSelectedItemChangedCommand(object param)
        {
            try
            {
                if (param != null)
                {
                    if (typeof(StockPurchased) == param.GetType())
                    {
                        StockPurchased = (StockPurchased)param;
                        Package package = StockPurchased.StockPackage.Package;
                        StockPackageRelationship = StockPurchased.StockPackageRelationship;
                        SelectedStock = StockPurchased.Stock;

                        LoadAllStockPackageBy(StockPurchased.Stock, StockPackageRelationship);
                    }
                    else
                    {
                        ClearInputSection(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllStockPackageBy(Stock stock, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllStockPackageByCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _businessFacade.GetStockPackagesBy(stock, stockPackageRelationship);
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

                List<StockPackage> stockPackages = null;
                if (e.Result != null)
                {
                    stockPackages = e.Result as List<StockPackage>;
                }

                if (stockPackages == null)
                {
                    stockPackages = new List<StockPackage>();
                }
                
                stockPackages = stockPackages.Where(sp => sp.Package.Id != 0).ToList();
                if (stockPackages.Count > 0)
                {
                    stockPackages.Insert(0, new StockPackage() { Package = new Package() { Name = "<< Select Package >>" } });
                }

                _dispatcher.Invoke(() =>
                {
                    Shelf.Quantity = 1;
                    StockPackages = new ObservableCollection<StockPackage>(stockPackages);
                    if (stockPackages.Count > 2)
                    {
                        StockPackage = stockPackages.FirstOrDefault();
                    }
                    else
                    {
                        StockPackage = stockPackages.LastOrDefault();
                    }

                    CanBeAddedToShelf = true;
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStockPurchasesAthand(List<StockPurchasedAtHand> stocksPurchasedAtHand)
        {
            try
            {
                if (stocksPurchasedAtHand == null)
                {
                    stocksPurchasedAtHand = new List<StockPurchasedAtHand>();
                }

                _dispatcher.Invoke(() =>
                {
                    StockPurchasesAtHand = new ObservableCollection<StockPurchasedAtHand>(stocksPurchasedAtHand);
                    RawStockPurchasesAtHand = StockPurchasesAtHand;
                });
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
                //PopUp.Closed += new EventHandler(PopUpView_Closed);

                PopUp.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        //protected void PopUpView_Closed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (PopUp.DialogResult != null)
        //        {
        //            bool result = (PopUp.DialogResult != null) ? Convert.ToBoolean(PopUp.DialogResult) : false;
        //            StockPricePopUpViewModel popupDialogViewModel = (StockPricePopUpViewModel)PopUp.DataContext;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}
       





    }

}
