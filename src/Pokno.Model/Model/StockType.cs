using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class StockType
    {
        public StockType()
        {
            Category = new StockCategory();
        }

        
        public int Id { get; set; }
        
        public StockCategory Category { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        //
        //public List<Stock> Stocks { get; set; }

    }
}
