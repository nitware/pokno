using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_EXPIRY_DATE_ALERT
    {
        public int Stock_Package_Id { get; set; }
        public int? Stock_Id { get; set; }
        public int? Package_Id { get; set; }
        public string Stock_Name { get; set; }
        public string Package_Name { get; set; }
        public int? Total_Unit_Quantity { get; set; }
        public int? Quantity_On_Shelf { get; set; }
        //public int? Quantity_Sold { get; set; }
        public int? Expiry_Date_No_Of_Days_Alert { get; set; }
        public int? Remainig_Alert_Days { get; set; }
       

    }
}
