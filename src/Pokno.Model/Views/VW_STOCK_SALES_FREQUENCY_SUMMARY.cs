using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_SALES_FREQUENCY_SUMMARY : VW_PROFITABLE_STOCK
    {
        public int? Frequency { get; set; }
        public string Year_Sold { get; set; }
        public string Month_Sold { get; set; }
    }



}
