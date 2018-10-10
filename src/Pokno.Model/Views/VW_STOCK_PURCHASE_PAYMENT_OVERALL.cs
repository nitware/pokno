using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_PURCHASE_PAYMENT_OVERALL : VW_STOCK_PURCHASE_PAYMENT
    {
        public decimal? Total_Amount_Payable { get; set; }
        public decimal? Total_Amount_Paid { get; set; }
        public decimal? Total_Balance { get; set; }

    }


}
