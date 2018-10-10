using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class DeletedSoldStock
    {
        public long Id { get; set; }
        public long ShelfId { get; set; }
        public StockPrice Price { get; set; }
        public DeletedSoldStockBatch Batch { get; set; }
        public long Quantity { get; set; }

        public bool Returned { get; set; }
       


    }
}
