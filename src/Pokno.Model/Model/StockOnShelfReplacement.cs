using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class StockOnShelfReplacement
    {
        
        public long Id { get; set;}
        
        public StockPackage StockPackage { get; set;}
        
        public int QuntityReplaced { get; set;}
        
        public DateTime DateReplaced { get; set;}
    }
}
