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

using System.Collections.ObjectModel;
using Pokno.Store.Interfaces;
using Pokno.Service;
using Pokno.Model;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class ModifyStockPurchasedBatchService : IModifyStockPurchasedBatchService
    {
        private IBusinessFacade _service;

        public ModifyStockPurchasedBatchService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockPurchaseBatch> LoadAllStockPurchaseBatch()
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

        public bool Modify(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                return _service.ModifyStockPurchaseBatch(stockPurchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }

}
