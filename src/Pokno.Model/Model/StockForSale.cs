using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    public class StockForSale : BaseModel
    {
        private StockPrice _stockPrice;
        private decimal _actualSellingPrice;
        private decimal _totalSellingPrice;
        private decimal _discount;
        private int _quantity;

        public int OriginalQuantity { get; set; }
        public decimal OriginalActualSellingPrice { get; set; }
        public StockPrice OriginalStockPrice { get; set; }
        public StockPackage StockPackage { get; set; }
        public long StockPackageRelationshipId { get; set; }
        public StockType StockType { get; set; }
        public int ReorderLevel { get; set; }

        public StockPrice StockPrice
        {
            get { return _stockPrice; }
            set
            {
                _stockPrice = value;
                base.OnPropertyChanged("StockPrice");
            }
        }
        public decimal ActualSellingPrice
        {
            get { return _actualSellingPrice; }
            set
            {
                _actualSellingPrice = value;
                base.OnPropertyChanged("ActualSellingPrice");
            }
        }
        public decimal Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                base.OnPropertyChanged("Discount");
            }
        }
        public decimal TotalSellingPrice
        {
            get { return _totalSellingPrice; }
            set
            {
                _totalSellingPrice = value;
                base.OnPropertyChanged("TotalSellingPrice");
            }
        }
        public int Quantity
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
