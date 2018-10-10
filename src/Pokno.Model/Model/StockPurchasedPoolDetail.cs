using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class StockPurchasedPoolDetail
    {
        
        public StockPurchasedPool StockPurchasedPool { get; set; }
        
        public StockPurchased StockPurchased { get; set; }
        
        public string Remarks { get; set; }

    }


}
