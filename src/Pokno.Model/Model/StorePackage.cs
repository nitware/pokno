using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    public class StorePackage
    {
        public string StockName { get; set; }
        public string PackageName { get; set; }
        public string SubPackageName { get; set; }
        public decimal QuantityInPackage { get; set; }
    }




}
