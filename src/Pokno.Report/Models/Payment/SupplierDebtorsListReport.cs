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
    public class SupplierDebtorsListReport : BaseReport
    {
        private List<PaymentStatus> _payments;

        public SupplierDebtorsListReport(IBusinessFacade businessFacade)
             : base(businessFacade)
        {
            ReportName = "Supplier Debtors List";
            ReportEmbeddedResource = "Pokno.Common.Reports.Payment.SupplierDebtorsList.rdlc";
            _payments = new List<PaymentStatus>();
        }

        public override void GetData()
        {
            try
            {
                _payments = _businessFacade.GetDeptors(Trader.User);
                if (_payments == null || _payments.Count <= 0)
                {
                    throw new Exception("No supplier debtor's list found!");
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
