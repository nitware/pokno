using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Common.Interfaces;
using Prism.Events;

namespace Pokno.Report.ViewModels.Stock
{
    public class StockListViewModel : BaseReportViewModel
    {
        public StockListViewModel(IBaseReportFactory reportFactory) : base(reportFactory)
        {
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanViewStockListReport;
            OnInitialise(ReportType.StockList);
        }



    }


}
