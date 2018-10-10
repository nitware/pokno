using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_CUSTOMER_STATISTICS
    {
        public string Customer { get; set; }
        public int? Frequency { get; set; }
        public decimal? Selling_Price { get; set; }
        public decimal? Profit { get; set; }
        public string Month_Sold { get; set; }
        public string Year_Sold { get; set; }
    }




}
