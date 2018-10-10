using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    public class StockPurchasedPool
    {
        public long Id { get; set; }
        public StockPurchaseBatch StockPurchaseBatch { get; set; }
        public StockPackageRelationship StockPackageRelationship { get; set; }
        public Stock Stock { get; set; }
        public StockPackage UnitItem { get; set; }
        public decimal Quantity { get; set; }
        //public long Quantity { get; set; }
        public DateTime Date { get; set; }
    }



}
