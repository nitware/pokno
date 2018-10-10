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
using System.Collections.ObjectModel;
using Pokno.Service;
using Pokno.Model;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class StockCategoryService : ISetupService<StockCategory>
    {
        private IBusinessFacade _service;

        public StockCategoryService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockCategory> LoadAll()
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
        public bool Save(StockCategory stockCategory)
        {
            try
            {
                return _service.AddStockCategory(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(StockCategory stockCategory)
        {
            try
            {
                return _service.ModifyStockCategory(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(StockCategory stockCategory)
        {
            try
            {
                return _service.RemoveStockCategory(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

}
