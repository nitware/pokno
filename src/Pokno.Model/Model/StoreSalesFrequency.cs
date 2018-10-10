using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class StoreSalesFrequency : StoreProfitableStock
    {
        public int? Frequency { get; set; }
        public string YearSold { get; set; }
        public string MonthSold { get; set; }

    }



}
