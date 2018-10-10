using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class StockTypeLogic : BusinessLogicBase<StockType, STOCK_TYPE>
    {
        public StockTypeLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockTypeTranslator();
        }

        public override List<StockType> GetAll()
        {
            try
            {
                Expression<Func<STOCK_TYPE, bool>> selector = s => s.Stock_Type_Id > 0;
                Func<IQueryable<STOCK_TYPE>, IOrderedQueryable<STOCK_TYPE>> orderBy = s => s.OrderBy(st => st.Stock_Type_Name);

                return base.GetModelsBy(selector, orderBy);


                //List<StockType> stockTypes = null;

                //stockTypes = base.GetAll();
                //if (stockTypes != null)
                //{
                //    stockTypes = stockTypes.OrderBy(s => s.Name).ToList();
                //}

                //return stockTypes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockType Get(int id)
        {
            try
            {
                Expression<Func<STOCK_TYPE, bool>> selector = st => st.Stock_Type_Id == id;
                return GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockType> GetAllUnsold()
        {
            List<StockType> stockTypes = null;

            try
            {
                string query = "SELECT Distinct Stock_Type_Id FROM VW_STOCK_FOR_SALE_SUMMARY";
                List<int> unsoldStockTypeIds = repository.DbContext.Database.SqlQuery<int>(query).ToList();

                if (unsoldStockTypeIds != null && unsoldStockTypeIds.Count > 0)
                {
                    stockTypes = new List<StockType>();
                    foreach (int unsoldStockTypeId in unsoldStockTypeIds)
                    {
                        StockType stockType = new StockType();
                        stockType = Get(unsoldStockTypeId);
                        stockTypes.Add(stockType);
                    }
                }

                if (stockTypes != null)
                {
                    stockTypes = stockTypes.OrderBy(st => st.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stockTypes;
        }


        //public List<StockType> GetAllUnsold()
        //{
        //    try
        //    {
        //        List<StockType> stockTypes = null;
        //        List<int> unsoldStockTypeIds = repository.GetBy<VW_STOCK_FOR_SALE_SUMMARY>().Select(s => s.Stock_Type_Id).Distinct().ToList();

        //        if (unsoldStockTypeIds != null && unsoldStockTypeIds.Count > 0)
        //        {
        //            stockTypes = new List<StockType>();
        //            foreach (int unsoldStockTypeId in unsoldStockTypeIds)
        //            {
        //                StockType stockType = new StockType();
        //                stockType = Get(unsoldStockTypeId);
        //                stockTypes.Add(stockType);
        //            }
        //        }

        //        if (stockTypes != null)
        //        {
        //            stockTypes = stockTypes.OrderBy(st => st.Name).ToList();
        //        }

        //        return stockTypes;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool Modify(StockType stockType)
        {
            try
            {
                Expression<Func<STOCK_TYPE, bool>> predicate = stokType => stokType.Stock_Type_Id == stockType.Id;
                STOCK_TYPE stockTypeEntity  = GetEntityBy(predicate);
                stockTypeEntity.Stock_Type_Name = stockType.Name;
                stockTypeEntity.Stock_Type_Description = stockType.Description;
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
                throw;
            }
        }

        public bool Remove(StockType stockType)
        {
            try
            {
                Expression<Func<STOCK_TYPE, bool>> selector = st => st.Stock_Type_Id == stockType.Id;
                bool suceeded = base.Remove(selector);
                
                //repository.Save();
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }

}
