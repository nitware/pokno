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
    public class CustomerTransactionStatisticsByDateRangeReportViewModel : BaseReportByDateRangeViewModel
    {
        public CustomerTransactionStatisticsByDateRangeReportViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {

        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.CustomerTransactionStatisticsByDateRange);
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
                CustomerTransactionStatisticsByDateRangeReport customerStatisticsReport = report as CustomerTransactionStatisticsByDateRangeReport;
                                
                customerStatisticsReport.DateTo = ToDate;
                customerStatisticsReport.DateFrom = FromDate;
                ReportEngine reportEngine = new ReportEngine(customerStatisticsReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }






    }


}
