using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    public class ExpensesDetail
    {
        public long Id { get; set; }
        public Expenses Expenses { get; set; }
        public string CollectedBy { get; set; }
        public PaymentType PaymentMode { get; set; }
        public ExpensesCategory Category { get; set; }
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
       
    }


}
