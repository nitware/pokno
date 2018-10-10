using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class ReturnedStockDetail
    {
        public long Id { get; set; }
        public SoldStock SoldStock { get; set; }
        public ReturnedStock ReturnedStock { get; set; }
        public int ReturnQuantity { get; set; }
        public StockState StockState { get; set; }
        public StockReturnAction Action { get; set; }
        public bool Refunded { get; set; }
        public Payment Payment { get; set; }
        public bool ReturnedToShelf { get; set; }

    }


}
