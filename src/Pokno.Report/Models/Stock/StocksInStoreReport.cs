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
    public class StocksInStoreReport : BaseReport
    {
        private List<StoreStock> _stocksInStore;

        public StocksInStoreReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Available Stocks in Store Report";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.StocksInStore.rdlc";
            _stocksInStore = new List<StoreStock>();
        }

        public override void GetData()
        {
            try
            {
                _stocksInStore = _businessFacade.GetStocksInStore();
                if (_stocksInStore == null || _stocksInStore.Count <= 0)
                {
                    throw new Exception("No stock found in store!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ReportViewer GenerateHelper()
        {
            try
            {
                string dsStocksInstore = "dsStocksInstore";

                if (_stocksInStore != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStocksInstore.Trim(), _stocksInStore));
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
