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

namespace Pokno.Report.Models.Payment
{
    public class PaymentHistoryByPersonReport : BaseReport
    {
        private List<PaymentHistory> _payments;

        public PaymentHistoryByPersonReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _payments = new List<PaymentHistory>();
        }

        public Person Person { get; set; }

        public override void GetData()
        {
            try
            {
                if (Person == null || Person.Id <= 0)
                {
                    throw new Exception("Please select a person!");
                }

                _payments = _businessFacade.GetPaymentHistoryByPerson(Person);
                if (_payments == null || _payments.Count <= 0)
                {
                    throw new Exception("No payment history found for! '" + Person.Name + "'");
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
                ReportName = "Payment History";
                ReportEmbeddedResource = "Pokno.Common.Reports.Payment.PaymentHistoryByPerson.rdlc";
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
                ReportParameter personParam = new ReportParameter("Name", Person.Name);
                ReportParameter[] reportParams = new ReportParameter[] { personParam };
                _report.LocalReport.SetParameters(reportParams);
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
                SetParameter();

                string dsPaymentHistory = "dsPaymentHistory";

                if (_payments != null)
                {
                    _report.ProcessingMode = ProcessingMode.Local;
                    _report.LocalReport.DataSources.Add(new ReportDataSource(dsPaymentHistory.Trim(), _payments));
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
