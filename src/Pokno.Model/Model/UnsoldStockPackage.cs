using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    public class UnsoldStockPackage
    {
        public Stock Stock { get; set; }
        public List<Shelf> Shelfs { get; set; }
    }


}
