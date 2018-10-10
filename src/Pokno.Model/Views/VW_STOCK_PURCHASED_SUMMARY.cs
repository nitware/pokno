using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_PURCHASED_SUMMARY
    {
        public string Supplier { get; set; }
        public string Buyer { get; set; }
        public long Payment_Id { get; set; }
        public DateTime Date_Puchased { get; set; }
        public decimal? Supplier_Expenses { get; set; }
        public long Stock_Purchase_Batch_Id { get; set; }
        public long? Quantity { get; set; }
        public decimal? Unit_Cost { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Amount_Payable { get; set; }
        public decimal? Amount_Paid { get; set; }
    }


}
