using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Common.Models;
using Microsoft.Reporting.WinForms;
using Pokno.Model;

namespace Pokno.Report.Models.Stock
{
    public class StockListByTypeReport : BaseReport
    {
        private List<StoreStock> _stocks;

        public StockListByTypeReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "List of Stocks";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.StockListByType.rdlc";
            _stocks = new List<StoreStock>();
        }

        public StockType Type { get; set; }

        public override void GetData()
        {
            try
            {
                _stocks = _businessFacade.GetStoreStocksBy(Type);
                if (_stocks == null || _stocks.Count <= 0)
                {
                    throw new Exception("No stock found for the '" + Type.Name + "'!");
                }

                //if (_stocks != null && _stocks.Count > 0)
                //{
                //    _stocks = _stocks.OrderBy(s => s.StockName).ToList();
                //}
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void SetParameter()
        {
            try
            {
                ReportParameter stockTypeParam = new ReportParameter("StockType", Type.Name);
                ReportParameter[] reportParams = new ReportParameter[] { stockTypeParam };
                _report.LocalReport.SetParameters(reportParams);
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
                SetParameter();

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
