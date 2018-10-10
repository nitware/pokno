using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_SOLD_STOCK
    {
        public long Stock_Id { get; set; }
        public string Stock_Name { get; set; }
        public string Package_Name { get; set; }
        public decimal? Cost_Price { get; set; }
        public decimal? Selling_Price { get; set; }
        public long Package_Id { get; set; }
        public long Sold_Stock_Batch_Id { get; set; }
        public long Seller_Id { get; set; }
        public long? Customer_Id { get; set; }
        public long Payment_Id { get; set; }
        public DateTime Date_Sold { get; set; }
        public decimal Total_Discount { get; set; }
        public decimal? Discount { get; set; }
        //public decimal Actual_Selling_Price { get; set; }
        public decimal? Profit { get; set; }
        public long Stock_Price_Id { get; set; }
        public decimal? Total_Amount_Paid { get; set; }
        public string Customer_Name { get; set; }
        public int Quantity { get; set; }
        public string Month_Sold { get; set; }
        public string Year_Sold { get; set; }
        public string Month_Year_Sold { get; set; }
        public bool Returned { get; set; }
        public long Stock_Package_Id { get; set; }
        public long Stock_Package_Relationship_Id { get; set; }

        //public long Stock_Id { get; set; }
        //public string Stock_Name { get; set; }
        //public string Package_Name { get; set; }
        //public Nullable<decimal> Cost_Price { get; set; }
        //public Nullable<decimal> Selling_Price { get; set; }
        //public int Package_Id { get; set; }
        //public long Sold_Stock_Batch_Id { get; set; }
        //public int Seller_Id { get; set; }
        //public Nullable<int> Customer_Id { get; set; }
        //public long Payment_Id { get; set; }
        //public System.DateTime Date_Sold { get; set; }
        //public decimal Total_Discount { get; set; }
        //public decimal Discount { get; set; }
        //public Nullable<decimal> Profit { get; set; }
        //public long Stock_Price_Id { get; set; }
        //public Nullable<decimal> Total_Amount_Paid { get; set; }
        //public string Customer_Name { get; set; }
        //public int Quantity { get; set; }
        //public Nullable<int> Month_Sold { get; set; }
        //public Nullable<int> Year_Sold { get; set; }
        //public string Month_Year_Sold { get; set; }
        //public bool Returned { get; set; }
        //public long Stock_Package_Id { get; set; }
        //public int Stock_Package_Relationship_Id { get; set; }
       

    }


}
