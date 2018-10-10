using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class StoreCustomerStatistics
    {
        public string Customer { get; set; }
        public int? Frequency { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? Profit { get; set; }
        public string TransactionMonth { get; set; }
        public string TransactionYear { get; set; }
    }



}
