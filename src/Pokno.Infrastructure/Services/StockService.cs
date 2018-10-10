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

using System.Collections.Generic;
using Pokno.Infrastructure.Interfaces;
using System.Collections.ObjectModel;
using Pokno.Service;
using Pokno.Model;

namespace Pokno.Infratructure.Services
{
    public class StockService : ISetupService<Stock>
    {
        private IBusinessFacade _service;

        public StockService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Stock> LoadAll()
        {
            try
            {
                return _service.GetAllStocks();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Stock> LoadAllWithPackageQuantity()
        {
            try
            {
                return _service.GetAllStocksWithPackageQuantity();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockType> LoadAllStockTypes()
        {
            try
            {
                return _service.GetAllStockTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(Stock stock)
        {
            try
            {
                return _service.AddStock(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(Stock stock)
        {
            try
            {
                return _service.ModifyStock(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(Stock stock)
        {
            try
            {
                return _service.RemoveStock(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

      




    }
}
