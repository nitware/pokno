using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Infrastructure.Models;
using Pokno.Infratructure.Services;
using Pokno.Store.Interfaces;
using Pokno.Store.Services;
using Pokno.Infrastructure.Interfaces;
using System.ComponentModel;
using System.Windows.Threading;
using Pokno.Infrastructure.Events;
using Prism.Commands;
using System.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Prism.Events;
using Pokno.Service;
using Pokno.Infrastructure.ViewModels;

namespace Pokno.Store.ViewModels
{
    public class ModifyPurchasedStockViewModel : BasePurchasedStock // ObservableCollectionManagerBase<StockPurchased>
    {
        private BackgroundWorker _worker2;
        private StockPurchaseBatch _purchaseStockBatch;
        private ObservableCollection<StockPurchaseBatch> _purchaseStockBatches;

        public ModifyPurchasedStockViewModel(StockPricePopUpViewModel stockPriceVM, IBusinessFacade businessFacade, StockPurchaseBatchViewModel purchaseBatchViewModel, IEventAggregator eventAggregator)
            : base(stockPriceVM, businessFacade, purchaseBatchViewModel)
        {
            eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        private bool IsView(UI.Store ui)
        {
            return ui == UI.Store.ModifyPurchasedStock;
        }
        
        public string TabCaption
        {
            //get { return "Modify Purchased Stock"; }
            get { return "Edit Purchased Stock"; }
        }
        public ObservableCollection<StockPurchaseBatch> PurchaseStockBatches
        {
            get { return _purchaseStockBatches; }
            set
            {
                _purchaseStockBatches = value;
                base.OnPropertyChanged("PurchaseStockBatches");
            }
        }
        public StockPurchaseBatch PurchaseStockBatch
        {
            get { return _purchaseStockBatch; }
            set
            {
                _purchaseStockBatch = value;
                base.OnPropertyChanged("PurchaseStockBatch");

                GetPurchasedStockDetailByBatch(_purchaseStockBatch);
            }
        }

        public override void OnInitialise(UI.Store ui)
        {
            try
            {
                //base.OnInitialise(ui);
                LoadStockPurchaseBatch();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //protected override Dictionary<string, object> LoadInitializationData()
        //{
        //    try
        //    {
        //        Dictionary<string, object> dictionary = base.LoadInitializationData();
        //        if (dictionary == null)
        //        {
        //            Utility.DisplayMessage("Initialization data load operation failed!");
        //            return null;
        //        }

        //        List<StockPurchaseBatch> purchaseBatches = _businessFacade.GetPurchaseBatchNotOnShelf();
        //        dictionary["purchaseBatches"] = purchaseBatches;

        //        return dictionary;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //protected override void PopulateInitializationData(Dictionary<string, object> dictionary)
        //{
        //    try
        //    {
        //        base.PopulateInitializationData(dictionary);

        //        List<StockPurchaseBatch> stockPurchaseBatches = (List<StockPurchaseBatch>)dictionary["purchaseBatches"];
        //        PopulateAllStockPurchaseBatch(stockPurchaseBatches);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void GetPurchasedStockDetailByBatch(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                if (purchaseBatch != null && purchaseBatch.Id > 0)
                {
                    PurchaseBatchViewModel.Payment = purchaseBatch.Payment;
                    PurchaseBatchViewModel.TargetModel.Payment = purchaseBatch.Payment;
                    SupplierExpenses = purchaseBatch.SupplierExpenses.GetValueOrDefault();

                    using (_worker = new BackgroundWorker())
                    {
                        _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnGetPurchasedStockDetailByBatchCompleted);
                        _worker.DoWork += (s, e) =>
                        {
                            PurchaseBatchViewModel.Buyer = GetPerson(PurchaseBatchViewModel.Buyers, purchaseBatch.Buyer.Id);
                            PurchaseBatchViewModel.Supplier = GetPerson(PurchaseBatchViewModel.Suppliers, purchaseBatch.Supplier.Id);

                            List<StockPurchased> stockPurchases = _businessFacade.LoadStockPurchaseByBatch(purchaseBatch);
                            StockPurchaseBatch loadedPurchaseBatch = _businessFacade.LoadBatchStockPurchaseAndPaymentInformation(purchaseBatch);

                            Dictionary<string, object> objectDictionary = new Dictionary<string, object>();
                            objectDictionary["loadedPurchaseBatch"] = loadedPurchaseBatch;
                            objectDictionary["stockPurchases"] = stockPurchases;

                            e.Result = objectDictionary;
                        };
                        _worker.RunWorkerAsync(purchaseBatch);
                    }
                }

                PurchaseBatchViewModel.TargetModel.AmountPaid = 0;
                PurchaseBatchViewModel.TargetModel.PaymentDate = Utility.GetDate();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnGetPurchasedStockDetailByBatchCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    Dictionary<string, object> objectDictionary = e.Result as Dictionary<string, object>;
                    StockPurchaseBatch purchaseBatch = (StockPurchaseBatch)objectDictionary["loadedPurchaseBatch"];
                    List<StockPurchased> stockPurchases = (List<StockPurchased>)objectDictionary["stockPurchases"];

                    LoadPaymentByBatch(purchaseBatch);
                    PopulateStockPurchased(stockPurchases);

                    UpdateSummary();
                    UpdateViewState(Edit.Mode.Editing);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void PopulateStockPurchased(List<StockPurchased> stockPurchases)
        {
            try
            {
                if (stockPurchases != null)
                {
                    _dispatcher.Invoke(() =>
                    {
                        TargetCollection = new ListCollectionView(new ObservableCollection<StockPurchased>(stockPurchases));
                        collectionManager.Collection = new ObservableCollection<StockPurchased>(stockPurchases);
                        if (stockPurchases.Count > 0)
                        {
                            TargetCollection.MoveCurrentTo(null);
                            TargetCollection.CurrentChanged += (s, e) =>
                            {
                                if (TargetCollection.CurrentItem != null)
                                {
                                    UpdateViewState(Edit.Mode.Selected);
                                }
                            };
                        }
                        else
                        {
                            UpdateViewState(Edit.Mode.Loaded);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void LoadPaymentByBatch(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                if (purchaseBatch != null && purchaseBatch.Id > 0)
                {
                    _dispatcher.Invoke(() =>
                    {
                        PurchaseBatchViewModel.StockPurchaseBatch = purchaseBatch;

                        if (PurchaseBatchViewModel.StockPurchaseBatch != null)
                        {
                            PurchaseBatchViewModel.Payment = purchaseBatch.Payment;
                            PurchaseBatchViewModel.TargetCollection = new ListCollectionView(purchaseBatch.Payment.Details);
                            if (PurchaseBatchViewModel.StockPurchaseBatch.Payment.Details != null)
                            {
                                PurchaseBatchViewModel.collectionManager.Collection = new ObservableCollection<PaymentDetail>(purchaseBatch.Payment.Details);
                                PurchaseBatchViewModel.RefreshModelCollection();
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        
        private void LoadStockPurchaseBatch()
        {
            try
            {
                using (_worker2 = new BackgroundWorker())
                {
                    _worker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadStockPurchaseBatchCompleted);
                    _worker2.DoWork += (s, e) =>
                    {
                        e.Result = _businessFacade.GetPurchaseBatchNotOnShelf();
                    };
                    _worker2.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadStockPurchaseBatchCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    List<StockPurchaseBatch> stockPurchaseBatches = e.Result as List<StockPurchaseBatch>;
                    PopulateAllStockPurchaseBatch(stockPurchaseBatches);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private Person GetPerson(ObservableCollection<Person> people, int personId)
        {
            try
            {
                Person person = null;
                if (people != null && people.Count > 0)
                {
                    person = people.Where(p => p.Id == personId).SingleOrDefault();
                }

                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void PopulateAllStockPurchaseBatch(List<StockPurchaseBatch> stockPurchaseBatches)
        {
            try
            {
                if (stockPurchaseBatches == null || stockPurchaseBatches.Count <= 0)
                {
                    stockPurchaseBatches = new List<StockPurchaseBatch>();
                    Utility.DisplayMessage("No modifiable purchase transaction found!");
                }
                else
                {
                    base.OnInitialise(UI.Store.ModifyPurchasedStock);
                }

                if (stockPurchaseBatches.Count > 0)
                {
                    stockPurchaseBatches.Insert(0, new StockPurchaseBatch() { Id = 0, Buyer = new Person() { Name = "<< Select Purchase Batch >>" }, Supplier = new Person() });
                }

                _dispatcher.Invoke(() =>
                {
                    PurchaseStockBatches = new ObservableCollection<StockPurchaseBatch>(stockPurchaseBatches);
                    PurchaseStockBatch = PurchaseStockBatches.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected override void OnClearPurchasedStocksCommand()
        {
            try
            {
                collectionManager.Collection.Clear();
                ObservableCollection<StockPurchased> stockPurchases = GetStockPurchases();

                stockPurchases.Clear();
                TargetCollection = new ListCollectionView(stockPurchases);

                if (PurchaseStockBatches != null && PurchaseStockBatches.Count > 0)
                {
                    PurchaseStockBatch = PurchaseStockBatches.FirstOrDefault();
                    SupplierExpenses = 0;
                }

                if (PurchaseBatchViewModel.TargetCollection != null)
                {
                    ObservableCollection<PaymentDetail> paymentDetails = (ObservableCollection<PaymentDetail>)PurchaseBatchViewModel.TargetCollection.SourceCollection;
                    if (paymentDetails != null)
                    {
                        paymentDetails.Clear();
                        PurchaseBatchViewModel.TargetCollection = new ListCollectionView(paymentDetails);
                    }
                }

                UpdateSummary();
                UpdateViewState(Edit.Mode.Editing);

                ModelCanBeSaved = false;
                PaymentCanBeAdded = false;
                PurchasedStocksCanBeCleared = false;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override StockPurchased GetNewModel()
        {
            try
            {
                Stock stock = new Stock();
                StockPurchased newStockPurchased = new StockPurchased();
                StockPurchaseBatch stockPurchaseBatch = new StockPurchaseBatch();
                StockPackage stockPackage = new StockPackage();
                stockPackage.Package = new Package();

                stockPurchaseBatch.Id = PurchaseBatchViewModel.StockPurchaseBatch.Id; // StockPurchaseBatch.Id;
                stock.Id = TargetModel.Stock.Id;
                stock.Name = TargetModel.Stock.Name;

                stockPackage.Id = StockPackage.Id;
                stockPackage.Package.Name = TargetModel.StockPackage.Package.Name;

                newStockPurchased.Stock = stock;
                newStockPurchased.Batch = stockPurchaseBatch;
                newStockPurchased.StockPackage = stockPackage;
                newStockPurchased.Id = TargetModel.Id;
                newStockPurchased.Quantity = TargetModel.Quantity;
                newStockPurchased.UnitCost = TargetModel.UnitCost;
                newStockPurchased.Cost = TargetModel.Cost;

                return newStockPurchased;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void ClearView()
        {
            try
            {
                base.ClearView();
                if (PurchaseStockBatches != null)
                {
                    PurchaseStockBatch = PurchaseStockBatches.FirstOrDefault();
                    SupplierExpenses = 0;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override bool Save()
        {
            try
            {
                bool done = _businessFacade.ModifyStockPurchaseBatch(PurchaseBatchViewModel.StockPurchaseBatch);
                return done;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnSaveCommandHelper(bool done)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (done)
                    {
                        ClearView();
                        LoadStockPurchaseBatch();
                        Utility.DisplayMessage("Purchased stocks have been successfully saved");
                    }
                    else
                    {
                        Utility.DisplayMessage("Purchased stocks has not been saved successfully! Please try again");
                    }
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void UpdateViewState(Edit.Mode uiState)
        {
            try
            {
                int purchasedStocksCount = 0;
                int paymentDetailsCount = 0;
                ObservableCollection<StockPurchased> purchasedStocks = null;
                ObservableCollection<PaymentDetail> paymentDetails = null;

                if (TargetCollection != null)
                {
                    purchasedStocks = (ObservableCollection<StockPurchased>)TargetCollection.SourceCollection;
                }
                if (PurchaseBatchViewModel != null && PurchaseBatchViewModel.TargetCollection != null)
                {
                    paymentDetails = (ObservableCollection<PaymentDetail>)PurchaseBatchViewModel.TargetCollection.SourceCollection;
                }

                if (purchasedStocks != null)
                {
                    purchasedStocksCount = purchasedStocks.Count;
                }
                if (paymentDetails != null)
                {
                    paymentDetailsCount = paymentDetails.Count;
                }

                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;
                            ModelCanBeSaved = false;
                            ModelCanBeCleared = false;
                            PaymentCanBeRemoved = false;
                            PaymentCanBeAdded = false;
                            PurchasedStocksCanBeCleared = false;

                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;

                            UpdateViewStateHelper(purchasedStocksCount, paymentDetailsCount);

                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            if (TargetCollection != null)
                            {
                                if (TargetCollection.CurrentItem != null)
                                {
                                    ModelCanBeRemoved = true;
                                }
                            }

                            break;
                        }
                    case Edit.Mode.Editing:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;

                            UpdateViewStateHelper(purchasedStocksCount, paymentDetailsCount);

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void UpdateViewStateHelper(int purchasedStocksCount, int paymentDetailsCount)
        {
            try
            {
                if (purchasedStocksCount > 0 && paymentDetailsCount > 0)
                {
                    ModelCanBeSaved = true;
                    ModelCanBeCleared = true;
                    PaymentCanBeRemoved = true;
                    PaymentCanBeAdded = true;
                    PurchasedStocksCanBeCleared = true;
                }
                else if (purchasedStocksCount <= 0 && paymentDetailsCount <= 0)
                {
                    ModelCanBeSaved = false;
                    ModelCanBeCleared = false;
                    PaymentCanBeRemoved = false;
                    PaymentCanBeAdded = false;
                    PurchasedStocksCanBeCleared = false;
                }
                else if (purchasedStocksCount > 0 && paymentDetailsCount <= 0)
                {
                    ModelCanBeSaved = false;
                    PaymentCanBeAdded = true;
                    ModelCanBeCleared = true;
                    PaymentCanBeRemoved = false;
                    PurchasedStocksCanBeCleared = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


       
    }




}
