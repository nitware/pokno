using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Sales
{
    public class SoldStockDetailAnalysisReport : BaseReport
    {
        private List<SoldStockView> _soldProducts;

        public SoldStockDetailAnalysisReport(IBusinessFacade businessFacade) : base(businessFacade)
        {
            ReportName = "Product Sales Detail Analysis";
            ReportEmbeddedResource = "Pokno.Common.Reports.Sales.SoldStockDetailAnalysis.rdlc";
            _soldProducts = new List<SoldStockView>();
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override void GetData()
        {
            try
            {
                _soldProducts = _businessFacade.GetSoldStockDetailsByDateRange(FromDate, ToDate);
                if (_soldProducts == null || _soldProducts.Count <= 0)
                {
                    throw new Exception("No sold stock detail analysis found for dates between " + FromDate.ToShortDateString() + " and " + ToDate.ToShortDateString() + "!");
                }

                if (_soldProducts != null && _soldProducts.Count > 0)
                {
                    _soldProducts = _soldProducts.OrderBy(s => s.DateSold).ToList();
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
                ReportParameter startDateParam = new ReportParameter("StartDate", FromDate.ToString());
                ReportParameter endDateParam = new ReportParameter("EndDate", ToDate.ToString());
                ReportParameter[] reportParams = new ReportParameter[] { startDateParam, endDateParam };
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

                string dsSoldStockDetail = "dsSoldStockDetail";
                if (_soldProducts != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsSoldStockDetail.Trim(), _soldProducts));
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
                    if (FromDate == null || DateTime.MinValue == FromDate)
                    {
                        errorMessage = "Please select From Date!";
                    }
                    else if (ToDate == null || DateTime.MinValue == ToDate)
                    {
                        errorMessage = "Please select To Date!";
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
