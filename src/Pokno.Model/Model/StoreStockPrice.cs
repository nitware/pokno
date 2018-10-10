using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class StoreStockPrice
    {
        public string StockName { get; set; }
        public string PackageName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Profit { get { return SellingPrice - CostPrice; } }
        public DateTime DateEntered { get; set; }
    }



}
