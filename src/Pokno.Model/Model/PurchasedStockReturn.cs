using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class PurchasedStockReturn : BaseStockPurchased
    {
        private string _returnReason;
        private StockState _stockState;
                        
        //public Person EnteredBy { get; set; }
        public Person ReturnedBy { get; set; }
        //public DateTime DateEntered { get; set; }
        public DateTime DateReturnd { get; set; }
        public ReplacedStockAction Action { get; set; }
        //public string ReturnReason { get; set; }

        public ObservableCollection<StockState> StockStates { get; set; }
        public StockState OldStockState { get; set; }
        public string OldReturnReason { get; set; }

        public StockState StockState
        {
            get { return _stockState; }
            set
            {
                _stockState = value;
                base.OnPropertyChanged("StockState");
            }
        }
        public string ReturnReason
        {
            get { return _returnReason; }
            set
            {
                _returnReason = value;
                base.OnPropertyChanged("ReturnReason");
            }
        }





    }


}
