using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class Fault
    {
        public Fault() {}

        
        public Fault(string message)
        {
            Message = message;
        }

        
        public int Number { get; set; }
        
        public string Title { get; set; }
        
        public string Message { get; set; }
        
        public string Description { get; set; }
        
        public string Reason { get; set; }
        
        public string Advice { get; set; }
        
        public string Action { get; set; }
    }



}
