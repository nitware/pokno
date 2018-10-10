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

using System.ComponentModel;
using Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infratructure.Services;
using Pokno.Store.Interfaces;
using Pokno.Model;
using Pokno.Service;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class EditSoldStockViewModel : BaseSoldStockViewModel
    {
        private bool _isItemPrintable;
        private bool _isItemRemovable;
        private int _cartDataGridSelectedIndex;
        private bool _uiCanBeCleared;
        private bool _isBusy;

        public EditSoldStockViewModel(IEventAggregator eventAggregator, IBusinessFacade businessFacade, ISoldStockService service, ISetupService<Person> personService, ISetupService<PaymentType> paymentTypeService, IPaymentService paymentService)
            : base(businessFacade, service, personService, paymentTypeService, paymentService)
        {
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
            PrintCommand = new DelegateCommand(OnPrintCommand, CanPrint);
            ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
            ClearUiCommand = new DelegateCommand(OnClearUiCommand, CanClearUi);
            RemoveSoldItemCommand = new DelegateCommand(OnRemoveSoldItemCommand, CanRemoveSoldItemCommand);

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanEditSoldStock;
            eventAggregator.GetEvent<SalesEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        private bool CanClearUi()
        {
            return UiCanBeCleared;
        }

        private void OnClearUiCommand()
        {
            try
            {
                RefreshUi();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public DelegateCommand ClearUiCommand { get; private set; }
        public DelegateCommand RemoveSoldItemCommand { get; private set; }
        public DelegateCommand PrintCommand { get; protected set; }

        private bool IsView(UI.Sales ui)
        {
            return ui == UI.Sales.EditSoldItems;
        }

        public string TabCaption
        {
            get { return "Edit Sold Stock"; }
        }
        private bool UiCanBeCleared
        {
            get { return _uiCanBeCleared; }
            set
            {
                _uiCanBeCleared = value;
                ClearUiCommand.RaiseCanExecuteChanged();
            }
        }
        private bool IsItemPrintable
        {
            get { return _isItemPrintable; }
            set
            {
                _isItemPrintable = value;
                PrintCommand.RaiseCanExecuteChanged();
            }
        }
        private bool IsItemRemovable
        {
            get { return _isItemRemovable; }
            set
            {
                _isItemRemovable = value;
                RemoveSoldItemCommand.RaiseCanExecuteChanged();
            }
        }
       
        public int CartDataGridSelectedIndex
        {
            get { return _cartDataGridSelectedIndex; }
            set
            {
                _cartDataGridSelectedIndex = value;
                base.OnPropertyChanged("CartDataGridSelectedIndex");
            }
        }
        
        private bool CanRemoveSoldItemCommand()
        {
            return IsItemRemovable;
        }
        private bool CanPrint()
        {
            return IsItemPrintable;
        }

        private void OnPrintCommand()
        {
            try
            {
                //if (OutgoingStockBatch != null && OutgoingStockBatch.Id > 0)
                //{
                //    Utility.DisplayReport(Utility.RootWebAddress + "/ReportPresenter/salesInvoice.aspx?ssbi=" + OutgoingStockBatch.Id);
                //}
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
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
        private void OnSaveCommand()
        {
            try
            {
                if (IncorrectDataDetected())
                {
                    return;
                }

                List<SoldStock> soldStocks = StocksToRemove;
                OutgoingStockBatch.SoldStocks = new List<SoldStock>(soldStocks);

                OutgoingStockBatch.Payment.Details = new List<PaymentDetail>((ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection);
                if (Customer == null || Customer.Id <= 0)
                {
                    Customer = null;
                    OutgoingStockBatch.Customer = null;
                }
                else
                {
                    OutgoingStockBatch.Customer = Customer;
                }

                OutgoingStockBatch.Payment.AmountPayable = OutgoingStockBatch.Payment.Details.Sum(p => p.AmountPaid);
                OutgoingStockBatch.SoldStocks = StocksToRemove;
                OnSaveCommandBackgroundWorker();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommandBackgroundWorker()
        {
            try
            {
                IsBusy = true;

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.Modify(OutgoingStockBatch);
                        
                        //if (isModifying)
                        //{
                        //    e.Result = _service.Modify(OutgoingStockBatch);
                        //}
                        //else
                        //{
                        //    e.Result = _service.Remove(OutgoingStockBatch);
                        //}
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
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

                if (e.Result != null)
                {
                    bool done = (bool)e.Result;
                    OnSaveCommandHelper(done);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool IncorrectDataDetected()
        {
            const string TRY_AGAIN = "Please try again. And contact your system administrator after three unsuccessful trials.";

            try
            {
                if (OutgoingStockBatch == null || OutgoingStockBatch.Id <= 0)
                {
                    Utility.DisplayMessage("Sold Stock Batch cannot be null! " + TRY_AGAIN);
                    return true;
                }
                else if (StocksToRemove == null || StocksToRemove.Count <= 0)
                {
                    Utility.DisplayMessage("Sold item list has not be modified! Please remove sold item(s) from Transaction Summary section to continue");
                    return true;
                }
                else if (OutgoingStockBatch.Payment == null || OutgoingStockBatch.Payment.Id <= 0)
                {
                    Utility.DisplayMessage("Payment not set! " + TRY_AGAIN);
                    return true;
                }

                if (TargetCollection == null)
                {
                    Utility.DisplayMessage("Payment Tray cannot be empty!");
                    return true;
                }
                else
                {
                    ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection;
                    if (paymentDetails == null || paymentDetails.Count <= 0)
                    {
                        Utility.DisplayMessage("Payment details not set!");
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

        protected void OnSaveCommandHelper(bool done)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (done)
                    {
                        LoadAllSoldStockBatch();
                        OutgoingStocks = new ObservableCollection<SoldStock>();

                        RefreshUi();
                        Utility.DisplayMessage("Sold stock modification operation was successful");
                    }
                    else
                    {
                        Utility.DisplayMessage("Sold stock modification operation failed! Please try again");
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnRemoveSoldItemCommand()
        {
            try
            {
                if (OutgoingStocks == null || OutgoingStocks.Count <= 0)
                {
                    return;
                }

                List<SoldStock> stocksToRemove = OutgoingStocks.Where(s => s.Returned == true).ToList();
                List<SoldStock> selectedStocks = OutgoingStocks.Where(s => s.Returned == false).ToList();

                if (stocksToRemove == null || stocksToRemove.Count <= 0)
                {
                    Utility.DisplayMessage("No selection made! Please select a row");
                    return;
                }

                SaveStocksToRemove(stocksToRemove);

                OutgoingStocks = new ObservableCollection<SoldStock>(selectedStocks);
                collectionManager.Collection.Clear();
                RefreshModelCollection();

                ComputeBalance();
                UpdateViewState(Edit.Mode.Editing);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SaveStocksToRemove(List<SoldStock> stocksToRemove)
        {
            try
            {
                if (stocksToRemove != null && stocksToRemove.Count > 0)
                {
                    if (StocksToRemove == null)
                    {
                        StocksToRemove = new List<SoldStock>();
                    }

                    StocksToRemove.AddRange(stocksToRemove);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void UpdateViewState(Edit.Mode viewState)
        //protected override void UpdateButtons(Edit.Mode viewState)
        {
            try
            {
                UpdateClearUiButton();
                base.UpdateViewState(viewState);

                switch (viewState)
                {
                    case Edit.Mode.Loaded:
                        {
                            IsItemPrintable = false;
                            IsItemRemovable = false;

                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            if (OutgoingStocks != null && OutgoingStocks.Count > 0)
                            {
                                List<SoldStock> selectedStocks = OutgoingStocks.Where(s => s.Returned == true).ToList();
                                if (selectedStocks != null && selectedStocks.Count > 0 && selectedStocks.Count < OutgoingStocks.Count)
                                {
                                    IsItemRemovable = true;
                                    IsItemPrintable = true;
                                    
                                    break;
                                }
                            }

                            IsItemRemovable = false;
                            IsItemPrintable = true;

                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            UpdateButtonsHelper();
                            break;
                        }
                    case Edit.Mode.Editing:
                        {
                            UpdateButtonsHelper();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdateClearUiButton()
        {
            try
            {
                ObservableCollection<PaymentDetail> paymentDetails = null;
                if (TargetCollection != null)
                {
                    paymentDetails = (ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection;
                }

                if (OutgoingStocks != null && OutgoingStocks.Count > 0 || paymentDetails != null && paymentDetails.Count > 0)
                {
                    UiCanBeCleared = true;
                }
                else
                {
                    UiCanBeCleared = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdateButtonsHelper()
        {
            try
            {
                ObservableCollection<SoldStock> outgoingStocks = null;
                ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)TargetCollection.SourceCollection;

                if (OutgoingStocks != null)
                {
                    outgoingStocks = OutgoingStocks;
                }

                if (outgoingStocks != null && outgoingStocks.Count > 0)
                {
                    if (paymentDetails != null && paymentDetails.Count > 0)
                    {
                        ModelCanBeSaved = true;
                        IsItemPrintable = true;
                        IsItemRemovable = false;

                    }
                    else
                    {
                        ModelCanBeSaved = false;
                        IsItemPrintable = false;
                        IsItemRemovable = false;
                    }
                }
                else
                {
                    ModelCanBeSaved = false;
                    IsItemRemovable = false;
                    IsItemPrintable = false;
                }

                if (StocksToRemove == null || StocksToRemove.Count <= 0)
                {
                    ModelCanBeSaved = false;
                }
                else
                {
                    ModelCanBeSaved = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        



       


    }

}
