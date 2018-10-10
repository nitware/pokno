using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Miscellaneous
{
    public class DailyTransactionReport : BaseReport
    {
        private List<SoldStockView> _soldStocks;
        private List<StoreStockPurchased> _stocksPurchased;
        private List<StoreExpenses> _dailyExpenses;
        private List<PaymentStatus> _dailyPayments;

        public DailyTransactionReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Daily Transaction Report";
            ReportEmbeddedResource = "Pokno.Common.Reports.Miscellaneous.DailyTransaction.rdlc";

            _soldStocks = new List<SoldStockView>();
            _stocksPurchased = new List<StoreStockPurchased>();
            _dailyPayments = new List<PaymentStatus>();
            _dailyExpenses = new List<StoreExpenses>();
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        private decimal SupplierExpenses { get; set; }

        public override void GetData()
        {
            try
            {
                _soldStocks = _businessFacade.GetSoldStockDetailsByDateRange(FromDate, ToDate);
                _stocksPurchased = _businessFacade.GetStoreStockPurchasedByDateRange(FromDate, ToDate);
                _dailyPayments = _businessFacade.GetDailyPaymentTransactions(FromDate);
                _dailyExpenses = _businessFacade.GetDailyExpensesByDate(FromDate);

                SupplierExpenses = _businessFacade.GetSupplierExpensesBy(FromDate, ToDate);
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
                ReportParameter dateParam = new ReportParameter("Date", FromDate.ToString());
                ReportParameter supplierExpensesParam = new ReportParameter("SupplierExpenses", SupplierExpenses.ToString());
                ReportParameter[] reportParams = new ReportParameter[] { dateParam, supplierExpensesParam };
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

                string dsDailySalesTransaction = "dsDailySalesTransaction";
                string dsDailyPurchaseTransaction = "dsDailyPurchaseTransaction";
                string dsDailyPaymentTransaction = "dsDailyPaymentTransaction";
                string dsDailyExpenses = "dsDailyExpenses";

                if (_soldStocks == null || _soldStocks.Count <= 0)
                {
                    _soldStocks = new List<SoldStockView>();
                }
                if (_stocksPurchased == null || _stocksPurchased.Count <= 0)
                {
                    _stocksPurchased = new List<StoreStockPurchased>();
                }
                if (_dailyPayments == null || _dailyPayments.Count <= 0)
                {
                    _dailyPayments = new List<PaymentStatus>();
                }
                if (_dailyExpenses == null || _dailyExpenses.Count <= 0)
                {
                    _dailyExpenses = new List<StoreExpenses>();
                }

                _report.ProcessingMode = ProcessingMode.Local;
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsDailySalesTransaction.Trim(), _soldStocks));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsDailyPurchaseTransaction.Trim(), _stocksPurchased));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsDailyPaymentTransaction.Trim(), _dailyPayments));
                _report.LocalReport.DataSources.Add(new ReportDataSource(dsDailyExpenses.Trim(), _dailyExpenses));
                _report.LocalReport.Refresh();
                _report.RefreshReport();
                
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
