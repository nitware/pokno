using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model
{
    public class StockPackageRelationshipTranslator : TranslatorBase<StockPackageRelationship, STOCK_PACKAGE_RELATIONSHIP>
    {
        private StockTranslator stockTranslator;
        private PersonTranslator personTranslator;

        public StockPackageRelationshipTranslator()
        {
            stockTranslator = new StockTranslator();
            personTranslator = new PersonTranslator();
        }

        public override StockPackageRelationship TranslateToModel(STOCK_PACKAGE_RELATIONSHIP entity)
        {
            try
            {
                StockPackageRelationship model = null;
                if (entity != null)
                {
                    model = new StockPackageRelationship();
                    model.Id = entity.Stock_Package_Relationship_Id;
                    model.Stock = stockTranslator.Translate(entity.STOCK);
                    model.SetBy = personTranslator.Translate(entity.PERSON);
                    model.DateSet = entity.Date_Set;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override STOCK_PACKAGE_RELATIONSHIP TranslateToEntity(StockPackageRelationship model)
        {
            try
            {
                STOCK_PACKAGE_RELATIONSHIP entity = null;
                if (model != null)
                {
                    entity = new STOCK_PACKAGE_RELATIONSHIP();
                    entity.Stock_Package_Relationship_Id = model.Id;
                    entity.Stock_Id = model.Stock.Id;
                    entity.Date_Set = model.DateSet;
                    entity.Set_By_Person_Id = model.SetBy.Id;
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
