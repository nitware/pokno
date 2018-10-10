using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Prism.Commands;
using Pokno.Infrastructure.Models;
using System.Windows.Threading;
using System.Windows;
using Pokno.Report.Models;
using System.ComponentModel;
using Pokno.Service;
using Pokno.Model;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Purchase;

namespace Pokno.Report.ViewModels.Purchase
{
    public class StockPurchaseDetailByStockReportViewModel : BaseReportByProductViewModel
    {
        private DateTime _toDate;
        private DateTime _fromDate;
      
        public StockPurchaseDetailByStockReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
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
                base.OnInitialise(ReportType.StockPurchaseDetailByStock);
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
                StockPurchaseDetailByStockReport stockPurchaseDetailByStockReport = report as StockPurchaseDetailByStockReport;

                stockPurchaseDetailByStockReport.Stock = Stock;
                stockPurchaseDetailByStockReport.ToDate = ToDate;
                stockPurchaseDetailByStockReport.FromDate = FromDate;
                ReportEngine reportEngine = new ReportEngine(stockPurchaseDetailByStockReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }




    }

}
