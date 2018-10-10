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

using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Data;
using System.Linq;
using System.ComponentModel;
using Pokno.Store.Interfaces;
using Pokno.Store.Services;
using Pokno.Infrastructure.Interfaces;
using Pokno.Model;
using Pokno.Infratructure.Services;
using Pokno.Service;
using Prism.Commands;
using Pokno.Infrastructure.View.Popups;
using Pokno.Infrastructure.ViewModel.Popups;

namespace Pokno.Store.ViewModels
{
    public abstract class StockPurchaseBatchViewModelBase : ObservableCollectionManagerBase<PaymentDetail>
    {
        private Person _buyer;
        private Person _supplier;
        private ObservableCollection<Person> _buyers;
        private ObservableCollection<Person> _suppliers;
        private ObservableCollection<PaymentType> _paymentTypes;
        private StockPurchaseBatch _stockPurchaseBatch;
        private PaymentType _paymentType;
        private decimal _balance;
        private Cheque _cheque;

        private Payment _payment;
        protected Dispatcher _dispatcher;
        protected Window PopUp;

        protected PersonService _personService;
        protected IStockPurchaseBatchService _service;
        protected PaymentTypeService _paymentTypeService;
        private readonly IBusinessFacade _businessFacade;

        public StockPurchaseBatchViewModelBase(IBusinessFacade businessFacade, IStockPurchaseBatchService service)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;
            _businessFacade = businessFacade;

            _personService = new PersonService(businessFacade);
            _paymentTypeService = new PaymentTypeService(businessFacade);
            collectionManager = new ObservableCollectionManager<PaymentDetail>();

            Payment = new Payment();
            Payment.DatePaid = Utility.GetDate();
            Payment.TransactionType = new Model.Model.TransactionType() { Id = (int)Payment.Transaction.Purchase };
            TargetModel = new PaymentDetail();
            StockPurchaseBatch = new StockPurchaseBatch();

            TargetModel.Payment = Payment;
            TargetModel.PaymentDate = Utility.GetDate();
            StockPurchaseBatch.DatePurchased = Utility.GetDate();

            AddCommand = new DelegateCommand(OnAddDetailCommand, CanAdd);
            RemoveCommand = new DelegateCommand(OnDeleteCommand, CanRemove);
            ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);

