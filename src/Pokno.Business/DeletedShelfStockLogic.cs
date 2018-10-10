using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;
using Pokno.Model;
using System.Transactions;
using System.Data;
using System.Linq.Expressions;

namespace Pokno.Business
{
    public class DeletedShelfStockLogic : BusinessLogicBase<DeletedShelfStock, DELETED_SHELF_STOCK>
    {
        private ShelfLogic shelfLogic;
        private PackageRelationshipLogic packageRelationshipLogic;

        public DeletedShelfStockLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            shelfLogic = new ShelfLogic(repository);
            translator = new DeletedShelfStockTranslator();
            packageRelationshipLogic = new PackageRelationshipLogic(repository);
        }

        public override int Add(List<DeletedShelfStock> deletedStocksOnShelf)
        {
            try
            {
                if (deletedStocksOnShelf == null || deletedStocksOnShelf.Count <= 0)
                {
                    throw new ArgumentNullException("deletedStocksOnShelf");
                }

                int deleteStockCount = 0;
                List<Shelf> shelfStocks = new List<Shelf>();
                List<DeletedShelfStock> deletedShelfStocks = new List<DeletedShelfStock>();

                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    foreach (DeletedShelfStock deletedStockOnShelf in deletedStocksOnShelf)
                    {
                        for (int i = 0; i < deletedStockOnShelf.Quantity; i++)
                        {
                            DeletedShelfStock shelfStockToDelete = new DeletedShelfStock();
                            shelfStockToDelete.StockPackage = deletedStockOnShelf.StockPackage;
                            shelfStockToDelete.DateDeleted = deletedStockOnShelf.DateDeleted;
                            shelfStockToDelete.DeletedBy = deletedStockOnShelf.DeletedBy;
                            shelfStockToDelete.StockPackageRelationship = deletedStockOnShelf.StockPackageRelationship;
                            shelfStockToDelete.Quantity = 1;

                            deletedShelfStocks.Add(shelfStockToDelete);
                        }

                        Expression<Func<SHELF, bool>> selector = s => s.Stock_Package_Id == deletedStockOnShelf.StockPackage.Id && s.Stock_Package_Relationship_Id == deletedStockOnShelf.StockPackageRelationship.Id && s.Sold == false;
                        List<Shelf> shelfs = shelfLogic.GetTopBy((int)deletedStockOnShelf.Quantity, selector);
                        shelfStocks.AddRange(shelfs);
                    }

                    for (int i = 0; i < deletedShelfStocks.Count; i++)
                    {
                        deletedShelfStocks[i].Id = shelfStocks[i].Id;
                    }

                    deleteStockCount = base.Add(deletedShelfStocks);
                    if (deleteStockCount <= 0 || deleteStockCount != deletedShelfStocks.Count)
                    {
                        throw new Exception("Shelf stock deletion failed! Please try again.");
                    }

                    shelfLogic.repository = repository;
                    bool removed = shelfLogic.Remove(shelfStocks);
                    if (removed == false)
                    {
                        throw new Exception("Removal of stocks on shelf failed! " + TryAgain);
                    }

                    transaction.Commit();
                    repository.DbContext.Database.Connection.Close();
                }

                return deleteStockCount;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }


}
