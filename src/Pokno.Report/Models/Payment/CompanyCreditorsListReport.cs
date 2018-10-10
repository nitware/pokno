using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;
using Pokno.Business.Helper;
using Pokno.Common.Models;

namespace Pokno.Report.Models.Payment
{
    public class CompanyCreditorsListReport : BaseReport
    {
        private List<PaymentStatus> _payments;

        public CompanyCreditorsListReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            ReportName = "Company Creditors List";
            ReportEmbeddedResource = "Pokno.Common.Reports.Payment.CompanyCreditorsList.rdlc";
            _payments = new List<PaymentStatus>();
        }

        public override void GetData()
        {
            try
            {
                _payments = _businessFacade.GetCreditors(Trader.Customer);
                if (_payments == null || _payments.Count <= 0)
                {
                    throw new Exception("No Company Creditor found!");
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
                string dsCreditors = "dsCreditors";

                if (_payments != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsCreditors.Trim(), _payments));
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
