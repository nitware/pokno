using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Models;
using Prism.Events;
using Pokno.Common.Interfaces;

namespace Pokno.Report.ViewModels.Stock
{
    public class RemainingStockOnShelfViewModel : BaseReportViewModel
    {
        public RemainingStockOnShelfViewModel(IBaseReportFactory reportFactory)
            : base(reportFactory)
        {
            OnInitialise(ReportType.RemainingStockOnShelf);
        }



    }




}
