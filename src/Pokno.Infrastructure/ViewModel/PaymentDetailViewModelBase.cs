using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Infrastructure.Models;
using System.ComponentModel;
//using Pokno.Infrastructure.ViewModelBase.Popups;
using System.Collections.ObjectModel;
using System.Windows.Threading;
//using Pokno.Infrastructure.View.Popups;
using Prism.Commands;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.Services;
using System.Linq;
using System.Windows.Data;
using Pokno.Model;
using Pokno.Infratructure.Services;
using System.Collections.Generic;
using Pokno.Infrastructure.View.Popups;
using Pokno.Infrastructure.ViewModel.Popups;
using Pokno.Service;

namespace Pokno.Infrastructure.ViewModel
{
    public class PaymentDetailViewModelBase : ObservableCollectionManagerBase<PaymentDetail>
    {
        protected Window PopUp;
        protected Dispatcher _dispatcher;

        private ObservableCollection<Payment> _payments;
        private ObservableCollection<PaymentType> _paymentTypes;
        protected PaymentType _paymentType;
        private decimal _totalAmount;
        private decimal _amountPaid;
        protected Payment _payment;
        private Cheque _cheque;

        protected readonly IBusinessFacade _businessFacade;
        protected readonly IPaymentService _paymentService;
        private readonly ISetupService<PaymentType> _paymentTypeService;

        public PaymentDetailViewModelBase(IBusinessFacade businessFacade, ISetupService<PaymentType> paymentTypeService, IPaymentService paymentService)
        {
            _dispatcher = Application.Current.Dispatcher;

            _businessFacade = businessFacade;
            _paymentTypeService = paymentTypeService;
            _paymentService = paymentService;

            AddCommand = new DelegateCommand(OnAddDetailCommand, CanAdd);
            RemoveCommand = new DelegateCommand(OnDeleteCommand, CanRemove);

            collectionManager = new ObservableCollectionManager<PaymentDetail>();
        }

