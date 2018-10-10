using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;
using Pokno.Model.Translator;
using Pokno.Model;
using Pokno.Model.Views;
using System.Transactions;
using System.Data;

namespace Pokno.Business
{
    public class StockPackageRelationshipLogic : BusinessLogicBase<StockPackageRelationship, STOCK_PACKAGE_RELATIONSHIP>
    {
        private PackageRelationshipLogic _packageRelationshipLogic;
        private CurrentStockPackageRelationshipLogic _currentStockPackageRelationshipLogic;

        public StockPackageRelationshipLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new StockPackageRelationshipTranslator();
            _packageRelationshipLogic = new PackageRelationshipLogic(repository);
            _currentStockPackageRelationshipLogic = new CurrentStockPackageRelationshipLogic(repository);
        }

        public StockPackageRelationship GetBy(int id)
        {
            try
            {
                Expression<Func<STOCK_PACKAGE_RELATIONSHIP, bool>> selector = spr => spr.Stock_Package_Relationship_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockPackageRelationship GetBy(Stock stock)
        {
            StockPackageRelationship currentStockPackageRelationship = null;

            try
            {
                string query = "SELECT Stock_Package_Relationship_Id FROM VW_CURRENT_STOCK_PACKAGE_RELATIONSHIP where Stock_Id = " + stock.Id;
                long packageRelationshipId = repository.DbContext.Database.SqlQuery<long>(query).FirstOrDefault();
                                
                if (packageRelationshipId > 0)
                {
                    currentStockPackageRelationship = new StockPackageRelationship() { Id = packageRelationshipId };
                }
            }
            catch (Exception ex)
            {
                base.SuppressError(ex);
            }

            return currentStockPackageRelationship;
        }

        public override StockPackageRelationship Add(StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                if (stockPackageRelationship == null || stockPackageRelationship.Relationships == null || stockPackageRelationship.Relationships.Count <= 0)
                {
                    throw new ArgumentNullException("stockPackageRelationship");
                }

                base.OpenDatabaseConnectionIfClosed();
                StockPackageRelationship newStockPackageRelationship = null;
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    newStockPackageRelationship = AddHelper(stockPackageRelationship);

                    base.CommitTransaction(transaction);


                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return newStockPackageRelationship;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private StockPackageRelationship AddHelper(StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                StockPackageRelationship newStockPackageRelationship = base.Add(stockPackageRelationship);
                if (newStockPackageRelationship == null || newStockPackageRelationship.Id <= 0)
                {
                    throw new Exception("Stock Package Relationship save operation failed! " + TryAgain);
                }

                foreach (PackageRelationship packageRelationship in stockPackageRelationship.Relationships)
                {
                    packageRelationship.StockPackageRelationship = newStockPackageRelationship;
                }

                _packageRelationshipLogic.repository = repository;
                int rowsAffected = _packageRelationshipLogic.Add(stockPackageRelationship.Relationships);
                if (rowsAffected <= 0 || rowsAffected != stockPackageRelationship.Relationships.Count)
                {
                    throw new Exception("Package Relationship save operation failed! " + TryAgain);
                }
                                
                newStockPackageRelationship.Stock = stockPackageRelationship.Stock;
                CurrentStockPackageRelationship currentStockPackageRelationship = new CurrentStockPackageRelationship();
                currentStockPackageRelationship.StockPackageRelationship = newStockPackageRelationship;

                _currentStockPackageRelationshipLogic.repository = repository;
                _currentStockPackageRelationshipLogic.Add(currentStockPackageRelationship);

                return newStockPackageRelationship;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                if (stockPackageRelationship == null || stockPackageRelationship.Id <= 0 || stockPackageRelationship.Relationships == null || stockPackageRelationship.Relationships.Count <= 0)
                {
                    throw new ArgumentNullException("stockPackageRelationship");
                }

                base.OpenDatabaseConnectionIfClosed();
                StockPackageRelationship newStockPackageRelationship = null;
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    newStockPackageRelationship = AddHelper(stockPackageRelationship);
                    if (newStockPackageRelationship == null || newStockPackageRelationship.Id <= 0)
                    {
                        throw new Exception("Existing 'Current Stock Package Relationship' removal failed! " + TryAgain);
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return newStockPackageRelationship != null && newStockPackageRelationship.Id > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Stock stock)
        {
            try
            {
                if (stock == null || stock.Id <= 0)
                {
                    throw new ArgumentNullException("stock");
                }

                if(NoPackageRelationshipExist(stock))
                {
                    throw new Exception("No Package Relationship exist for '" + stock.Name + "'");
                }

                bool deleted = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    _currentStockPackageRelationshipLogic.repository = repository;
                    bool currentStockPackageRemoved = _currentStockPackageRelationshipLogic.Remove(stock);
                    //if (currentStockPackageRemoved == false)
                    //{
                    //    throw new Exception("Current Package Relationship delete operation failed! " + TryAgain);
                    //}

                    _packageRelationshipLogic.repository = repository;
                    bool packageRelationshipRemoved = _packageRelationshipLogic.Remove(stock);
                    //if (packageRelationshipRemoved == false)
                    //{
                    //    throw new Exception("Package Relationship delete operation failed! " + TryAgain);
                    //}

                    Expression<Func<STOCK_PACKAGE_RELATIONSHIP, bool>> selector = sp => sp.Stock_Id == stock.Id;
                    deleted = base.Remove(selector);
                    if (deleted == false)
                    {
                        throw new Exception("No Package Relationship found to delete!");
                    }

                    base.CommitTransaction(transaction);


                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool NoPackageRelationshipExist(Stock stock)
        {
            try
            {
                if (stock == null || stock.Id <= 0)
                {
                    throw new ArgumentNullException("stock");
                }

                //validate
                List<CurrentStockPackageRelationship> currentStockPackageRelationships = _currentStockPackageRelationshipLogic.GetBy(stock);
                List<PackageRelationship> packageRelationships = _packageRelationshipLogic.GetBy(stock);
                StockPackageRelationship stockPackageRelationship = GetBy(stock);
                if ((currentStockPackageRelationships == null || currentStockPackageRelationships.Count <= 0) && (packageRelationships == null || packageRelationships.Count <= 0) && (stockPackageRelationship == null || stockPackageRelationship.Id <= 0))
                {
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }






    }



}
