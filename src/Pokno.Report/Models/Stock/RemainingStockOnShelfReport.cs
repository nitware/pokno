using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Microsoft.Reporting.WinForms;
using Pokno.Model.Model;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Stock
{
    public class RemainingStockOnShelfReport : BaseReport
    {
        private List<StoreStock> _stocksOnShelf;

        public RemainingStockOnShelfReport(IBusinessFacade businessFacade) : base(businessFacade)
        {
            ReportName = "Remaining Stock on Shelf Report";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.RemainingStockOnShelf.rdlc";
            _stocksOnShelf = new List<StoreStock>();
        }

        public override void GetData()
        {
            try
            {
                _stocksOnShelf = _businessFacade.GetRemainingStockOnShelf();
                if (_stocksOnShelf == null || _stocksOnShelf.Count <= 0)
                {
                    throw new Exception("No stock found on shelf!");
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
                string dsStocksOnShelf = "StocksOnShelf";

                if (_stocksOnShelf != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStocksOnShelf.Trim(), _stocksOnShelf));
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
