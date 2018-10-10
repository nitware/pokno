using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model;
using Pokno.Model.Translator;
using Pokno.Model.Views;
using System.Data;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;

namespace Pokno.Business
{
    public class StockReviewLogic : BusinessLogicBase<StockReview, STOCK_REVIEW>
    {
        private SoldStockBatchLogic _soldStockBatchLogic;
        private StockReviewDetailLogic _stockReviewDetailLogic;
        private StockPurchaseBatchLogic _stockPurchaseBatchLogic;
        private PackageRelationshipLogic _packageRelationshipLogic;
        private StockPackageLogic _stockPackageLogic;
        private StockPriceLogic _stockPriceLogic;

        //private List<VW_STOCK_PURCHASED> _purchasedStockViews;
        //private List<VW_SOLD_STOCK> _soldStockViews;

        public StockReviewLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new StockReviewTranslator();
            _soldStockBatchLogic = new SoldStockBatchLogic(repository);
            _stockPurchaseBatchLogic = new StockPurchaseBatchLogic(repository);
            _stockReviewDetailLogic = new StockReviewDetailLogic(repository);
            _packageRelationshipLogic = new PackageRelationshipLogic(repository);
            _stockPackageLogic = new StockPackageLogic(repository);
            _stockPriceLogic = new StockPriceLogic(repository);
        }

