using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Infrastructure.Models;
using Pokno.Report.Models.Expenses;

namespace Pokno.Report.ViewModels.Expenses
{
    public class YearlyExpensesReportViewModel : BaseReportByYearViewModel
    {
        public YearlyExpensesReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(service, reportFactory)
        {
            UpdateDisplayButtonState();
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.YearlyExpenses);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void OnInitialiseHelper(ReportType reportType)
        {
            try
            {
                BaseReport report = _reportFactory.Create(reportType);
                YearlyExpensesReport yearlyExpensesReport = report as YearlyExpensesReport;

                yearlyExpensesReport.Year = Year.Id;
                ReportEngine reportEngine = new ReportEngine(yearlyExpensesReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override sealed void UpdateDisplayButtonState()
        {
            try
            {
                base.UpdateDisplayButtonState();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



    }



}
