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

using System.Linq;
using Pokno.Model.Model;
using Pokno.Infrastructure.Models;
using Pokno.Account.Interfaces;
using Prism.Commands;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;
using Pokno.Model;
using System.Collections.Generic;
using Pokno.Service;

namespace Pokno.Account.ViewModels
{
    public class DailyExpensesViewModel : ObservableCollectionManagerBase<ExpensesDetail>
    {
        private Dispatcher _dispatcher;

        private IBusinessFacade _service;
        private BackgroundWorker _worker;

        private bool _canEdit;
        private bool _isBusy;
        private bool _isSaving;
        private int _recordCount;
        private Expenses _expenses;
        private Expenses _oldExpenses;
        private DateTime _expensesDate;
        private decimal _totalExpenses;
        private string _financialStatus;
        private decimal _financialStatusValue;
        private decimal _financialStatusControl;
        
        private PaymentType _paymentType;
        private ExpensesCategory _expensesCategory;
        private ObservableCollection<PaymentType> _paymentTypes;
        private ObservableCollection<ExpensesCategory> _expensesCategories;
        
        public DailyExpensesViewModel(IBusinessFacade service) 
        {
            _service = service;
            Initialize();
        }
                        
        public DelegateCommand SearchCommand { get; private set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                base.OnPropertyChanged("IsBusy");
            }
        }
        public bool IsSaving
        {
            get { return _isSaving; }
            set
            {
                _isSaving = value;
                base.OnPropertyChanged("IsSaving");

                _isSaving = value;
                if (_isSaving)
                {
                    ModelCanBeSaved = false;
                }
            }
        }
        public int RecordCount 
        {
            get { return _recordCount; }
            set
            {
                _recordCount = value;
                base.OnPropertyChanged("RecordCount");
            }
        }
        public string TabCaption
        {
            get { return "Daily Expenses"; }
        }
        public decimal TotalExpenses
        {
            get { return _totalExpenses; }
            set
            {
                _totalExpenses = value;
                base.OnPropertyChanged("TotalExpenses");
            }
        }
        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                _canEdit = value;
                base.OnPropertyChanged("CanEdit");
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
        public ObservableCollection<ExpensesCategory> ExpensesCategories
        {
            get { return _expensesCategories; }
            set
            {
                _expensesCategories = value;
                base.OnPropertyChanged("ExpensesCategories");
            }
        }
        public ExpensesCategory ExpensesCategory
        {
            get { return _expensesCategory; }
            set
            {
                _expensesCategory = value;
                base.OnPropertyChanged("ExpensesCategory");
            }
        }
        public PaymentType PaymentType
        {
            get { return _paymentType; }
            set
            {
                _paymentType = value;
                base.OnPropertyChanged("PaymentType");
            }
        }
            
        public DateTime ExpensesDate
        {
            get { return _expensesDate; }
            set
            {
                _expensesDate = value;
                base.OnPropertyChanged("ExpensesDate");
            }
        }
        public string FinancialStatus
        {
            get { return _financialStatus; }
            set
            {
                _financialStatus = value;
                base.OnPropertyChanged("FinancialStatus");
            }
        }
        public decimal FinancialStatusValue
        {
            get { return _financialStatusValue; }
            set
            {
                _financialStatusValue = value;
                base.OnPropertyChanged("FinancialStatusValue");
            }
        }
        public decimal FinancialStatusControl
        {
            get { return _financialStatusControl; }
            set
            {
                _financialStatusControl = value;
                base.OnPropertyChanged("FinancialStatusControl");
            }
        }
        public Expenses Expenses
        {
            get { return _expenses; }
            set
            {
                _expenses = value;
                base.OnPropertyChanged("Expenses");
            }
        }
        public Expenses OldExpenses
        {
            get { return _oldExpenses; }
            set
            {
                _oldExpenses = value;
                base.OnPropertyChanged("OldExpenses");
            }
        }

