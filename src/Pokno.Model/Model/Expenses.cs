using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class Expenses : BaseModel
    {
        private decimal _cashAtHand;
        private decimal? _additionalCash;
        private decimal _openingBalace;
        private decimal _closingBalance;
        private decimal _totalSalesAmount;
        private bool _canSaveChanges;
        
        public long Id { get; set; }
        public bool CanSaveChanges 
        {
            get { return _canSaveChanges; }
            set
            {
                _canSaveChanges = value;
                base.OnPropertyChanged("CanSaveChanges");
            }
        }
        
        public decimal TotalSalesAmount 
        {
            get { return _totalSalesAmount; } 
            set
            {
                _totalSalesAmount = value;
                base.OnPropertyChanged("TotalSalesAmount");
            }
        }
        public decimal OpeningBalace 
        {
            get { return _openingBalace; }
            set
            {
                _openingBalace = value;
                base.OnPropertyChanged("OpeningBalace");
            }
        }
        public decimal? AdditionalCash 
        { 
            get {return _additionalCash; }
            set
            {
                _additionalCash = value;
                base.OnPropertyChanged("AdditionalCash");
            }
        }
        public decimal CashAtHand
        {
            get { return _cashAtHand; }
            set
            {
                _cashAtHand = value;
                base.OnPropertyChanged("CashAtHand");
            }
        }
        public decimal ClosingBalance 
        {
            get { return _closingBalance; }
            set
            {
                _closingBalance = value;
                base.OnPropertyChanged("ClosingBalance");
            }
        }

        public Person CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpensesDate { get; set; }
        
        public List<ExpensesDetail> Details { get; set; }
    }


}
