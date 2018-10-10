using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Prism.Commands;
using System.Windows;
using System.ComponentModel;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Report.Models;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Purchase;

namespace Pokno.Report.ViewModels.Purchase
{
    public class StockPurchasedDetailReportViewModel : BaseReportByDateRangeViewModel
    {
        public StockPurchasedDetailReportViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            //UpdateDisplayButtonState();
        }

        //protected override sealed void UpdateDisplayButtonState()
        //{
        //    try
        //    {
        //        base.UpdateDisplayButtonState();
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.StockPurchaseDetail);
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
                StockPurchaseDetailReport stockPurchaseDetailReport = report as StockPurchaseDetailReport;

                stockPurchaseDetailReport.ToDate = ToDate;
                stockPurchaseDetailReport.FromDate = FromDate;
                ReportEngine reportEngine = new ReportEngine(stockPurchaseDetailReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }





    }


}
