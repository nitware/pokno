using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class StockPurchasedAtHand
    {
        
        public Stock Stock { get; set; }
        
        public StockPurchasedPool StockPurchasedPool { get; set; }
        
        public List<StockPurchased> StockPurchases { get; set; }
    }



}
