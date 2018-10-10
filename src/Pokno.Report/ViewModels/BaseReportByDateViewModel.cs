
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using Prism.Commands;
using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.ViewModels
{
    public abstract class BaseReportByDateViewModel : BaseReportViewModel
    {
        private DateTime _date;
        private bool _isEnabled;

        protected readonly Dispatcher _dispatcher;

        public BaseReportByDateViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            _dispatcher = Application.Current.Dispatcher;
            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);

            Date = Utility.GetDate();
            UpdateDisplayButtonState();
        }

        public DelegateCommand DisplayCommand { get; private set; }

        //protected virtual void OnDisplayCommand()
        //{
        //    try
        //    {
        //        Pokno.Common.Models.ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                base.OnPropertyChanged("Date");
                UpdateDisplayButtonState();
            }
        }

        private bool CanDisplay()
        {
            return IsEnabled;
        }

        private void UpdateDisplayButtonState()
        {
            try
            {
                if ((Date != null && Date > DateTime.MinValue))
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
