using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.ViewModel;
using Prism.Commands;
using Pokno.Infrastructure.Models;
using Pokno.Service;
using Pokno.Model;
using System.Collections.ObjectModel;
using Pokno.Model.Model;
using System.ComponentModel;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows;

namespace Pokno.Store.ViewModels
{
    public class StockReturnViewModel : BaseApplicationViewModel
    {
        private Dispatcher _dispatcher;

        private string _invoiceNumber;
        private bool _findByDateRange;
        private bool _findByReceiptNumber;
        private DateTime _fromDate;
        private DateTime _toDate;
        private DateTime _dateReturned;
        private string _returnReason;
        private string _remarks;
        private bool _isBusy;
        private BitmapImage _searchIcon;
        private StockState _stockState;
        private ObservableCollection<StockState> _stockStates;
        private ObservableCollection<StockReturnAction> _actions;
        public StockReturnAction _action;
        
        private ObservableCollection<SoldStockBatch> _soldStockBatches;
        private ObservableCollection<SoldItemReturn> _soldStocks;
        private SoldStockBatch _soldStockBatch;
        private SoldItemReturn _soldStock;
        private int _selectedItemCount;
        private int _recordCount;

        //private bool _itemIsReturnable;
        private readonly IBusinessFacade _service;
        private BackgroundWorker _worker;

        public StockReturnViewModel(IEventAggregator eventAggregator, IBusinessFacade service)
        {
            _service = service;
            _dispatcher = Application.Current.Dispatcher;

            FindCommand = new DelegateCommand(OnFindCommand, CanFind);
            ReturnCommand = new DelegateCommand(OnReturnCommand, CanReturnItem);

            ToDate = Utility.GetDate();
            FromDate = Utility.GetDate();
            DateReturned = Utility.GetDate();
            FindByReceiptNumber = true;

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanReturnStock;
            SearchIcon = Utility.SetImageSource(Utility.ApplicationRoot + @"Images\search.jpg");
            eventAggregator.GetEvent<ReturnEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
            OnInitialise(UI.Returns.Return);
        }

        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand ReturnCommand { get; private set; }
        public List<StoreStock> StocksOnShelf { get; set; }
        public List<SoldStock> SoldItems { get; set; }

        private bool IsView(UI.Returns ui)
        {
            return ui == UI.Returns.Return;
        }
        
        public string TabCaption
        {
            get { return "Stock Return"; }
        }
        public BitmapImage SearchIcon
        {
            get { return _searchIcon; }
            set
            {
                _searchIcon = value;
                base.OnPropertyChanged("SearchIcon");
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
        public int SelectedItemCount
        {
            get { return _selectedItemCount; }
            set
            {
                _selectedItemCount = value;
                base.OnPropertyChanged("SelectedItemCount");
            }
        }
        //public bool ItemIsReturnable
        //{
        //    get { return _itemIsReturnable; }
        //    set
        //    {
        //        _itemIsReturnable = value;
        //        if (ReturnCommand != null)
        //        {
        //            ReturnCommand.RaiseCanExecuteChanged();
        //        }
        //    }
        //}
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                //if (_isBusy)
                //{
                //    ItemIsReturnable = false;
                //}

                base.OnPropertyChanged("IsBusy");
                ReturnCommand.RaiseCanExecuteChanged();
            }
        }

