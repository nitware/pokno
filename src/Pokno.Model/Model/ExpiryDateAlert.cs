using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class ExpiryDateAlert
    {
        
        public string PackageName { get; set; }
        
        public string StockName { get; set; }
        
        public int? QuantityOnShelf { get; set; }
        
        public int QuantitySold { get; set; }
        
        public int QuantityRemaining { get; set; }
        
        public int? ExpiryDaysAlert { get; set; }
        
        public DateTime DateEntered { get; set; }
        
        public DateTime? ExpiryDate { get; set; }
        
        public DateTime? DateSold { get; set; }
        
        public DateTime? ExpiryAlertDate { get; set; }
        
        public int? RemainingAlertDays { get; set; }
        
       
    }


}
