using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Threading;
using Prism.Events;
using System.Windows;
using Pokno.Model;
using Prism.Commands;
using Pokno.Service;
using System.Windows.Data;
using Pokno.Infrastructure.Models;
using System.Collections.ObjectModel;
using Pokno.Common.Interfaces;
using Pokno.Common.Models;
using Pokno.Report.Models.Stock;

namespace Pokno.Report.ViewModels.Stock
{
    public class StockPriceHistoryByStockReportViewModel : BaseReportByProductViewModel
    {
        public StockPriceHistoryByStockReportViewModel(IBusinessFacade service, IBaseReportFactory reportFactory)
            : base(service, reportFactory)
        {

        }
      
        protected override void OnDisplayCommand()
        {
            try
            {
                ReportEngine.ReportLoadCompleted += ReportEngine_ReportLoadCompleted;
                base.OnInitialise(ReportType.StockPriceHistoryByStock);
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
                StockPriceHistoryByStockReport stockPriceHistoryByStockReport = report as StockPriceHistoryByStockReport;

                stockPriceHistoryByStockReport.Stock = Stock;
                ReportEngine reportEngine = new ReportEngine(stockPriceHistoryByStockReport);
                reportEngine.Generate();
            }
            catch (Exception)
            {
                throw;
            }
        }

        





    }


}
