using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_SALES_FREQUENCY : VW_STOCK_SALES_FREQUENCY_SUMMARY
    {
        public DateTime Date_Sold { get; set; }
        public string Customer { get; set; }
    }



}
