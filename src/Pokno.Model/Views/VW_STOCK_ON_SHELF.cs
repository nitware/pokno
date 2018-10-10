using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_ON_SHELF
    {
        public long Stock_Package_Id { get; set; }
        public int? Quantity_On_Shelf { get; set; }
        public long? Total_Unit_Quantity { get; set; }
        public int? Quantity_Sold { get; set; }
        public int? Quantity_Deleted { get; set; }
        public long? Unit_Quantity_Deleted { get; set; }
        public int? Unsold_Shelf_Quantity { get; set; }
        public string Stock_Name { get; set; }
        public string Package_Name { get; set; }
       

    }
}
