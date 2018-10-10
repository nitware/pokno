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
using Pokno.Model;
using Pokno.Service;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class StockReturnTypeService : ISetupService<StockReturnType>
    {
        private IBusinessFacade _service;

        public StockReturnTypeService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockReturnType> LoadAll()
        {
            try
            {
                return _service.GetAllStockReturnTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(StockReturnType stockReturnType)
        {
            try
            {
                return _service.AddStockReturnType(stockReturnType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(StockReturnType stockReturnType)
        {
            try
            {
                return _service.ModifyStockReturnType(stockReturnType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(StockReturnType stockReturnType)
        {
            try
            {
                return _service.RemoveStockReturnType(stockReturnType);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
