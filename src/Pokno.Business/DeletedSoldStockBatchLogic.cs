using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;
using Pokno.Model;
using System.Data;

namespace Pokno.Business
{
    public class DeletedSoldStockBatchLogic : BusinessLogicBase<DeletedSoldStockBatch, DELETED_SOLD_STOCK_BATCH>
    {
        private SoldStockBatchLogic _soldStockBatchLogic;
        private DeletedSoldStockLogic _deletedSoldStockLogic;

        public DeletedSoldStockBatchLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new DeletedSoldStockBatchTranslator();
            _deletedSoldStockLogic = new DeletedSoldStockLogic(repository);
            _soldStockBatchLogic = new SoldStockBatchLogic(repository);
        }

        public override DeletedSoldStockBatch Add(DeletedSoldStockBatch deletedSoldStockBatch)
        {
            try
            {
                if (deletedSoldStockBatch == null || deletedSoldStockBatch.SoldStocks == null || deletedSoldStockBatch.SoldStocks.Count <= 0)
                {
                    throw new ArgumentNullException("deletedSoldStockBatch");
                }

                //SoldStockBatch soldStockBatch = new SoldStockBatch();
                //soldStockBatch.SoldStocks = deletedSoldStockBatch.SoldStocks;
                //soldStockBatch.Id = deletedSoldStockBatch.Id;

                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    bool soldStockBatchRemoved = _soldStockBatchLogic.Remove(deletedSoldStockBatch.SoldStocks[0].Batch);
                    if (soldStockBatchRemoved == false)
                    {
                        throw new Exception("Existing Sold Stock removal failed! " + TryAgain);
                    }

                    DeletedSoldStockBatch newDeletedSoldStockBatch = base.Add(deletedSoldStockBatch);
                    if (newDeletedSoldStockBatch == null || newDeletedSoldStockBatch.Id <= 0)
                    {
                        throw new Exception("Deleted Sold Stock Batch save operation failed! " + TryAgain);
                    }

                    int rowsDeleted = _deletedSoldStockLogic.Add(deletedSoldStockBatch.DeletedSoldStocks);
                    if (rowsDeleted <= 0 || rowsDeleted != deletedSoldStockBatch.DeletedSoldStocks.Count)
                    {
                        throw new Exception("Deleted Sold Stock save operation failed! " + TryAgain);
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return deletedSoldStockBatch;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }


}