        public List<Year> GetTotalYears()
        {
            try
            {
                int minimumYear = 0;
                int maximumYear = 0;

                DateTime minimumSoldStockDate = _soldStockBatchLogic.GetSoldDate(true);
                DateTime maximumSoldStockDate = _soldStockBatchLogic.GetSoldDate(false);
                DateTime minimumStockPurchaseDate = _stockPurchaseBatchLogic.GetPurchaseDate(true);
                DateTime maximumStockPurchaseDate = _stockPurchaseBatchLogic.GetPurchaseDate(false);
                               
                if (minimumSoldStockDate > DateTime.MinValue && minimumStockPurchaseDate <= DateTime.MinValue)
                {
                    minimumYear = minimumSoldStockDate.Year;
                }
                else if (minimumSoldStockDate > DateTime.MinValue && minimumStockPurchaseDate > DateTime.MinValue)
                {
                    minimumYear = minimumSoldStockDate.Year < minimumStockPurchaseDate.Year ? minimumSoldStockDate.Year : minimumStockPurchaseDate.Year;
                }
                else if (minimumSoldStockDate <= DateTime.MinValue && minimumStockPurchaseDate > DateTime.MinValue)
                {
                    minimumYear = minimumStockPurchaseDate.Year;
                }

                if (maximumSoldStockDate > DateTime.MinValue && maximumStockPurchaseDate <= DateTime.MinValue)
                {
                    maximumYear = maximumSoldStockDate.Year;
                }
                else if (maximumSoldStockDate > DateTime.MinValue && maximumStockPurchaseDate > DateTime.MinValue)
                {
                    maximumYear = maximumSoldStockDate.Year > maximumStockPurchaseDate.Year ? maximumSoldStockDate.Year : maximumStockPurchaseDate.Year;
                }
                else if (maximumSoldStockDate <= DateTime.MinValue && maximumStockPurchaseDate > DateTime.MinValue)
                {
                    maximumYear = maximumStockPurchaseDate.Year;
                }

                List<Year> years = null;
                if (maximumYear > 0)
                {
                    years = new List<Year>();
                    for (int i = minimumYear; i <= maximumYear; i++)
                    {
                        Year year = new Year();
                        year.Id = minimumYear;
                        year.Name = minimumYear.ToString();
                        years.Add(year);

                        minimumYear += 1;
                    }
                }

                return years;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        public List<StockReviewDetail> GetBy(int year)
        {
            List<StockReviewDetail> stockReviewDetails = null;

            try
            {
                string query = "SELECT * FROM VW_STOCK_REVIEW where (Transaction_Year = '" + year.ToString() + "')";

                stockReviewDetails = (from srd in repository.DbContext.Database.SqlQuery<VW_STOCK_REVIEW>(query)
                                      select new StockReviewDetail
                                      {
                                          StockId = srd.Stock_Id.Value,
                                          StockName = srd.Stock_Name,
                                          Cost = srd.Cost,
                                          TransactionMonth = Convert.ToInt32(srd.Transaction_Month),
                                          TransactionYear = Convert.ToInt32(srd.Transaction_Year),
                                          SellingPrice = srd.Selling_Price,
                                          CostPrice = srd.Cost_Price,
                                          Discount = srd.Discount,
                                          Profit = srd.Profit,
                                          //MonthYearSold = srd.Month_Year_Sold,
                                          MonthlyTotalExpenses = srd.Monthly_Total_Expenses,
                                          MonthlyTransactionDiscount = srd.Monthly_Transaction_Discount,
                                          StockPackageRelationshipId = srd.Stock_Package_Relationship_Id,
                                      }).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return stockReviewDetails;
        }


        //public void GetPurchasedStockBy(int year)
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM VW_STOCK_PURCHASED WHERE Year_Purchased = '" + year.ToString() + "'";
        //        _purchasedStockViews = (from x in repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED>(query) select x).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public void GetSoldStockBy(int year)
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM VW_SOLD_STOCK WHERE Year_Sold = '" + year.ToString() + "'";
        //        _soldStockViews = (from x in repository.DbContext.Database.SqlQuery<VW_SOLD_STOCK>(query) select x).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}




        //public List<StockView> GetPurchasedStockBy(long stockId, int stockPackageRelationshipId, int month, int year)
        //{
        //    try
        //    {

        //        string monthString = month.ToString().Length == 1 ? "0" + month.ToString() : month.ToString();

        //        //string query = "SELECT * FROM VW_STOCK_PURCHASED where Stock_Id = " + stockId + " AND Stock_Package_Relationship_Id = " + stockPackageRelationshipId + " AND Year_Purchased = '" + year.ToString() + "' AND Month_Purchased = '" + monthString + "'";
        //        List<StockView> stockViews = (from x in _purchasedStockViews
        //                                      where x.Stock_Id == stockId && x.Stock_Package_Relationship_Id == stockPackageRelationshipId && x.Year_Purchased == year.ToString() && x.Month_Purchased == monthString
        //                                      select new StockView
        //                                      {
        //                                          StockId = x.Stock_Id,
        //                                          StockName = x.Stock_Name,
        //                                          PackageId = (int)x.Package_Id,
        //                                          PackageName = x.Package_Name,
        //                                          StockPackageId = x.Stock_Package_Id,
        //                                          StockPackageRelationshipId = x.Stock_Package_Relationship_Id,
        //                                          Quantity = (int)x.Quantity,
        //                                          Cost = x.Cost,
        //                                      }).ToList();
        //        return stockViews;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public List<StockView> GetSoldStockBy(long stockId, int stockPackageRelationshipId, int month, int year)
        //{
        //    try
        //    {
        //        string monthString = month.ToString().Length == 1 ? "0" + month.ToString() : month.ToString();

        //        //string query = "SELECT * FROM VW_SOLD_STOCK where Stock_Id = " + stockId + " AND Stock_Package_Relationship_Id = " + stockPackageRelationshipId + " AND Year_Sold = '" + year.ToString() + "' AND Month_Sold = '" + monthString + "'";
        //        List<StockView> stockViews = (from x in _soldStockViews
        //                                      where x.Stock_Id == stockId && x.Stock_Package_Relationship_Id == stockPackageRelationshipId && x.Year_Sold == year.ToString() && x.Month_Sold == monthString
        //                                      select new StockView
        //                                      {
        //                                          StockId = x.Stock_Id,
        //                                          StockName = x.Stock_Name,
        //                                          PackageId = (int)x.Package_Id,
        //                                          PackageName = x.Package_Name,
        //                                          StockPackageId = x.Stock_Package_Id,
        //                                          StockPackageRelationshipId = x.Stock_Package_Relationship_Id,
        //                                          Quantity = (int)x.Quantity,
        //                                          CostPrice = x.Cost_Price,
        //                                      }).ToList();
        //        return stockViews;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public List<StockView> GetPurchasedStockBy(long stockId, int stockPackageRelationshipId, int month, int year)
        {
            List<StockView> stockViews = null;

            try
            {
                string monthString = month.ToString().Length == 1 ? "0" + month.ToString() : month.ToString();

                string query = "SELECT * FROM VW_STOCK_PURCHASED where Stock_Id = " + stockId + " AND Stock_Package_Relationship_Id = " + stockPackageRelationshipId + " AND Year_Purchased = '" + year.ToString() + "' AND Month_Purchased = '" + monthString + "'";
                stockViews = (from x in repository.DbContext.Database.SqlQuery<VW_STOCK_PURCHASED>(query)
                              select new StockView
                              {
                                  StockId = x.Stock_Id,
                                  StockName = x.Stock_Name,
                                  PackageId = (int)x.Package_Id,
                                  PackageName = x.Package_Name,
                                  StockPackageId = x.Stock_Package_Id,
                                  StockPackageRelationshipId = x.Stock_Package_Relationship_Id,
                                  Quantity = (int)x.Quantity,
                                  Cost = x.Cost,
                              }).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return stockViews;
        }

        public List<StockView> GetSoldStockBy(long stockId, int stockPackageRelationshipId, int month, int year)
        {
            List<StockView> stockViews = null;

            try
            {
                string monthString = month.ToString().Length == 1 ? "0" + month.ToString() : month.ToString();

                string query = "SELECT * FROM VW_SOLD_STOCK where Stock_Id = " + stockId + " AND Stock_Package_Relationship_Id = " + stockPackageRelationshipId + " AND Year_Sold = '" + year.ToString() + "' AND Month_Sold = '" + monthString + "'";
                stockViews = (from x in repository.DbContext.Database.SqlQuery<VW_SOLD_STOCK>(query)
                              select new StockView
                              {
                                  StockId = x.Stock_Id,
                                  StockName = x.Stock_Name,
                                  PackageId = (int)x.Package_Id,
                                  PackageName = x.Package_Name,
                                  StockPackageId = x.Stock_Package_Id,
                                  StockPackageRelationshipId = x.Stock_Package_Relationship_Id,
                                  Quantity = (int)x.Quantity,
                                  CostPrice = x.Cost_Price,
                              }).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return stockViews;
        }

        private List<StockReviewDetail> SetStockBalance(List<StockReviewDetail> stockReviewDetails, List<StockReviewDetail> previousYearStockReviewDetails)
        {
            try
            {
                if (stockReviewDetails == null || stockReviewDetails.Count <= 0)
                {
                    return stockReviewDetails;
                }

                List<StockReviewDetail> stocks = stockReviewDetails.GroupBy(x => new { x.StockId, x.StockPackageRelationshipId }).Select(s => new StockReviewDetail
                {
                    StockId = s.First().StockId,
                    StockPackageRelationshipId = s.First().StockPackageRelationshipId
                }).ToList();

                foreach (StockReviewDetail stockReview in stocks)
                {
                    StockReviewDetail lastPreviousYearStockReviewDetail = null;
                    if (previousYearStockReviewDetails != null && previousYearStockReviewDetails.Count > 0)
                    {
                        lastPreviousYearStockReviewDetail = previousYearStockReviewDetails.Where(s => s.StockId == stockReview.StockId && s.StockPackageRelationshipId == stockReview.StockPackageRelationshipId).OrderBy(x => x.TransactionMonth).LastOrDefault();
                    }

                    List<StockReviewDetail> selectedStockReviewDetails = stockReviewDetails.Where(s => s.StockId == stockReview.StockId && s.StockPackageRelationshipId == stockReview.StockPackageRelationshipId).OrderBy(x => x.TransactionMonth).ToList();
                    for (int i = 0; i < selectedStockReviewDetails.Count; i++)
                    {
                        StockReviewDetail stockReviewDetail = selectedStockReviewDetails[i];
                        int month = (int)stockReviewDetail.TransactionMonth;
                        int year = (int)stockReviewDetail.TransactionYear;

                        int previousMonth = 0;
                        int previousYear = year - 1;

                        if (i > 0)
                        {
                            int j = i - 1;
                            previousMonth = (int)selectedStockReviewDetails[j].TransactionMonth;
                        }
                        else
                        {
                            previousMonth = month - 1;
                        }

                        List<StockView> previousPurchasedStocks = GetPurchasedStockBy(stockReview.StockId, (int)stockReview.StockPackageRelationshipId, previousMonth, year);
                        List<StockView> previousSoldStocks = GetSoldStockBy(stockReview.StockId, (int)stockReview.StockPackageRelationshipId, previousMonth, year);
                        StockReviewDetail previousStockReviewDetail = stockReviewDetails.Where(x => x.StockId == stockReview.StockId && x.StockPackageRelationshipId == stockReview.StockPackageRelationshipId && x.TransactionMonth == previousMonth && x.TransactionYear == year).SingleOrDefault();

                        decimal totalPreviousSalesUnitItem = 0;
                        decimal totalPreviousPurchasedUnitItem = 0;
                        decimal totalPreviousSalesCostPrice = 0;
                        decimal totalPreviousPurchaseCost = 0;

                        if (previousPurchasedStocks != null && previousPurchasedStocks.Count > 0)
                        {
                            totalPreviousPurchasedUnitItem = GetTotalUnitItem(previousPurchasedStocks);
                            totalPreviousPurchaseCost = previousPurchasedStocks.Sum(x => x.Cost);
                        }
                        if (previousSoldStocks != null && previousSoldStocks.Count > 0)
                        {
                            totalPreviousSalesUnitItem = GetTotalUnitItem(previousSoldStocks);
                            totalPreviousSalesCostPrice = previousSoldStocks.Sum(x => x.CostPrice.Value);
                        }

                        decimal balancePreviousStockValue = 0;
                        string balancePreviousStockPackage = null;
                        decimal balancePreviousStockUnitItem = 0;
                        if (previousStockReviewDetail != null)
                        {
                            if (previousStockReviewDetail.StockBalanceUnitItem > 0)
                            {
                                balancePreviousStockValue = (totalPreviousPurchaseCost - totalPreviousSalesCostPrice) + previousStockReviewDetail.InitialStockBalanceValue;
                                balancePreviousStockUnitItem = (totalPreviousPurchasedUnitItem - totalPreviousSalesUnitItem) + previousStockReviewDetail.TempStockPackageUnitItem;
                            }
                            else
                            {
                                balancePreviousStockValue = 0;
                            }
                        }
                        else
                        {
                            balancePreviousStockValue = (totalPreviousPurchaseCost - totalPreviousSalesCostPrice);
                            balancePreviousStockUnitItem = (totalPreviousPurchasedUnitItem - totalPreviousSalesUnitItem);
                        }

                        if (i == 0)
                        {
                            if (lastPreviousYearStockReviewDetail != null)
                            {
                                if (lastPreviousYearStockReviewDetail.StockBalanceUnitItem > 0)
                                {
                                    balancePreviousStockValue += lastPreviousYearStockReviewDetail.StockBalanceValue;
                                    balancePreviousStockUnitItem += lastPreviousYearStockReviewDetail.StockBalanceUnitItem;
                                }
                                else
                                {
                                    balancePreviousStockValue = 0;
                                }
                            }
                        }

                        if (balancePreviousStockValue < 0)
                        {
                            balancePreviousStockValue = GetStockPrice(previousStockReviewDetail.StockId, balancePreviousStockUnitItem);
                        }

                        if (balancePreviousStockUnitItem > 0)
                        {
                            balancePreviousStockPackage = _packageRelationshipLogic.Get(balancePreviousStockUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
                        }

                        List<StockView> currentPurchasedStocks = GetPurchasedStockBy(stockReviewDetail.StockId, (int)stockReviewDetail.StockPackageRelationshipId, month, year);
                        List<StockView> currentSoldStocks = GetSoldStockBy(stockReviewDetail.StockId, (int)stockReviewDetail.StockPackageRelationshipId, month, year);

                        decimal totalCurrentSalesUnitItem = 0;
                        decimal totalCurrentPurchasedUnitItem = 0;
                        decimal totalCurrentSalesCostPrice = 0;
                        decimal totalCurrentPurchaseCost = 0;

                        if (currentPurchasedStocks != null && currentPurchasedStocks.Count > 0)
                        {
                            totalCurrentPurchasedUnitItem = GetTotalUnitItem(currentPurchasedStocks);
                            totalCurrentPurchaseCost = currentPurchasedStocks.Sum(x => x.Cost);
                        }
                        if (currentSoldStocks != null && currentSoldStocks.Count > 0)
                        {
                            totalCurrentSalesUnitItem = GetTotalUnitItem(currentSoldStocks);
                            totalCurrentSalesCostPrice = currentSoldStocks.Sum(x => x.CostPrice.Value);
                        }

                        decimal balanceStockUnitItem = (totalCurrentPurchasedUnitItem - totalCurrentSalesUnitItem) + balancePreviousStockUnitItem;
                        decimal balanceStockValue = (totalCurrentPurchaseCost - totalCurrentSalesCostPrice) + balancePreviousStockValue;

                        string balanceStockPackage = null;
                        string quantityPurchasedStockPackage = _packageRelationshipLogic.Get(totalCurrentPurchasedUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
                        string quantitySoldStockPackage = _packageRelationshipLogic.Get(totalCurrentSalesUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
                        if (balanceStockUnitItem > 0)
                        {
                            balanceStockPackage = _packageRelationshipLogic.Get(balanceStockUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
                        }

                        decimal originalStockBalanceValue = balanceStockValue;
                        if (balanceStockValue < 0)
                        {
                            if (balanceStockUnitItem > 0)
                            {
                                balanceStockValue = GetStockPrice(stockReviewDetail.StockId, balanceStockUnitItem);
                            }
                            else
                            {
                                balanceStockValue = 0;
                            }

                            stockReviewDetail.Profit += Math.Abs(originalStockBalanceValue);
                            stockReviewDetail.Profit2 = originalStockBalanceValue;
                        }

                        stockReviewDetail.TempStockPackageUnitItem = balancePreviousStockUnitItem;
                        stockReviewDetail.InitialStockBalance = balancePreviousStockPackage;
                        stockReviewDetail.InitialStockBalanceValue = balancePreviousStockValue;
                        stockReviewDetail.StockPackageBalance = balanceStockPackage;
                        stockReviewDetail.StockBalanceValue = balanceStockValue;
                        stockReviewDetail.StockBalanceUnitItem = balanceStockUnitItem;

                        stockReviewDetail.QuantityPackageSold = quantitySoldStockPackage;
                        stockReviewDetail.QuantityPackagePurchased = quantityPurchasedStockPackage;
                        stockReviewDetail.RelationshipOfStockPackage = _packageRelationshipLogic.GetRelationshipString((int)stockReviewDetail.StockPackageRelationshipId);
                    }
                }

                return stockReviewDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //private List<StockReviewDetail> SetStockBalance(List<StockReviewDetail> stockReviewDetails, List<StockReviewDetail> previousYearStockReviewDetails)
        //{
        //    try
        //    {
        //        if (stockReviewDetails == null || stockReviewDetails.Count <= 0)
        //        {
        //            return stockReviewDetails;
        //        }

        //        List<StockReviewDetail> stocks = stockReviewDetails.GroupBy(x => new { x.StockId, x.StockPackageRelationshipId }).Select(s => new StockReviewDetail
        //        {
        //            StockId = s.First().StockId,
        //            StockPackageRelationshipId = s.First().StockPackageRelationshipId
        //        }).ToList();

        //        foreach (StockReviewDetail stockReview in stocks)
        //        {
        //            StockReviewDetail lastPreviousYearStockReviewDetail = null;
        //            if (previousYearStockReviewDetails != null && previousYearStockReviewDetails.Count > 0)
        //            {
        //                lastPreviousYearStockReviewDetail = previousYearStockReviewDetails.Where(s => s.StockId == stockReview.StockId && s.StockPackageRelationshipId == stockReview.StockPackageRelationshipId).OrderBy(x => x.TransactionMonth).LastOrDefault();
        //            }

        //            List<StockReviewDetail> selectedStockReviewDetails = stockReviewDetails.Where(s => s.StockId == stockReview.StockId && s.StockPackageRelationshipId == stockReview.StockPackageRelationshipId).OrderBy(x => x.TransactionMonth).ToList();
        //            for (int i = 0; i < selectedStockReviewDetails.Count; i++)
        //            {
        //                StockReviewDetail stockReviewDetail = selectedStockReviewDetails[i];
        //                int month = (int)stockReviewDetail.TransactionMonth;
        //                int year = (int)stockReviewDetail.TransactionYear;

        //                int previousMonth = 0;
        //                int previousYear = year - 1;

        //                if (i > 0)
        //                {
        //                    int j = i - 1;
        //                    previousMonth = (int)selectedStockReviewDetails[j].TransactionMonth;
        //                }
        //                else
        //                {
        //                    previousMonth = month - 1;
        //                }

        //                List<StockView> previousPurchasedStocks = GetPurchasedStockBy(stockReview.StockId, (int)stockReview.StockPackageRelationshipId, previousMonth, year);
        //                List<StockView> previousSoldStocks = GetSoldStockBy(stockReview.StockId, (int)stockReview.StockPackageRelationshipId, previousMonth, year);
        //                StockReviewDetail previousStockReviewDetail = stockReviewDetails.Where(x => x.StockId == stockReview.StockId && x.StockPackageRelationshipId == stockReview.StockPackageRelationshipId && x.TransactionMonth == previousMonth && x.TransactionYear == year).SingleOrDefault();

        //                long totalPreviousSalesUnitItem = 0;
        //                long totalPreviousPurchasedUnitItem = 0;
        //                decimal totalPreviousSalesCostPrice = 0;
        //                decimal totalPreviousPurchaseCost = 0;

        //                if (previousPurchasedStocks != null && previousPurchasedStocks.Count > 0)
        //                {
        //                    totalPreviousPurchasedUnitItem = GetTotalUnitItem(previousPurchasedStocks);
        //                    totalPreviousPurchaseCost = previousPurchasedStocks.Sum(x => x.Cost);
        //                }
        //                if (previousSoldStocks != null && previousSoldStocks.Count > 0)
        //                {
        //                    totalPreviousSalesUnitItem = GetTotalUnitItem(previousSoldStocks);
        //                    totalPreviousSalesCostPrice = previousSoldStocks.Sum(x => x.CostPrice.Value);
        //                }

        //                decimal balancePreviousStockValue = 0;
        //                string balancePreviousStockPackage = null;
        //                long balancePreviousStockUnitItem = 0;
        //                if (previousStockReviewDetail != null)
        //                {
        //                    if (previousStockReviewDetail.StockBalanceUnitItem > 0)
        //                    {
        //                        balancePreviousStockValue = (totalPreviousPurchaseCost - totalPreviousSalesCostPrice) + previousStockReviewDetail.InitialStockBalanceValue;
        //                        balancePreviousStockUnitItem = (totalPreviousPurchasedUnitItem - totalPreviousSalesUnitItem) + previousStockReviewDetail.TempStockPackageUnitItem;
        //                    }
        //                    else
        //                    {
        //                        balancePreviousStockValue = 0;
        //                    }
        //                }
        //                else
        //                {
        //                    balancePreviousStockValue = (totalPreviousPurchaseCost - totalPreviousSalesCostPrice);
        //                    balancePreviousStockUnitItem = (totalPreviousPurchasedUnitItem - totalPreviousSalesUnitItem);
        //                }

        //                if (i == 0)
        //                {
        //                    if (lastPreviousYearStockReviewDetail != null)
        //                    {
        //                        if (lastPreviousYearStockReviewDetail.StockBalanceUnitItem > 0)
        //                        {
        //                            balancePreviousStockValue += lastPreviousYearStockReviewDetail.StockBalanceValue;
        //                            balancePreviousStockUnitItem += lastPreviousYearStockReviewDetail.StockBalanceUnitItem;
        //                        }
        //                        else
        //                        {
        //                            balancePreviousStockValue = 0;
        //                        }
        //                    }
        //                }

        //                if (balancePreviousStockValue < 0)
        //                {
        //                    balancePreviousStockValue = GetStockPrice(previousStockReviewDetail.StockId, balancePreviousStockUnitItem);
        //                }
                       
        //                if (balancePreviousStockUnitItem > 0)
        //                {
        //                    balancePreviousStockPackage = _packageRelationshipLogic.Get(balancePreviousStockUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
        //                }

        //                List<StockView> currentPurchasedStocks = GetPurchasedStockBy(stockReviewDetail.StockId, (int)stockReviewDetail.StockPackageRelationshipId, month, year);
        //                List<StockView> currentSoldStocks = GetSoldStockBy(stockReviewDetail.StockId, (int)stockReviewDetail.StockPackageRelationshipId, month, year);

        //                long totalCurrentSalesUnitItem = 0;
        //                long totalCurrentPurchasedUnitItem = 0;
        //                decimal totalCurrentSalesCostPrice = 0;
        //                decimal totalCurrentPurchaseCost = 0;

        //                if (currentPurchasedStocks != null && currentPurchasedStocks.Count > 0)
        //                {
        //                    totalCurrentPurchasedUnitItem = GetTotalUnitItem(currentPurchasedStocks);
        //                    totalCurrentPurchaseCost = currentPurchasedStocks.Sum(x => x.Cost);
        //                }
        //                if (currentSoldStocks != null && currentSoldStocks.Count > 0)
        //                {
        //                    totalCurrentSalesUnitItem = GetTotalUnitItem(currentSoldStocks);
        //                    totalCurrentSalesCostPrice = currentSoldStocks.Sum(x => x.CostPrice.Value);
        //                }

        //                long balanceStockUnitItem = (totalCurrentPurchasedUnitItem - totalCurrentSalesUnitItem) + balancePreviousStockUnitItem;
        //                decimal balanceStockValue = (totalCurrentPurchaseCost - totalCurrentSalesCostPrice) + balancePreviousStockValue;
                       
        //                string balanceStockPackage = null;
        //                string quantityPurchasedStockPackage = _packageRelationshipLogic.Get(totalCurrentPurchasedUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
        //                string quantitySoldStockPackage = _packageRelationshipLogic.Get(totalCurrentSalesUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
        //                if (balanceStockUnitItem > 0)
        //                {
        //                    balanceStockPackage = _packageRelationshipLogic.Get(balanceStockUnitItem, (long)stockReviewDetail.StockPackageRelationshipId);
        //                }
                      
        //                decimal originalStockBalanceValue = balanceStockValue;
        //                if (balanceStockValue < 0)
        //                {
        //                    if (balanceStockUnitItem > 0)
        //                    {
        //                        balanceStockValue = GetStockPrice(stockReviewDetail.StockId, balanceStockUnitItem);
        //                    }
        //                    else
        //                    {
        //                        balanceStockValue = 0;
        //                    }

        //                    stockReviewDetail.Profit += Math.Abs(originalStockBalanceValue);
        //                    stockReviewDetail.Profit2 = originalStockBalanceValue;
        //                }



        //                //string quantityPurchasedStockPackage = _packageRelationshipLogic.Get(totalCurrentPurchasedUnitItem, stockReviewDetail);
        //                //string quantitySoldStockPackage = _packageRelationshipLogic.Get(totalCurrentSalesUnitItem, stockReviewDetail);
        //                //string balanceStockPackage = _packageRelationshipLogic.Get(balanceStockUnitItem, stockReviewDetail);

        //                stockReviewDetail.TempStockPackageUnitItem = balancePreviousStockUnitItem;
        //                stockReviewDetail.InitialStockBalance = balancePreviousStockPackage;
        //                stockReviewDetail.InitialStockBalanceValue = balancePreviousStockValue;
        //                stockReviewDetail.StockPackageBalance = balanceStockPackage;
        //                stockReviewDetail.StockBalanceValue = balanceStockValue;
        //                stockReviewDetail.StockBalanceUnitItem = balanceStockUnitItem;

        //                stockReviewDetail.QuantityPackageSold = quantitySoldStockPackage;
        //                stockReviewDetail.QuantityPackagePurchased = quantityPurchasedStockPackage;
        //                stockReviewDetail.RelationshipOfStockPackage = _packageRelationshipLogic.GetRelationshipString((int)stockReviewDetail.StockPackageRelationshipId);
        //            }
        //        }

        //        return stockReviewDetails;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private decimal GetStockPrice(long stockId, long balanceStockUnitItem)
        //{
        //    try
        //    {
        //        decimal stockPrice = 0;
        //        Stock stock = new Stock() { Id = stockId };
        //        PackageRelationship packageRelationship = _packageRelationshipLogic.GetSmallestBy(stock);

        //        if (packageRelationship != null && packageRelationship.Id > 0)
        //        {
        //            StockPackage stockPackage = packageRelationship.SubPackage;
        //            if (stockPackage == null || stockPackage.Id <= 0)
        //            {
        //                stockPackage = packageRelationship.Package;
        //            }

        //            StockPrice price = _stockPriceLogic.Get(stockPackage);
        //            if (price == null || price.Id <= 0)
        //            {
        //                throw new Exception("Stock Price not set for " + stockPackage.Package.Name + " of " + stockPackage.Stock.Name + "! Set price and try again.");
        //            }

        //            stockPrice = price.CostPrice * (decimal)balanceStockUnitItem;
        //        }

        //        return stockPrice;
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}

        private decimal GetStockPrice(long stockId, decimal balanceStockUnitItem)
        {
            try
            {
                decimal stockPrice = 0;
                Stock stock = new Stock() { Id = stockId };
                PackageRelationship packageRelationship = _packageRelationshipLogic.GetSmallestBy(stock);

                if (packageRelationship != null && packageRelationship.Id > 0)
                {
                    StockPackage stockPackage = packageRelationship.SubPackage;
                    if (stockPackage == null || stockPackage.Id <= 0)
                    {
                        stockPackage = packageRelationship.Package;
                    }

                    StockPrice price = _stockPriceLogic.Get(stockPackage);
                    if (price == null || price.Id <= 0)
                    {
                        throw new Exception("Stock Price not set for " + stockPackage.Package.Name + " of " + stockPackage.Stock.Name + "! Set price and try again.");
                    }

                    stockPrice = price.CostPrice * balanceStockUnitItem;
                }

                return stockPrice;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private decimal GetTotalUnitItem(List<StockView> stocks)
        {
            try
            {
                decimal totalUnitItem = 0;
                foreach (StockView stock in stocks)
                {
                    decimal unitItemValue = 0;
                    StockPackageRelationship stockPackageRelationship = new StockPackageRelationship() { Id = stock.StockPackageRelationshipId };

                    unitItemValue += _packageRelationshipLogic.GetTotalUnitItem(stock.StockPackageId, stockPackageRelationship);
                    unitItemValue *= stock.Quantity;

                    totalUnitItem += unitItemValue;
                }

                return totalUnitItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private long GetTotalUnitItem(List<StockView> stocks)
        //{
        //    try
        //    {
        //        long totalUnitItem = 0;
        //        foreach (StockView stock in stocks)
        //        {
        //            long unitItemValue = 0;
        //            StockPackageRelationship stockPackageRelationship = new StockPackageRelationship() { Id = stock.StockPackageRelationshipId };

        //            unitItemValue += _packageRelationshipLogic.GetTotalUnitItem(stock.StockPackageId, stockPackageRelationship);
        //            unitItemValue *= stock.Quantity;

        //            totalUnitItem += unitItemValue;
        //        }

        //        return totalUnitItem;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public bool Remove(StockReview stockReview)
        {
            try
            {
                Expression<Func<STOCK_REVIEW, bool>> selector = srd => srd.Review_Year >= stockReview.ReviewYear;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override StockReview Add(StockReview stockReview)
        {
            try
            {
                StockReview newStockReview = null;
                List<StockReviewDetail> specifiedYearStockReviewDetails = GetBy(stockReview.ReviewYear);
                List<StockReviewDetail> previousYearStockReviewDetails = _stockReviewDetailLogic.GetPreviousYear(stockReview.ReviewYear - 1);

                if (specifiedYearStockReviewDetails != null && specifiedYearStockReviewDetails.Count > 0)
                {
                    specifiedYearStockReviewDetails = SetStockBalance(specifiedYearStockReviewDetails, previousYearStockReviewDetails);

                    base.OpenDatabaseConnectionIfClosed();
                    using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                    {
                        _stockReviewDetailLogic.repository = repository;
                        bool stockReviewDetailRemoved = _stockReviewDetailLogic.Remove(stockReview);
                        //if (!stockReviewDetailRemoved)
                        //{
                        //    throw new Exception("Stock Review Detail deletion operation failed!");
                        //}

                        bool stockReviewRemoved = Remove(stockReview);
                        //if (!stockReviewRemoved)
                        //{
                        //    throw new Exception("Stock Review deletion operation failed!");
                        //}

                        newStockReview = base.Add(stockReview);
                        if (newStockReview != null && newStockReview.Id > 0)
                        {
                            foreach (StockReviewDetail stockReviewDetail in specifiedYearStockReviewDetails)
                            {
                                stockReviewDetail.StockReviewId = newStockReview.Id;
                            }

                            if (newStockReview != null)
                            {
                                SetStockReviewDetailId(specifiedYearStockReviewDetails);
                                _stockReviewDetailLogic.Add(specifiedYearStockReviewDetails);

                                base.CommitTransaction(transaction);
                            }
                        }
                    }
                }

                return newStockReview;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetStockReviewDetailId(List<StockReviewDetail> specifiedYearStockReviewDetails)
        {
            try
            {
                if (specifiedYearStockReviewDetails != null && specifiedYearStockReviewDetails.Count > 0)
                {
                    long id = _stockReviewDetailLogic.GetMaximumId();

                    for (int i = 0; i < specifiedYearStockReviewDetails.Count; i++)
                    {
                        id += 1;
                        specifiedYearStockReviewDetails[i].Id = id;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


     






    }


}
