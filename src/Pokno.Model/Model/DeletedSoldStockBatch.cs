using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class DeletedSoldStockBatch
    {
        public long Id { get; set; }
        public Person Seller { get; set; }
        public Payment Payment { get; set; }
        public DateTime DateSold { get; set; }
        public decimal? TotalDiscount { get; set; }
        public DateTime DateDeleted { get; set; }
        public string DeletedReason { get; set; }
        public Person DeletedBy { get; set; }
        public Person Customer { get; set; }

        public List<SoldStock> SoldStocks { get; set; }
        public List<DeletedSoldStock> DeletedSoldStocks { get; set; }

    }




}
