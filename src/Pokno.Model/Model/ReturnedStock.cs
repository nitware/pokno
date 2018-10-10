using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class ReturnedStock
    {
        public long Id { get; set; }
        public DateTime ReturnedDate { get; set; }
        public string ReturnReason { get; set; }
        public string Remarks { get; set; }
        public Person EnteredBy { get; set; }

        public List<ReturnedStockDetail> Details { get; set; }

    }


}
