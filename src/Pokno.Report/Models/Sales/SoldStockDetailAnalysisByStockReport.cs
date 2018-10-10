using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Sales
{
    public class SoldStockDetailAnalysisByStockReport : BaseReport
    {
        private List<SoldStockView> _soldProducts;

        public SoldStockDetailAnalysisByStockReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Product Sales Detail By Stock";
            ReportEmbeddedResource = "Pokno.Common.Reports.Sales.SoldStockDetailAnalysisByStock.rdlc";
            _soldProducts = new List<SoldStockView>();
        }

        public Model.Stock Stock { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override void GetData()
        {
            try
            {
                _soldProducts = _businessFacade.GetSoldStockDetailsByDateRangeAndStock(FromDate, ToDate, Stock);
                if (_soldProducts == null || _soldProducts.Count <= 0)
                {
                    throw new Exception("No sold stock analysis found for dates between " + FromDate.ToShortDateString() + " and " + ToDate.ToShortDateString() + " for " + Stock.Name + "!");
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
                ReportParameter stockNameParam = new ReportParameter("StockName", Stock.Name);
                ReportParameter[] reportParams = new ReportParameter[] { startDateParam, endDateParam, stockNameParam };
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

                string dsSoldStockDetails = "dsSoldStockDetails";
                if (_soldProducts != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsSoldStockDetails.Trim(), _soldProducts));
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
                    else if (Stock == null || Stock.Id <= 0)
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
