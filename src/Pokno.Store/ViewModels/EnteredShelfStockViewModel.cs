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
using System.Windows.Threading;

using Pokno.Infrastructure.ViewModel;
using Pokno.Store.Interfaces;
using Pokno.Model;
using System.Collections.ObjectModel;
using Prism.Commands;
using Pokno.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class EnteredShelfStockViewModel : BaseViewModel
    {
        private Dispatcher _dispatcher;
        private readonly IShelfService _service;
        private BackgroundWorker _worker;

        private ListCollectionView _shelfStocks;
        private ObservableCollection<Shelf> _shelfs;
        private string _recordCount;
        private DateTime _fromDate;
        private DateTime _toDate;

        public EnteredShelfStockViewModel(IShelfService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;

            FromDate = Utility.GetDate();
            ToDate = Utility.GetDate();
            SearchCommand = new DelegateCommand(OnSearchCommand);
           
            eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }
                
        public string TabCaption
        {
            //get { return "Entered Shelf Stock"; }
            get { return "View Shelf Stock"; }
        }

        public DelegateCommand SearchCommand { get; private set; }

        public ObservableCollection<Shelf> Shelfs
        {
            get { return _shelfs; }
            set
            {
                _shelfs = value;
                OnPropertyChanged("Shelfs");
            }
        }
        public ListCollectionView ShelfStocks
        {
            get { return _shelfStocks; }
            set
            {
                _shelfStocks = value;
                OnPropertyChanged("ShelfStocks");
            }
        }

        public string RecordCount
        {
            get { return _recordCount; }
            set
            {
                _recordCount = value;
                OnPropertyChanged("RecordCount");
            }
        }
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                OnPropertyChanged("FromDate");
            }
        }
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                OnPropertyChanged("ToDate");
            }
        }

        private bool IsView(UI.Store ui)
        {
            return ui == UI.Store.ViewStockOnShelf;
        }
        private void OnInitialise(UI.Store ui)
        {
            try
            {
                OnSearchCommand();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSearchCommand()
        {
            try
            {
                if (InvalidEntry())
                {
                    return;
                }

                LoadByDateRange(FromDate, ToDate);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadByDateRangeCompleted);
                    _worker.DoWork += (s,e) =>
                        {
                            e.Result = _service.LaodByDateRange(fromDate, toDate);
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadByDateRangeCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    List<Shelf> shelfs = e.Result as List<Shelf>;
                    _dispatcher.Invoke(() =>
                    {
                        // this
                        //List<Shelf> result = shelfs.GroupBy(s => s.StockPackageRelationship.Id).Select(s => new Shelf
                        //    {
                        //        StockPackage = s.First().StockPackage,
                        //        StockType = s.First().StockType,
                        //        DateEntered = s.First().DateEntered,
                        //        ExpiryDate = s.First().ExpiryDate,
                        //        Quantity = s.Sum(q => q.Quantity)
                        //    }).ToList();

                        // or - any of them can serve
                        List<Shelf> result = shelfs.GroupBy(x => new { x.StockPackage.Stock.Id, x.StockPackage.Package.Name, x.DateEntered.Date }).Select(s => new Shelf
                        {
                            StockPackage = s.First().StockPackage,
                            StockType = s.First().StockType,
                            DateEntered = s.First().DateEntered.Date,
                            ExpiryDate = s.First().ExpiryDate,
                            Quantity = s.Sum(q => q.Quantity)
                        }).ToList();

                        Shelfs = new ObservableCollection<Shelf>(result);
                        if (Shelfs != null && Shelfs.Count > 0)
                        {
                            RecordCount = "Record Count: " + Shelfs.Count;
                        }


                        ShelfStocks = new ListCollectionView(Shelfs);
                        PropertyGroupDescription groupDescription = new PropertyGroupDescription("DateEntered");
                        ShelfStocks.GroupDescriptions.Add(groupDescription);
                        ShelfStocks.MoveCurrentTo(null);
                    });
                }
                else
                {
                    RecordCount = "Record Count: " + 0;
                    Shelfs = new ObservableCollection<Shelf>();
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool InvalidEntry()
        {
            try
            {
                TimeSpan dateDiff = ToDate - FromDate;

                if (DateTime.MinValue == FromDate || FromDate == null)
                {
                    Utility.DisplayMessage("Please specify start date!");
                    return true;
                }
                else if (DateTime.MinValue == ToDate || ToDate == null)
                {
                    Utility.DisplayMessage("Please specify end date!");
                    return true;
                }
                else if (dateDiff.Days < 0)
                {
                    Utility.DisplayMessage("End date cannot be less than start date! Please adjust.");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadLatestHundred()
        {
            try
            {
                List<Shelf> shelfs = _service.LaodLatestHundred();
                _dispatcher.Invoke(() =>
                {
                    Shelfs = new ObservableCollection<Shelf>(shelfs);
                    if (Shelfs != null && Shelfs.Count > 0)
                    {
                        RecordCount = "Record Count: " + Shelfs.Count;
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }




    }

}
