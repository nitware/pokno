using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    public class DeletedShelfStock
    {
        public long Id { get; set; }
        public StockPackage StockPackage { get; set; }
        public StockPackageRelationship StockPackageRelationship { get; set; }
        public long Quantity { get; set; }
        public Person DeletedBy { get; set; }
        public DateTime DateDeleted { get; set; }
    }


}
