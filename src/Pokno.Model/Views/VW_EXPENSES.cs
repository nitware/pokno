using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_EXPENSES
    {
        public string Initiator { get; set; }
        public string Collected_By { get; set; }
        public string Expenses_Category_Name { get; set; }
        public string Purpose { get; set; }
        public decimal Amount { get; set; }
        public DateTime Expenses_Date { get; set; }

        public string Expenses_Month { get; set; }
        public string Expenses_Year { get; set; }
    }




}
