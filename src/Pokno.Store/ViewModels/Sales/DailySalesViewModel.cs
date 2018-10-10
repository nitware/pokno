using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Infrastructure.ViewModel;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows;
using Prism.Events;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Model.Model;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Prism.Commands;

namespace Pokno.Store.ViewModels
{
    public class DailySalesViewModel : BaseApplicationViewModel
    {
        private bool _isBusy;
        private DateTime _date;
        private ListCollectionView _dailySales;
        private BitmapImage _searchIcon;
        private Dispatcher _dispatcher;
        private BackgroundWorker _worker;
        private readonly IBusinessFacade _businessFacade;

        public DailySalesViewModel(IBusinessFacade businessFacade, IEventAggregator eventAggregator)
        {
            if (businessFacade == null)
            {
                throw new ArgumentNullException("businessFacade");
            }

            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;

            FindCommand = new DelegateCommand(OnFindCommand, CanFind);

            Date = Utility.GetDate();
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanViewDailySales;
            SearchIcon = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\search.jpg");
            eventAggregator.GetEvent<SalesEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public DelegateCommand FindCommand { get; private set; }

        private decimal _totalCostPrice;
        private decimal _totalSellingPrice;
        private decimal _totalAmountPayable;
        private decimal _totalAmountPaid;
        private decimal _totalDiscount;
        private decimal _totalProfit;

        public decimal TotalSellingPrice
        {
            get { return _totalSellingPrice; }
            set
            {
                _totalSellingPrice = value;
                base.OnPropertyChanged("TotalSellingPrice");
            }
        }
        public decimal TotalCostPrice
        {
            get { return _totalCostPrice; }
            set
            {
                _totalCostPrice = value;
                base.OnPropertyChanged("TotalCostPrice");
            }
        }
        public decimal TotalAmountPayable
        {
            get { return _totalAmountPayable; }
            set
            {
                _totalAmountPayable = value;
                base.OnPropertyChanged("TotalAmountPayable");
            }
        }
        public decimal TotalAmountPaid
        {
            get { return _totalAmountPaid; }
            set
            {
                _totalAmountPaid = value;
                base.OnPropertyChanged("TotalAmountPaid");
            }
        }
        public decimal TotalDiscount
        {
            get { return _totalDiscount; }
            set
            {
                _totalDiscount = value;
                base.OnPropertyChanged("TotalDiscount");
            }
        }
        public decimal TotalProfit
        {
            get { return _totalProfit; }
            set
            {
                _totalProfit = value;
                base.OnPropertyChanged("TotalProfit");
            }
        }

        public string TabCaption
        {
            get { return "Daily Sales"; }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
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
        public DateTime Date 
        {
            get { return _date; }
            set
            {
                _date = value;
                base.OnPropertyChanged("Date");
            }
        }

        public ListCollectionView DailySales 
        {
            get { return _dailySales; }
            set
            {
                _dailySales = value;
                base.OnPropertyChanged("DailySales");
            }
        }

        private bool CanFind()
        {
            return Date != DateTime.MinValue && Date != null;
        }
        private bool IsView(UI.Sales ui)
        {
            return ui == UI.Sales.DailySales;
        }

        private void OnInitialise(UI.Sales ui)
        {
            try
            {
                if (Date == null)
                {
                    return;
                }

                FindDailySalesBy(Date);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void FindDailySalesBy(DateTime date)
        {
            try
            {
                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnFindDailySalesByCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _businessFacade.GetSoldStockDetailsByDateRange(date, date);
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                IsBusy = false;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnFindDailySalesByCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    List<SoldStockView> dailySales = e.Result as List<SoldStockView>;
                    _dispatcher.Invoke(() =>
                    {
                        TotalCostPrice = dailySales.Sum(ds => ds.CostPrice);
                        TotalSellingPrice = dailySales.Sum(ds => ds.SellingPrice);
                        TotalDiscount = dailySales.Sum(ds => ds.TotalDiscount);
                        TotalAmountPaid = dailySales.Sum(ds => ds.AmountPaid);
                        TotalAmountPayable = TotalSellingPrice - TotalDiscount;
                        TotalProfit = TotalSellingPrice - TotalCostPrice - TotalDiscount;
                        
                        DailySales = new ListCollectionView(dailySales);
                        PropertyGroupDescription groupDescription = new PropertyGroupDescription("InvoiceNumber");
                        DailySales.GroupDescriptions.Add(groupDescription);
                        DailySales.MoveCurrentTo(null);
                    });
                }
            }
            catch(Exception ex)
            {

                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnFindCommand()
        {
            try
            {
                if (Date == null || Date == DateTime.MinValue)
                {
                    Utility.DisplayMessage("Selected date is invalid!");
                    return;
                }

                FindDailySalesBy(Date);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Utility.DisplayMessage(ex.Message);
            }
        }

       





    }





}
