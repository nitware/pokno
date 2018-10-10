using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class PurchasedStockReturnTranslator : TranslatorBase<PurchasedStockReturn, STOCK_PURCHASED_RETURN>
    {
        private StockPackageTranslator _stockPackageTranslator;
        private StockPurchaseBatchTranslator _stockPurchaseBatchTranslator;
        private StockPackageRelationshipTranslator _stockPackageRelationshipTranslator;
        private ReplacedStockActionTranslator _replacedStockActionTranslator;
        private StockStateTranslator _stockStateTranslator;
        private PersonTranslator _personTranslator;

        public PurchasedStockReturnTranslator()
        {
            _stockPackageTranslator = new StockPackageTranslator();
            _stockPurchaseBatchTranslator = new StockPurchaseBatchTranslator();
            _stockPackageRelationshipTranslator = new StockPackageRelationshipTranslator();
            _replacedStockActionTranslator = new ReplacedStockActionTranslator();
            _stockStateTranslator = new StockStateTranslator();
            _personTranslator = new PersonTranslator();
        }

        public override PurchasedStockReturn TranslateToModel(STOCK_PURCHASED_RETURN entity)
        {
            try
            {
                PurchasedStockReturn model = null;
                if (entity != null)
                {
                    model = new PurchasedStockReturn();
                    model.Id = entity.Stock_Purchased_Return_Id;
                    model.Quantity = (int)entity.Quantity;
                    model.UnitCost = Math.Round(entity.Unit_Cost, 2);
                    model.Cost = Math.Round(entity.Cost, 2);
                    model.StockPackage = _stockPackageTranslator.Translate(entity.STOCK_PACKAGE);
                    model.Batch = _stockPurchaseBatchTranslator.Translate(entity.STOCK_PURCHASE_BATCH);
                    model.StockPackageRelationship = _stockPackageRelationshipTranslator.Translate(entity.STOCK_PACKAGE_RELATIONSHIP);
                    model.StockState = _stockStateTranslator.Translate(entity.STOCK_STATE);
                    model.Action = _replacedStockActionTranslator.Translate(entity.REPLACED_STOCK_ACTION);
                    model.ReturnedBy = _personTranslator.Translate(entity.PERSON);
                    model.DateReturnd = entity.Date_Returned;
                    model.ReturnReason = entity.Return_Reason;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_PURCHASED_RETURN TranslateToEntity(PurchasedStockReturn model)
        {
            try
            {
                STOCK_PURCHASED_RETURN entity = null;
                if (model != null)
                {
                    entity = new STOCK_PURCHASED_RETURN();
                    entity.Quantity = (long)model.Quantity;
                    entity.Unit_Cost = model.UnitCost;
                    entity.Cost = model.Cost;
                    entity.Stock_Package_Id = model.StockPackage.Id;
                    entity.Stock_Purchase_Batch_Id = model.Batch.Id;
                    entity.Stock_Package_Relationship_Id = model.StockPackageRelationship.Id;
                    entity.Stock_State_Id = model.StockState.Id;
                    entity.Date_Returned = model.DateReturnd;
                    entity.Return_Reason = model.ReturnReason;

                    if (model.Action != null && model.Action.Id > 0)
                    {
                        entity.Replaced_Stock_Action_Id = model.Action.Id;
                    }
                    if (model.ReturnedBy != null && model.ReturnedBy.Id > 0)
                    {
                        entity.Returned_By_Person_Id = model.ReturnedBy.Id;
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
