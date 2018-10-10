using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    public class StockPackage : BaseModel
    {
        private long _reOrderLevel;
        private long _expiryDaysAlert;
        private string _description;

        public long Id { get; set; }
        public Stock Stock { get; set; }
        public Package Package { get; set; }

        public long ReOrderLevel
        {
            get { return _reOrderLevel; }
            set
            {
                _reOrderLevel = value;
                base.OnPropertyChanged("ReOrderLevel");
            }
        }
        public long ExpiryDaysAlert 
        {
            get { return _expiryDaysAlert; }
            set
            {
                _expiryDaysAlert = value;
                base.OnPropertyChanged("ExpiryDaysAlert");
            }
        
        }
        public string Description 
        {
            get { return _description; }
            set
            {
                _description = value;
                base.OnPropertyChanged("Description");
            }
        }
        
        



        
    }
}
