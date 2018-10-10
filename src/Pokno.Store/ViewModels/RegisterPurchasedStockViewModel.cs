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

using System.Windows.Data;
using Pokno.Infrastructure.Models;
using Pokno.Model;
using Pokno.Store.Interfaces;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.Windows.Threading;
using System.ComponentModel;
using Prism.Commands;
using Pokno.Infratructure.Services;
using Pokno.Store.Services;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.Interfaces;
using Pokno.Service;
using Pokno.Infrastructure.ViewModels;

namespace Pokno.Store.ViewModels
{
    public class RegisterPurchasedStockViewModel : BasePurchasedStock
    {
        public RegisterPurchasedStockViewModel(StockPricePopUpViewModel stockPriceVM, IBusinessFacade businessFacade, StockPurchaseBatchViewModel purchaseBatchViewModel, IEventAggregator eventAggregator)
            : base(stockPriceVM, businessFacade, purchaseBatchViewModel)
        {
            eventAggregator.GetEvent<StockPurchasedInitialiseEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
            //OnInitialise(UI.Store.RegisterPurchasedStock);
        }

        public override sealed void OnInitialise(UI.Store ui)
        {
            try
            {
                base.OnInitialise(ui);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool IsView(UI.Store payload)
        {
            return payload == UI.Store.RegisterPurchasedStock;
        }

        public string TabCaption
        {
            get { return "Register Purchased Stock"; }
        }

        private bool StockPurchasedExist { get; set; }
        
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
                    ModelCanBeCleared = true;
                    PaymentCanBeRemoved = false;
                    PaymentCanBeAdded = true;
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
