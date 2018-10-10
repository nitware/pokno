using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Stock
{
    public class StockPriceHistoryReport : BaseReport
    {
        private List<StoreStockPrice> _stockPriceHistories;

        public StockPriceHistoryReport(IBusinessFacade businessFacade) : base(businessFacade)
        {
            ReportName = "Stock Price History";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.StockPriceHistory.rdlc";
            _stockPriceHistories = new List<StoreStockPrice>();
        }

        public override void GetData()
        {
            try
            {
                _stockPriceHistories = _businessFacade.GetAllStoreStockPriceHistory();
                if (_stockPriceHistories == null || _stockPriceHistories.Count <= 0)
                {
                    throw new Exception("No stock price history found!");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public override ReportViewer GenerateHelper()
        {
            try
            {
                string dsStockPrice = "StockPriceHistory";

                if (_stockPriceHistories != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStockPrice.Trim(), _stockPriceHistories));
                    _report.LocalReport.Refresh();
                    _report.RefreshReport();
                }

                return _report;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //protected override string ValidateReportData()
        //{
        //    try
        //    {
        //        string errorMessage = null;
        //        if (_stockPriceHistories == null || _stockPriceHistories.Count <= 0)
        //        {
        //            errorMessage = "Stock Price History not found in the system!";
        //        }

        //        return errorMessage;
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}






    }


}
