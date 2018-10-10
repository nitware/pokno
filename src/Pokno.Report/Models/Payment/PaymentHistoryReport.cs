using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Common.Models;
using Pokno.Service;
using Pokno.Model.Model;
using Microsoft.Reporting.WinForms;

namespace Pokno.Report.Models.Payment
{
    public class PaymentHistoryReport : BaseReport
    {
        private List<PaymentHistory> _payments;

        public PaymentHistoryReport(IBusinessFacade businessFacade)
            : base(businessFacade)
        {
            _payments = new List<PaymentHistory>();
        }

        public PersonType PersonType { get; set; }
        public string EmbeddedResource { get; set; }

        public override void GetData()
        {
            try
            {
                if (PersonType == null || PersonType.Id <= 0)
                {
                    throw new Exception("Please select person type!");
                }

                switch(PersonType.Id)
                {
                    case 1:
                        {
                            _payments = _businessFacade.GetPaymentHistory();
                            break;
                        }
                    case 2:
                    case 3:
                        {
                            _payments = _businessFacade.GetPaymentHistoryByPersonType(PersonType);
                            break;
                        }
                }
                                
                if (_payments == null || _payments.Count <= 0)
                {
                    throw new Exception("No payment history found!");
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
                ReportEmbeddedResource = "Pokno.Common.Reports.Payment.PaymentHistory.rdlc";
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
                ReportParameter personTypeParam = new ReportParameter("PersonType", PersonType.Name);
                ReportParameter[] reportParams = new ReportParameter[] { personTypeParam };
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
