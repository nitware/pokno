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
    public class YearlyCustomerTransactionStatisticsReportViewModel: BaseReportByYearViewModel
    {
        public YearlyCustomerTransactionStatisticsReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(service, reportFactory)
        {
            UpdateDisplayButtonState();
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.YearlyCustomerTransactionStatistics);
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
                YearlyCustomerTransactionStatisticsReport customerStatisticsReport = report as YearlyCustomerTransactionStatisticsReport;

                customerStatisticsReport.Year = Year;
                ReportEngine reportEngine = new ReportEngine(customerStatisticsReport);
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
