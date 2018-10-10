using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class PersonCompany
    {
        
        public long Id { get; set; }
        
        public Person Person { get; set; }
        
        public Company Company { get; set; }
        
        public string Remarks { get; set; }
    }


}
