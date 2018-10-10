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
using Pokno.Store.Interfaces;
using Pokno.Service;
using Pokno.Model;

namespace Pokno.Store.Services
{
    public class StockPackageService : ICollectibleService<StockPackage>
    {
        private IBusinessFacade _service;

        public StockPackageService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockPackage> LoadAll()
        {
            try
            {
                return _service.GetAllStockPackages();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(List<StockPackage> models)
        {
            try
            {
                return _service.AddStockPackages(models);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(List<StockPackage> models)
        {
            try
            {
                return _service.ModifyStockPackages(models);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPackage> LoadByStock(Stock stock)
        {
            try
            {
                return _service.GetStockPackages(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }







    }
}
