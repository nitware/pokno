using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class SalesInvoice
    {
        public long SoldStockBatchId { get; set; }
        public string StockName { get; set; }
        public string PackageName { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TotalSellingPrice { get; set; }
               
        public string Customer { get; set; }
        public string Address { get; set; }
        public decimal AmountPaid { get; set; }
        public string AmountPaidInWord { get; set; }
                
        public string CashierName { get; set; }
        public string CashierCompany { get; set; }
        public string CashierCompanyAddress { get; set; }
        public string CashierCompanyWebsite { get; set; }
        public string CashierCompanyEmail { get; set; }
        public string CashierCompanyPhone { get; set; }
        public string CashierCompanyDisclaimer { get; set; }
                
        public DateTime DateSold { get; set; }
        public string InvoiceNumber { get; set; }
    }


}
