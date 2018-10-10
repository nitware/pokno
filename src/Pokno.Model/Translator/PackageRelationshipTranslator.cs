using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;
using Pokno.Model.Translator;

namespace Pokno.Model
{
    public class PackageRelationshipTranslator : TranslatorBase<PackageRelationship, PACKAGE_RELATIONSHIP>
    {
        private StockPackageTranslator stockPackageTranslator;
        private StockPackageRelationshipTranslator stockPackageRelationshipTranslator;
        
        public PackageRelationshipTranslator()
        {
            stockPackageTranslator = new StockPackageTranslator();
            stockPackageRelationshipTranslator = new StockPackageRelationshipTranslator();
        }

        public override PackageRelationship TranslateToModel(PACKAGE_RELATIONSHIP entity)
        {
            try
            {
                PackageRelationship model = null;
                if (entity != null)
                {
                    model = new PackageRelationship();
                    model.Id = entity.Package_Relationship_Id;
                    model.Package = stockPackageTranslator.Translate(entity.STOCK_PACKAGE1);
                    model.SubPackage = stockPackageTranslator.Translate(entity.STOCK_PACKAGE);
                    model.Quantity = entity.Quantity_In_Package;
                    model.StockPackageRelationship = stockPackageRelationshipTranslator.Translate(entity.STOCK_PACKAGE_RELATIONSHIP);
                    model.Rank = entity.Rank;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PACKAGE_RELATIONSHIP TranslateToEntity(PackageRelationship model)
        {
            try
            {
                PACKAGE_RELATIONSHIP entity = null;
                if (model != null)
                {
                    entity = new PACKAGE_RELATIONSHIP();
                    entity.Package_Relationship_Id = model.Id;
                    entity.Stock_Package_Id = model.Package.Id;
                    entity.Quantity_In_Package = model.Quantity;
                    entity.Stock_Package_Relationship_Id = model.StockPackageRelationship.Id;
                    entity.Rank = model.Rank;

                    if (model.SubPackage != null && model.SubPackage.Id > 0)
                    {
                        entity.Sub_Stock_Package_Id = model.SubPackage.Id;
                    }
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
