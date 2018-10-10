using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    
    public class StockPrice : BaseModel
    {
        private long _id;
        private decimal _costPrice;
        private decimal _sellingPrice;
        private StockPackage _stockPackage;

        public DateTime DateEntered { get; set; }
        public CurrentStockPrice CurrentStockPrice { get; set; }

        public long Id 
        {
            get { return _id; }
            set
            {
                _id = value;
                base.OnPropertyChanged("Id");
            }
        }
        public StockPackage StockPackage 
        {
            get { return _stockPackage; }
            set
            {
                _stockPackage = value;
                base.OnPropertyChanged("StockPackage");
            }
        }
        public decimal CostPrice 
        {
            get { return _costPrice; }
            set
            {
                _costPrice = value;
                base.OnPropertyChanged("CostPrice");
            }
        }
        public decimal SellingPrice 
        {
            get { return _sellingPrice; }
            set 
            {
                _sellingPrice = value;
                base.OnPropertyChanged("SellingPrice");
            } 
        }





    }
}
