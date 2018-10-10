using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class DeletedShelfStockTranslator : TranslatorBase<DeletedShelfStock, DELETED_SHELF_STOCK>
    {
        private PersonTranslator personTranslator;
        private StockPackageTranslator stockPackageTranslator;
        private StockPackageRelationshipTranslator stockPackageRelationshipTranslator;

        public DeletedShelfStockTranslator()
        {
            personTranslator = new PersonTranslator();
            stockPackageTranslator = new StockPackageTranslator();
            stockPackageRelationshipTranslator = new StockPackageRelationshipTranslator();
        }

        public override DeletedShelfStock TranslateToModel(DELETED_SHELF_STOCK deletedStockOnshelfEntity)
        {
            try
            {
                DeletedShelfStock deletedStockOnshelf = null;
                if (deletedStockOnshelfEntity != null)
                {
                    deletedStockOnshelf = new DeletedShelfStock();
                    deletedStockOnshelf.Id = deletedStockOnshelfEntity.Shelf_Id;
                    deletedStockOnshelf.StockPackage = stockPackageTranslator.Translate(deletedStockOnshelfEntity.STOCK_PACKAGE);
                    deletedStockOnshelf.Quantity = deletedStockOnshelfEntity.Quantity;
                    deletedStockOnshelf.StockPackageRelationship = stockPackageRelationshipTranslator.Translate(deletedStockOnshelfEntity.STOCK_PACKAGE_RELATIONSHIP);
                    deletedStockOnshelf.DeletedBy = personTranslator.Translate(deletedStockOnshelfEntity.PERSON);
                    deletedStockOnshelf.DateDeleted = deletedStockOnshelfEntity.Date_Deleted;
                }

                return deletedStockOnshelf;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DELETED_SHELF_STOCK TranslateToEntity(DeletedShelfStock deletedStockOnshelf)
        {
            try
            {
                DELETED_SHELF_STOCK deletedStockOnshelfEntity = null;
                if (deletedStockOnshelf != null)
                {
                    deletedStockOnshelfEntity = new DELETED_SHELF_STOCK();
                    deletedStockOnshelfEntity.Shelf_Id = deletedStockOnshelf.Id;
                    deletedStockOnshelfEntity.Stock_Package_Id = deletedStockOnshelf.StockPackage.Id;
                    deletedStockOnshelfEntity.Quantity = deletedStockOnshelf.Quantity;
                    deletedStockOnshelfEntity.Stock_Package_Relationship_Id = deletedStockOnshelf.StockPackageRelationship.Id;
                    deletedStockOnshelfEntity.Deleted_By = deletedStockOnshelf.DeletedBy.Id;
                    deletedStockOnshelfEntity.Date_Deleted = deletedStockOnshelf.DateDeleted;
                }

                return deletedStockOnshelfEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }


}
