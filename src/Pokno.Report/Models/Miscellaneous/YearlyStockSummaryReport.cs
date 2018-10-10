using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;
using Pokno.Infrastructure.Models;

namespace Pokno.Report.Models.Miscellaneous
{
    public class YearlyStockSummaryReport : BaseReport
    {
        private List<StockReviewDetail> _stocksBreakDown;

        public YearlyStockSummaryReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Yearly Stock Summary";
            ReportEmbeddedResource = "Pokno.Common.Reports.Miscellaneous.YearlyStockSummary.rdlc";
            _stocksBreakDown = new List<StockReviewDetail>();
        }

        public int Year { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalStockBalanceValue { get; set; }

        public override void GetData()
        {
            try
            {
                _stocksBreakDown = _businessFacade.GetYearlyStockReview(Year);
                if (_stocksBreakDown == null || _stocksBreakDown.Count <= 0)
                {
                    throw new Exception("No yearly stock summary found for " + Year.ToString() + "!");
                }

                List<StockReviewDetail> stocksBreakDown = _stocksBreakDown.OrderBy(x => x.StockId).ThenBy(x => x.TransactionMonth).ThenBy(x => x.TransactionYear).ToList();

                List<StockReviewDetail> stocks = _stocksBreakDown.GroupBy(x => new { x.StockId, x.StockPackageRelationshipId }).Select(s => new StockReviewDetail
                {
                    StockId = s.First().StockId,
                    StockPackageRelationshipId = s.First().StockPackageRelationshipId
                }).OrderBy(x => x.StockId).ToList();


                decimal sbv = 0;
                if (stocks != null && stocks.Count > 0)
                {
                    foreach(StockReviewDetail stock in stocks)
                    {
                       sbv += stocksBreakDown.Last(s => s.StockId == stock.StockId).StockBalanceValue;
                    }

                    TotalStockBalanceValue = sbv;
                }


                //List<StockReviewDetail> result = _stocksBreakDown.GroupBy(x => new { x.StockId, x.TransactionMonth, x.TransactionYear }).Select(s => new StockReviewDetail
                //{
                //    StockId = s.Last().StockId,
                //    StockBalanceValue = s.Last().StockBalanceValue,
                //}).OrderBy(x => x.StockId).ThenBy(x => x.TransactionMonth).ThenBy(x => x.TransactionYear).ToList();

                //decimal sbv = result.Sum(s => s.StockBalanceValue);

                TotalDiscount = _businessFacade.GetYearlySalesDiscount(Year);
                TotalExpenses = _businessFacade.GetTotalYearlyExpenses(Year);
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
                ReportName = Year.ToString() + ", " + ReportName;
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
                ReportParameter totalExpensesParam = new ReportParameter("TotalExpenses", TotalExpenses.ToString());
                ReportParameter totalDiscountParam = new ReportParameter("TotalDiscount", TotalDiscount.ToString());
                ReportParameter totalStockBalanceValueParam = new ReportParameter("TotalStockBalanceValue", TotalStockBalanceValue.ToString());
                ReportParameter showPackageRelationshipParam = new ReportParameter("ShowPackageRelationship", showPackageRelationship.ToString());

                ReportParameter[] reportParams = new ReportParameter[] { yearParam, totalExpensesParam, totalDiscountParam, totalStockBalanceValueParam, showPackageRelationshipParam };
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

                if (_stocksBreakDown != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsYearlyStockSummary.Trim(), _stocksBreakDown));
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
