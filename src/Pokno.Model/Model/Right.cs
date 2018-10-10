using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model
{
    
    public class Right : SetupBase
    {
        private bool isInRole { get; set; }

        public bool IsInRole
        {
            get { return isInRole; }
            set
            {
                isInRole = value;
                base.OnPropertyChanged("IsInRole");
            }
        }
    }


}
