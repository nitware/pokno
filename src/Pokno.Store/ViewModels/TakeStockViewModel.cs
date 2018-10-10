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

using Pokno.Infrastructure.ViewModel;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Pokno.Model.Model;
using Prism.Commands;
using System.Collections.Generic;
using Pokno.Infrastructure.Interfaces;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.Linq;

namespace Pokno.Store.ViewModels
{
    public class TakeStockViewModel : BaseViewModel
    {
        private Year _year;
        private bool _isBusy;
        private string _recordCount;
        private ITakeStockService _service;
        private StockReviewDetail _stockReviewDetail;
        private ListCollectionView _stockReviewDetails;
        private ObservableCollection<Year> _years;
        private Dispatcher _dispatcher;
        private bool _stockCanBeTaking;

        private BackgroundWorker _worker;

        public TakeStockViewModel(ITakeStockService service, IEventAggregator eventAggregator)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;

            TakeStockCommand = new DelegateCommand(OnTakeStockCommand, CanTakeStock);
            eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);

            StockCanBeTaking = true;
        }
               
        public DelegateCommand TakeStockCommand { get; private set; }

        public string TabCaption
        {
            get { return "Take Stock"; }
        }
        public bool StockCanBeTaking
        {
            get { return _stockCanBeTaking; }
            set
            {
                _stockCanBeTaking = value;
                if (TakeStockCommand != null)
                {
                    TakeStockCommand.RaiseCanExecuteChanged();
                }
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
       
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                StockCanBeTaking = _isBusy ? false : true;

                //if (_isBusy)
                //{
                //    StockCanBeTaking = false;
                //}
                //else
                //{
                //    StockCanBeTaking = true;
                //}

                base.OnPropertyChanged("IsBusy");
            }
        }
        public ObservableCollection<Year> Years
        {
            get { return _years; }
            set
            {
                _years = value;
                base.OnPropertyChanged("Years");
            }
        }
        public Year Year
        {
            get { return _year; }
            set
            {
                _year = value;
                base.OnPropertyChanged("Year");

                //UpdateButton(_year);
                if (_year != null && _year.Id > 0)
                {
                    GetYearlyStockReview(_year);
                }
            }
        }
        public ListCollectionView StockReviewDetails
        {
            get { return _stockReviewDetails; }
            set
            {
                _stockReviewDetails = value;
                base.OnPropertyChanged("StockReviewDetails");
            }
        }
        public StockReviewDetail StockReviewDetail
        {
            get { return _stockReviewDetail; }
            set
            {
                _stockReviewDetail = value;
                base.OnPropertyChanged("StockReviewDetails");
            }
        }

        private bool CanTakeStock()
        {
            return StockCanBeTaking;
        }

        private bool IsView(UI.Store payload)
        {
            return payload == UI.Store.YearlyStockSummary;
        }
        private void OnInitialise(UI.Store ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.GetTotalYears();
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
                    List<Year> years = e.Result as List<Year>;
                    LoadYears(years);
                }
                else
                {
                    Years = new ObservableCollection<Year>();
                    Year = new Year();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadYears(List<Year> years)
        {
            try
            {
                if (years == null)
                {
                    years = new List<Year>();
                }

                if (years.Count > 0)
                {
                    years.Insert(0, new Year() { Id = 0, Name = "<< Select Year >>" });
                }

                _dispatcher.Invoke
                          (() =>
                          {
                              Years = new ObservableCollection<Year>(years);
                              Year = Years.FirstOrDefault();
                          });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnTakeStockCommand()
        {
            try
            {
                if (Year == null || Year.Id == 0)
                {
                    return;
                }

                StockReview stockReview = new StockReview();
                stockReview.ReviewDate = Utility.GetDate();
                stockReview.ReviewedBy = Utility.LoggedInUser;
                stockReview.ReviewYear = Year.Id;

                IEnumerable<StockReviewDetail> stockReviewDetails = null;
                if (StockReviewDetails != null)
                {
                    stockReviewDetails = (IEnumerable<StockReviewDetail>)StockReviewDetails.SourceCollection;
                }

                if (stockReviewDetails != null)
                {
                    MessageBoxResult response = Utility.DisplayMessage("Stock has already been taken for the selected year '" + Year.Id + "'. This action will over write the existing entries. Do you which to continue?", MessageBoxButton.YesNo);
                    if (response == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnTakeStockCommandCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.TakeStock(stockReview);
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                StockCanBeTaking = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnTakeStockCommandCompleted(object source, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    StockCanBeTaking = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                bool done = false;
                if (e.Result != null)
                {
                   done = (bool)e.Result;
                }

                if (done)
                {
                    GetYearlyStockReview(Year);
                    Utility.DisplayMessage("Stock for " + Year.Name + " has been successfully taking");
                }
                else
                {
                    Utility.DisplayMessage("Stock for " + Year.Name + " was not successfully taking");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetYearlyStockReview(Year year)
        {
            try
            {
                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetYearlyStockReviewCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _service.GetYearlyStockReview(year.Id);
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                StockCanBeTaking = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetYearlyStockReviewCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;
                if (e.Error != null)
                {
                    StockCanBeTaking = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                ObservableCollection<StockReviewDetail> stockReviewDetails = null;
                if (e.Result != null )
                {
                    List<StockReviewDetail> detailStockReviews = e.Result as List<StockReviewDetail>;
                    stockReviewDetails = new ObservableCollection<StockReviewDetail>(detailStockReviews);
                }

                _dispatcher.Invoke(() =>
                {
                    if (stockReviewDetails != null && stockReviewDetails.Count > 0)
                    {
                        RecordCount = "Record Count: " + stockReviewDetails.Count;

                        StockReviewDetails = new ListCollectionView(stockReviewDetails);
                        //PropertyGroupDescription transactionMonth = new PropertyGroupDescription("TransactionMonth");
                        PropertyGroupDescription monthNumber = new PropertyGroupDescription("MonthName");
                        //StockReviewDetails.GroupDescriptions.Add(transactionMonth);
                        StockReviewDetails.GroupDescriptions.Add(monthNumber);

                        //StockReviewDetails.GroupDescriptions.OrderBy(s => s.t)

                        StockReviewDetails.MoveCurrentTo(null);
                    }
                    else
                    {
                        StockReviewDetails = new ListCollectionView(new ObservableCollection<StockReviewDetail>());
                    }
                });
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void UpdateButton(Year year)
        //{
        //    try
        //    {
        //        if (year != null && year.Id > 0)
        //        {
        //            StockCanBeTaking = true;
        //        }
        //        else
        //        {
        //            StockCanBeTaking = false;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}



    }

}
