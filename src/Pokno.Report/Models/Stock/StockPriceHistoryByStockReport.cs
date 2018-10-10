using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Stock
{
    public class StockPriceHistoryByStockReport : BaseReport
    {
        private List<StoreStockPrice> _stockPrices;

        public StockPriceHistoryByStockReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Product Price History By Stock";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.StockPriceHistoryByStock.rdlc";
            _stockPrices = new List<StoreStockPrice>();
        }

        public Model.Stock Stock { get; set; }

        public override void GetData()
        {
            try
            {
                _stockPrices = _businessFacade.GetAllStoreStockPriceHistoryByStock(Stock);
                if (_stockPrices == null || _stockPrices.Count <= 0)
                {
                    throw new Exception("No stock price history found for '" + Stock.Name + "'!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetParameter()
        {
            try
            {
                ReportParameter stockNameParam = new ReportParameter("StockName", Stock.Name);
                ReportParameter[] reportParams = new ReportParameter[] { stockNameParam };
                _report.LocalReport.SetParameters(reportParams);
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
                SetParameter();

                string dsStockPriceHistory = "StockPriceHistory";
                if (_stockPrices != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStockPriceHistory.Trim(), _stockPrices));
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

        public override string KeyPropertiesNotSet()
        {
            try
            {
                string errorMessage = base.KeyPropertiesNotSet();

                if (string.IsNullOrWhiteSpace(errorMessage))
                {
                    if (Stock == null || Stock.Id <= 0)
                    {
                        errorMessage = "Please select stock!";
                    }
                }

                return errorMessage;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }



}
