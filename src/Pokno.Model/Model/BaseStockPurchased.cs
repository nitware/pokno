using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public abstract class BaseStockPurchased : BaseModel
    {
        private decimal _cost;
        private decimal _unitCost;
        private decimal _quantity;

        //private long _quantity;

        public long Id { get; set; }
        public StockPurchaseBatch Batch { get; set; }
        public StockPackage StockPackage { get; set; }
        public StockPackageRelationship StockPackageRelationship { get; set; }

        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                base.OnPropertyChanged("Quantity");
            }
        }


        //public long Quantity
        //{
        //    get { return _quantity; }
        //    set
        //    {
        //        _quantity = value;
        //        base.OnPropertyChanged("Quantity");
        //    }
        //}

        public decimal UnitCost
        {
            get { return _unitCost; }
            set
            {
                _unitCost = value;
                base.OnPropertyChanged("UnitCost");
            }
        }


        public decimal Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                base.OnPropertyChanged("Cost");
            }
        }


        

    }
}
