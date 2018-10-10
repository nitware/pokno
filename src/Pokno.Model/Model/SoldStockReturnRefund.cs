using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class SoldStockReturnRefund
    {
        
        public long StockOnShelfId { get; set; }
        
        public Payment Payment { get; set; }
        
        public string Remarks { get; set; }
    }


}
