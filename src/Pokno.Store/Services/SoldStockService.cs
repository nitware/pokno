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
using System.Collections.Generic;
using Pokno.Service;
using Pokno.Model;

namespace Pokno.Store.Services
{
    public class SoldStockService : ISoldStockService
    {
        private IBusinessFacade _service;

        public SoldStockService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<SoldStockBatch> LoadAllOutgoingStockBatch()
        {
            try
            {
                return _service.GetAllSoldStockBatch();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStock> LoadOutgoingStockByBatch(SoldStockBatch outgoingStockBatch)
        {
            try
            {
                return _service.GetOutgoingStockByBatch(outgoingStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<SoldStock> LoadOutgoingStockByBatchId(long receiptNumber)
        //{
        //    try
        //    {
        //        return _service.GetOutgoingStockByBatchId(receiptNumber);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool Modify(SoldStockBatch soldStockBatch)
        {
            try
            {
                return _service.ModifySoldStock(soldStockBatch);
                //return _service.ModifyOutgoingStockBatch(outgoingStocks, payment, customer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public bool Modify(Payment payment, SoldStockBatch soldStockBatch)
        //{
        //    try
        //    {
        //        return _service.ModifyOutgoingStocksPayment(payment, soldStockBatch);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public bool Remove(SoldStockBatch outgoingStockBatch)
        {
            try
            {
                return _service.RemoveSoldStockBatch(outgoingStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
    
}
