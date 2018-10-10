using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Infrastructure.Models;
using Pokno.Report.Models.Miscellaneous;

namespace Pokno.Report.ViewModels.Miscellaneous
{
    public class StockStatisticsByDateRangeReportViewModel : BaseReportByDateRangeViewModel
    {
        public StockStatisticsByDateRangeReportViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.StockStatisticsByDateRange);
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
                StockStatisticsByDateRangeReport stockStatisticsReport = report as StockStatisticsByDateRangeReport;
                                
                stockStatisticsReport.DateTo = ToDate;
                stockStatisticsReport.DateFrom = FromDate;
                ReportEngine reportEngine = new ReportEngine(stockStatisticsReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
