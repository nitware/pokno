using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Business.Helper;
using Microsoft.Reporting.WinForms;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Payment
{
    public class CompanyDebtorsListReport : BaseReport
    {
        private List<PaymentStatus> _payments;

        public CompanyDebtorsListReport(IBusinessFacade businessFacade)
             : base(businessFacade)
        {
            ReportName = "Company Debtors List";
            ReportEmbeddedResource = "Pokno.Common.Reports.Payment.CompanyDebtorsList.rdlc";
            _payments = new List<PaymentStatus>();
        }

        public override void GetData()
        {
            try
            {
                _payments = _businessFacade.GetDeptors(Trader.Customer);
                if (_payments == null || _payments.Count <= 0)
                {
                    throw new Exception("No company debtor list found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ReportViewer GenerateHelper()
        {
            try
            {
                string dsDebtors = "dsDebtors";

                if (_payments != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsDebtors.Trim(), _payments));
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
