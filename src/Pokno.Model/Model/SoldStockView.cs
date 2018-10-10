using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class SoldStockView
    {
        public long BatchId { get; set; }
        public long Quantity { get; set; }
        public string PackageName { get; set; }
        public long StockId { get; set; }
        public string StockName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string SellerName { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ActualSellingPrice { get; set; }
        public decimal Profit { get; set; }
        public decimal AmountPaid { get; set; }
        public string InvoiceNumber { get; set; }
    }



}
