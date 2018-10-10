using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Pokno.Model.Model;

namespace Pokno.Model
{
    public class Shelf : BaseModel
    {
        private long _quantity;
        private long _reorderLevel;

        public long Id { get; set; }
        public StockPackage StockPackage { get; set; }
        public StockPackageRelationship StockPackageRelationship { get; set; }
        public StockType StockType { get; set; }
        public Location Location { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Person EnteredBy { get; set; }
        public int FakeQuantityOnShelf { get; set; }
        //public long TotalUnitQuantity { get; set; }
        public decimal TotalUnitQuantity { get; set; }
        public bool Sold { get; set; }

        public long ReorderLevel
        {
            get { return _reorderLevel; }
            set
            {
                _reorderLevel = value;
                base.OnPropertyChanged("ReorderLevel");
            }
        }

        public long Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                base.OnPropertyChanged("Quantity");
            }
        }
    }


}
