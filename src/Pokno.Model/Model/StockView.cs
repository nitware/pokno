using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokno.Model.Model
{
    public class StockView
    {
        public long StockId { get; set; }
        public long StockPackageId { get; set; }
        public long StockPackageRelationshipId { get; set; }
        public string StockName { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal? CostPrice { get; set; }
    }



}
