using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Interfaces;
using Pokno.Infrastructure.Models;
using Pokno.Common.Models;
using Pokno.Report.Models.Returns;

namespace Pokno.Report.ViewModels.Returns
{
    public class StockReturnByDateRangeReportViewModel : BaseReportByDateRangeViewModel
    {
        public StockReturnByDateRangeReportViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.StockReturnByDateRange);
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
                StockReturnByDateRangeReport returnedStockReport = report as StockReturnByDateRangeReport;

                returnedStockReport.DateTo = ToDate;
                returnedStockReport.DateFrom = FromDate;
                ReportEngine reportEngine = new ReportEngine(returnedStockReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }





    }



}
