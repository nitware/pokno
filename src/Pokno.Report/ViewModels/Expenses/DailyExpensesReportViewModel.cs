using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;
using Pokno.Common.Models;
using Pokno.Report.Models.Expenses;

namespace Pokno.Report.ViewModels.Expenses
{
    public class DailyExpensesReportViewModel : BaseReportByDateViewModel
    {
        public DailyExpensesReportViewModel(IBaseReportFactory reportFactory) : base(reportFactory)
        {

        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.DailyExpenses);
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
                DailyExpensesReport dailyExpensesReport = report as DailyExpensesReport;

                dailyExpensesReport.ToDate = Date;
                dailyExpensesReport.FromDate = Date;
                ReportEngine reportEngine = new ReportEngine(dailyExpensesReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }






    }


}
