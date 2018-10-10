using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Infrastructure.Models;
using Pokno.Report.Models.Payment;
using System.Collections.ObjectModel;
using Pokno.Model;
using Prism.Commands;

namespace Pokno.Report.ViewModels.Payment
{
    public class PaymentHistoryReportViewModel : BaseReportViewModel
    {
        private bool _isEnabled;
        private PersonType _personType;
        private ObservableCollection<PersonType> _personTypes;
        
        public PaymentHistoryReportViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            DisplayCommand = new DelegateCommand(OnDisplayCommand, CanDisplay);
            
            UpdateDisplayButtonState();
            PopulateReportType();
        }

        public DelegateCommand DisplayCommand { get; private set; }
               
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

        public ObservableCollection<PersonType> PersonTypes
        {
            get { return _personTypes; }
            set
            {
                _personTypes = value;
                base.OnPropertyChanged("PersonTypes");
            }
        }
        public PersonType PersonType
        {
            get { return _personType; }
            set
            {
                _personType = value;
                base.OnPropertyChanged("PersonType");
                UpdateDisplayButtonState();
            }
        }

        private bool CanDisplay()
        {
            return IsEnabled;
        }

        private void PopulateReportType()
        {
            try
            {
                PersonTypes = new ObservableCollection<PersonType>();
                PersonType select = new PersonType() { Id = 0, Name = "<< Select Type >>" };
                PersonType all = new PersonType() { Id = 1, Name = "All" };
                PersonType customer = new PersonType() { Id = 3, Name = "Customer" };
                PersonType supplier = new PersonType() { Id = 2, Name = "Supplier" };

                PersonTypes.Add(select);
                PersonTypes.Add(all);
                PersonTypes.Add(customer);
                PersonTypes.Add(supplier);
               
                PersonType = PersonTypes.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.PaymentHistory);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void OnInitialiseHelper(ReportType reportType)
        {
            try
            {
                BaseReport report = _reportFactory.Create(reportType);
                PaymentHistoryReport paymentHistoryReport = report as PaymentHistoryReport;

                paymentHistoryReport.PersonType = PersonType;
                ReportEngine reportEngine = new ReportEngine(paymentHistoryReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void UpdateDisplayButtonState()
        {
            try
            {
                if (PersonType != null && PersonType.Id > 0 )
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
