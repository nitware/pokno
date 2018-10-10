using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Models;
using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;
using Pokno.Report.Models.Miscellaneous;

namespace Pokno.Report.ViewModels.Miscellaneous
{
    public class DailyTransactionReportViewModel : BaseReportByDateViewModel
    {
        public DailyTransactionReportViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {

        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.DailyTransaction);
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
                DailyTransactionReport dailyTransactionReport = report as DailyTransactionReport;

                dailyTransactionReport.ToDate = Date;
                dailyTransactionReport.FromDate = Date;
                ReportEngine reportEngine = new ReportEngine(dailyTransactionReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }



       

    }


}
