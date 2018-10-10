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
using Pokno.Model.Model;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class SellStockService : ISellStockService
    {
        private IBusinessFacade _service;

        public SellStockService(IBusinessFacade service)
        {
            _service = service;
        }

        public SoldStockBatch Sell(SoldStockBatch outgoingStockBatch)
        {
            try
            {
                return _service.SellStock(outgoingStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockForSale LoadStockForSaleBy(StockPackage stockPackage, int stockPackageRelationshipId)
        {
            try
            {
                return _service.GetStockForSale(stockPackage, stockPackageRelationshipId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockAtHand> LoadStockAtHandByStock(Stock stock)
        {
            try
            {
                return _service.GetStocksAtHand(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }



    
}
