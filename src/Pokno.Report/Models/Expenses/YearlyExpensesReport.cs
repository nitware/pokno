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
    public class YearlyExpensesReport : BaseReport
    {
        private List<StoreExpenses> _yearlyExpenses;

        public YearlyExpensesReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _yearlyExpenses = new List<StoreExpenses>();
        }

        public int Year { get; set; }
        //public string EmbeddedResource { get; set; }

        public override void GetData()
        {
            try
            {
                _yearlyExpenses = _businessFacade.GetYearlyExpenses(Year);
                if (_yearlyExpenses == null || _yearlyExpenses.Count <= 0)
                {
                    throw new Exception("No yearly expenses found for " + Year.ToString() + "!");
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
                ReportName = Year.ToString() + " Yearly Expenses";
                ReportEmbeddedResource = "Pokno.Common.Reports.Expenses.YearlyExpenses.rdlc";
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
                ReportParameter yearParam = new ReportParameter("Year", Year.ToString());
                ReportParameter[] reportParams = new ReportParameter[] { yearParam };
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
                string dsYearlyExpenses = "dsYearlyExpenses";

                SetParameter();

                if (_yearlyExpenses != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsYearlyExpenses.Trim(), _yearlyExpenses));
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
