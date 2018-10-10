using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Translator;
using Pokno.Entity;

namespace Pokno.Model
{
    public class ShelfTranslator : TranslatorBase<Shelf, SHELF>
    {
        private StockPackageRelationshipTranslator stockPackageRelationshipTranslator;
        private StockPurchasedPoolTranslator stockPurchasedPoolTranslator;
        private StockPackageTranslator stockPackageTranslator;
        private PersonTranslator personTranslator;
        private LocationTranslator locationTranslator;

        public ShelfTranslator()
        {
            stockPackageRelationshipTranslator = new StockPackageRelationshipTranslator();
            stockPurchasedPoolTranslator = new StockPurchasedPoolTranslator();
            stockPackageTranslator = new StockPackageTranslator();
            personTranslator = new PersonTranslator();
            locationTranslator = new LocationTranslator();
        }

        public override Shelf TranslateToModel(SHELF shelfEntity)
        {
            try
            {
                Shelf shelf = null;
                if (shelfEntity != null)
                {
                    shelf = new Shelf();
                    shelf.Id = shelfEntity.Shelf_Id;
                    shelf.StockPackage = stockPackageTranslator.Translate(shelfEntity.STOCK_PACKAGE);
                    shelf.EnteredBy = personTranslator.Translate(shelfEntity.PERSON);
                    shelf.Location = locationTranslator.Translate(shelfEntity.LOCATION);
                    shelf.Quantity = shelfEntity.Quantity;
                    shelf.TotalUnitQuantity = shelfEntity.Total_Unit_Quantity;
                    shelf.DateEntered = shelfEntity.Date_Entered;
                    shelf.ExpiryDate = shelfEntity.Expiry_Date;
                    shelf.Sold = shelfEntity.Sold;

                    shelf.StockPackageRelationship = stockPackageRelationshipTranslator.Translate(shelfEntity.STOCK_PACKAGE_RELATIONSHIP);
                }

                return shelf;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override SHELF TranslateToEntity(Shelf shelf)
        {
            try
            {
                SHELF shelfEntity = null;
                if (shelf != null)
                {
                    shelfEntity = new SHELF();
                    shelfEntity.Shelf_Id = shelf.Id;
                    shelfEntity.Stock_Package_Id = shelf.StockPackage.Id;
                    shelfEntity.Entered_By = shelf.EnteredBy.Id;
                    shelfEntity.Location_Id = shelf.Location.Id;
                    shelfEntity.Quantity = shelf.Quantity;
                    shelfEntity.Total_Unit_Quantity = shelf.TotalUnitQuantity;
                    shelfEntity.Date_Entered = shelf.DateEntered;
                    shelfEntity.Expiry_Date = shelf.ExpiryDate;
                    shelfEntity.Sold = shelf.Sold;

                    shelfEntity.Stock_Package_Relationship_Id = shelf.StockPackageRelationship.Id;
                }

                return shelfEntity;
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
