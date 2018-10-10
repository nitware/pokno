using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Service;
using Pokno.Store.Interfaces;
using Pokno.Infrastructure.Interfaces;
using Prism.Commands;
using Pokno.Infrastructure.Models;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.ComponentModel;
using Pokno.Model.Model;

namespace Pokno.Store.ViewModels
{
    public class DeleteSalesTransactionViewModel : BaseSoldStockViewModel
    {
        private string _deleteReason;
        private bool _canDeleteSalesTransaction;

        public DeleteSalesTransactionViewModel(IEventAggregator eventAggregator, IBusinessFacade businessFacade, ISoldStockService service, ISetupService<Person> personService, ISetupService<PaymentType> paymentTypeService, IPaymentService paymentService)
            : base(businessFacade, service, personService, paymentTypeService, paymentService)
        {
            //_businessFacade = businessFacade;
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanDelete);

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanDeleteSalesTransaction;
            eventAggregator.GetEvent<SalesEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);

            UpdateViewState(Edit.Mode.Loaded);
        }
       
        private bool IsView(UI.Sales ui)
        {
            return ui == UI.Sales.DeleteSalesTransaction;
        }
        
        public DelegateCommand DeleteCommand { get; private set; }
        
        public string TabCaption
        {
            get { return "Delete Sales Transaction"; }
        }
        private bool CanDelete()
        {
            return CanDeleteSalesTransaction;
        }
        public bool CanDeleteSalesTransaction
        {
            get { return _canDeleteSalesTransaction; } 
            set
            {
                _canDeleteSalesTransaction = value;
                base.OnPropertyChanged("CanDeleteSalesTransaction");
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public string DeleteReason
        {
            get { return _deleteReason; }
            set
            {
                _deleteReason = value;
                base.OnPropertyChanged("DeleteReason");
                UpdateViewState(Edit.Mode.Adding);
                //UpdateButtons(Edit.Mode.Adding);
            }
        }

        private void OnDeleteCommand()
        {
            try
            {
                //DeletedSoldStockBatch deletedSoldStockBatch = new DeletedSoldStockBatch();
                //deletedSoldStockBatch.Id = OutgoingStockBatch.Id;
                //deletedSoldStockBatch.Payment = OutgoingStockBatch.Payment;
                //deletedSoldStockBatch.Seller = OutgoingStockBatch.Seller;
                //deletedSoldStockBatch.Customer = OutgoingStockBatch.Customer;
                //deletedSoldStockBatch.DateSold = OutgoingStockBatch.DateSold;
                //deletedSoldStockBatch.SoldStocks = new List<SoldStock>(OutgoingStocks);
                //deletedSoldStockBatch.TotalDiscount = OutgoingStockBatch.TotalDiscount;
                //deletedSoldStockBatch.DateDeleted = Utility.GetDate();
                //deletedSoldStockBatch.DeletedBy = Utility.LoggedInUser;
                //deletedSoldStockBatch.DeletedReason = DeleteReason;
                //_businessFacade.AddDeletedSoldStockBatch(deletedSoldStockBatch);


                if (InvalidInput())
                {
                    return;
                }

                OutgoingStockBatch.SoldStocks = new List<SoldStock>(OutgoingStocks);
                bool deleted = _businessFacade.RemoveSoldStockBatch(OutgoingStockBatch);
                if (deleted)
                {
                    OnInitialise(UI.Sales.DeleteSalesTransaction);
                    Utility.DisplayMessage("Sales Transaction has been successfully deleted.");
                }
                else
                {
                    Utility.DisplayMessage("Sales Transaction delete operation failed!");
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool InvalidInput()
        {
            try
            {
                bool invalidInput = false;
                if (OutgoingStockBatch == null || OutgoingStockBatch.Id <= 0)
                {
                    invalidInput = true;
                    Utility.DisplayMessage("Please select sale transaction from the drop down list!");
                }
                else if (OutgoingStocks == null || OutgoingStocks.Count <= 0)
                {
                    invalidInput = true;
                    Utility.DisplayMessage("No sold item found for the selected transaction!");
                }
                else if (string.IsNullOrWhiteSpace(DeleteReason))
                {
                    invalidInput = true;
                    Utility.DisplayMessage("Please enter reason for transaction deletion!");
                }

                return invalidInput;
            }
            catch(Exception)
            {
                throw;
            }
        }

        //UpdateViewState(Edit.Mode.Editing);
        //protected override void UpdateButtons(Edit.Mode viewState)
        protected override void UpdateViewState(Edit.Mode viewState)
        {
            try
            {
                switch (viewState)
                {
                    case Edit.Mode.Loaded:
                        {
                            CanDeleteSalesTransaction = false;
                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            if (OutgoingStockBatch != null && OutgoingStockBatch.Id > 0 && !string.IsNullOrWhiteSpace(DeleteReason))
                            {
                                CanDeleteSalesTransaction = true;
                            }
                            else
                            {
                                CanDeleteSalesTransaction = false;
                            }

                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void ClearCustomer()
        {
            try
            {
                Customer = new Person();
            }
            catch (Exception)
            {
                throw;
            }
        }



    }



}
