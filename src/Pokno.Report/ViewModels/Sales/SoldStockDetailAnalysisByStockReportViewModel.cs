using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Sales;

namespace Pokno.Report.ViewModels.Sales
{
    public class SoldStockDetailAnalysisByStockReportViewModel : BaseReportByProductViewModel
    {
        private DateTime _toDate;
        private DateTime _fromDate;

        public SoldStockDetailAnalysisByStockReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(service, reportFactory)
        {
            ToDate = Utility.GetDate();
            FromDate = Utility.GetDate();
        }

        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                base.OnPropertyChanged("FromDate");
                UpdateDisplayButtonState();
            }
        }
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                base.OnPropertyChanged("ToDate");
                UpdateDisplayButtonState();
            }
        }

        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.SoldStockDetailAnalysisByStock);
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
                SoldStockDetailAnalysisByStockReport productSalesDetailByStockReport = report as SoldStockDetailAnalysisByStockReport;

                productSalesDetailByStockReport.Stock = Stock;
                productSalesDetailByStockReport.ToDate = ToDate;
                productSalesDetailByStockReport.FromDate = FromDate;
                ReportEngine reportEngine = new ReportEngine(productSalesDetailByStockReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }



    }



}
