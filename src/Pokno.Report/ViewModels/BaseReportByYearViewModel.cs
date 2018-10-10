using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Interfaces;
using Pokno.Model.Model;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using System.ComponentModel;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Service;
using Pokno.Common.Models;

namespace Pokno.Report.ViewModels
{
    public abstract class BaseReportByYearViewModel : BaseReportViewModel
    {
        private Year _year;
        private bool _isEnabled;
        private ObservableCollection<Year> _years;

        protected readonly Dispatcher _dispatcher;
        protected readonly IBusinessFacade _service;
        private BackgroundWorker _worker;

        public BaseReportByYearViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;
            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);

            LoadYears();
        }
                
        public DelegateCommand DisplayCommand { get; private set; }

        protected abstract void OnDisplayCommand();

        //protected virtual void OnDisplayCommand()
        //{
        //    try
        //    {
        //        ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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

        private bool CanDisplay()
        {
            return IsEnabled;
        }

        protected void LoadYears()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadYearsCompleted);
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

        private void OnLoadYearsCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    PopulateYears(years);
                }
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
                //List<Year> years = _service.GetTotalYears();
                if (years != null)
                {
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
                if (Year != null && Year.Id > 0)
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
