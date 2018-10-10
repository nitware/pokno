using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using System.Windows.Media.Imaging;
using Pokno.Infrastructure.Models;
using Pokno.Service;
using System.Windows.Data;
using Pokno.Model.Model;
using System.Collections.ObjectModel;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.ComponentModel;
using Pokno.Model;
using System.Windows.Threading;
using System.Windows;

namespace Pokno.Store.ViewModels
{
    public class StockPriceCheckViewModel : BaseApplicationViewModel
    {
        private Dispatcher _dispatcher;

        private BitmapImage _searchIcon;
        private BackgroundWorker _worker;
        private readonly IBusinessFacade _businessFacade;
        private ObservableCollection<StoreStockPrice> _searchedStockPrices;
        private ObservableCollection<StoreStockPrice> _rawStockPrices;
        private ObservableCollection<Stock> _stocks;
        private ListCollectionView _stockPrices;
        private Stock _stock;
        
        public StockPriceCheckViewModel(IBusinessFacade businessFacade, IEventAggregator eventAggregator)
        {
            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanViewStockPriceList;
            SearchIcon = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\search.jpg");
            eventAggregator.GetEvent<SalesEvent>().Subscribe(Oninitialise, ThreadOption.UIThread, false, IsView);
        }
        
        public string TabCaption
        {
            get { return "Check Stock Price"; }
        }
     
        public ListCollectionView StockPrices
        {
            get { return _stockPrices; }
            set
            {
                _stockPrices = value;
                base.OnPropertyChanged("StockPrices");
            }
        }
        public ObservableCollection<StoreStockPrice> SearchedStockPrices
        {
            get { return _searchedStockPrices; }
            set
            {
                _searchedStockPrices = value;
                base.OnPropertyChanged("SearchedStockPrices");
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
        public Stock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                base.OnPropertyChanged("Stock");

                if (_stock != null)
                {
                    GetStockPriceBy(_stock);
                }
                else
                {
                    SearchedStockPrices = new ObservableCollection<StoreStockPrice>();
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
        public ObservableCollection<StoreStockPrice> RawStockPrices
        {
            get { return _rawStockPrices; }
            set
            {
                _rawStockPrices = value;
                OnPropertyChanged("RawStockPrices");
            }
        }

        private bool IsView(UI.Sales ui)
        {
            return ui == UI.Sales.StockPriceCheck;
        }
        private void Oninitialise(UI.Sales ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OninitialiseCompleted);
                    _worker.DoWork += (o, e) =>
                    {
                        List<StoreStockPrice> stockPrices = _businessFacade.GetAllStoreStockPrice();
                        List<Stock> stocks = _businessFacade.GetAllStocks();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stockPrices"] = stockPrices;
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

        private void OninitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<Stock> stocks = null;
                List<StoreStockPrice> stockPrices = null;

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    stockPrices = (List<StoreStockPrice>)dictionary["stockPrices"];
                    stocks = (List<Stock>)dictionary["stocks"];
                }

                _dispatcher.Invoke(() =>
                {
                    if (stocks != null)
                    {
                        Stocks = new ObservableCollection<Stock>(stocks);
                    }

                    if (stockPrices != null)
                    {
                        StockPrices = new ListCollectionView(stockPrices);
                        PropertyGroupDescription groupDescription = new PropertyGroupDescription("StockName");
                        StockPrices.GroupDescriptions.Add(groupDescription);
                        StockPrices.MoveCurrentTo(null);
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetStockPriceBy(Stock stock)
        {
            try
            {
                if (StockPrices == null || StockPrices.Count <= 0)
                {
                    return;
                }

                List<StoreStockPrice> stockPrices = (List<StoreStockPrice>)StockPrices.SourceCollection;
                List<StoreStockPrice> filteredStockPrices = stockPrices.Where(x => x.StockName.StartsWith(stock.Name, StringComparison.OrdinalIgnoreCase)).ToList();

                if (filteredStockPrices != null)
                {
                    SearchedStockPrices = new ObservableCollection<StoreStockPrice>(filteredStockPrices);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }







    }
}
