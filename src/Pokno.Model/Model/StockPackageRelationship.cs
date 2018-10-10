using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class StockPackageRelationship
    {
        public long Id { get; set; }
        public Stock Stock { get; set; }
        public DateTime DateSet { get; set; }
        public Person SetBy { get; set; }

        public List<PackageRelationship> Relationships { get; set; }
    }


}