        private void Initialize()
        {
            try
            {
                _dispatcher = Application.Current.Dispatcher;
                collectionManager = new ObservableCollectionManager<ExpensesDetail>();
                TargetCollection = new ListCollectionView(new ObservableCollection<ExpensesDetail>());

                ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
                RemoveCommand = new DelegateCommand(OnRemoveCommand, CanRemove);
                SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
                AddCommand = new DelegateCommand(OnAddCommand, CanAdd);
                SearchCommand = new DelegateCommand(OnSearchCommand);

                IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupDailyExpenses;

                Expenses = new Expenses();
                OldExpenses = new Expenses();
                TargetModel = new ExpensesDetail();
                TargetModel.Expenses = Expenses;
                ExpensesDate = Utility.GetDate();
                Expenses.AdditionalCash = 0;

                LoadInitialisationData();

                //UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void GetExpensesByDate(DateTime expensesDate)
        {
            try
            {
                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnGetExpensesByDateCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.GetExpensisByDate(expensesDate);
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnGetExpensesByDateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                Expenses expenses = e.Result as Expenses;
                LoadExpensesByDate(expenses);

                if (expenses == null || expenses.Details == null || expenses.Details.Count <= 0)
                {
                    Utility.DisplayMessage("No expenses found for the selected date '" + ExpensesDate.ToString("dd/MM/yyyy") + "'!");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadInitialisationData()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitializeCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<ExpensesCategory> expensesCategories = _service.GetAllExpensesCategories();
                        List<PaymentType> paymentTypes = _service.GetAllPaymentTypes();
                        Expenses expenses = _service.GetExpensisByDate(ExpensesDate);

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["expensesCategories"] = expensesCategories;
                        dictionary["paymentTypes"] = paymentTypes;
                        dictionary["expenses"] = expenses;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnInitializeCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                Expenses expenses = null;
                List<PaymentType> paymentTypes = null;
                List<ExpensesCategory> expensesCategories = null;
                                     
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    expensesCategories = (List<ExpensesCategory>)dictionary["expensesCategories"];
                    paymentTypes = (List<PaymentType>)dictionary["paymentTypes"];
                    expenses = (Expenses)dictionary["expenses"];
                }

                LoadExpensesByDate(expenses);
                PopulatePaymentType(paymentTypes);
                PopulateExpensesCategory(expensesCategories);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulateExpensesCategory(List<ExpensesCategory> expensesCategories)
        {
            try
            {
                //List<ExpensesCategory> expensesCategories = _service.GetAllExpensesCategories();

                if (expensesCategories == null)
                {
                    expensesCategories = new List<ExpensesCategory>();
                }

                if (expensesCategories.Count > 0)
                {
                    expensesCategories.Insert(0, new ExpensesCategory() { Id = 0, Name = "<< Select >>" });
                }

                ExpensesCategories = new ObservableCollection<ExpensesCategory>(expensesCategories);
                ExpensesCategory = ExpensesCategories.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulatePaymentType(List<PaymentType> paymentTypes)
        {
            try
            {
                //List<PaymentType> paymentTypes = _service.GetAllPaymentTypes();

                if (paymentTypes == null)
                {
                    paymentTypes = new List<PaymentType>();
                }

                if (paymentTypes.Count > 0)
                {
                    paymentTypes.Insert(0, new PaymentType() { Id = 0, Name = "<< Select >>" });
                }

                PaymentTypes = new ObservableCollection<PaymentType>(paymentTypes);
                PaymentType = PaymentTypes.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadExpensesByDate(Expenses expenses)
        {
            try
            {
                //Expenses expenses = _service.GetExpensisByDate(ExpensesDate);

                _dispatcher.Invoke
                           (() =>
                           {
                               Expenses = expenses;
                               OldExpenses.Id = expenses.Id;
                               OldExpenses.CashAtHand = expenses.CashAtHand;
                               OldExpenses.AdditionalCash = expenses.AdditionalCash;

                               collectionManager.Collection = new ObservableCollection<ExpensesDetail>();
                               //TargetCollection = new ListCollectionView(new ObservableCollection<ExpensesDetail>());

                               if (Expenses != null)
                               {
                                   //Expenses.PropertyChanged += new PropertyChangedEventHandler(Expenses_PropertyChanged);
                                   if (Expenses.Details != null && Expenses.Details.Count > 0)
                                   {
                                       collectionManager.Collection = new ObservableCollection<ExpensesDetail>(Expenses.Details);
                                       TargetCollection = new ListCollectionView(collectionManager.Collection);

                                       SetCurrentTargetCollection(collectionManager.Collection);
                                       TargetCollection.MoveCurrentTo(null);

                                       TotalExpenses = Expenses.Details.Sum(ed => ed.Amount);
                                   }
                               }

                               base.RefreshModelCollection();
                               base.IsModelExist(collectionManager.Collection);
                               if (Expenses.Details != null && Expenses.Details.Count > 0)
                               {
                                   UpdateViewState(Edit.Mode.Editing);
                               }
                               else
                               {
                                   UpdateViewState(Edit.Mode.Loaded);
                               }

                               UpdateSummary();
                           });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override ExpensesDetail GetNewModel()
        {
            try
            {
                ExpensesDetail newExpensisDetail = new ExpensesDetail();
                newExpensisDetail.CollectedBy = TargetModel.CollectedBy;
                newExpensisDetail.Amount = TargetModel.Amount;
                newExpensisDetail.Purpose = TargetModel.Purpose;
                newExpensisDetail.PaymentMode = PaymentType;
                newExpensisDetail.Category = ExpensesCategory;
                               
                return newExpensisDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }
               
        //private void Expenses_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (e.PropertyName.Equals("AdditionalCash") || e.PropertyName.Equals("CashAtHand"))
        //        {
        //            UpdateSummary();
        //            ProcessFinancialStatus(Expenses.CashAtHand);

        //            if ((Expenses.AdditionalCash != OldExpenses.AdditionalCash) || (Expenses.CashAtHand != OldExpenses.CashAtHand))
        //            {
        //                if (Expenses.Details != null && Expenses.Details.Count > 0)
        //                {
        //                    ModelCanBeSaved = true;
        //                }
        //            }
        //            else
        //            {
        //                ModelCanBeSaved = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void OnSearchCommand()
        {
            try
            {
                if (InvalidDate())
                {
                    return;
                }

                GetExpensesByDate(ExpensesDate);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool InvalidDate()
        {
            try
            {
                if (ExpensesDate == null || DateTime.MinValue == ExpensesDate)
                {
                    Utility.DisplayMessage("Please select expenses date!");
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void OnRemoveCommand()
        {
            try
            {
                int index = TargetCollection.CurrentPosition;
                if (index > -1)
                {
                    collectionManager.Collection.RemoveAt(index);
                    RefreshModelCollection();

                    UpdateSummary();
                }
                else
                {
                    Utility.DisplayMessage("No selection made! Please select a row for removal");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void OnAddCommand()
        {
            try
            {
                if (InvalidRequiredDetailsEntered())
                {
                    return;
                }

                UpdateModels();
                UpdateSummary();
                ClearUserInputSection();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage("Error Occurred! " + ex.Message);
            }
        }

        private void ClearUserInputSection()
        {
            try
            {
                TargetModel = new ExpensesDetail();
                if (ExpensesCategories != null)
                {
                    ExpensesCategory = ExpensesCategories.FirstOrDefault();
                }
                if (PaymentTypes != null)
                {
                    PaymentType = PaymentTypes.FirstOrDefault();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        private bool InvalidRequiredDetailsEntered()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TargetModel.CollectedBy))
                {
                    Utility.DisplayMessage("Please enter benefiary!");
                    return true;
                }
                else if (ExpensesCategory == null || ExpensesCategory.Id <= 0)
                {
                    Utility.DisplayMessage("Please select Expenses Category!");
                    return true;
                }
                else if (PaymentType == null || PaymentType.Id <= 0)
                {
                    Utility.DisplayMessage("Please select Payment Mode!");
                    return true;
                }
                else if (TargetModel.Amount <= 0)
                {
                    Utility.DisplayMessage("Please the amount collected!");
                    return true;
                }

                ObservableCollection<ExpensesDetail> expensesDetails = (ObservableCollection<ExpensesDetail>)TargetCollection.SourceCollection;
                ExpensesDetail expensesDetail = expensesDetails.Where(e => e.Category.Id == ExpensesCategory.Id).SingleOrDefault();
                if (expensesDetail != null)
                {
                    Utility.DisplayMessage(ExpensesCategory.Name + " already exist on the list!");
                    return true;
                }
                              
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdateSummary()
        {
            try
            {
                if (TargetCollection != null)
                {
                    ObservableCollection<ExpensesDetail> expensesDetails = (ObservableCollection<ExpensesDetail>)TargetCollection.SourceCollection;
                    TotalExpenses = expensesDetails.Sum(a => a.Amount);

                    RecordCount = expensesDetails.Count;
                }
                else
                {
                    RecordCount = 0;
                }

                //ProcessFinancialStatus(Expenses.CashAtHand);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void ProcessFinancialStatus(decimal cashAtHand)
        //{
        //    try
        //    {
        //        if (Expenses != null)
        //        {
        //            Expenses.ClosingBalance = (Expenses.OpeningBalace + Expenses.TotalSalesAmount + Convert.ToDecimal(Expenses.AdditionalCash)) - TotalExpenses;
        //            if (Expenses.ClosingBalance == cashAtHand)
        //            {
        //                FinancialStatus = "Balanced - ";
        //            }
        //            else if (Expenses.ClosingBalance > cashAtHand)
        //            {
        //                FinancialStatus = "Shortage of - ";
        //            }
        //            else
        //            {
        //                FinancialStatus = "Suplus of - ";
        //            }

        //            FinancialStatusValue = Math.Abs(Expenses.ClosingBalance - cashAtHand);
        //            FinancialStatusControl = Expenses.ClosingBalance - cashAtHand;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}
       
        private void OnClearCommand()
        {
            try
            {
                base.ClearTargetCollection();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void OnSaveCommand()
        {
            try
            {
                if (InvalidEntry())
                {
                    return;
                }

                ObservableCollection<ExpensesDetail> expensesDetails = (ObservableCollection<ExpensesDetail>)TargetCollection.SourceCollection;
                Expenses.CreatedBy = Utility.LoggedInUser;
                Expenses.Details = new List<ExpensesDetail>(expensesDetails);
                Expenses.ExpensesDate = ExpensesDate;
                Expenses.DateCreated = Utility.GetDate();

                IsSaving = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.AddExpensis(Expenses);
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsSaving = false;
                ModelCanBeSaved = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsSaving = false;

                if (e.Error != null)
                {
                    ModelCanBeSaved = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                bool saved = (bool)e.Result;
                OnSaveCommandHelper(saved);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
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
                                   ClearUI();
                                   Utility.DisplayMessage("Expenses has been successfully saved");
                               }
                               else
                               {
                                   Utility.DisplayMessage("Expenses save operation failed!");
                               }
                           });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearUI()
        {
            try
            {
                TotalExpenses = 0;
                Expenses = new Expenses();
                base.ClearTargetCollection();
                ExpensesDate = Utility.GetDate();

                FinancialStatus = "";
                FinancialStatusValue = 0;
                FinancialStatusControl = 0;

                UpdateViewState(Edit.Mode.Loaded);
                if (PaymentTypes != null && PaymentTypes.Count > 0)
                {
                    PaymentType = PaymentTypes.FirstOrDefault();
                }
                if (ExpensesCategories != null && ExpensesCategories.Count > 0)
                {
                    ExpensesCategory = ExpensesCategories.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool InvalidEntry()
        {
            try
            {
                if (Expenses == null)
                {
                    Utility.DisplayMessage("No expenses found!");
                    return true;
                }

                return false;
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
                base.UpdateViewState(uiState);

                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;
                            ModelCanBeCleared = false;
                            ModelCanBeSaved = false;

                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;

                            if (TargetCollection != null)
                            {
                                ObservableCollection<ExpensesDetail> models = (ObservableCollection<ExpensesDetail>)TargetCollection.SourceCollection;
                                if (models != null && models.Count > 0)
                                {
                                    ModelCanBeSaved = true;
                                    ModelCanBeCleared = true;
                                }
                                else
                                {
                                    ModelCanBeSaved = false;
                                    ModelCanBeCleared = false;
                                }
                            }

                            break;
                        }
                }

                CanEdit = true;

                //DateTime today = Utility.GetDate();
                //if (Expenses.ExpensesDate.Date < today.Date && ExpensesDate.Date < today.Date)
                //{
                //    CanEdit = false;
                //    ModelCanBeAdded = false;
                //    ModelCanBeRemoved = false;
                //    ModelCanBeCleared = false;
                //    ModelCanBeSaved = false;
                //}

            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



    }



}
