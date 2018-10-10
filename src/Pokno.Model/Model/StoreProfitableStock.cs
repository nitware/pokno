using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class StoreProfitableStock
    {
        public long StockId { get; set; }
        public string Stock { get; set; }
        public string StockName { get; set; }
        public long PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? Profit { get; set; }
    }


}
