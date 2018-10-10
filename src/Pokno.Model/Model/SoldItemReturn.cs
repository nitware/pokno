using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class SoldItemReturn : SoldStock
    {
        private bool _canReturn;
        private bool _isSelected;
        private StockState _stockState;
        private StockReturnAction _action;
        private bool _canEditReturnQuantity;
        private bool _canEditReturnAmount;
        private ObservableCollection<StockReturnAction> _actions;

        public ObservableCollection<StockState> StockStates { get; set; }

        public bool CanReturn
        {
            get { return _canReturn; }
            set
            {
                _canReturn = value;
                base.OnPropertyChanged("CanReturn");
            }
        }
        public bool CanEditReturnQuantity
        {
            get { return _canEditReturnQuantity; }
            set
            {
                _canEditReturnQuantity = value;
                base.OnPropertyChanged("CanEditReturnQuantity");
            }
        }

        public bool CanEditReturnAmount
        {
            get { return _canEditReturnAmount; }
            set
            {
                _canEditReturnAmount = value;
                base.OnPropertyChanged("CanEditReturnAmount");
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                base.OnPropertyChanged("IsSelected");

                CanReturn = _isSelected == true ? true : false;
                CanEditReturnQuantity = _isSelected == true && Quantity > 1 ? true : false;
            }
        }
        public StockState StockState
        {
            get { return _stockState; }
            set
            {
                _stockState = value;
                base.OnPropertyChanged("StockState");
            }
        }
        public StockReturnAction Action
        {
            get { return _action; }
            set
            {
                _action = value;
                base.OnPropertyChanged("Action");

                CanEditReturnAmount = (_action != null && _action.Id > 0 && _action.Id == 3) ? true : false;
            }
        }
                
        public ObservableCollection<StockReturnAction> Actions
        {
            get { return _actions; }
            set
            {
                _actions = value;
                base.OnPropertyChanged("Actions");
            }
        }
        
        public int ShelfQuantity { get; set; }
        public int ReturnQuantity { get; set; }
        public decimal ReturnAmount { get; set; }

       

    }
}
