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

using Pokno.Infrastructure.Interfaces;
using Pokno.Store.Interfaces;
using Pokno.Model;
using Pokno.Service;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class StockPriceService : ICollectibleService<StockPrice>
    {
        private IBusinessFacade _service;

        public StockPriceService(IBusinessFacade service)
        {
            _service = service;
        }

        public bool Save(List<StockPrice> models)
        {
            try
            {
                return _service.AddStockPrices(models);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(List<StockPrice> models)
        {
            try
            {
                return _service.ModifyStockPrices(models);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPrice> LoadByStock(Stock stock)
        {
            try
            {
                return _service.GetStockPriceByStock(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StockPrice GetByStockPackage(StockPackage stockPackage)
        {
            try
            {
                return _service.GetStockPriceByStockPackage(stockPackage);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
