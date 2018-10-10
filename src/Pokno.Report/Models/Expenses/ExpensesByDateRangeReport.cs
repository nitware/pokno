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
    public class ExpensesByDateRangeReport : BaseReport
    {
        private List<StoreExpenses> _expenses;

        public ExpensesByDateRangeReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _expenses = new List<StoreExpenses>();
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string EmbeddedResource { get; set; }

        public override void GetData()
        {
            try
            {
                _expenses = _businessFacade.GetExpensesByDateRange(FromDate, ToDate);
                if (_expenses == null || _expenses.Count <= 0)
                {
                    throw new Exception("No expenses found for the selected dates between " + FromDate.Date.ToString() + " and " + ToDate.Date.ToString() + "!");
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
                ReportName = "Expenses By Date Range";
                ReportEmbeddedResource = EmbeddedResource;
                //ReportEmbeddedResource = "Pokno.Common.Reports.Expenses.ExpensesByDateRange.rdlc";
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

                string dsExpenses = "dsExpenses";
                if (_expenses != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsExpenses.Trim(), _expenses));
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
                        errorMessage = "Please select Start Date!";
                    }
                    else if (ToDate == null || DateTime.MinValue == ToDate)
                    {
                        errorMessage = "Please select End Date!";
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