            UpdateViewState(Edit.Mode.Loaded);
        }

        public void PopulatePaymentType(List<PaymentType> paymentTypes)
        {
            try
            {
                if (paymentTypes == null)
                {
                    paymentTypes = new List<PaymentType>();
                }

                if (paymentTypes.Count > 0)
                {
                    paymentTypes.Insert(0, new PaymentType() { Name = "<< Select Pay Mode >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    PaymentTypes = new ObservableCollection<PaymentType>(paymentTypes);
                    PaymentType = PaymentTypes.FirstOrDefault();
                    TargetModel.PaymentType = PaymentType;
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public bool UserResponse { get; set; }

        public Cheque Cheque
        {
            get { return _cheque; }
            set
            {
                _cheque = value;
                base.OnPropertyChanged("Cheque");
            }
        }
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                base.OnPropertyChanged("Balance");
            }
        }
        public StockPurchaseBatch StockPurchaseBatch
        {
            get { return _stockPurchaseBatch; }
            set
            {
                _stockPurchaseBatch = value;
                base.OnPropertyChanged("StockPurchaseBatch");
            }
        }
        public ObservableCollection<Person> Suppliers
        {
            get { return _suppliers; }
            set
            {
                _suppliers = value;
                base.OnPropertyChanged("Suppliers");
            }
        }
        public Person Supplier
        {
            get { return _supplier; }
            set
            {
                _supplier = value;
                base.OnPropertyChanged("Supplier");
            }
        }
        public Payment Payment
        {
            get { return _payment; }
            set
            {
                _payment = value;
                base.OnPropertyChanged("Payment");
            }
        }
        public ObservableCollection<Person> Buyers
        {
            get { return _buyers; }
            set
            {
                _buyers = value;
                base.OnPropertyChanged("Buyers");
            }
        }
        public Person Buyer
        {
            get { return _buyer; }
            set
            {
                _buyer = value;
                base.OnPropertyChanged("Buyer");
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
        public PaymentType PaymentType
        {
            get { return _paymentType; }
            set
            {
                _paymentType = value;
                base.OnPropertyChanged("PaymentType");
                TargetModel.PaymentType = PaymentType;
            }
        }

        protected virtual void OnSaveCommand()
        {
            try
            {
                StockPurchaseBatch.Supplier = Supplier;
                StockPurchaseBatch.Payment = Payment;
                StockPurchaseBatch.Buyer = Buyer;
                StockPurchaseBatch.DatePurchased = Utility.GetDate();

                StockPurchaseBatch.Payment.Details = new List<PaymentDetail>((IEnumerable<PaymentDetail>)TargetCollection.SourceCollection);
                if (InvalidEntry())
                {
                    return;
                }

                bool saved = _service.Save(StockPurchaseBatch);
                OnSaveCommandHelper(saved);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommandHelper(bool saved)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (saved)
                    {
                        ClearView();
                        Utility.DisplayMessage("Save operation was successful");
                    }
                    else
                    {
                        Utility.DisplayMessage("Save operation failed!");
                    }
                });
            }
            catch (Exception)
            {
                throw;
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
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public virtual void ClearView()
        {
            try
            {
                OnClearCommand();
                if (Buyers != null && Buyers.Count > 0)
                {
                    Buyer = Buyers.FirstOrDefault();
                }
                if (Suppliers != null && Suppliers.Count > 0)
                {
                    Supplier = Suppliers.FirstOrDefault();
                }
                if (PaymentTypes != null && PaymentTypes.Count > 0)
                {
                    PaymentType = PaymentTypes.FirstOrDefault();
                }

                Payment = new Payment();
                Payment.DatePaid = Utility.GetDate();
                TargetModel = new PaymentDetail();
                TargetModel.PaymentDate = Utility.GetDate();
                StockPurchaseBatch = new StockPurchaseBatch();
                StockPurchaseBatch.DatePurchased = Utility.GetDate();

                TargetModel.AmountPaid = 0;
                Balance = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PopulateSuppliers(List<Person> people)
        {
            try
            {
                if (people != null)
                {
                    ObservableCollection<Person> toSuppliers = new ObservableCollection<Person>(people);
                    ObservableCollection<Person> toBuyers = new ObservableCollection<Person>(people);

                    PopulateSuppliers(toSuppliers);
                    PopulateBuyers(toBuyers);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public void OnAddDetailCommand()
        {
            try
            {
                TargetModel.Cheque = null;

                if (!IsRequiredDetailsEntered())
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


        protected virtual bool IsRequiredDetailsEntered()
        {
            try
            {
                if (Payment.AmountPayable == 0)
                {
                    Utility.DisplayMessage("Please enter amount Payable!");
                    return false;
                }
                else if (PaymentType == null || PaymentType.Id == 0)
                {
                    Utility.DisplayMessage("Please select payment type!");
                    return false;
                }
                else if (PaymentType != null && PaymentType.Id != 3)
                {
                    if (TargetModel.AmountPaid == 0)
                    {
                        Utility.DisplayMessage("Please enter amount paid!");
                        return false;
                    }
                    else if (InvalidDatePaid())
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual bool InvalidDatePaid()
        {
            try
            {
                if (TargetModel.PaymentDate == null || TargetModel.PaymentDate == DateTime.MinValue)
                {
                    Utility.DisplayMessage("Please enter payment date!");
                    return true;
                }
                else if (TargetModel.PaymentDate != null && TargetModel.PaymentDate != DateTime.MinValue)
                {
                    TimeSpan difference = TargetModel.PaymentDate - Utility.GetDate();
                    if (difference.TotalDays > 0)
                    {
                        Utility.DisplayMessage("Date Paid cannot be a date in the future! Please modify to continue");
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

        public bool InvalidEntry()
        {
            try
            {
                if (StockPurchaseBatch.Supplier == null || StockPurchaseBatch.Supplier.Id == 0)
                {
                    Utility.DisplayMessage("Please select supplier!");
                    return true;
                }
                else if (StockPurchaseBatch.Buyer == null || StockPurchaseBatch.Buyer.Id == 0)
                {
                    Utility.DisplayMessage("Please select buyer!");
                    return true;
                }
                else if (StockPurchaseBatch.Payment == null)
                {
                    Utility.DisplayMessage("Please enter payment information!");
                    return true;
                }
                else if (StockPurchaseBatch.Payment.AmountPayable <= 0)
                {
                    Utility.DisplayMessage("Amount Payable cannot be less than or equal to zero!");
                    return true;
                }
                else if (StockPurchaseBatch.Payment.Details == null || StockPurchaseBatch.Payment.Details.Count == 0)
                {
                    Utility.DisplayMessage("Please enter payment detail information!");
                    return true;
                }

                if (StockPurchaseBatch.DatePurchased != null && StockPurchaseBatch.DatePurchased != DateTime.MinValue)
                {
                    TimeSpan difference = StockPurchaseBatch.DatePurchased - Utility.GetDate();
                    if (difference.TotalDays > 0)
                    {
                        Utility.DisplayMessage("Date purchased cannot be a date in the future! Please modify to continue");
                        return true;
                    }
                }
                else
                {
                    Utility.DisplayMessage("Please specify date purchased!");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ComputeBalance()
        {
            try
            {
                if (TargetCollection != null)
                {
                    ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection;
                    decimal totalAmountPaid = paymentDetails.Sum(a => a.AmountPaid);
                    Balance = Payment.AmountPayable - totalAmountPaid;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdatePaymentDetails(Cheque cheque)
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

        public virtual void OnDeleteCommand()
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
            catch (Exception)
            {
                throw;
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

        protected abstract void SetUserViewRight();

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

        private void PopulateBuyers(ObservableCollection<Person> toUers)
        {
            try
            {
                if (toUers == null)
                {
                    toUers = new ObservableCollection<Person>();
                }

                _dispatcher.Invoke(() =>
                {
                    if (toUers.Count > 0)
                    {
                        List<Person> users = toUers.Where(s => s.Type.Id == (int)PoknoPersonType.User).ToList();
                        if (users != null && users.Count() > 0)
                        {
                            //users.Insert(0, new Person() { FullName = "<< Select Buyers >>" });
                            users.Insert(0, new Person() { FullName = "<< Select Initiator >>" });
                        }

                        Buyers = new ObservableCollection<Person>(users);
                        Buyer = Buyers.FirstOrDefault();
                    }
                    else
                    {
                        Buyers = new ObservableCollection<Person>();
                        Buyer = new Person();
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void PopulateSuppliers(ObservableCollection<Person> toSuppliers)
        {
            try
            {
                if (toSuppliers != null && toSuppliers.Count > 0)
                {
                    List<Person> suppliers = toSuppliers.Where(s => s.Type.Id == (int)PoknoPersonType.Supplier).ToList();
                    if (suppliers != null && suppliers.Count() > 0)
                    {
                        suppliers.Insert(0, new Person() { FullName = "<< Select Supplier >>" });

                        _dispatcher.Invoke(() =>
                            {
                                Suppliers = new ObservableCollection<Person>(suppliers);
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

       


    }

}
