using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    public class SoldStockBatch : BaseModel
    {
        private decimal _totalDiscount;

        public long Id { get; set; }
        public Person Seller { get; set; }
        public Payment Payment { get; set; }
        public DateTime DateSold { get; set; }
        public List<SoldStock> SoldStocks { get; set; }
        public Person Customer { get; set; }

        public decimal TotalDiscount
        {
            get { return _totalDiscount; }
            set
            {
                _totalDiscount = value;
                base.OnPropertyChanged("TotalDiscount");
            }
        }
    }




}
