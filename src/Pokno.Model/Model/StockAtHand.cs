using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using Pokno.Model;

namespace Pokno
{
    
    public class StockAtHand
    {
        
        public Package Package { get; set; }
        
        public int Quantity { get; set; }
    }


}
