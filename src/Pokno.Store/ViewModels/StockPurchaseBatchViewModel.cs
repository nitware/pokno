using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Infrastructure.Interfaces;
using Pokno.Service;
using Pokno.Infrastructure.Models;
using System.Windows.Data;
using Pokno.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pokno.Infrastructure.Events;
using Prism.Events;

namespace Pokno.Store.ViewModels
{
    public class StockPurchaseBatchViewModel : StockPurchaseBatchViewModelBase
    {
        private ListCollectionView _supplierPaymentHistory;

        public StockPurchaseBatchViewModel(IBusinessFacade businessFacade, IStockPurchaseBatchService service, IEventAggregator eventAggregator)
            : base(businessFacade, service)
        {
        }
                
        public string TabCaption
        {
            get { return "Stock Purchase Batch"; }
        }

        public ListCollectionView SupplierPaymentHistory
        {
            get { return _supplierPaymentHistory; }
            set
            {
                _supplierPaymentHistory = value;
                base.OnPropertyChanged("SupplierPaymentHistory");
            }
        }

        protected override void OnClearCommand()
        {
            try
            {
                base.OnClearCommand();
                ComputeBalance();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void PopulateSuppliers(ObservableCollection<Person> toSuppliers)
        {
            try
            {
                if (toSuppliers != null && toSuppliers.Count > 0)
                {
                    List<Person> suplliers = toSuppliers.Where(s => s.Type.Id == (int)PoknoPersonType.Supplier).ToList();
                    if (suplliers != null && suplliers.Count() > 0)
                    {
                        suplliers.Insert(0, new Person() { FullName = "<< Select Supplier >>" });
                        _dispatcher.Invoke(() =>
                        {
                            Suppliers = new ObservableCollection<Person>(suplliers);
                            Supplier = Suppliers.FirstOrDefault();
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void Initialise()
        {
            ComputeBalance();
        }

        protected override void SetUserViewRight()
        {
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupStockCategory;
        }




    }

}
