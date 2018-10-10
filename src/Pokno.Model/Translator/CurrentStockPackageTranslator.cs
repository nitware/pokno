using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class CurrentStockPackageTranslator : TranslatorBase<CurrentStockPackage, CURRENT_STOCK_PACKAGE>
    {
        private StockPackageTranslator stockPackageTranslator;

        public CurrentStockPackageTranslator()
        {
            stockPackageTranslator = new StockPackageTranslator();
        }

        public override CurrentStockPackage TranslateToModel(CURRENT_STOCK_PACKAGE entity)
        {
            try
            {
                CurrentStockPackage model = null;
                if (entity != null)
                {
                    model = new CurrentStockPackage();
                    model.StockPackage = new StockPackage();
                    model.StockPackage.Id = entity.Stock_Package_Id;

                    if (entity.STOCK_PACKAGE != null)
                    {
                        model.StockPackage = stockPackageTranslator.Translate(entity.STOCK_PACKAGE);
                    }
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override CURRENT_STOCK_PACKAGE TranslateToEntity(CurrentStockPackage model)
        {
            try
            {
                CURRENT_STOCK_PACKAGE entity = null;
                if (model != null)
                {
                    entity = new CURRENT_STOCK_PACKAGE();
                    entity.Stock_Package_Id = model.StockPackage.Id;
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
