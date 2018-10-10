using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class PersonLocation
    {
        
        public Person Person { get; set; }
        
        public Location Location { get; set; }
        
        public string Remarks { get; set; }
    }


}
