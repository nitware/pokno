using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model
{
    public class Role : SetupBase
    {
        private bool hasUser;
        private string _name;
                
        public PersonRight PersonRight { get; set; }
        public List<Right> Rights { get; set; }

        public override string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                base.OnPropertyChanged("Name");
            }
        }
        
        public bool HasUser
        {
            get { return hasUser; }
            set
            {
                hasUser = value;
                base.OnPropertyChanged("HasUser");
            }
        }


    }



}
