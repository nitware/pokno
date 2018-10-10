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
using System.Collections.Generic;
using Pokno.Model;

namespace Pokno.Store.Services
{
    public class ShelfService : IShelfService
    {
        private IBusinessFacade _service;

        public ShelfService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Shelf> LaodLatestHundred()
        {
            try
            {
                return _service.GetLatestHundredStocksOnShelf();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Shelf> LaodByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return _service.GetStocksOnShelfByDateRange(fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public int ArrangeStockOnShelf(Shelf stockOnShelf)
        //{
        //    try
        //    {
        //        return _service.ArrangeStockOnShelf(stockOnShelf);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}






    }

}
