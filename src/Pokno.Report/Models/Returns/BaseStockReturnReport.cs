using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Common.Models;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;

namespace Pokno.Report.Models.Returns
{
    public abstract class BaseStockReturnReport : BaseReport
    {
        protected List<StoreReturnStock> _returnedStocks;

        public BaseStockReturnReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _returnedStocks = new List<StoreReturnStock>();
        }

        public virtual string Title { get; set; }

        private void SetParameter()
        {
            try
            {
                ReportParameter titleParam = new ReportParameter("Title", Title);
                ReportParameter[] reportParams = new ReportParameter[] { titleParam };
                _report.LocalReport.SetParameters(reportParams);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public override void SetProperties()
        {
            try
            {
                ReportEmbeddedResource = "Pokno.Common.Reports.Returns.ReturnedStock.rdlc";
                base.SetProperties();
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

                string dsReturnedStocks = "dsReturnedStocks";
                if (_returnedStocks == null || _returnedStocks.Count <= 0)
                {
                    _returnedStocks = new List<StoreReturnStock>();
                }
              
                _report.ProcessingMode = ProcessingMode.Local;
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsReturnedStocks.Trim(), _returnedStocks));
                _report.LocalReport.Refresh();
                _report.RefreshReport();
                
                return _report;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
