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
using System.Windows.Threading;
using System.Windows.Data;
using Pokno.Store.Interfaces;
using Pokno.Model;
using System.ComponentModel;
using Prism.Events;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Service;
using Pokno.Infrastructure.Interfaces;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pokno.Store.ViewModels
{
    public class ModifyStockPurchasedBatchViewModel : StockPurchaseBatchViewModelBase
    {
        private BackgroundWorker _worker;
        private IModifyStockPurchasedBatchService _modifyStockPurchasedBatchService;

        private PaymentDetail _paymentDetail;
        private ICollectionView _paymentDetails;
        private ICollectionView _stockPurchaseBatches;

        public ModifyStockPurchasedBatchViewModel(IBusinessFacade businessFacade, IStockPurchaseBatchService service, IModifyStockPurchasedBatchService modifyStockPurchasedBatchService, IEventAggregator eventAggregator)
            : base(businessFacade, service)
        {
            _modifyStockPurchasedBatchService = modifyStockPurchasedBatchService;
        }

        public string TabCaption
        {
            get { return "Modify Purchase Batch"; }
        }

        public DelegateCommand ModifyCommand { get; private set; }
       
        public void OnInitialise(int selectedTabIndex)
        {
            try
            {
                if (selectedTabIndex == 1)
                {
                    using (_worker = new BackgroundWorker())
                    {
                        _worker.DoWork += (o, e) => LoadInitialisationData();
                        _worker.RunWorkerAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public void LoadInitialisationData()
        {
            try
            {
                LoadAllStockPurchaseBatch();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public ICollectionView PaymentDetails
        {
            get { return _paymentDetails; }
            set
            {
                _paymentDetails = value;
                base.OnPropertyChanged("PaymentDetails");
            }
        }
        public PaymentDetail PaymentDetail
        {
            get { return _paymentDetail; }
            set
            {
                _paymentDetail = value;
                base.OnPropertyChanged("PaymentDetail");
            }
        }
        public ICollectionView StockPurchaseBatches
        {
            get { return _stockPurchaseBatches; }
            set
            {
                _stockPurchaseBatches = value;
                base.OnPropertyChanged("StockPurchaseBatches");
            }
        }

        protected override bool IsRequiredDetailsEntered()
        {
            try
            {
                if (StockPurchaseBatch == null)
                {
                    Utility.DisplayMessage("No batch selected! Please select batch");
                    return false;
                }
                else if (StockPurchaseBatch.Payment.AmountPayable == 0)
                {
                    Utility.DisplayMessage("Please enter amount Payable!");
                    return false;
                }
                else if (PaymentType == null)
                {
                    Utility.DisplayMessage("Please select payment type!");
                    return false;
                }
                else if (PaymentType != null && PaymentType.Id == 0)
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

        protected override void OnSaveCommand()
        {
            try
            {
                IEnumerable<PaymentDetail> paymentDetails = (IEnumerable<PaymentDetail>)TargetCollection.SourceCollection;
                StockPurchaseBatch.Payment.Details = new List<Model.PaymentDetail>(paymentDetails);
                StockPurchaseBatch.Supplier = Supplier;
                StockPurchaseBatch.Buyer = Buyer;

                if (InvalidEntry())
                {
                    return;
                }

                OnSaveCommandHelper(StockPurchaseBatch);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommandHelper(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                bool modified = _modifyStockPurchasedBatchService.Modify(stockPurchaseBatch);
                _dispatcher.Invoke(() =>
                           {
                               if (modified)
                               {
                                   LoadAllStockPurchaseBatch();
                                   ClearView();

                                   Utility.DisplayMessage("Purchase batch has been successfully modified");
                               }
                               else
                               {
                                   Utility.DisplayMessage("Purchase batch modification failed!");
                               }
                           });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllStockPurchaseBatch()
        {
            try
            {
                List<StockPurchaseBatch> stockPurchaseBatches = _modifyStockPurchasedBatchService.LoadAllStockPurchaseBatch();
                if (stockPurchaseBatches != null )
                {
                    _dispatcher.Invoke(() =>
                               {
                                   StockPurchaseBatches = new CollectionView(stockPurchaseBatches);
                                   if (stockPurchaseBatches.Count > 0)
                                   {
                                       StockPurchaseBatch purchaseBatch = stockPurchaseBatches.Where(pb => pb.Id == 0).SingleOrDefault();
                                       if (purchaseBatch == null)
                                       {
                                           stockPurchaseBatches.Insert(0, new StockPurchaseBatch() { Id = 0, Buyer = new Person() { Name = "<< Select Purchase Batch >>" }, Supplier = new Person() });
                                                                                     
                                           StockPurchaseBatches.MoveCurrentToFirst();
                                           StockPurchaseBatches.CurrentChanged += (s, e) =>
                                           {
                                               StockPurchaseBatch = StockPurchaseBatches.CurrentItem as StockPurchaseBatch;
                                               if (StockPurchaseBatch != null && StockPurchaseBatch.Id > 0)
                                               {
                                                   TargetModel.Payment = StockPurchaseBatch.Payment;

                                                   LoadPurchasedStockBatchByBatch(StockPurchaseBatch);

                                                   Buyer = GetPerson(Buyers, StockPurchaseBatch.Buyer.Id);
                                                   Supplier = GetPerson(Suppliers, StockPurchaseBatch.Supplier.Id);
                                               }

                                               TargetModel.AmountPaid = 0;
                                               TargetModel.PaymentDate = Utility.GetDate();

                                               if (PaymentTypes != null && PaymentTypes.Count > 0)
                                               {
                                                   PaymentType = PaymentTypes.FirstOrDefault();
                                               }
                                           };
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

        private void LoadPurchasedStockBatchByBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                StockPurchaseBatch loadedPurchaseBatch = _modifyStockPurchasedBatchService.LoadBatchDetailsByBatch(stockPurchaseBatch);
                _dispatcher.Invoke(() =>
                           {
                               StockPurchaseBatch = loadedPurchaseBatch;
                               if (StockPurchaseBatch != null)
                               {
                                   TargetCollection = new ListCollectionView(loadedPurchaseBatch.Payment.Details);
                                   if (StockPurchaseBatch.Payment.Details != null)
                                   {
                                       collectionManager.Collection = new System.Collections.ObjectModel.ObservableCollection<Model.PaymentDetail>(loadedPurchaseBatch.Payment.Details);
                                       base.RefreshModelCollection();
                                   }
                               }
                           });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        public override void OnDeleteCommand()
        {
            try
            {
                if (StockPurchaseBatch != null)
                {
                    int index = TargetCollection.CurrentPosition;
                    if (index > -1)
                    {
                        collectionManager.Collection.RemoveAt(index);
                        RefreshModelCollection();
                    }
                    else
                    {
                        Utility.DisplayMessage("No selection made! Please select a row for removal");
                    }
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

        //private void SetPerson(ICollectionView peopleView, int personId)
        //{
        //    try
        //    {
        //        if (peopleView != null)
        //        {
        //            IEnumerable<Person> people = (IEnumerable<Person>)peopleView.SourceCollection;
        //            Person person = people.Where(p => p.Id == personId).SingleOrDefault();
        //            peopleView.MoveCurrentTo(person);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected override void SetUserViewRight()
        {
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanModifyPurchaseBatch;
        }



    }
}
