using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokno.Model.Model
{
    public class StockOnShelfAtHand
    {
        public StockType StockType { get; set; }
        public List<UnsoldStockPackage> UnsoldStockPackages { get; set; }
    }



}