        protected decimal AmountPaid
        {
            get { return _amountPaid; }
            set
            {
                _amountPaid = value;
                OnPropertyChanged("AmountPaid");
            }
        }
        public ObservableCollection<PaymentType> PaymentTypes
        {
            get { return _paymentTypes; }
            set
            {
                _paymentTypes = value;
                base.OnPropertyChanged("PaymentTypes");
            }
        }
        public virtual PaymentType PaymentType
        {
            get { return _paymentType; }
            set
            {
                _paymentType = value;
                base.OnPropertyChanged("PaymentType");

                PaymentTypesSelectionChanged(_paymentType);
            }
        }
        public Cheque Cheque
        {
            get { return _cheque; }
            set
            {
                _cheque = value;
                base.OnPropertyChanged("Cheque");
            }
        }
        public ObservableCollection<Payment> Payments
        {
            get { return _payments; }
            set
            {
                _payments = value;
                OnPropertyChanged("Payments");
            }
        }
        public Pokno.Model.Payment Payment
        {
            get { return _payment; }
            set
            {
                _payment = value;
                OnPropertyChanged("Payment");

                PaymentsSelectionChanged(_payment);
            }
        }
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        protected void PaymentsSelectionChanged(Pokno.Model.Payment payment)
        {
            try
            {
                if (payment != null && payment.Id > 0)
                {
                    LoadPaymentDetailsByPayment(payment);
                    LoadAllPaymentType();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllPaymentType()
        {
            try
            {
                List<PaymentType> paymentTypes = _paymentTypeService.LoadAll();
                LoadAllPaymentTypeHelper(paymentTypes);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllPaymentTypeHelper(List<PaymentType> paymentTypes)
        {
            try
            {
                if (paymentTypes == null)
                {
                    paymentTypes = new List<PaymentType>();
                }

                if (paymentTypes.Count > 0)
                {
                    //paymentTypes.Insert(0, new PaymentType() { Name = "<< Select Payment Type >>" });
                    paymentTypes.Insert(0, new PaymentType() { Name = "<< Select Pay Mode >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    PaymentTypes = new ObservableCollection<PaymentType>(paymentTypes);
                    PaymentType = PaymentTypes.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void PaymentTypesSelectionChanged(PaymentType paymentType)
        {
            try
            {
                if (paymentType != null)
                {
                    if (TargetModel != null)
                    {
                        TargetModel.PaymentType = paymentType;
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        
        protected virtual void OnClearCommand()
        {
            try
            {
                if (collectionManager.Collection.Count > 0)
                {
                    collectionManager.Collection.Clear();
                    RefreshModelCollection();
                    ComputeBalance();
                }

                Payment = new Payment();
                if (Payments != null && Payments.Count > 0)
                {
                    Payment = Payments.FirstOrDefault();
                }
                else
                {
                    Payments = new ObservableCollection<Model.Payment>();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override PaymentDetail GetNewModel()
        {
            try
            {
                PaymentDetail newPaymentDetail = new PaymentDetail();
                newPaymentDetail.PaymentType = new PaymentType();

                Cheque newCheque = null;
                if (Cheque != null)
                {
                    Bank bank = new Bank();
                    bank.Id = Cheque.Bank.Id;
                    bank.Name = Cheque.Bank.Name;

                    newCheque = new Cheque();
                    newCheque.Id = Cheque.Id;
                    newCheque.Bank = Cheque.Bank;
                    newCheque.ChequeNumber = Cheque.ChequeNumber;
                    newCheque.AccountNumber = Cheque.AccountNumber;
                }

                newPaymentDetail.Cheque = newCheque;
                newPaymentDetail.Id = TargetModel.Id;
                newPaymentDetail.AmountPaid = TargetModel.AmountPaid;
                newPaymentDetail.PaymentDate = TargetModel.PaymentDate;
                newPaymentDetail.PaymentType = TargetModel.PaymentType;

                return newPaymentDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void UpdatePaymentDetails(Cheque cheque)
        {
            try
            {
                Cheque = cheque;
                collectionManager.Collection.Add(GetNewModel());
                RefreshModelCollection();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnDeleteCommand()
        {
            try
            {
                if (PaymentDetailsIsEmpty())
                {
                    return;
                }

                int index = TargetCollection.CurrentPosition;
                if (index > -1)
                {
                    collectionManager.Collection.RemoveAt(index);
                    RefreshModelCollection();
                }
                else
                {
                    Utility.DisplayMessage("No selection made! Please select a payment details row for removal");
                }

                ComputeBalance();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool PaymentDetailsIsEmpty()
        {
            try
            {
                if (TargetCollection == null)
                {
                    Utility.DisplayMessage("No payment detail to remove");
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        protected virtual bool RequiredDetailsNotEntered()
        {
            try
            {
                if (PaymentType == null || PaymentType.Id <= 0)
                {
                    Utility.DisplayMessage("Please select payment type!");
                    return true;
                }
                else if (PaymentType != null && PaymentType.Id != 3)
                {
                    if (TargetModel.AmountPaid == 0)
                    {
                        Utility.DisplayMessage("Please enter amount paid!");
                        return true;
                    }
                    else if (TargetModel.PaymentDate == null || TargetModel.PaymentDate == DateTime.MinValue)
                    {
                        Utility.DisplayMessage("Please enter payment date!");
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void OnAddDetailCommand()
        {
            try
            {
                TargetModel.Cheque = null;

                if (RequiredDetailsNotEntered())
                {
                    return;
                }

                if (PaymentType != null)
                {
                    if (PaymentType.Id == (int)PoknoPaymentType.Cheque)
                    {
                        PopUp = new BankAccountDetailPopUpView(_businessFacade);
                        PopUp.Closed += new EventHandler(PopUpView_Closed);

                        PopUp.ShowDialog();
                    }
                    else if (PaymentType.Id == (int)PoknoPaymentType.Credit)
                    {
                        TargetModel.AmountPaid = 0;
                        UpdatePaymentDetails(null);
                    }
                    else
                    {
                        UpdatePaymentDetails(null);
                    }
                }

                ComputeBalance();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void PopUpView_Closed(object sender, EventArgs e)
        {
            try
            {
                if (PopUp.DialogResult != null)
                {
                    bool result = (PopUp.DialogResult != null) ? Convert.ToBoolean(PopUp.DialogResult) : false;
                    BankAccountDetailPopUpViewModel popupDialogViewModel = (BankAccountDetailPopUpViewModel)PopUp.DataContext;

                    if (result)
                    {
                        TargetModel.Cheque = popupDialogViewModel.Cheque;
                        UpdatePaymentDetails(TargetModel.Cheque);
                        ComputeBalance();
                    }

                    SetUserViewRight();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void ComputeBalance()
        {
            try
            {
                if (TargetCollection != null)
                {
                    ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection;
                    TotalAmount = paymentDetails.Sum(a => a.AmountPaid);


                    if (Payment != null)
                    {
                        Payment.AmountPaid = TotalAmount;
                        Payment.Balance = Payment.AmountPayable - TotalAmount;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadPaymentDetailsByPayment(Payment payment)
        {
            try
            {
                if (payment != null && payment.Id > 0)
                {
                    List<PaymentDetail> paymentDetails = _paymentService.LoadPaymentDetailByPayment(payment);
                    LoadPaymentDetailsByPaymentHelper(paymentDetails);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadPaymentDetailsByPaymentHelper(List<PaymentDetail> paymentDetails)
        {
            try
            {
                if (paymentDetails != null)
                {
                    _dispatcher.Invoke(() =>
                    {
                        collectionManager.Collection = new ObservableCollection<PaymentDetail>(paymentDetails);
                        RefreshModelCollection();

                        if (paymentDetails != null)
                        {
                            ComputeBalance();
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void Clear()
        {
            try
            {
                TargetModel = new PaymentDetail();
                TargetModel.PaymentDate = Utility.GetDate();

                
                ClearPaymentTypes();
                ClearTargetCollection();
                ComputeBalance();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void ClearPaymentTypes()
        {
            try
            {
                if (PaymentTypes != null && PaymentTypes.Count > 0)
                {
                    PaymentType = PaymentTypes.FirstOrDefault();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        protected void SetUserViewRight()
        {
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanUpdatePayment;
        }


        


    }


}
