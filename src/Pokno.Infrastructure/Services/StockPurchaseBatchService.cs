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
using Pokno.Infrastructure.Interfaces;
using Pokno.Service;
using Pokno.Model;
using System.Collections.Generic;

namespace Pokno.Infratructure.Services
{
    public class StockPurchaseBatchService : IStockPurchaseBatchService
    {
        private IBusinessFacade _service;

        public StockPurchaseBatchService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockPurchasePayment> LoadSupplierPaymentHistory(Pokno.Model.Person supplier)
        {
            try
            {
                return _service.GetSupplierPaymentHistory(supplier);
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        public bool Save(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                return _service.AddStockPurchaseBatch(stockPurchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }
      
      
      

    }

}
