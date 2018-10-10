using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_RETURNED_STOCK
    {
        public long Stock_Id { get; set; }
        public string Stock { get; set; }
        public string Stock_Name { get; set; }
        public long Package_Id { get; set; }
        public string Package_Name { get; set; }
        public string Stock_State { get; set; }
        public string Type { get; set; }
        public long Returned_Quantity { get; set; }
        public bool Refunded { get; set; }
        public decimal? Amount_Refunded { get; set; }
        public string Action { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Initiator { get; set; }
    }


}
