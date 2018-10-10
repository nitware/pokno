using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Models;
using Pokno.Model.Model;
using Pokno.Service;
using Pokno.Model;
using Microsoft.Reporting.WinForms;

namespace Pokno.Report.Models.Expenses
{
    public class MonthlyExpensesReport : BaseReport
    {
        private List<StoreExpenses> _monthlyExpenses;

        public MonthlyExpensesReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _monthlyExpenses = new List<StoreExpenses>();
        }

        public int Year { get; set; }
        public Value Month { get; set; }
        public string EmbeddedResource { get; set; }

        public override void GetData()
        {
            try
            {
                _monthlyExpenses = _businessFacade.GetMonthlyExpenses(Year, Month.Id);
                if (_monthlyExpenses == null || _monthlyExpenses.Count <= 0)
                {
                    throw new Exception("No monthly expenses found for " + Month.Name + ", " + Year.ToString() + "!");
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
                ReportEmbeddedResource = EmbeddedResource;
                ReportName = Month.Name + " " + Year.ToString() + ", Monthly Expenses";
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
                ReportParameter monthParam = new ReportParameter("Month", Month.Name);
                ReportParameter[] reportParams = new ReportParameter[] { yearParam, monthParam };
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
                string dsMonthlyExpenses = "dsMonthlyExpenses";

                SetParameter();

                if (_monthlyExpenses != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsMonthlyExpenses.Trim(), _monthlyExpenses));
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
