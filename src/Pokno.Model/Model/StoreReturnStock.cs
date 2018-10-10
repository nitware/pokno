using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class StoreReturnStock
    {
        public string Stock { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public long Stock_Id { get; set; }
        public string StockName { get; set; }
        public string PackageName { get; set; }
        public string StockState { get; set; }
        public decimal? AmountRefunded { get; set; }
        public string Action { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public string Initiator { get; set; }
    }




}
