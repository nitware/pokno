using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class StockReviewTranslator : TranslatorBase<StockReview, STOCK_REVIEW>
    {
        private PersonTranslator personTranslator;

        public StockReviewTranslator()
        {
            personTranslator = new PersonTranslator();
        }

        public override StockReview TranslateToModel(STOCK_REVIEW entity)
        {
            try
            {
                StockReview storeStockReview = null;
                if (entity != null)
                {
                    storeStockReview = new StockReview();
                    storeStockReview.Id = entity.Stock_Review_Summary_Id;
                    storeStockReview.ReviewYear = (int)entity.Review_Year;
                    storeStockReview.ReviewedBy = personTranslator.Translate(entity.PERSON);
                    storeStockReview.ReviewDate = entity.Review_Date;
                }

                return storeStockReview;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_REVIEW TranslateToEntity(StockReview storeStockReview)
        {
            try
            {
                STOCK_REVIEW entity = null;
                if (storeStockReview != null)
                {
                    entity = new STOCK_REVIEW();
                    entity.Stock_Review_Summary_Id = storeStockReview.Id;
                    entity.Review_Year = storeStockReview.ReviewYear;
                    entity.Reviewed_By_Person_Id = storeStockReview.ReviewedBy.Id;
                    entity.Review_Date = storeStockReview.ReviewDate;
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
