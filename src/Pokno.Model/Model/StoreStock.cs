using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    public class StoreStock
    {
        public string StockType { get; set; }
        public string StockName { get; set; }
        public string StockDescription { get; set; }
        public string PackageName { get; set; }
        public decimal Quantity { get; set; }

        //public long Quantity { get; set; }
    }



}
