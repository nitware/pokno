using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class StockReturnInformation
    {
        
        public SoldStockBatch OutgoingStockBatch { get; set; }
        
        public SoldStockReturn OutgoingStockReturn { get; set; }
    }
}
