using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class CurrentStockPriceLogic : BusinessLogicBase<CurrentStockPrice, CURRENT_STOCK_PRICE>
    {
        public CurrentStockPriceLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new CurrentStockPriceTranslator();
        }

        public List<CurrentStockPrice> GetBy(Stock stock)
        {
            try
            {
                string include = "STOCK_PRICE";

                Expression<Func<CURRENT_STOCK_PRICE, bool>> selector = pr => pr.STOCK_PRICE.STOCK_PACKAGE.Stock_Id == stock.Id;
                return base.GetModelsBy(selector, null, include);
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
                Expression<Func<CURRENT_STOCK_PRICE, bool>> selector = sp => sp.STOCK_PRICE.STOCK_PACKAGE.Stock_Id == stock.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public bool Remove(StockPrice stockPrice)
        //{
        //    try
        //    {
        //        Expression<Func<CURRENT_STOCK_PRICE, bool>> selector = sp => sp.STOCK_PRICE.Stock_Price_Id == stockPrice.Id;
        //        return base.Remove(selector);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        

    }

}
