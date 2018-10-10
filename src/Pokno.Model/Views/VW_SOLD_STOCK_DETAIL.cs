using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_SOLD_STOCK_DETAIL
    {
        public long Sold_Stock_Batch_Id { get; set; }
        public long Package_Id { get; set; }
        public string Package_Name { get; set; }
        public long Stock_Id { get; set; }
        public string Stock_Name { get; set; }
        public long? Quantity { get; set; }
        public decimal? Cost_Price { get; set; }
        public decimal? Selling_Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total_Discount { get; set; }
        public decimal? Profit { get; set; }
        public DateTime Date_Sold { get; set; }
        public string Seller_Name { get; set; }
        public string Customer_Name { get; set; }
        public string Invoice_Number { get; set; }
        
        //public decimal? Actual_Selling_Price { get; set; }
        
        
    }


}
