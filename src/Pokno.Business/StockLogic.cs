using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using System.Data;
using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Model.Model;
using System.Collections.ObjectModel;
using Pokno.Model.Views;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class StockLogic : BusinessLogicBase<Stock, STOCK>
    {
        private PackageRelationshipLogic _packageRelationshipLogic;

        public StockLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockTranslator();
            _packageRelationshipLogic = new PackageRelationshipLogic(repository);
        }

        public override List<Stock> GetAll()
        {
            try
            {
                Expression<Func<STOCK, bool>> selector = s => s.Stock_Id > 0;
                Func<IQueryable<STOCK>, IOrderedQueryable<STOCK>> orderBy = s => s.OrderBy(st => st.Stock_Name);

                return base.GetModelsBy(selector, orderBy);


                //List<Stock> stocks = base.GetAll();
                //if (stocks != null && stocks.Count > 0)
                //{
                //    stocks = stocks.OrderBy(s => s.Name).ToList();
                //}

                //return stocks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Stock> GetAllWithDependant()
        {
            List<Stock> stocks = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK";
                stocks = (from s in repository.DbContext.Database.SqlQuery<VW_STOCK>(query)
                          select new Stock
                          {
                              Id = s.Stock_Id,
                              Name = s.Stock_Name,
                              Description = s.Stock_Descrption,
                              ImagePath = s.Image_Path,
                              HasPackage = s.Stock_Package_Count > 0 ? true : false,
                              HasPackageRelationship = s.Package_Relationship_Count > 0 ? true : false,
                              HasPrice = s.Stock_Price_Count > 0 ? true : false,
                          }).ToList();

            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stocks;
        }

        public bool Modify(Stock stock)
        {
            try
            {
                Expression<Func<STOCK, bool>> predicate = stockItem => stockItem.Stock_Id == stock.Id;
                STOCK stockEntity = GetEntityBy(predicate);
                stockEntity.Stock_Name = stock.Name;
                stockEntity.Stock_Type_Id = stock.Type.Id;
                stockEntity.Image_Path = stock.ImagePath;
                stockEntity.Stock_Descrption = stock.Description;

                int rowAffected = repository.Save();
                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
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
                Expression<Func<STOCK, bool>> selector = stockItem => stockItem.Stock_Id == stock.Id;
                bool suceeded = base.Remove(selector);
                
                //repository.Save();
                return suceeded;
            }           
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreStock> Get()
        {
            try
            {
                List<Stock> stocks = base.GetAll();
                List<StoreStock> storeStocks = GetHelper(stocks);

                return storeStocks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static List<StoreStock> GetHelper(List<Stock> stocks)
        {
            try
            {
                List<StoreStock> storeStocks = new List<StoreStock>();
                if (stocks != null && stocks.Count > 0)
                {
                    foreach (Stock stock in stocks)
                    {
                        StoreStock storeStock = new StoreStock();
                        storeStock.StockName = stock.Name;
                        storeStock.StockType = stock.Type.Name;
                        storeStock.StockDescription = stock.Description;

                        storeStocks.Add(storeStock);
                    }
                }

                return storeStocks;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public List<StoreStock> GetBy(StockType type)
        {
            try
            {
                string include = "STOCK_TYPE";

                Expression<Func<STOCK, bool>> selector = s => s.Stock_Type_Id == type.Id;
                Func<IQueryable<STOCK>, IOrderedQueryable<STOCK>> orderBy = p => p.OrderBy(x => x.Stock_Name);
                List<Stock> stocks = base.GetModelsBy(selector, orderBy, include);

                return GetHelper(stocks);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Stock Get(long id)
        {
            try
            {
                Expression<Func<STOCK, bool>> selector = s => s.Stock_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Stock> GetAllUnsoldByType(StockType stockType)
        {
            List<Stock> stocks = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_FOR_SALE_SUMMARY where Stock_Type_Id = " + stockType.Id;
                List<VW_STOCK_FOR_SALE_SUMMARY> unsoldStocks = repository.DbContext.Database.SqlQuery<VW_STOCK_FOR_SALE_SUMMARY>(query).ToList();
                
                List<long> unsoldStockIds = unsoldStocks.Select(s => s.Stock_Id).Distinct().ToList();
                if (unsoldStockIds != null && unsoldStockIds.Count > 0)
                {
                    stocks = new List<Stock>();
                    foreach (int unsoldStockId in unsoldStockIds)
                    {
                        Stock stock = new Stock();
                        stock = Get(unsoldStockId);
                        stocks.Add(stock);
                    }
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return stocks;
        }

        public List<Stock> GetAllWithPackageQuantity()
        {
            try
            {
                List<Stock> stocksWithPackageRelationship = new List<Stock>();

                List<Stock> stocks = this.GetAll();
                if (stocks != null && stocks.Count > 0)
                {
                    foreach (Stock stock in stocks)
                    {
                        List<PackageRelationship> packageRelationships = _packageRelationshipLogic.GetBy(stock);
                        if (packageRelationships != null && packageRelationships.Count > 0)
                        {
                            stocksWithPackageRelationship.Add(stock);
                        }
                    }
                }

                return stocksWithPackageRelationship;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
