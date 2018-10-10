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

using Pokno.Service;
using Pokno.Model.Model;
using System.Collections.Generic;
using Pokno.Infrastructure.Interfaces;

namespace Pokno.Store.Services
{
    public class TakeStockService : ITakeStockService
    {
        private IBusinessFacade _service;

        public TakeStockService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Year> GetTotalYears()
        {
            try
            {
                return _service.GetTotalYears();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockReviewDetail> GetYearlyStockReview(int year)
        {
            try
            {
                return _service.GetYearlyStockReview(year);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool TakeStock(StockReview stockReview)
        {
            try
            {
                return _service.AddStockReview(stockReview);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }

}
