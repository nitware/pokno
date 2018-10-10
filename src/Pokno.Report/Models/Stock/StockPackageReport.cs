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
    public class StockPackageReport : BaseReport
    {
        private List<StoreStock> _stockPackages;

        public StockPackageReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "List of Stock Packages";
            ReportEmbeddedResource = "Pokno.Common.Reports.Stock.StockPackages.rdlc";
            _stockPackages = new List<StoreStock>();
        }

        public override void GetData()
        {
            try
            {
                _stockPackages = _businessFacade.GetAllStoreStock();
                if (_stockPackages == null || _stockPackages.Count <= 0)
                {
                    throw new Exception("No stock package found!");
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
                string dsStockPackages = "StockPackages";

                if (_stockPackages != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStockPackages.Trim(), _stockPackages));
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
