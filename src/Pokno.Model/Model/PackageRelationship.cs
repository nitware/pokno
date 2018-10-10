using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    public class PackageRelationship : BaseModel
    {
        private decimal _quantity;

        public long Id { get; set; }
        public StockPackageRelationship StockPackageRelationship { get; set; }
        public StockPackage Package { get; set; }
        public StockPackage SubPackage { get; set; }
        public DateTime Date { get; set; }
        public long Rank { get; set; }

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


    }


}
