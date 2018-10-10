using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class LoginDetail
    {
        
        public Person Person { get; set; }
        
        public string Username { get; set; }
        //
        //public string Password { get; set; }
        
        public byte[] Password { get; set; }
        
        public bool IsActivated { get; set; }
        
        public bool IsLocked { get; set; }
        
        public bool IsFirstLogon { get; set; }

    }


}
