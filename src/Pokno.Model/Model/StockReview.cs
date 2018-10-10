using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class StockReview
    {
        
        public long Id { get; set; }
        
        public Person ReviewedBy { get; set; }
        
        public int ReviewYear { get; set; }
        
        public DateTime ReviewDate { get; set; }
    }


}
