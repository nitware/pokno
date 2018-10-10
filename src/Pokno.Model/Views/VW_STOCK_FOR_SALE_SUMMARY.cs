using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_FOR_SALE_SUMMARY
    {
        public int Stock_Type_Id { get; set; }
        public long Stock_Id { get; set; }
        public decimal Cost_Price { get; set; }
        public decimal Selling_Price { get; set; }
        public long Stock_Price_Id { get; set; }
        public int Package_Id { get; set; }
        public int Re_Order_Level { get; set; }
        public long Stock_Package_Id { get; set; }
        public int? Unsold_Shelf_Quantity { get; set; }
        public string Package_Name { get; set; }
        public string Stock_Name { get; set; }
        public string Stock_Type_Name { get; set; }
        public long Stock_Package_Relationship_Id { get; set; }

    }
}
