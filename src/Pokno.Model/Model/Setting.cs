using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class Setting : BaseModel
    {
        private bool _isDefaultDb;
        private DateTime? _applicationDate;
        private ApplicationMode _applicationMode;
        private bool _showPackageRelationshipInStockSummaryReviewReport;
        private bool _isCustomerLoyaltyEnabled;
        private bool _isActivated;
        private string _dbPath;

        public int Id { get; set; }
        public DateTime? ApplicationDate 
        {
            get { return _applicationDate; } 
            set
            {
                _applicationDate = value;
                base.OnPropertyChanged("ApplicationDate");
            }
        }
        public ApplicationMode ApplicationMode 
        {
            get { return _applicationMode; } 
            set
            {
                _applicationMode = value;
                base.OnPropertyChanged("ApplicationMode");
            }
        }
        public bool IsCustomerLoyaltyEnabled 
        {
            get { return _isCustomerLoyaltyEnabled; } 
            set
            {
                _isCustomerLoyaltyEnabled = value;
                base.OnPropertyChanged("IsCustomerLoyaltyEnabled");
            }
        }

        public bool ShowPackageRelationshipInStockSummaryReviewReport
        {
            get { return _showPackageRelationshipInStockSummaryReviewReport; } 
            set
            {
                _showPackageRelationshipInStockSummaryReviewReport = value;
                base.OnPropertyChanged("ShowPackageRelationshipInStockSummaryReviewReport");
            }
        }

        public bool IsActivated 
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                base.OnPropertyChanged("IsActivated");
            }
        }
        public string DbPath
        {
            get { return _dbPath; }
            set
            {
                _dbPath = value;
                base.OnPropertyChanged("DbPath");
            }
        }
        public bool IsDefaultDb
        {
            get { return _isDefaultDb; }
            set
            {
                _isDefaultDb = value;
                base.OnPropertyChanged("IsDefaultDb");
            }
        }


    }




}
