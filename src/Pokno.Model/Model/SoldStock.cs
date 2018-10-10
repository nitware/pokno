using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    public class SoldStock : BaseModel
    {
        private bool _returned;

        public long Id { get; set; }
        public Shelf ShelfStock { get; set; }
        public StockPrice Price { get; set; }
        public SoldStockBatch Batch { get; set; }
        public long Quantity { get; set; }
        public decimal Discount { get; set; }

        public bool Returned
        {
            get { return _returned; }
            set
            {
                _returned = value;
                base.OnPropertyChanged("Returned");
            }
        }

        public List<Shelf> ShelfStocks { get; set; }

    }


}
