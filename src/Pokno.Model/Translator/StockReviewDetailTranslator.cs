using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class StockReviewDetailTranslator : TranslatorBase<StockReviewDetail, STOCK_REVIEW_DETAIL>
    {
        public override StockReviewDetail TranslateToModel(STOCK_REVIEW_DETAIL entity)
        {
            try
            {
                StockReviewDetail storeStockReviewSummary = null;
                if (entity != null)
                {
                    storeStockReviewSummary = new StockReviewDetail();
                    storeStockReviewSummary.Id = entity.Stock_Review_Detail_Id;
                    storeStockReviewSummary.StockReviewId = entity.Stock_Review_Id;
                    storeStockReviewSummary.StockPackageBalance = entity.Stock_Balance;
                    storeStockReviewSummary.InitialStockBalance = entity.Initial_Stock_Balance;
                    storeStockReviewSummary.StockBalanceValue = entity.Stock_Balance_Value.HasValue ? entity.Stock_Balance_Value.Value : (decimal)0;
                    storeStockReviewSummary.InitialStockBalanceValue = entity.Initial_Stock_Balance_Value.HasValue ? entity.Initial_Stock_Balance_Value.Value : (decimal)0;
                    storeStockReviewSummary.StockId = entity.Stock_Id;
                    storeStockReviewSummary.StockName = entity.Stock_Name;
                    storeStockReviewSummary.QuantityPackagePurchased = entity.Quantity_Purchased;
                    storeStockReviewSummary.Cost = entity.Cost;
                    storeStockReviewSummary.TransactionMonth = entity.Transaction_Month;
                    storeStockReviewSummary.TransactionYear = entity.Transaction_Year;
                    storeStockReviewSummary.QuantityPackageSold = entity.Quantity_Sold;
                    storeStockReviewSummary.CostPrice = entity.Cost_Price;
                    storeStockReviewSummary.SellingPrice = entity.Selling_Price;
                    storeStockReviewSummary.Discount = entity.Discount;
                    storeStockReviewSummary.MonthName = GetMonthName(entity.Transaction_Month);
                    storeStockReviewSummary.Profit = entity.Profit;
                    storeStockReviewSummary.MonthlyTotalExpenses = entity.Monthly_Total_Expenses;
                    storeStockReviewSummary.MonthlyTransactionDiscount = entity.Monthly_Transaction_Discount;
                    storeStockReviewSummary.StockPackageRelationshipId = entity.Stock_Package_Relationship_Id;
                    storeStockReviewSummary.RelationshipOfStockPackage = entity.Package_Relationship;
                    storeStockReviewSummary.StockBalanceUnitItem = entity.Stock_Balance_Unit_Item;

                    storeStockReviewSummary.Profit2 = entity.Profit2;

                    //storeStockReviewSummary.StockPackageId = entity.Stock_Package_Id;
                    //storeStockReviewSummary.PackageId = entity.Package_Id;
                    //storeStockReviewSummary.PackageName = entity.Package_Name;
                    //storeStockReviewSummary.StockPurchaseBatchId = entity.Stock_Purchase_Batch_Id;
                    //storeStockReviewSummary.UnitCost = entity.Unit_Cost;
                    //storeStockReviewSummary.AmountPayable = entity.Amount_Payable;
                    //storeStockReviewSummary.AmountPaid = entity.Amount_Paid;
                    //storeStockReviewSummary.MiscExpenses = entity.Misc_Expenses;
                    //storeStockReviewSummary.DatePurchased = entity.Date_Purchased;
                    //storeStockReviewSummary.SoldStockBatchId = entity.Sold_Stock_Batch_Id;
                    //storeStockReviewSummary.TransactionDiscount = entity.Transaction_Discount;
                    //storeStockReviewSummary.ActualSellingPrice = entity.Actual_Selling_Price;
                    //storeStockReviewSummary.TotalAmountPaid = entity.Total_Amount_Paid;
                    //storeStockReviewSummary.MonthYearSold = entity.Month_Year_Sold;
                }

                return storeStockReviewSummary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_REVIEW_DETAIL TranslateToEntity(StockReviewDetail storeStockReviewSummary)
        {
            try
            {
                STOCK_REVIEW_DETAIL entity = null;
                if (storeStockReviewSummary != null)
                {
                    entity = new STOCK_REVIEW_DETAIL();
                    entity.Stock_Review_Detail_Id = storeStockReviewSummary.Id;
                    entity.Stock_Review_Id = storeStockReviewSummary.StockReviewId;
                    entity.Stock_Balance = storeStockReviewSummary.StockPackageBalance;
                    entity.Initial_Stock_Balance = storeStockReviewSummary.InitialStockBalance;
                    entity.Stock_Balance_Value = storeStockReviewSummary.StockBalanceValue;
                    entity.Initial_Stock_Balance_Value = storeStockReviewSummary.InitialStockBalanceValue;
                    entity.Stock_Id = storeStockReviewSummary.StockId;
                    entity.Stock_Name = storeStockReviewSummary.StockName;
                    entity.Quantity_Purchased = storeStockReviewSummary.QuantityPackagePurchased;
                    entity.Cost = storeStockReviewSummary.Cost;
                    entity.Transaction_Month = storeStockReviewSummary.TransactionMonth;
                    entity.Transaction_Year = storeStockReviewSummary.TransactionYear;
                    entity.Quantity_Sold = storeStockReviewSummary.QuantityPackageSold;
                    entity.Cost_Price = storeStockReviewSummary.CostPrice;
                    entity.Selling_Price = storeStockReviewSummary.SellingPrice;
                    entity.Discount = storeStockReviewSummary.Discount;
                    entity.Profit = storeStockReviewSummary.Profit;
                    entity.Monthly_Total_Expenses = storeStockReviewSummary.MonthlyTotalExpenses;
                    entity.Monthly_Transaction_Discount = storeStockReviewSummary.MonthlyTransactionDiscount;
                    entity.Stock_Package_Relationship_Id = (int)storeStockReviewSummary.StockPackageRelationshipId;
                    entity.Package_Relationship = storeStockReviewSummary.RelationshipOfStockPackage;
                    entity.Stock_Balance_Unit_Item = storeStockReviewSummary.StockBalanceUnitItem;

                    entity.Profit2 = storeStockReviewSummary.Profit2;

                    //entity.Stock_Package_Id = storeStockReviewSummary.StockPackageId;
                    //entity.Package_Id = storeStockReviewSummary.PackageId;
                    //entity.Package_Name = storeStockReviewSummary.PackageName;
                    //entity.Stock_Purchase_Batch_Id = storeStockReviewSummary.StockPurchaseBatchId;
                    //entity.Unit_Cost = storeStockReviewSummary.UnitCost;
                    //entity.Amount_Payable = storeStockReviewSummary.AmountPayable;
                    //entity.Amount_Paid = storeStockReviewSummary.AmountPaid;
                    //entity.Misc_Expenses = storeStockReviewSummary.MiscExpenses;
                    //entity.Date_Purchased = storeStockReviewSummary.DatePurchased;
                    //entity.Sold_Stock_Batch_Id = storeStockReviewSummary.SoldStockBatchId;
                    //entity.Transaction_Discount = storeStockReviewSummary.TransactionDiscount;
                    //entity.Actual_Selling_Price = storeStockReviewSummary.ActualSellingPrice;
                    //entity.Total_Amount_Paid = storeStockReviewSummary.TotalAmountPaid;
                    //entity.Month_Year_Sold = storeStockReviewSummary.MonthYearSold;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetMonthName(long? monthIndex)
        {
            try
            {

                string monthName = "";
                switch (monthIndex)
                {
                    case (int)CalendarMonth.January:
                        {
                            monthName = CalendarMonth.January.ToString();
                            break;
                        }
                    case 2:
                        {
                            monthName = CalendarMonth.February.ToString();
                            break;
                        }
                    case 3:
                        {
                            monthName = CalendarMonth.March.ToString();
                            break;
                        }
                    case 4:
                        {
                            monthName = CalendarMonth.April.ToString();
                            break;
                        }
                    case 5:
                        {
                            monthName = CalendarMonth.May.ToString();
                            break;
                        }
                    case 6:
                        {
                            monthName = CalendarMonth.June.ToString();
                            break;
                        }
                    case 7:
                        {
                            monthName = CalendarMonth.July.ToString();
                            break;
                        }
                    case 8:
                        {
                            monthName = CalendarMonth.August.ToString();
                            break;
                        }
                    case 9:
                        {
                            monthName = CalendarMonth.September.ToString();
                            break;
                        }
                    case 10:
                        {
                            monthName = CalendarMonth.October.ToString();
                            break;
                        }
                    case 11:
                        {
                            monthName = CalendarMonth.November.ToString();
                            break;
                        }
                    case 12:
                        {
                            monthName = CalendarMonth.December.ToString();
                            break;
                        }
                }

                return monthName;
            }
            catch (Exception)
            {
                throw;
            }
        }






    }


}
