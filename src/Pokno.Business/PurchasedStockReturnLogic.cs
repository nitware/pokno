using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using Pokno.Model.Translator;
using Pokno.Model;
using System.Linq.Expressions;
using System.Data;

namespace Pokno.Business
{
    public class PurchasedStockReturnLogic : BusinessLogicBase<PurchasedStockReturn, STOCK_PURCHASED_RETURN>
    {
        private StockPackageRelationshipLogic _stockPackageRelationshipLogic;

        public PurchasedStockReturnLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new PurchasedStockReturnTranslator();
            _stockPackageRelationshipLogic = new StockPackageRelationshipLogic(repository);
        }

        public List<PurchasedStockReturn> GetBy(StockPurchaseBatch purchasedBatch)
        {
            try
            {
                Expression<Func<STOCK_PURCHASED_RETURN, bool>> selector = spb => spb.Stock_Purchase_Batch_Id == purchasedBatch.Id;
                return base.GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int Add(List<PurchasedStockReturn> returnBoundStocksPurchased)
        {
            try
            {
                if (returnBoundStocksPurchased == null || returnBoundStocksPurchased.Count <= 0)
                {
                    throw new Exception("returnBoundStocksPurchased");
                }

                List<PurchasedStockReturn> completeReturnBoundStocksPurchased = SetStockPackageRelationship(returnBoundStocksPurchased);

                int rowsAdded = base.Add(completeReturnBoundStocksPurchased);
                if (rowsAdded <= 0)
                {
                    throw new Exception("Stocks Purchased cannot be saved for return! " + TryAgain);
                }

                return rowsAdded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(List<PurchasedStockReturn> returnBoundStocksPurchased)
        {
            try
            {
                if (returnBoundStocksPurchased == null || returnBoundStocksPurchased.Count <= 0)
                {
                    throw new Exception("returnBoundStocksPurchased");
                }

                int modifiedRecordCount = 0;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    long purchaseBatch = returnBoundStocksPurchased[0].Batch.Id;
                    bool removed = base.Remove(spr => spr.Stock_Purchase_Batch_Id == purchaseBatch);
                    if (removed == false)
                    {
                        throw new Exception("Removing existing Return Bound Purchased Stocks failed! " + TryAgain);
                    }

                    List<PurchasedStockReturn> completeReturnBoundStocksPurchased = SetStockPackageRelationship(returnBoundStocksPurchased);

                    modifiedRecordCount = Add(completeReturnBoundStocksPurchased);
                    if (modifiedRecordCount <= 0 || modifiedRecordCount != completeReturnBoundStocksPurchased.Count)
                    {
                        throw new Exception("Saving the modified Return Bound Purchased Stocks failed! " + TryAgain);
                    }

                    base.CommitTransaction(transaction);
                }

                return (modifiedRecordCount > 0 && modifiedRecordCount == returnBoundStocksPurchased.Count) ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<PurchasedStockReturn> SetStockPackageRelationship(List<PurchasedStockReturn> returnBoundStocksPurchased)
        {
            try
            {
                foreach (PurchasedStockReturn returnBoundStockPurchased in returnBoundStocksPurchased)
                {
                    returnBoundStockPurchased.StockPackageRelationship = _stockPackageRelationshipLogic.GetBy(returnBoundStockPurchased.StockPackage.Stock);
                }

                return returnBoundStocksPurchased;
            }
            catch(Exception)
            {
                throw;
            }
        }

        





    }




}
