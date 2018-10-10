using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK_PURCHASED_POOL_SUMMARY
    {
        public long Stock_Id { get; set; }
        //public long? Quantity { get; set; }
        //public long? Quantity_On_Shelf { get; set; }
        //public long? Remaining_Pool_Quantity { get; set; }

        public decimal? Quantity { get; set; }
        public decimal? Quantity_On_Shelf { get; set; }
        public decimal? Remaining_Pool_Quantity { get; set; }
        public long Stock_Package_Relationship_Id { get; set; }

    }


}
