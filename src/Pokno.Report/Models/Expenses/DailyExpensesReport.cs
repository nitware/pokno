using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Models;
using Pokno.Model.Model;
using Pokno.Service;
using Microsoft.Reporting.WinForms;

namespace Pokno.Report.Models.Expenses
{
    public class DailyExpensesReport : BaseReport
    {
        private List<StoreExpenses> _dailyExpenses;

        public DailyExpensesReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Daily Expenses Report";
            ReportEmbeddedResource = "Pokno.Common.Reports.Expenses.DailyExpenses.rdlc";

            _dailyExpenses = new List<StoreExpenses>();
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override void GetData()
        {
            try
            {
                _dailyExpenses = _businessFacade.GetDailyExpensesByDate(FromDate);
                if (_dailyExpenses == null || _dailyExpenses.Count <= 0)
                {
                    throw new Exception("No daily expenses found for date between " + FromDate.Date.ToShortDateString() + " and " + ToDate.Date.ToShortDateString() + "!");
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
                ReportParameter dateParam = new ReportParameter("Date", FromDate.ToString());
                ReportParameter[] reportParams = new ReportParameter[] { dateParam };
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

                string dsDailyExpenses = "dsDailyExpenses";
                if (_dailyExpenses == null || _dailyExpenses.Count <= 0)
                {
                    _dailyExpenses = new List<StoreExpenses>();
                }

                _report.ProcessingMode = ProcessingMode.Local;
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
