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
    public class StockStateService : ISetupService<StockState>
    {
        private IBusinessFacade _service;

        public StockStateService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<StockState> LoadAll()
        {
            try
            {
                return _service.GetAllStockStates();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(StockState stockState)
        {
            try
            {
                return _service.AddStockState(stockState);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(StockState stockState)
        {
            try
            {
                return _service.ModifyStockState(stockState);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(StockState stockState)
        {
            try
            {
                return _service.RemoveStockState(stockState);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }

}
