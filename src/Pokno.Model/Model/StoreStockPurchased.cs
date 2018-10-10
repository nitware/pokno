using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class StoreStockPurchased
    {
        public string Supplier { get; set; }
        public string Buyer { get; set; }
        public DateTime DatePurchased { get; set; }
        public decimal? SupplierExpenses { get; set; }
        public string StockName { get; set; }
        public string PackageName { get; set; }
        public long Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Cost { get; set; }

        public decimal? AmountPayable { get; set; }
        public decimal? AmountPaid { get; set; }

        public long PurchaseBatchId { get; set; }
       
        
        
        
        
        

    }


}
