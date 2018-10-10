using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class ReturnedStockReplacement : BaseModel
    {
        private bool _isSelected;
        private bool _canEnterActionReason;
        private string _actionReason;

        public enum ActionType
        {
            ReturnToSupplier = 1,
            ReturnToShelf = 2,
            Trashed = 3
        }

        public long Id { get; set; }
        public ReturnedStockDetail ReturnedDetail { get; set; }
        public SoldStock SoldStockReplacement { get; set; }
        public ReplacedStockAction Action { get; set; }
        public Person ActionExecutor { get; set; }
        public DateTime? ActionDate { get; set; }
        
        public ObservableCollection<ReplacedStockAction> Actions { get; set; }

        public string ActionReason
        {
            get { return _actionReason; }
            set
            {
                _actionReason = value;
                base.OnPropertyChanged("ActionReason");
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                base.OnPropertyChanged("IsSelected");

                CanEnterActionReason = _isSelected;
            }
        }
        public bool CanEnterActionReason
        {
            get { return _canEnterActionReason; }
            set
            {
                _canEnterActionReason = value;
                base.OnPropertyChanged("CanEnterActionReason");
            }
        }

        

    }

}
