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
using Pokno.Model;
using Pokno.Service;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class StockTypeService : ISetupService<StockType>
    {
        private IBusinessFacade _service;

        public StockTypeService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockType> LoadAll()
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
        public List<StockCategory> LoadAllStockCategories()
        {
            try
            {
                return _service.GetAllStockCategorys();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(StockType stockCategory)
        {
            try
            {
                return _service.AddStockType(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(StockType stockCategory)
        {
            try
            {
                return _service.ModifyStockType(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(StockType stockCategory)
        {
            try
            {
                return _service.RemoveStockType(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }

}
