using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Events;
using Prism.Events;
using Pokno.Infrastructure.Models;
using Pokno.Report.Models;
using Pokno.Common.Interfaces;

namespace Pokno.Report.ViewModels.Stock
{
    public class StockPriceHistoryReportViewModel : BaseReportViewModel
    {
        public StockPriceHistoryReportViewModel(IBaseReportFactory reportFactory) : base(reportFactory)
        {
            OnInitialise(ReportType.StockPriceHistory);
        }
     


    }


}
