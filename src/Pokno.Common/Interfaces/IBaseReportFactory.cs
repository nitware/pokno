using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Common.Models;
using Pokno.Infrastructure.Models;

namespace Pokno.Common.Interfaces
{
    public interface IBaseReportFactory
    {
        BaseReport Create(ReportType type);
    }
}
