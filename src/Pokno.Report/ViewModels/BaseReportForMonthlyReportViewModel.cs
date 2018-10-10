using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows;
using Prism.Commands;

namespace Pokno.Report.ViewModels
{
    public abstract class BaseReportForMonthlyReportViewModel : BaseReportViewModel
    {
        private Year _year;
        private Value _month;
        private bool _isEnabled;
        private ObservableCollection<Year> _years;
        private ObservableCollection<Value> _months;
        
        protected readonly IBusinessFacade _service;
        protected readonly Dispatcher _dispatcher;
        private BackgroundWorker _worker;

        public BaseReportForMonthlyReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;
            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);

            LoadYearAndMonths();
        }
                
        public DelegateCommand DisplayCommand { get; private set; }

        protected abstract void OnDisplayCommand();

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                base.OnPropertyChanged("IsEnabled");
                DisplayCommand.RaiseCanExecuteChanged();
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
                UpdateDisplayButtonState();
            }
        }
        public Value Month
        {
            get { return _month; }
            set
            {
                _month = value;
                base.OnPropertyChanged("Month");
                UpdateDisplayButtonState();
            }
        }
        public ObservableCollection<Value> Months
        {
            get { return _months; }
            set
            {
                _months = value;
                base.OnPropertyChanged("Months");
            }
        }

        private bool CanDisplay()
        {
            return IsEnabled;
        }

        protected void LoadYearAndMonths()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadYearAndMonthsCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<Year> years = _service.GetTotalYears();
                        List<Value> months = Utility.GetMonthsInYear();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["months"] = months;
                        dictionary["years"] = years;

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

        private void OnLoadYearAndMonthsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<Year> years = null;
                List<Value> months = null;
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    months = (List<Value>)dictionary["months"];
                    years = (List<Year>)dictionary["years"];
                }

                PopulateYears(years);
                PopulateMonths(months);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void PopulateYears(List<Year> years)
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

                _dispatcher.Invoke(() =>
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
        private void PopulateMonths(List<Value> months)
        {
            try
            {
                if (months == null)
                {
                    months = new List<Value>();
                }

                if (months.Count > 0)
                {
                    months.Insert(0, new Value() { Id = 0, Name = "<< Select Month >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    Months = new ObservableCollection<Value>(months);
                    Month = Months.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void UpdateDisplayButtonState()
        {
            try
            {
                if (Year != null && Year.Id > 0 && Month != null && Month.Id > 0)
                {
                    IsEnabled = true;
                }
                else
                {
                    IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }




    }
}
