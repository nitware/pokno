using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_REVIEW
    {
        public long? Stock_Id { get; set; }
        public string Stock_Name { get; set; }
        public decimal? Cost { get; set; }
        public string Month_Purchased { get; set; }
        public string Year_Purchased { get; set; }
        public string Month_Year_Puchased { get; set; }
        public decimal? Cost_Price { get; set; }
        public decimal? Selling_Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Profit { get; set; }
        public string Month_Sold { get; set; }
        public string Year_Sold { get; set; }
        public string Month_Year_Sold { get; set; }
        public string Transaction_Month { get; set; }
        public string Transaction_Year { get; set; }
        public decimal? Monthly_Total_Expenses { get; set; }
        public decimal? Monthly_Transaction_Discount { get; set; }
        public long Stock_Package_Relationship_Id { get; set; }
    }





}
