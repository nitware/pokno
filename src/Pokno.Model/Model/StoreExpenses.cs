using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class StoreExpenses
    {
        public string Initiator { get; set; }
        public string CollectedBy { get; set; }
        public string ExpensesCategory { get; set; }
        public string Purpose { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpensesDate { get; set; }
        public string ExpensesMonthString { get; set; }
        public string ExpensesYearString { get; set; }
        public int ExpensesMonth { get; set; }
        public int ExpensesYear { get; set; }
        
    }



}
