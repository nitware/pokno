using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class StocksAndStockTypesUnderCategory
    {

        
        public List<Stock> Stocks { get; set; }
        
        public List<StockType> StockTypes { get; set; }
    }
}
