using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Models;
using Pokno.Model;
using Pokno.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Miscellaneous;

namespace Pokno.Report.ViewModels.Miscellaneous
{
    public class MonthlyStockSummaryReportViewModel : BaseReportForMonthlyReportViewModel // BaseReportByYearViewModel
    {
        public MonthlyStockSummaryReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(service, reportFactory)
        {

        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.MonthlyStockSummary);
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
                MonthlyStockSummaryReport monthlyStockSummaryReport = report as MonthlyStockSummaryReport;

                monthlyStockSummaryReport.Year = Year.Id;
                monthlyStockSummaryReport.Month = Month;
                ReportEngine reportEngine = new ReportEngine(monthlyStockSummaryReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
