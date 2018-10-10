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
    public class StockListReport : BaseReport
    {
        private List<StoreStock> _stocks;

        public StockListReport(IBusinessFacade businessFacade) : base(businessFacade)
        {
            ReportName = "List of Stocks";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.StockList.rdlc";
            _stocks = new List<StoreStock>();
        }

        public override void GetData()
        {
            try
            {
                _stocks = _businessFacade.GetStoreStocks();
                if (_stocks == null || _stocks.Count <= 0)
                {
                    throw new Exception("No stock found!");
                }

                if (_stocks != null && _stocks.Count > 0)
                {
                    _stocks = _stocks.OrderBy(s => s.StockName).ToList();
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
                string dsStoreStocks = "dsStoreStocks";

                if (_stocks != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStoreStocks.Trim(), _stocks));
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
