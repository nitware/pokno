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

using Pokno.Store.Interfaces;
using Pokno.Infrastructure.Models;
using System.Windows.Threading;
using Pokno.Model.Model;
using System.Collections.ObjectModel;
using Pokno.Store.Services;
using Prism.Events;
using Pokno.Infrastructure.Events;
using Prism.Commands;
using System.Collections.Generic;
using Pokno.Model;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;
using Pokno.Service;
using System.Windows.Media.Imaging;

namespace Pokno.Store.ViewModels
{
    public class RemoveStockFromShelfViewModel : ObservableCollectionManagerBase<StockForSale>
    {
        private Dispatcher _dispatcher;
        private BackgroundWorker _worker;

        private bool _isBusy;
        private Shelf _shelf;
        private decimal _netTotal;
        private int _cartItemCount;
        private decimal _subTotal;
        private decimal _balance;
        private bool _isItemInCart;
        private decimal _amountPaid;
        private bool _itemIsRemovable;
        private int _cartDataGridSelectedIndex;
        private BitmapImage _searchIcon;

        private StockForSale _stockForSale;
        private ListCollectionView _stocksForSale;
        private ObservableCollection<StockOnShelfAtHand> _stocksOnShelfAtHand;
        private ObservableCollection<StockOnShelfAtHand> _stocksOnShelfAtHandBackUp;
        private ObservableCollection<StockOnShelfAtHand> _rawStocksOnShelfAtHand;
        
        private readonly IDeletedStockOnShelfService _deletedStockOnShelfService;
        private readonly ISellStockService _stockSaleService;
        private readonly IBusinessFacade _businessFacade;
        private readonly IPosService _service;

        public RemoveStockFromShelfViewModel(IBusinessFacade businessFacade, IDeletedStockOnShelfService deletedStockOnShelfService, IEventAggregator eventAggregator, IPosService service, ISellStockService stockSaleService)
        {
            _service = service;
            _businessFacade = businessFacade;
            _stockSaleService = stockSaleService;
            _deletedStockOnShelfService = deletedStockOnShelfService;
            _dispatcher = Application.Current.Dispatcher;

            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChangedCommand);
            TreeViewSelectedItemChangedCommand = new DelegateCommand<object>(OnTreeViewSelectedItemChangedCommand, CanSelectItem);
            RemoveItemCommand = new DelegateCommand(OnRemoveItemCommand, CanRemoveItem);
            ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
            AddCommand = new DelegateCommand(OnAddCommand, CanAdd);
            ReloadCommand = new DelegateCommand(OnReloadCommand);

            SearchIcon = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\search.jpg");
            eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public DelegateCommand ReloadCommand { get; private set; }
        public DelegateCommand RemoveItemCommand { get; private set; }
        public ICommand TreeViewSelectedItemChangedCommand { get; private set; }
        public ICommand SelectionChangedCommand { get; private set; }

        public string TabCaption
        {
            get { return "Remove Shelf Stock"; }
        }
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
        
