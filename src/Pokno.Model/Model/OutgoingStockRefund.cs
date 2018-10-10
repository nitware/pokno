using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Pokno.Model
{
    
    public class OutgoingStockReturnRefund
    {
        
        public long IncomingStockId { get; set; }
        
        public Payment Payment { get; set; }
        
        public string Remarks { get; set; }
    }
}
