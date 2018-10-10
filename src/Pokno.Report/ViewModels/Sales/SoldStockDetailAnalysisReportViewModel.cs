using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Models;
using Prism.Events;
using Prism.Commands;
using System.Windows.Threading;
using System.Windows;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Sales;

namespace Pokno.Report.ViewModels.Sales
{
    public class SoldStockDetailAnalysisReportViewModel : BaseReportByDateRangeViewModel
    {
        public SoldStockDetailAnalysisReportViewModel(IBaseReportFactory reportFactory) : base(reportFactory)
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
                base.OnInitialise(ReportType.SoldStockDetailAnalysis);
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
                SoldStockDetailAnalysisReport productSalesDetailAnalysisReport = report as SoldStockDetailAnalysisReport;

                productSalesDetailAnalysisReport.ToDate = ToDate;
                productSalesDetailAnalysisReport.FromDate = FromDate;
                ReportEngine reportEngine = new ReportEngine(productSalesDetailAnalysisReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

       





    }
}
