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

using Pokno.Store.Interfaces;
using System.Collections.ObjectModel;
using Pokno.Service;
using Pokno.Model;
using System.Collections.Generic;
using Pokno.Model.Model;

namespace Pokno.Store.Services
{
    public class RegisterPurchasedStockService : IRegisterPurchasedStockService
    {
        private IBusinessFacade _service;

        public RegisterPurchasedStockService(IBusinessFacade service)
        {
            _service = service;
        }

        public bool Modify(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                return _service.ModifyStockPurchases(purchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(List<StockPurchased> stockPurchases)
        {
            try
            {
                return _service.AddStockPurchases(stockPurchases);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPurchaseBatch> LoadAll()
        {
            try
            {
                return _service.GetAllStockPurchaseBatches();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StockPurchaseBatch LoadBatchDetailsByBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                return _service.LoadBatchStockPurchaseAndPaymentInformation(stockPurchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPurchased> LoadStockPurchasedByBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                return _service.LoadStockPurchaseByBatch(stockPurchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchasedAtHand> LoadStockPurchasedAtHand()
        {
            try
            {
                return _service.GetStockPurchasedAtHand();
            }
            catch (Exception)
            {
                throw;
            }
        }





    }

}
