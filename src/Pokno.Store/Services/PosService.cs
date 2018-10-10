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
using Pokno.Store.Interfaces;
using Pokno.Service;
using Pokno.Model.Model;
using System.Collections.Generic;

namespace Pokno.Store.Services
{
    public class PosService : IPosService
    {
        private IBusinessFacade _service;

        public PosService(IBusinessFacade service)
        {
            _service = service;
        }
        
        public List<StockOnShelfAtHand> LoadStocksOnShelfAtHand()
        {
            try
            {
                return _service.GetStockOnShelfAtHand();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreStock> LoadRemainingStocksOnShelf()
        {
            try
            {
                return _service.GetRemainingStockOnShelf();
            }
            catch (Exception)
            {
                throw;
            }
        }





    }

}
