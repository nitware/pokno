using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Models;
using Pokno.Report.Models;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Sales;

namespace Pokno.Report.ViewModels.Sales
{
    public class SoldStockAnalysisReportViewModel : BaseReportByDateRangeViewModel
    {
        public SoldStockAnalysisReportViewModel(IBaseReportFactory reportFactory) : base(reportFactory)
        {
            //UpdateDisplayButtonState();
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanViewStockSalesAnalysisReport;
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
                base.OnInitialise(ReportType.SoldStockAnalysis);
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
                SoldStockAnalysisReport productSalesAnalysisReport = report as SoldStockAnalysisReport;

                productSalesAnalysisReport.ToDate = ToDate;
                productSalesAnalysisReport.FromDate = FromDate;
                ReportEngine reportEngine = new ReportEngine(productSalesAnalysisReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }




        
    }
}
