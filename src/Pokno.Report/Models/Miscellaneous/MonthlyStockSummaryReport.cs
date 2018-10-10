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
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Models.Miscellaneous
{
    public class MonthlyStockSummaryReport : BaseReport
    {
        private List<StockReviewDetail> _stocksBreakDown;

        public MonthlyStockSummaryReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Monthly Stock Summary";
            ReportEmbeddedResource = "Pokno.Common.Reports.Miscellaneous.MonthlyStockSummary.rdlc";
            _stocksBreakDown = new List<StockReviewDetail>();
        }

        public int Year { get; set; }
        public Value Month { get; set; }
        private decimal TotalExpenses { get; set; }
        private decimal TotalDiscount { get; set; }

        public override void GetData()
        {
            try
            {
                _stocksBreakDown = _businessFacade.GetMonthlyStockSummaryBy(Year, Month.Id);
                if (_stocksBreakDown == null || _stocksBreakDown.Count <= 0)
                {
                    throw new Exception("No monthly stock summary found for " + Month.Name + ", " + Year.ToString() + "!");
                }

                TotalDiscount = _businessFacade.GetMonthlySalesDiscount(Year, Month.Id);
                TotalExpenses = _businessFacade.GetTotalMonthlyExpenses(Year, Month.Id);
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
                ReportName = Month.Name + " " + Year.ToString() + ", Monthly Stock Summary";
                base.SetProperties();
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
                bool showPackageRelationship = false;
                if (Utility.Setting != null && Utility.Setting.Id > 0)
                {
                    showPackageRelationship = Utility.Setting.ShowPackageRelationshipInStockSummaryReviewReport;
                }

                ReportParameter yearParam = new ReportParameter("Year", Year.ToString());
                ReportParameter monthParam = new ReportParameter("Month", Month.Name);
                ReportParameter totalExpensesParam = new ReportParameter("TotalExpenses", TotalExpenses.ToString());
                ReportParameter totalDiscountParam = new ReportParameter("TotalDiscount", TotalDiscount.ToString());
                ReportParameter showPackageRelationshipParam = new ReportParameter("ShowPackageRelationship", showPackageRelationship.ToString());

                ReportParameter[] reportParams = new ReportParameter[] { yearParam, monthParam, totalExpensesParam, totalDiscountParam, showPackageRelationshipParam };
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
                string dsMonthlyStockSummary = "dsMonthlyStockSummary";

                SetParameter();

                if (_stocksBreakDown != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsMonthlyStockSummary.Trim(), _stocksBreakDown));
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
