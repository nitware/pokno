using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Pokno.Infrastructure.Events;
using System.Windows.Forms.Integration;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Report.Models;
using Pokno.Common.Interfaces;

namespace Pokno.Report.ViewModels.Stock
{
    public class PackageRelationshipReportViewModel : BaseReportViewModel
    {
        public PackageRelationshipReportViewModel(IBaseReportFactory reportFactory) :base(reportFactory)
        {
            OnInitialise(ReportType.PackageQuantity);
        }

       





    }




}
