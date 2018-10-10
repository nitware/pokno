using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_PROFITABLE_STOCK
    {
        public long Stock_Id { get; set; }
        public string Stock { get; set; }
        public string Stock_Name { get; set; }
        public long Package_Id { get; set; }
        public string Package_Name { get; set; }
       
        public decimal? Cost_Price { get; set; }
        public decimal? Selling_Price { get; set; }
        public decimal? Profit { get; set; }
       
    }




}
