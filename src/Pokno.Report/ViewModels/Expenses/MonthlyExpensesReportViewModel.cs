using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;
using Pokno.Common.Models;
using Pokno.Report.Models.Expenses;
using System.Collections.ObjectModel;
using Pokno.Model;

namespace Pokno.Report.ViewModels.Expenses
{
    public class MonthlyExpensesReportViewModel : BaseReportForMonthlyReportViewModel
    {
        private Value _type;
        private ObservableCollection<Value> _types;

        public MonthlyExpensesReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory) : base(service, reportFactory)
        {
            PopulateReportType();
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
                base.OnInitialise(ReportType.MonthlyExpenses);
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
                MonthlyExpensesReport monthlyExpensesReport = report as MonthlyExpensesReport;

                monthlyExpensesReport.Year = Year.Id;
                monthlyExpensesReport.Month = Month;
                monthlyExpensesReport.EmbeddedResource = SetReportType();

                ReportEngine reportEngine = new ReportEngine(monthlyExpensesReport);
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
                            reportEmbeddedResource = "Pokno.Common.Reports.Expenses.MonthlyExpensesSummary.rdlc";
                            break;
                        }
                    case 2:
                        {
                            reportEmbeddedResource = "Pokno.Common.Reports.Expenses.MonthlyExpensesDetail.rdlc";
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
                if (Year != null && Year.Id > 0 && Month != null && Month.Id > 0 && Type != null && Type.Id > 0)
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
