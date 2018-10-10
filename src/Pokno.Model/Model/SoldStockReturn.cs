using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class SoldStockReturn
    {
        
        public long StockOnShelfId { get; set; }
        public StockPackage StockPackage { get; set; }
        
        public int QuantityReturned { get; set; }
        
        public DateTime DateReturned { get; set; }
        
        public string ReturnReason { get; set; }
        
        public bool Replaced { get; set; }
        
        public StockState StockState { get; set; }
        
        public bool Refunded { get; set; }
        
        public StockReturnType StockReturnType { get; set; }
        
        public SoldStockReturnRefund ReturnRefund { get; set; }
        
        public StockOnShelfReplacement StockOnShelfReplacement { get; set; }
    }


}
