using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Pokno.Model.Model;

namespace Pokno.Model
{
    
    public class StockPurchaseBatch : BaseModel
    {
        private DateTime _datePurchased;
        //private decimal? _supplierExpenses;

        public long Id { get; set; }
        public Person Buyer { get; set; }
        public Person Supplier { get; set; }
        public Payment Payment { get; set; }
        public decimal? SupplierExpenses { get; set; }
        public string InvoiceNumber { get; set; }
        public StockPurchaseBatchType StockPurchaseBatchType { get; set; }
        public List<StockPurchased> StockPurchases { get; set; }
                
        public DateTime DatePurchased 
        {
            get { return _datePurchased; } 
            set
            {
                _datePurchased = value;
                base.OnPropertyChanged("DatePurchased");
            }
        }

        




    }

}
