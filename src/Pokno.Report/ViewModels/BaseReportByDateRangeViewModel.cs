using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Prism.Commands;
using System.Windows;
using System.Windows.Threading;
using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.ViewModels
{
    public abstract class BaseReportByDateRangeViewModel : BaseReportViewModel
    {
        private DateTime _toDate;
        private DateTime _fromDate;
        private bool _isEnabled;

        protected readonly Dispatcher _dispatcher;

        public BaseReportByDateRangeViewModel(IBaseReportFactory reportFactory) : base(reportFactory)
        {
            _dispatcher = Application.Current.Dispatcher;
            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);

            ToDate = Utility.GetDate();
            FromDate = Utility.GetDate();

            UpdateDisplayButtonState();
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

        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                base.OnPropertyChanged("FromDate");
                UpdateDisplayButtonState();
            }
        }
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                base.OnPropertyChanged("ToDate");
                UpdateDisplayButtonState();
            }
        }

        private bool CanDisplay()
        {
            return IsEnabled;
        }

        protected virtual void UpdateDisplayButtonState()
        {
            try
            {
                if ((FromDate != null && FromDate > DateTime.MinValue) && (ToDate != null && ToDate > DateTime.MinValue))
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
