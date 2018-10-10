using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class StockQuantity
    {
        public StockQuantity()
        {
            Stock = new Stock();
        }

        
        public long Id { get; set; }
        
        public Stock Stock { get; set; }
        
        public string Name { get; set; }
        
        public long UnitCount { get; set; }
        
        public int ReOrderLevel { get; set; }
        
        public string Description { get; set; }
    }
}