        public ObservableCollection<StockOnShelfAtHand> RawStocksOnShelfAtHand
        {
            get { return _rawStocksOnShelfAtHand; }
            set
            {
                _rawStocksOnShelfAtHand = value;
                OnPropertyChanged("RawStocksOnShelfAtHand");
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

        private ObservableCollection<Stock> _stocks;
        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                base.OnPropertyChanged("Stocks");
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

        public int CartDataGridSelectedIndex
        {
            get { return _cartDataGridSelectedIndex; }
            set
            {
                _cartDataGridSelectedIndex = value;
                base.OnPropertyChanged("CartDataGridSelectedIndex");
            }
        }
        public bool IsItemInCart
        {
            get { return _isItemInCart; }
            set
            {
                _isItemInCart = value;
                base.OnPropertyChanged("IsItemInCart");
                ClearCommand.RaiseCanExecuteChanged();

            }
        }
        public bool ItemIsRemovable
        {
            get { return _itemIsRemovable; }
            set
            {
                _itemIsRemovable = value;
                base.OnPropertyChanged("ItemIsRemovable");
                RemoveItemCommand.RaiseCanExecuteChanged();
            }
        }

        private bool IsView(UI.Store ui)
        {
            return ui == UI.Store.RemoveStockFromShelf;
        }
        public void OnInitialise(UI.Store ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<Stock> stocks = _businessFacade.GetAllStocks();
                        List<StockOnShelfAtHand> stocksOnShelfAtHand = _service.LoadStocksOnShelfAtHand();

                        Dictionary<string, object> objs = new Dictionary<string, object>();
                        objs["stocksOnShelfAtHand"] = stocksOnShelfAtHand;
                        objs["stocks"] = stocks;

                        e.Result = objs;
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
                List<StockOnShelfAtHand> stocksOnShelfAtHand = null;
                if (e.Result != null)
                {
                    Dictionary<string, object> objs = e.Result as Dictionary<string, object>;
                    stocksOnShelfAtHand = (List<StockOnShelfAtHand>)objs["stocksOnShelfAtHand"];
                    stocks = (List<Stock>)objs["stocks"];
                }

                PopulateStockOnShelfAthand(stocksOnShelfAtHand);
                PopulateStocks(stocks);
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

        private void PopulateStockOnShelfAthand(List<StockOnShelfAtHand> stocksOnShelfAtHand)
        {
            try
            {
                if (stocksOnShelfAtHand == null)
                {
                    stocksOnShelfAtHand = new List<StockOnShelfAtHand>();
                }

                _dispatcher.Invoke(() =>
                {
                    StocksOnShelfAtHand = new ObservableCollection<StockOnShelfAtHand>(stocksOnShelfAtHand);
                    ObservableCollection<StockOnShelfAtHand> backUpOfStocksOnShelf = new ObservableCollection<StockOnShelfAtHand>();
                    StocksOnShelfAtHandBackUp = backUpOfStocksOnShelf;
                    RawStocksOnShelfAtHand = StocksOnShelfAtHand;
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnAddCommand()
        {

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
                
        private bool CanSelectItem(object param)
        {
            return true;
        }
        private bool CanRemoveItem()
        {
            return ItemIsRemovable;
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
                            //UpdateViewState(Edit.Mode.Adding);
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
        protected void OnSaveCommand()
        {
            try
            {
                if (StocksForSale == null)
                {
                    Utility.DisplayMessage("There is no item in tray! Add item to cart");
                    return;
                }

                List<DeletedShelfStock> deletedStockOnShelfs = GetDeletedShelfStocks();
                if (deletedStockOnShelfs == null || deletedStockOnShelfs.Count <= 0)
                {
                    Utility.DisplayMessage("No item selected for deletion!");
                }

                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                           bool deleted = _deletedStockOnShelfService.Add(deletedStockOnShelfs);
                           long noOfItemsToDelete = deletedStockOnShelfs.Sum(sfs => sfs.Quantity);

                           Dictionary<string, object> dictionary = new Dictionary<string, object>();
                           dictionary["noOfItemsToDelete"] = noOfItemsToDelete;
                           dictionary["deleted"] = deleted;

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
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    long noOfItemsToDelete = (long)dictionary["noOfItemsToDelete"];
                    bool deleted = (bool)dictionary["deleted"];

                    _dispatcher.Invoke(() =>
                    {
                        if (deleted)
                        {
                            ClearCart();
                            Utility.DisplayMessage(noOfItemsToDelete + " items has been deleted successfully");
                        }
                        else
                        {
                            Utility.DisplayMessage("Delete operation failed! Please try again");
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private List<DeletedShelfStock> GetDeletedShelfStocks()
        {
            try
            {
                List<DeletedShelfStock> deletedStockOnShelfs = null;
                if (StocksForSale != null)
                {
                    deletedStockOnShelfs = new List<DeletedShelfStock>();
                    foreach (StockForSale stockForSale in StocksForSale)
                    {
                        DeletedShelfStock deletedStockOnShelf = new DeletedShelfStock();

                        deletedStockOnShelf.StockPackage = stockForSale.StockPackage;
                        deletedStockOnShelf.Quantity = stockForSale.Quantity;
                        deletedStockOnShelf.DateDeleted = Utility.GetDate();
                        deletedStockOnShelf.DeletedBy = Utility.LoggedInUser;
                        deletedStockOnShelf.StockPackageRelationship = new StockPackageRelationship() { Id = stockForSale.StockPackageRelationshipId };

                        deletedStockOnShelfs.Add(deletedStockOnShelf);
                    }
                }

                return deletedStockOnShelfs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnRemoveItemCommand()
        {
            try
            {
                if (CartDataGridSelectedIndex > -1)
                {
                    StockForSale stockForSaleToRemove = collectionManager.Collection.ElementAt(CartDataGridSelectedIndex);
                    Shelf shelf = GetCorrespondingStockOnShelf(stockForSaleToRemove);
                    shelf.Quantity = shelf.FakeQuantityOnShelf;
                    shelf.ReorderLevel = shelf.Quantity - shelf.StockPackage.ReOrderLevel;

                    collectionManager.Collection.RemoveAt(CartDataGridSelectedIndex);
                    RefreshModelCollection();

                    if (collectionManager != null && collectionManager.Collection != null)
                    {
                        CartItemCount = collectionManager.Collection.Sum(x => x.Quantity);
                    }

                    if (StocksForSale != null)
                    {
                        StocksForSale.MoveCurrentTo(null);
                    }

                    SetCartViewState();
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
        private void ClearCartSummary()
        {
            try
            {
                CartItemCount = 0;
                SubTotal = Math.Round(0M, 2);
                NetTotal = Math.Round(0M, 2);
                Balance = Math.Round(0M, 2);
                AmountPaid = Math.Round(0M, 2);
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
                if (StocksForSale != null)
                {
                    foreach (StockForSale stockForSaleToRemove in StocksForSale)
                    {
                        Shelf shelf = GetCorrespondingStockOnShelf(stockForSaleToRemove);
                        shelf.Quantity = shelf.FakeQuantityOnShelf;
                        shelf.ReorderLevel = shelf.Quantity - shelf.StockPackage.ReOrderLevel;
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

                UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override StockForSale GetNewModel()
        {
            return StockForSale;
        }

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
                            return;
                        }

                        StockForSale stockForSale = _stockSaleService.LoadStockForSaleBy(Shelf.StockPackage, (int)Shelf.StockPackageRelationship.Id);
                        LoadStockForSaleHelper(stockForSale);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadStockForSaleHelper(StockForSale stockForSale)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (stockForSale != null)
                    {
                        StockForSale = stockForSale;
                        StockForSale.PropertyChanged += new PropertyChangedEventHandler(stockForSale_PropertyChanged);
                        Shelf.Quantity -= 1;
                        Shelf.ReorderLevel = Shelf.Quantity - Shelf.StockPackage.ReOrderLevel;

                        UpdateModels();
                        PopulateStockForSale();
                        
                        SetCartViewState();
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStockForSale()
        {
            try
            {
                StocksForSale = new ListCollectionView(collectionManager.Collection);
                StocksForSale.MoveCurrentTo(null);

                if (collectionManager != null && collectionManager.Collection != null)
                {
                    CartItemCount = collectionManager.Collection.Sum(x => x.Quantity);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool StockPackageAlreadyExistInCart(Shelf shelf)
        {
            try
            {
                StockForSale stockForSale = collectionManager.Collection.Where(sp => sp.StockPackage.Id == shelf.StockPackage.Id && sp.StockPackageRelationshipId == shelf.StockPackageRelationship.Id).SingleOrDefault();
                if (stockForSale != null)
                {
                    foreach (StockForSale stockForSaleInCart in collectionManager.Collection)
                    {
                        if (stockForSaleInCart.StockPackage.Id == shelf.StockPackage.Id && stockForSaleInCart.StockPackageRelationshipId == shelf.StockPackageRelationship.Id)
                        {
                            stockForSaleInCart.Quantity += 1;
                            stockForSale.OriginalQuantity = stockForSaleInCart.Quantity;
                            Shelf.Quantity = Shelf.FakeQuantityOnShelf - stockForSaleInCart.Quantity;
                            Shelf.ReorderLevel = Shelf.Quantity - Shelf.StockPackage.ReOrderLevel;

                            ReComputeTotalSellingPrice(stockForSaleInCart);
                            PopulateStockForSale();

                            SetCartViewState();

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
        }

        private void UpdateCartSummary()
        {
            try
            {
                ObservableCollection<StockForSale> stocksForSale = collectionManager.Collection;
                if (stocksForSale != null)
                {
                    decimal subTotal = stocksForSale.Sum(sfs => sfs.TotalSellingPrice);

                    CartItemCount = stocksForSale.Count;
                    SubTotal = Math.Round(subTotal, 2);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool QuantityEnteredIsGreater(StockForSale stockToSell)
        {
            try
            {
                Shelf currentStockOnShelf = GetCorrespondingStockOnShelf(stockToSell);

                if (currentStockOnShelf.FakeQuantityOnShelf < stockToSell.Quantity)
                {
                    Utility.DisplayMessage("Quantity entered '" + stockToSell.Quantity + "' for " + stockToSell.StockPackage.Package.Name + " of " + stockToSell.StockPackage.Stock.Name + " cannot be greater than quantity on shelf '" + currentStockOnShelf.FakeQuantityOnShelf + "'!");

                    stockToSell.OriginalQuantity = 1;
                    stockToSell.Quantity = 1;

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
                Shelf currentStockOnShelf = unsoldStockPackage.Shelfs.Where(s => s.StockPackage.Id == stockToSell.StockPackage.Id).SingleOrDefault();

                return currentStockOnShelf;
            }
            catch (Exception)
            {
                throw;
            }
        }
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

                    RefreshModelCollection();
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
                    if (stockOnCart.Quantity != stockOnCart.OriginalQuantity)
                    {
                        stockOnCart.StockPrice.SellingPrice = stockOnCart.OriginalStockPrice.SellingPrice * stockOnCart.Quantity;
                    }

                    stockOnCart.TotalSellingPrice = Math.Round(stockOnCart.StockPrice.SellingPrice - stockOnCart.Discount, 2);
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
                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            IsItemInCart = false;
                            ModelCanBeSaved = false;
                            ItemIsRemovable = false;
                            ModelCanBeCleared = false;

                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeSaved = true;

                            if (StocksForSale != null)
                            {
                                List<StockForSale> stocksForSale = new List<StockForSale>((IEnumerable<StockForSale>)StocksForSale.SourceCollection);
                                if (stocksForSale != null && stocksForSale.Count > 0)
                                {
                                    ModelCanBeCleared = true;
                                    ItemIsRemovable = false;
                                    IsItemInCart = true;
                                }
                                else
                                {
                                    ModelCanBeCleared = false;
                                    ItemIsRemovable = false;
                                    IsItemInCart = false;
                                }
                            }

                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeSaved = true;
                            ItemIsRemovable = true;
                            IsItemInCart = false;

                            break;
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
