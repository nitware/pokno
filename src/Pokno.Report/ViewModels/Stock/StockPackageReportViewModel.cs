using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using Pokno.Report.Models;
using Prism.Events;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;

namespace Pokno.Report.ViewModels.Stock
{
    public class StockPackageReportViewModel : BaseReportViewModel
    {
        public StockPackageReportViewModel(IBaseReportFactory reportFactory) : base(reportFactory)
        {
            OnInitialise(ReportType.StockPackage);
        }


      


    }


}
