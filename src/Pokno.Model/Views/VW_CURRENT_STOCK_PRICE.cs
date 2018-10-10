using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_CURRENT_STOCK_PRICE
    {
        public long Stock_Price_Id { get; set; }
        public long Stock_Package_Id { get; set; }
        public decimal Cost_Price { get; set; }
        public decimal Selling_Price { get; set; }
        public DateTime Date_Entered { get; set; }
        public long Stock_Id { get; set; }
        public int Package_Id { get; set; }
        public string Stock_Name { get; set; }
        public string Package_Name { get; set; }
    }



}
