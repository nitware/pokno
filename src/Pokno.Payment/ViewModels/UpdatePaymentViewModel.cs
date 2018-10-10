using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using System.Linq;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using System.Collections.ObjectModel;
using Pokno.Model;
using System.ComponentModel;
using Pokno.Infrastructure.Interfaces;
using Prism.Commands;
using Pokno.Infratructure.Services;
using System.Collections.Generic;
using System.Windows.Data;
using Pokno.Service;

namespace Pokno.Payment.ViewModels
{
    public class UpdatePaymentViewModel : PaymentDetailViewModelBase
    {
        private Person _person;
        private ObservableCollection<Person> _people;
        private ListCollectionView _supplierPaymentHistory;
        private IStockPurchaseBatchService _stockPurchaseBatchService;
        private ISetupService<Person> _personService;
        private decimal _totalAmountPayable;
        private decimal _totalAmountPaid;
        private decimal _totalBalance;

        private BackgroundWorker _worker;
        private bool _isBusy;

        public UpdatePaymentViewModel(IBusinessFacade businessFacade, ISetupService<PaymentType> paymentTypeService, IPaymentService paymentService, ISetupService<Person> personService, IStockPurchaseBatchService stockPurchaseBatchService)
            : base(businessFacade, paymentTypeService, paymentService)
        {
            ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);

            _personService = personService;
            _stockPurchaseBatchService = stockPurchaseBatchService;
            //_businessFacade = businessFacade;

            TargetModel = new PaymentDetail();
            TargetModel.PaymentDate = Utility.GetDate();

            SetUserViewRight();
            LoadCustomerAndSupplier();
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy)
                {
                    ModelCanBeSaved = false;
                }

