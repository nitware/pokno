using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class CurrentStockPackageRelationshipTranslator : TranslatorBase<CurrentStockPackageRelationship, CURRENT_STOCK_PACKAGE_RELATIONSHIP>
    {
        private PackageRelationshipTranslator packageRelationshipTranslator;
        private StockPackageRelationshipTranslator stockPackageRelationshipTranslator;

        public CurrentStockPackageRelationshipTranslator()
        {
            packageRelationshipTranslator = new PackageRelationshipTranslator();
            stockPackageRelationshipTranslator = new StockPackageRelationshipTranslator();
        }

        public override CurrentStockPackageRelationship TranslateToModel(CURRENT_STOCK_PACKAGE_RELATIONSHIP entity)
        {
            try
            {
                CurrentStockPackageRelationship model = null;

                if (entity != null)
                {
                    model = new CurrentStockPackageRelationship();
                    model.StockPackageRelationship = new StockPackageRelationship();
                    model.StockPackageRelationship.Id = entity.Stock_Package_Relationship_Id;

                    if (entity.STOCK_PACKAGE_RELATIONSHIP != null)
                    {
                        model.StockPackageRelationship = stockPackageRelationshipTranslator.Translate(entity.STOCK_PACKAGE_RELATIONSHIP);
                        if (entity.STOCK_PACKAGE_RELATIONSHIP.PACKAGE_RELATIONSHIP != null)
                        {
                            model.StockPackageRelationship.Relationships = packageRelationshipTranslator.Translate(new List<PACKAGE_RELATIONSHIP>(entity.STOCK_PACKAGE_RELATIONSHIP.PACKAGE_RELATIONSHIP));
                        }
                    }
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override CURRENT_STOCK_PACKAGE_RELATIONSHIP TranslateToEntity(CurrentStockPackageRelationship model)
        {
            try
            {
                CURRENT_STOCK_PACKAGE_RELATIONSHIP entity = null;
                if (model != null)
                {
                    entity = new CURRENT_STOCK_PACKAGE_RELATIONSHIP();
                    entity.Stock_Package_Relationship_Id = model.StockPackageRelationship.Id;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }




}
