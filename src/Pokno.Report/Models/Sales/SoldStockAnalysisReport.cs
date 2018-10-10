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
    public class SoldStockAnalysisReport : BaseReport
    {
        private List<SoldStockView> _soldProducts;

        public SoldStockAnalysisReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Product Sales Analysis";
            ReportEmbeddedResource = "Pokno.Common.Reports.Sales.SoldStockAnalysis.rdlc";

            //ReportEmbeddedResource = "Pokno.Report.Reports.SoldStockAnalysis.rdlc";
            _soldProducts = new List<SoldStockView>();
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override void GetData()
        {
            try
            {
                _soldProducts = _businessFacade.GetSoldStockByDateRange(FromDate, ToDate);
                if (_soldProducts == null || _soldProducts.Count <= 0)
                {
                    throw new Exception("No sold stock analysis found for dates between " + FromDate.ToShortDateString() + " and " + ToDate.ToShortDateString() + "!");
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
                //System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("Pokno.Report.dll");
                //System.IO.Stream stream = assembly.GetManifestResourceStream("Pokno.Report.Reports.SoldStockAnalysis.rdlc");
                //_report.LocalReport.LoadReportDefinition(stream);

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

                string dsSoldStocks = "dsSoldStocks";
                if (_soldProducts != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsSoldStocks.Trim(), _soldProducts));
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
