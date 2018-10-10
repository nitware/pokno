using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Purchase
{
    public class StockPurchaseSummaryReport : BaseReport
    {
        private List<StoreStockPurchased> _stocksPurchased;

        public StockPurchaseSummaryReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Product Purchase Summary";
            ReportEmbeddedResource = "Pokno.Common.Reports.Purchase.StockPurchasedSummary.rdlc";
            _stocksPurchased = new List<StoreStockPurchased>();
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override void GetData()
        {
            try
            {
                _stocksPurchased = _businessFacade.GetStoreStockPurchasedSummaryByDateRange(FromDate, ToDate);
                if (_stocksPurchased == null || _stocksPurchased.Count <= 0)
                {
                    throw new Exception("No Product Purchase Summary found for dates between " + FromDate.ToShortDateString() + " and " + ToDate.ToShortDateString() + "!");
                }

                if (_stocksPurchased != null && _stocksPurchased.Count > 0)
                {
                    _stocksPurchased = _stocksPurchased.OrderBy(s => s.DatePurchased).ToList();
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

                string dsStockPurchasedSummary = "StockPurchasedSummary";
                if (_stocksPurchased != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStockPurchasedSummary.Trim(), _stocksPurchased));
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
