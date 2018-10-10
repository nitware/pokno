using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class StockCategory
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        //
        //public List<StockType> StockTypes { get; set; }
    }


}
