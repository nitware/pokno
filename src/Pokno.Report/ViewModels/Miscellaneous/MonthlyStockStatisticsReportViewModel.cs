using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Infrastructure.Models;
using Pokno.Report.Models.Miscellaneous;

namespace Pokno.Report.ViewModels.Miscellaneous
{
    public class MonthlyStockStatisticsReportViewModel : BaseReportForMonthlyReportViewModel
    {
        public MonthlyStockStatisticsReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(service, reportFactory)
        {
            UpdateDisplayButtonState();
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.MonthlyStockStatistics);
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
                MonthlyStockStatisticsReport stockStatisticsReport = report as MonthlyStockStatisticsReport;

                stockStatisticsReport.Year = Year;
                stockStatisticsReport.Month = Month;
                ReportEngine reportEngine = new ReportEngine(stockStatisticsReport);
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
