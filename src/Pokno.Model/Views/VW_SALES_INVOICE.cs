using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_SALES_INVOICE
    {
        public long Sold_Stock_Batch_Id { get; set; }
        public string Package_Name { get; set; }
        public string Stock_Name { get; set; }
        public long Quantity { get; set; }
        public decimal Selling_Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total_Discount { get; set; }
        public decimal Amount_Paid { get; set; }
        public long Seller_Id { get; set; }
        public long Customer_Id { get; set; }
        public DateTime Date_Sold { get; set; }
        public long Payment_Id { get; set; }
        public string Invoice_Number { get; set; }

        public string Seller { get; set; }
        public string Customer { get; set; }
    }



}