                base.OnPropertyChanged("IsBusy");
            }
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

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                OnPropertyChanged("People");
            }
        }
      
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged("Person");
                PeopleSelectionChanged(_person);
            }
        }

        public decimal TotalAmountPayable
        {
            get { return _totalAmountPayable; }
            set
            {
                _totalAmountPayable = value;
                OnPropertyChanged("TotalAmountPayable");
            }
        }
        public decimal TotalAmountPaid
        {
            get { return _totalAmountPaid; }
            set
            {
                _totalAmountPaid = value;
                OnPropertyChanged("TotalAmountPaid");
            }
        }
        public decimal TotalBalance
        {
            get { return _totalBalance; }
            set
            {
                _totalBalance = value;
                OnPropertyChanged("TotalBalance");
            }
        }

        private void LoadCustomerAndSupplier()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadPeopleCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _businessFacade.GetAllCustomerAndSupplier();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadPeopleCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    List<Person> people = e.Result as List<Person>;
                    PopulatePeople(people);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        
        protected virtual void OnSaveCommand()
        {
            try
            {
                ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection;
                if (paymentDetails == null || paymentDetails.Count == 0)
                {
                    Utility.DisplayMessage("No payment details found! Please add payment details");
                    return;
                }

                foreach (PaymentDetail paymentDetail in paymentDetails)
                {
                    paymentDetail.Payment = Payment;
                }

                IsBusy = true;
                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = _businessFacade.UpdatePaymentDetail(new List<PaymentDetail>(paymentDetails));
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ModelCanBeSaved = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    ModelCanBeSaved = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                bool modified = false;
                if (e.Result != null)
                {
                    modified = (bool)e.Result;
                }

                if (Person != null && Person.Id > 0)
                {
                    PeopleSelectionChanged(Person);
                }

                OnSaveCommandHelper(modified);
            }
            catch(Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Utility.DisplayMessage(message);
            }
        }

        private void OnSaveCommandHelper(bool done)
        {
            try
            {
                _dispatcher.Invoke(() =>
                           {
                               if (done)
                               {
                                   Clear();
                                   Utility.DisplayMessage("Payment details has been successfully modified");
                               }
                               else
                               {
                                   Utility.DisplayMessage("Payment details modification failed! Please try again");
                               }
                           });
            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Utility.DisplayMessage(message);
            }
        }

        protected void PopulatePeople(List<Person> people)
        {
            try
            {
                if (people == null)
                {
                    people = new List<Person>();
                }

                _dispatcher.Invoke(() =>
                           {
                               //List<Person> persons = null;
                               if (people.Count > 0)
                               {
                                   //persons = people.Where(p => p.Type.Id == (int)PoknoPersonType.Supplier || p.Type.Id == (int)PoknoPersonType.Customer).ToList();
                                   people.Insert(0, new Person() { Name = "<< Select Person >>" });
                               }

                               People = new ObservableCollection<Person>(people);
                               Person = People.FirstOrDefault();
                           });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PeopleSelectionChanged(Person person)
        {
            try
            {
                if (person != null && person.Id > 0)
                {
                    using(_worker = new BackgroundWorker())
                    {
                        _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnPeopleSelectionChangedCompleted);
                        _worker.DoWork += (s, e) =>
                            {
                                List<Model.Payment> payments = _paymentService.LoadTransactionByPerson(person);
                                List<StockPurchasePayment> stockPurchasePayments = _stockPurchaseBatchService.LoadSupplierPaymentHistory(person);

                                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                                dictionary["stockPurchasePayments"] = stockPurchasePayments;
                                dictionary["payments"] = payments;

                                e.Result = dictionary;
                            };
                        _worker.RunWorkerAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnPeopleSelectionChangedCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }
                
                List<Model.Payment> payments = null;
                List<StockPurchasePayment> stockPurchasePayments = null;

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    stockPurchasePayments = (List<StockPurchasePayment>)dictionary["stockPurchasePayments"];
                    payments = (List<Model.Payment>)dictionary["payments"];
                }

                PopulateSupplierPaymentHistory(stockPurchasePayments);
                PopulatePaymentTransaction(payments);
                OnClearCommand();

                if (payments == null || payments.Count <= 0 && Person != null)
                {
                    Utility.DisplayMessage("No payment is currently associated with '" + Person.Name + "'");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected override void OnClearCommand()
        {
            try
            {
                base.OnClearCommand();
                if (SupplierPaymentHistory != null)
                {
                    SupplierPaymentHistory.MoveCurrentTo(null);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected void PopulatePaymentTransaction(List<Model.Payment> payments)
        {
            try
            {
                if (payments == null)
                {
                    payments = new List<Model.Payment>();
                }

                _dispatcher.Invoke(() =>
                {
                    Payments = new ObservableCollection<Model.Payment>(payments);
                    if (payments.Count > 0)
                    {
                        payments.Insert(0, new Model.Payment() { Id = 0 });

                        Payments = new ObservableCollection<Model.Payment>(payments);
                        Payment = Payments.FirstOrDefault();
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulateSupplierPaymentHistory(List<StockPurchasePayment> stockPurchasePayments)
        {
            try
            {
                if (stockPurchasePayments == null)
                {
                    stockPurchasePayments = new List<StockPurchasePayment>();
                }

                _dispatcher.Invoke(() =>
                {
                    SupplierPaymentHistory = new ListCollectionView(new ObservableCollection<StockPurchasePayment>(stockPurchasePayments));
                    SupplierPaymentHistory.MoveCurrentTo(null);
                    SupplierPaymentHistory.CurrentChanged += (s, e) =>
                    {
                        if (SupplierPaymentHistory.CurrentItem != null)
                        {
                            StockPurchasePayment stockPurchasePayment = SupplierPaymentHistory.CurrentItem as StockPurchasePayment;
                            if (stockPurchasePayment != null)
                            {
                                Payment = stockPurchasePayment.Payment;
                            }

                            MoveToSelectedPayment();
                            LoadAllPaymentType();

                            if (Payment != null && Payment.Id > 0)
                            {
                                LoadPaymentDetailsByPayment(Payment);
                            }
                        }
                    };

                    if (stockPurchasePayments.Count > 0)
                    {
                        List<StockPurchasePayment> payments = stockPurchasePayments.GroupBy(x => new { x.Payment.Id }).Select(s => new StockPurchasePayment
                        {
                            AmountPayable = s.First().AmountPayable,
                        }).ToList();
                                                
                        PropertyGroupDescription groupDescription = new PropertyGroupDescription("TransactionDate");
                        SupplierPaymentHistory.GroupDescriptions.Add(groupDescription);

                        TotalAmountPayable = payments.Sum(a => a.AmountPayable);
                        TotalAmountPaid = stockPurchasePayments.Sum(a => a.AmountPaid);
                        TotalBalance = TotalAmountPayable - TotalAmountPaid;  //stockPurchasePayments.Sum(a => a.Balance);
                    }
                    else
                    {
                        TotalAmountPayable = 0;
                        TotalAmountPaid = 0;
                        TotalBalance = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
              
        private void MoveToSelectedPayment()
        {
            try
            {
                ObservableCollection<Model.Payment> payments = Payments;
                if (Payments != null && Payments.Count > 0)
                {
                    Payment = payments.Where(p => p.Id == Payment.Id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void Clear()
        {
            try
            {
                base.Clear();

                Person = new Person();
                Payment = new Model.Payment();

                if (SupplierPaymentHistory != null)
                {
                    SupplierPaymentHistory.MoveCurrentTo(null);
                }

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

        protected override void SetCurrentTargetCollectionHelper()
        {
            try
            {
                PaymentDetail paymentDetail = TargetCollection.CurrentItem as PaymentDetail;
                if (paymentDetail != null)
                {
                    if (paymentDetail.Id <= 0)
                    {
                        UpdateViewState(Edit.Mode.Selected);
                    }
                    else
                    {
                        RefreshModelCollection();
                        Utility.DisplayMessage("You cannot remove this existing payment! The details is as follows:\n\nAmount Paid: " + paymentDetail.AmountPaid + "\nPayment Mode: " + paymentDetail.PaymentType.Name + "\nDate Paid: " + paymentDetail.PaymentDate.ToString("dd/MM/yyyy") + "\n\nfrom the list!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void UpdateViewState(Edit.Mode uiState)
        {
            try
            {
                ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection;

                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            if (paymentDetails != null && paymentDetails.Count > 0)
                            {
                                ModelCanBeCleared = true;
                            }
                            else
                            {
                                ModelCanBeCleared = false;
                            }

                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;
                            ModelCanBeSaved = false;

                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            base.UpdateViewState(Edit.Mode.Adding);
                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = true;
                            ModelCanBeCleared = true;
                            ModelCanBeSaved = false;

                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



        
    }
    

}
