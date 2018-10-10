using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using System.Windows;
using Prism.Commands;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Purchase;

namespace Pokno.Report.ViewModels.Purchase
{
    public class StockPurchaseSummaryReportViewModel : BaseReportByDateRangeViewModel
    {
        public StockPurchaseSummaryReportViewModel(IBaseReportFactory reportFactory)
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
                base.OnInitialise(ReportType.StockPurchaseSummary);
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
                StockPurchaseSummaryReport stockPurchaseSummaryReport = report as StockPurchaseSummaryReport;

                stockPurchaseSummaryReport.ToDate = ToDate;
                stockPurchaseSummaryReport.FromDate = FromDate;
                ReportEngine reportEngine = new ReportEngine(stockPurchaseSummaryReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }




    }



}
