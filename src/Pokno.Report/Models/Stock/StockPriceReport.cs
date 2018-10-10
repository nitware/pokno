using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model.Model;
using Pokno.Service;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Stock
{
    public class StockPriceReport : BaseReport
    {
        private List<StoreStockPrice> _stockPrices;
        
        public StockPriceReport(IBusinessFacade businessFacade) : base(businessFacade)
        {
            ReportName = "Stock Price List";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.StockPrice.rdlc";
            _stockPrices = new List<StoreStockPrice>();
        }

        public override void GetData()
        {
            try
            {
                _stockPrices = _businessFacade.GetAllStoreStockPrice();
                if (_stockPrices == null || _stockPrices.Count <= 0)
                {
                    throw new Exception("No stock price found!");
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
                string dsStockPrice = "StockPrice";

                if (_stockPrices != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStockPrice.Trim(), _stockPrices));
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






    }


}