        public bool FindByReceiptNumber
        {
            get { return _findByReceiptNumber; }
            set
            {
                _findByReceiptNumber = value;
                base.OnPropertyChanged("FindByReceiptNumber");
                FindCommand.RaiseCanExecuteChanged();
            }
        }

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set
            {
                _invoiceNumber = value;
                base.OnPropertyChanged("InvoiceNumber");
                FindCommand.RaiseCanExecuteChanged();
            }
        }
        public bool FindByDateRange
        {
            get { return _findByDateRange; }
            set
            {
                _findByDateRange = value;
                base.OnPropertyChanged("FindByDateRange");
                FindCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                base.OnPropertyChanged("FromDate");
                FindCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                base.OnPropertyChanged("ToDate");
                FindCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime DateReturned
        {
            get { return _dateReturned; }
            set
            {
                _dateReturned = value;
                base.OnPropertyChanged("DateReturned");
                ReturnCommand.RaiseCanExecuteChanged();
            }
        }
        public ObservableCollection<StockState> StockStates
        {
            get { return _stockStates; }
            set
            {
                _stockStates = value;
                base.OnPropertyChanged("StockStates");
            }
        }
        public StockState StockState
        {
            get { return _stockState; }
            set
            {
                _stockState = value;
                base.OnPropertyChanged("StockState");
            }
        }

        public ObservableCollection<StockReturnAction> Actions
        {
            get { return _actions; }
            set
            {
                _actions = value;
                base.OnPropertyChanged("Actions");
            }
        }
        public StockReturnAction Action
        {
            get { return _action; }
            set
            {
                _action = value;
                base.OnPropertyChanged("Action");
            }
        }

        public ObservableCollection<SoldStockBatch> SoldStockBatches
        {
            get { return _soldStockBatches; }
            set
            {
                _soldStockBatches = value;
                base.OnPropertyChanged("SoldStockBatches");
            }
        }
        public SoldStockBatch SoldStockBatch
        {
            get { return _soldStockBatch; }
            set
            {
                _soldStockBatch = value;
                base.OnPropertyChanged("SoldStockBatch");
                ReturnCommand.RaiseCanExecuteChanged();

                PopulateSaleTransactionList(_soldStockBatch);
            }
        }
        public ObservableCollection<SoldItemReturn> SoldStocks
        {
            get { return _soldStocks; }
            set
            {
                _soldStocks = value;
                base.OnPropertyChanged("SoldStocks");
            }
        }

        public SoldItemReturn SoldStock
        {
            get { return _soldStock; }
            set
            {
                _soldStock = value;
                base.OnPropertyChanged("SoldStock");
            }
        }

        public string ReturnReason
        {
            get { return _returnReason; }
            set
            {
                _returnReason = value;
                base.OnPropertyChanged("ReturnReason");
                ReturnCommand.RaiseCanExecuteChanged();
            }
        }

        public string Remarks
        {
            get { return _remarks; }
            set
            {
                _remarks = value;
                base.OnPropertyChanged("Remarks");
            }
        }

        private void OnInitialise(UI.Returns ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<StockState> stockStates = _service.GetAllStockStates();
                        List<StockReturnAction> actions = _service.GetAllStockReturnActions();
                        List<StoreStock> stocksOnShelf = _service.GetRemainingStockOnShelf();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stocksOnShelf"] = stocksOnShelf;
                        dictionary["stockStates"] = stockStates;
                        dictionary["actions"] = actions;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnInitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<StockState> stockStates = null;
                List<StoreStock> stocksOnShelf = null;
                List<StockReturnAction> actions = null;

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    stocksOnShelf = (List<StoreStock>)dictionary["stocksOnShelf"];
                    stockStates = (List<StockState>)dictionary["stockStates"];
                    actions = (List<StockReturnAction>)dictionary["actions"];
                }

                _dispatcher.BeginInvoke(DispatcherPriority.Normal, (System.Threading.ThreadStart) delegate()
                    {
                        StocksOnShelf = stocksOnShelf;
                        PopulateStockStates(stockStates);
                        PopulateStockReturnActions(actions);
                    });

                //_dispatcher.Invoke(() =>
                // {
                    
                // });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
              
        private bool CanFind()
        {
            bool isFindable = false;
            if (FindByReceiptNumber)
            {
                isFindable = string.IsNullOrWhiteSpace(InvoiceNumber) ? false : true;
            }
            else if (FindByDateRange)
            {
                isFindable = FromDate != DateTime.MinValue && ToDate != DateTime.MinValue && ToDate >= FromDate;
            }

            return isFindable;
        }

        private bool CanReturnItem()
        {
            if (IsBusy)
            {
                return false;
            }

            return CanReturnItemHelper();

            //ItemIsReturnable = CanReturnItemHelper();
            //return ItemIsReturnable;
        }

        private bool CanReturnItemHelper()
        {
            bool itemsSelected = false;

            try
            {
                if (SoldStocks != null && SoldStocks.Count > 0)
                {
                    int selectedItems = SoldStocks.Where(s => s.IsSelected == true).Count();

                    if (selectedItems > 0 && SoldStockBatch != null && SoldStockBatch.Id > 0 && !string.IsNullOrWhiteSpace(ReturnReason) && DateReturned != DateTime.MinValue)
                    {
                        itemsSelected = true;
                    }
                }
                else
                {
                    itemsSelected = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return itemsSelected;
        }

        private void PopulateStockStates(List<StockState> stockStates)
        {
            try
            {
                if (stockStates == null)
                {
                    stockStates = new List<StockState>();
                }

                StockStates = new ObservableCollection<StockState>(stockStates);
                StockState = StockStates.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulateStockReturnActions(List<StockReturnAction> actions)
        {
            try
            {
                if (actions == null)
                {
                    actions = new List<StockReturnAction>();
                }

                Actions = new ObservableCollection<StockReturnAction>(actions);
                Action = Actions.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnFindCommand()
        {
            try
            {
                IsBusy = true;

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnFindCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            List<SoldStockBatch> soldStockBatches = null;
                            if (FindByDateRange)
                            {
                                soldStockBatches = _service.GetSoldStockBatchByDateRange(FromDate, ToDate);
                            }
                            else if (FindByReceiptNumber)
                            {
                                soldStockBatches = _service.GetSoldStockByBatchInvoiceNumber(InvoiceNumber);
                                //soldStockBatches = _service.GetSoldStockByBatchReceiptNumber(Convert.ToInt64(InvoiceNumber));
                            }

                            e.Result = soldStockBatches;
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

        private void OnFindCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<SoldStockBatch> soldStockBatches = null;
                if (e.Result != null)
                {
                    soldStockBatches = e.Result as List<SoldStockBatch>;
                    if (soldStockBatches.Count > 0)
                    {
                        soldStockBatches.Insert(0, new SoldStockBatch() { Customer = new Person() { Name = "<< Select Transaction >>" } });
                    }
                }

                _dispatcher.Invoke(() =>
                {
                    if (soldStockBatches == null)
                    {
                        soldStockBatches = new List<SoldStockBatch>();
                    }

                    SoldStockBatches = new ObservableCollection<SoldStockBatch>(soldStockBatches);
                    SoldStockBatch = SoldStockBatches.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnReturnCommand()
        {
            try
            {
                List<SoldItemReturn> soldItemsToReturn = SoldStocks.Where(x => x.IsSelected == true).ToList();
                if (IncompleteUserEntry(soldItemsToReturn))
                {
                    return;
                }

                ReturnedStock stocksToReturn = new ReturnedStock();
                stocksToReturn.ReturnedDate = DateReturned;
                stocksToReturn.ReturnReason = ReturnReason;
                stocksToReturn.EnteredBy = Utility.LoggedInUser;
                stocksToReturn.Remarks = Remarks;

                stocksToReturn.Details = new List<ReturnedStockDetail>();
                foreach(SoldItemReturn soldItemReturn in soldItemsToReturn)
                {
                    ReturnedStockDetail returnedStockDetail = new ReturnedStockDetail();
                    returnedStockDetail.SoldStock = new SoldStock();
                    returnedStockDetail.SoldStock.Id = soldItemReturn.Id;
                    returnedStockDetail.SoldStock.ShelfStock = soldItemReturn.ShelfStock;
                    returnedStockDetail.SoldStock.Batch = soldItemReturn.Batch;
                    returnedStockDetail.SoldStock.Price = soldItemReturn.Price;
                    returnedStockDetail.SoldStock.Quantity = soldItemReturn.Quantity;
                    returnedStockDetail.SoldStock.Discount = soldItemReturn.Discount;
                    returnedStockDetail.SoldStock.Returned = true;

                    returnedStockDetail.ReturnedToShelf = false;
                    returnedStockDetail.Action = soldItemReturn.Action;
                    returnedStockDetail.StockState = soldItemReturn.StockState;
                    returnedStockDetail.ReturnQuantity = soldItemReturn.ReturnQuantity;

                    if (RefundAmountNotEntered(soldItemReturn))
                    {
                        return;
                    }

                    if (soldItemReturn.ReturnAmount > 0)
                    {
                        returnedStockDetail.Payment = SetReturnPayment(soldItemReturn, returnedStockDetail);
                        returnedStockDetail.Refunded = true;
                    }
                    
                    stocksToReturn.Details.Add(returnedStockDetail);
                }

                
                OnReturnCommandHelper(stocksToReturn);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnReturnCommandHelper(ReturnedStock stocksToReturn)
        {
            try
            {
                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnReturnCommandCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.ReturnSoldStock(stocksToReturn);
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                IsBusy = false;
                //ItemIsReturnable = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnReturnCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;
                if (e.Error != null)
                {
                    //ItemIsReturnable = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    bool soldStockReturned = (bool)e.Result;
                    if (soldStockReturned)
                    {
                        PopulateSaleTransactionList(SoldStockBatch);

                        ClearUi();
                        Utility.DisplayMessage("Selected sold stock has been successfully returned.");
                    }
                    else
                    {
                        Utility.DisplayMessage("Sold stock return failed! Please try again");
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private Payment SetReturnPayment(SoldItemReturn soldItemReturn, ReturnedStockDetail returnedStockDetail)
        {
            try
            {
                Payment payment = new Payment();
                payment.TransactionType = new TransactionType() { Id = (int)Payment.Transaction.Refund };
                payment.AmountPayable = soldItemReturn.Price.SellingPrice;
                payment.Details = new List<PaymentDetail>();

                PaymentDetail paymentDetail = new PaymentDetail();
                paymentDetail.AmountPaid = soldItemReturn.ReturnAmount;
                paymentDetail.PaymentType = new PaymentType() { Id = (int)PoknoPaymentType.Cash };
                paymentDetail.PaymentDate = Utility.GetDate();
                payment.Details.Add(paymentDetail);

                return payment;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private bool IncompleteUserEntry(List<SoldItemReturn> soldItemsToReturn)
        {
            try
            {
                TimeSpan time = DateReturned - Utility.GetDate();

                if (SoldStockBatch == null || SoldStockBatch.Id <= 0)
                {
                    Utility.DisplayMessage("Please select a transaction from the transaction drop down.");
                    return true;
                }
                else if (soldItemsToReturn == null || soldItemsToReturn.Count <= 0)
                {
                    Utility.DisplayMessage("No item selected to return! Please select an item on the list.");
                    return true;
                }
                else if (DateReturned == DateTime.MinValue)
                {
                    Utility.DisplayMessage("Please specify Return Date");
                    return true;
                }
                else if (time.TotalDays > 0)
                {
                    Utility.DisplayMessage("You cannot specify a date in the future '" + DateReturned + "' as stock return date! Please adjust, to continue.");
                    return true;
                }
                else if (string.IsNullOrWhiteSpace(ReturnReason))
                {
                    Utility.DisplayMessage("Please enter reason for item return");
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private bool RefundAmountNotEntered(SoldItemReturn itemReturned)
        {
            try
            {
                if (itemReturned.Action != null && itemReturned.Action.Id > 0)
                {
                    if (itemReturned.Action.Id == (int)StockReturnAction.Actions.Refund && itemReturned.ReturnAmount <= 0)
                    {
                        Utility.DisplayMessage("Please enter the amount to be refunded for " + itemReturned.ShelfStock.StockPackage.Package.Name + " of " + itemReturned.ShelfStock.StockPackage.Stock.Name + " selected.");
                        return true;
                    }
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void PopulateSaleTransactionList(SoldStockBatch salesBatch)
        {
            try
            {
                if (salesBatch == null || salesBatch.Id <= 0)
                {
                    SoldStocks = new ObservableCollection<SoldItemReturn>();
                    return;
                }

                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnPopulateSaleTransactionListCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<StoreStock> stocksOnShelf = _service.GetRemainingStockOnShelf();
                        List<SoldStock> soldStocks = _service.GetOutgoingStockByBatch(salesBatch);

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stocksOnShelf"] = stocksOnShelf;
                        dictionary["soldStocks"] = soldStocks;
                        
                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                IsBusy = false;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnPopulateSaleTransactionListCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    StocksOnShelf = (List<StoreStock>)dictionary["stocksOnShelf"];
                    SoldItems = (List<SoldStock>)dictionary["soldStocks"];

                    SelectedItemCount = 0;
                    if (SoldItems != null && SoldItems.Count > 0)
                    {
                        RecordCount = SoldItems.Count;

                        List<SoldItemReturn> soldItemReturns = new List<SoldItemReturn>();
                        foreach (SoldStock soldItem in SoldItems)
                        {
                            SoldItemReturn soldItemReturn = new SoldItemReturn();
                            soldItemReturn.ShelfStock = new Shelf();
                            soldItemReturn.Id = soldItem.Id;
                            soldItemReturn.ShelfStock = soldItem.ShelfStock;
                            soldItemReturn.Price = soldItem.Price;
                            soldItemReturn.Batch = soldItem.Batch;
                            soldItemReturn.Quantity = soldItem.Quantity;
                            soldItemReturn.Discount = soldItem.Discount;
                            soldItemReturn.CanEditReturnQuantity = false;
                            soldItemReturn.ReturnQuantity = 1;
                            soldItemReturn.IsSelected = false;

                            soldItemReturn.PropertyChanged += soldItemReturn_PropertyChanged;
                            if (StockStates != null && StockStates.Count > 0)
                            {
                                soldItemReturn.StockStates = StockStates;
                                soldItemReturn.StockState = soldItemReturn.StockStates.FirstOrDefault();
                            }

                            if (Actions != null && Actions.Count > 0)
                            {
                                soldItemReturn.Actions = Actions;
                                soldItemReturn.Action = soldItemReturn.Actions.FirstOrDefault();
                            }

                            soldItemReturns.Add(soldItemReturn);
                        }

                        SoldStocks = new ObservableCollection<SoldItemReturn>(soldItemReturns);
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void soldItemReturn_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                ReturnCommand.RaiseCanExecuteChanged();

                if (SoldStocks != null)
                {
                    SelectedItemCount = SoldStocks.Where(x => x.IsSelected == true).Count();
                }
            }
        }

        private void ClearUi()
        {
            try
            {
                Remarks = "";
                ReturnReason = "";
                InvoiceNumber = "";
                DateReturned = Utility.GetDate();
                FromDate = Utility.GetDate();
                ToDate = Utility.GetDate();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }





    }


}
