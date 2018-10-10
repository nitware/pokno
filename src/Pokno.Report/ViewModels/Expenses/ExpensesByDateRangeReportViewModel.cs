using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Service;
using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;
using Pokno.Common.Models;
using System.Collections.ObjectModel;
using Pokno.Report.Models.Expenses;

namespace Pokno.Report.ViewModels.Expenses
{
    public class ExpensesByDateRangeReportViewModel : BaseReportByDateRangeViewModel
    {
         private Value _type;
        private ObservableCollection<Value> _types;

        public ExpensesByDateRangeReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            PopulateReportType();
            //UpdateDisplayButtonState();
        }

        private void PopulateReportType()
        {
            try
            {
                Types = new ObservableCollection<Value>();
                Value select = new Value() { Id = 0, Name = "<< Select Type >>" };
                Value summary = new Value() { Id = 1, Name = "Summary" };
                Value detail = new Value() { Id = 2, Name = "Detail" };

                Types.Add(select);
                Types.Add(summary);
                Types.Add(detail);

                Type = Types.FirstOrDefault();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public ObservableCollection<Value> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                base.OnPropertyChanged("Types");
            }
        }
        public Value Type
        {
            get { return _type; }
            set
            {
                _type = value;
                base.OnPropertyChanged("Type");
                UpdateDisplayButtonState();
            }
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.ExpensesByDateRange);
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
                ExpensesByDateRangeReport expensesByDateRangeReport = report as ExpensesByDateRangeReport;

                expensesByDateRangeReport.FromDate = FromDate;
                expensesByDateRangeReport.ToDate = ToDate;
                expensesByDateRangeReport.EmbeddedResource = SetReportType();

                ReportEngine reportEngine = new ReportEngine(expensesByDateRangeReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string SetReportType()
        {
            try
            {
                string reportEmbeddedResource = null;

                switch (Type.Id)
                {
                    case 1:
                        {
                            reportEmbeddedResource = "Pokno.Common.Reports.Expenses.ExpensesSummaryByDateRange.rdlc";
                            break;
                        }
                    case 2:
                        {
                            reportEmbeddedResource = "Pokno.Common.Reports.Expenses.ExpensesDetailByDateRange.rdlc";
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException();
                        }
                }

                return reportEmbeddedResource;
            }
            catch(Exception)
            {
                throw;
            }
        }

        protected override sealed void UpdateDisplayButtonState()
        {
            try
            {
                if ((FromDate != null && FromDate > DateTime.MinValue) && (ToDate != null && ToDate > DateTime.MinValue) && (Type != null && Type.Id > 0))
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
