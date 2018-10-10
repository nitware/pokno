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
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Models.Miscellaneous
{
    public class YearlyStockSummaryByStockReport : BaseReport
    {
        private List<StockReviewDetail> _stockSummary;

        public YearlyStockSummaryByStockReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Yearly Stock Summary";
            ReportEmbeddedResource = "Pokno.Common.Reports.Miscellaneous.YearlyStockSummaryByStock.rdlc";
            _stockSummary = new List<StockReviewDetail>();
        }

        public int Year { get; set; }
        public Model.Stock Stock { get; set; }

        public override void GetData()
        {
            try
            {
                _stockSummary = _businessFacade.GetYearlyStockSummaryBy(Year, Stock);
                if (_stockSummary == null || _stockSummary.Count <= 0)
                {
                    throw new Exception("No yearly stock summary found for " + Stock.Name + "!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void SetProperties()
        {
            try
            {
                ReportName = Year.ToString() + ", Yearly Stock Summary for " + Stock.Name;
                base.SetProperties();
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
                bool showPackageRelationship = false;
                if (Utility.Setting != null && Utility.Setting.Id > 0)
                {
                    showPackageRelationship = Utility.Setting.ShowPackageRelationshipInStockSummaryReviewReport;
                }

                ReportParameter yearParam = new ReportParameter("Year", Year.ToString());
                ReportParameter stockParam = new ReportParameter("Stock", Stock.Name);
                ReportParameter showPackageRelationshipParam = new ReportParameter("ShowPackageRelationship", showPackageRelationship.ToString());

                ReportParameter[] reportParams = new ReportParameter[] { yearParam, stockParam, showPackageRelationshipParam };
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
                string dsYearlyStockSummary = "dsYearlyStockSummary";

                SetParameter();

                if (_stockSummary != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsYearlyStockSummary.Trim(), _stockSummary));
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
