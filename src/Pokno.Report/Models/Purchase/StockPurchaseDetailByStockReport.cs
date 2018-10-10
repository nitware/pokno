using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Model;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Purchase
{
    public class StockPurchaseDetailByStockReport : BaseReport
    {
        private List<StoreStockPurchased> _stocksPurchased;

        public StockPurchaseDetailByStockReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Product Purchase Detail By Stock";
            ReportEmbeddedResource = "Pokno.Common.Reports.Purchase.StockPurchasedDetailByStock.rdlc";
            _stocksPurchased = new List<StoreStockPurchased>();
        }

        public Model.Stock Stock { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override void GetData()
        {
            try
            {
                _stocksPurchased = _businessFacade.GetStoreStockPurchasedByStockAndDateRange(FromDate, ToDate, Stock);
                if (_stocksPurchased == null || _stocksPurchased.Count <= 0)
                {
                    throw new Exception("No Product Purchase Detail found for dates between " + FromDate.ToShortDateString() + " and " + ToDate.ToShortDateString() + " for "  + Stock.Name + "!");
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

                string dsStockPurchases = "dsStockPurchases";
                if (_stocksPurchased != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsStockPurchases.Trim(), _stocksPurchased));
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
