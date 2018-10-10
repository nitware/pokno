using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using System.Windows.Forms.Integration;
using Pokno.Common.Models;
using Pokno.Report.Models;
using Pokno.Infrastructure.Events;
using Prism.Events;
using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.ViewModels
{
    public abstract class BaseReportViewModel : BaseApplicationViewModel // BaseViewModel
    {
        private bool _isBusy;
        private string _errorMessage;
        
        private WindowsFormsHost _reportHost;
        protected readonly IBaseReportFactory _reportFactory;

        public BaseReportViewModel(IBaseReportFactory reportFactory)
        {
            if (reportFactory == null)
            {
                throw new ArgumentNullException("reportFactory");
            }

            _reportFactory = reportFactory;

            IsBusy = false;
            ReportHost = new WindowsFormsHost();
            ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
        }
               
        protected ReportType ReportType { get; set; }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                base.OnPropertyChanged("ErrorMessage");
            }
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
        public WindowsFormsHost ReportHost
        {
            get { return _reportHost; }
            set
            {
                _reportHost = value;
                base.OnPropertyChanged("ReportHost");
            }
        }

        protected void ReportEngine_ReportLoadCompleted(object sender, EventArgs e)
        {
            try
            {
                IsBusy = false;
                ReportEngine.ReportLoadCompleted -= ReportEngine_ReportLoadCompleted;

                if (sender is Exception)
                {
                    ReportHost.Child = null;
                    Exception ex = sender as Exception;
                    ErrorMessage = ex.Message;
                                       
                    return;
                }
                
                ReportHost.Child = ReportEngine._loadedViewer;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void OnInitialise(ReportType reportType)
        {
            try
            {
                IsBusy = true;
                ErrorMessage = null;
                OnInitialiseHelper(reportType);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Utility.DisplayMessage(ex.Message);
                ErrorMessage = ex.Message;
            }
        }

        protected virtual void OnInitialiseHelper(ReportType reportType)
        {
            try
            {
                BaseReport report = _reportFactory.Create(reportType);
                ReportEngine reportEngine = new ReportEngine(report);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }





    }


}
