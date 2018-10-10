using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class StockPackageTranslator : TranslatorBase<StockPackage, STOCK_PACKAGE>
    {
        private StockTranslator stockTranslator;
        private PackageTranslator packageTranslator;

        public StockPackageTranslator()
        {
            stockTranslator = new StockTranslator();
            packageTranslator = new PackageTranslator();
        }

        public override StockPackage TranslateToModel(STOCK_PACKAGE stockPackageEntity)
        {
            try
            {
                StockPackage stockPackage = null;

                if (stockPackageEntity != null)
                {
                    stockPackage = new StockPackage();
                    stockPackage.Id = stockPackageEntity.Stock_Package_Id;
                    stockPackage.ReOrderLevel = stockPackageEntity.Re_Order_Level;
                    stockPackage.Stock = stockTranslator.Translate(stockPackageEntity.STOCK);
                    stockPackage.Description = stockPackageEntity.Stock_Package_Description;
                    stockPackage.Package = packageTranslator.Translate(stockPackageEntity.PACKAGE);
                    stockPackage.ExpiryDaysAlert = stockPackageEntity.Expiry_Date_No_Of_Days_Alert;
                }

                return stockPackage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_PACKAGE TranslateToEntity(StockPackage stockPackage)
        {
            try
            {
                STOCK_PACKAGE stockPackageEntity = null;
                if (stockPackage != null)
                {
                    stockPackageEntity = new STOCK_PACKAGE();
                    stockPackageEntity.Stock_Package_Id = stockPackage.Id;
                    stockPackageEntity.Re_Order_Level = stockPackage.ReOrderLevel;
                    stockPackageEntity.Stock_Id = stockPackage.Stock.Id;
                    stockPackageEntity.Stock_Package_Description = stockPackage.Description;
                    stockPackageEntity.Package_Id = stockPackage.Package.Id;
                    stockPackageEntity.Expiry_Date_No_Of_Days_Alert = stockPackage.ExpiryDaysAlert;
                }
                return stockPackageEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
