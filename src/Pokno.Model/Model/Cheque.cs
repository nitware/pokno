using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model
{
    public class Cheque
    {
        public long Id { get; set; }
        public Bank Bank { get; set; }
        public string ChequeNumber { get; set; }
        public string AccountNumber { get; set; }

        //
        //public PaymentDetail PaymentDetail { get; set; }

    }
}
