using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using System.Data;
using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
   
    public class StockCategoryLogic : BusinessLogicBase<StockCategory, STOCK_CATEGORY>
    {
        private StockLogic stockLogic;
        private StockTypeLogic stockTypeLogic;
        
        public StockCategoryLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockCategoryTranslator();
            stockTypeLogic = new StockTypeLogic(repository);
            stockLogic = new StockLogic(repository);
        }

        public override List<StockCategory> GetAll()
        {
            try
            {
                Expression<Func<STOCK_CATEGORY, bool>> selector = sc => sc.Stock_Category_Id > 0;
                Func<IQueryable<STOCK_CATEGORY>, IOrderedQueryable<STOCK_CATEGORY>> orderBy = sc => sc.OrderBy(s => s.Stock_Category_Name);

                return base.GetModelsBy(selector, orderBy);


                //return base.GetAll().OrderBy(s => s.Name).ToList();
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
                Expression<Func<STOCK_CATEGORY, bool>> predicate = Category => Category.Stock_Category_Id == stockCategory.Id;
                STOCK_CATEGORY stockCategoryEntity = GetEntityBy(predicate);
                stockCategoryEntity.Stock_Category_Name = stockCategory.Name;
                stockCategoryEntity.Stock_Category_Description = stockCategory.Description;

                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
            catch (Exception)
            {
                //repository.GetContext().Refresh(RefreshMode.StoreWins, bankEntity);
                //repository.SaveChanges();
                throw;
            }
        }

        public bool Remove(StockCategory stockCategory)
        {
            try
            {
                Expression<Func<STOCK_CATEGORY, bool>> selector = Category => Category.Stock_Category_Id == stockCategory.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StocksAndStockTypesUnderCategory GetStocksByCategory(StockCategory stockCategory)
        {
            try
            {
                StocksAndStockTypesUnderCategory stocksAndStockType = new StocksAndStockTypesUnderCategory();
                List<StockType> stockTypes = (from StockType stockType in stockTypeLogic.GetAll()
                                              where stockType.Category.Id == stockCategory.Id
                                              select stockType).ToList();

                stocksAndStockType.StockTypes = stockTypes;

                List<Stock> stocks = new List<Stock>();
                foreach (StockType type in stockTypes)
                {
                    Expression<Func<STOCK, bool>> selector = s => s.Stock_Type_Id == type.Id;

                    List<Stock> retrievedStocks = stockLogic.GetModelsBy(selector);
                    if (retrievedStocks != null && retrievedStocks.Count > 0)
                    {
                        stocks.AddRange(retrievedStocks);
                    }

                    //List<Stock> retrievedstocks = stockLogic.GetAll().Where(stk => stk.Type.Id == type.Id).ToList();
                    //stocks.AddRange(retrievedstocks);
                }
                
                stocksAndStockType.Stocks = stocks;
                return stocksAndStockType;
            }
            catch(Exception)
            {
                throw;
            }
        }





    }
}
