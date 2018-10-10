using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class Location
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
    }
}
