using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;

namespace Pokno.Report.ViewModels.Payment
{
    public class CompanyDebtorsListReportViewModel : BaseReportViewModel
    {
        public CompanyDebtorsListReportViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            OnInitialise(ReportType.CompanyDebtorsList);
        }
    }




}
