using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using Pokno.Model.Model;

namespace Pokno.Model
{
    public class StockPurchased : BaseStockPurchased
    {
        public Stock Stock { get; set; }
    }



}
