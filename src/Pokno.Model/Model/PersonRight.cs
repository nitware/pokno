using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Pokno.Model
{

    public class PersonRight
    {
        public List<Right> Rights { get; set; }
        public List<Right> View { get; set; }
        public bool CanSetupUser { get; set; }
        public bool CanSetupLoginDetail { get; set; }
        public bool CanSetupRole { get; set; }
        public bool CanSetupRight { get; set; }
        public bool CanAssignRightToRole { get; set; }
        public bool CanAssignRoleToPerson { get; set; }
        public bool CanSetupPersonType { get; set; }
        public bool CanSetupPaymentType { get; set; }
        public bool CanSetupBank { get; set; }
        public bool CanUpdatePayment { get; set; }
        public bool CanSetupStockCategory { get; set; }
        public bool CanSetupStockType { get; set; }
        public bool CanSetupStock { get; set; }
        public bool CanSetupPackageType { get; set; }
        public bool CanSetupStockPackage { get; set; }
        public bool CanSetupPackageTypeQuantity { get; set; }
        public bool CanSetupStockPrice { get; set; }
        public bool CanSetupReturnType { get; set; }
        public bool CanSetupStockState { get; set; }
        public bool CanSetupLocation { get; set; }
        public bool CanCreateStockPurchaseBatch { get; set; }
        public bool CanModifyPurchaseBatch { get; set; }
        public bool CanRegisterPurchasedStock { get; set; }
        public bool CanArrangeStockOnShelf { get; set; }
        public bool CanRemoveShelfStock { get; set; }
        public bool CanViewEnteredShelfStock { get; set; }
        public bool CanSellStock { get; set; }
        public bool CanManageStockSetup { get; set; }
        public bool CanManagePayment { get; set; }
        public bool CanManagePerson { get; set; }
        public bool CanManageStock { get; set; }
        public bool CanViewReport { get; set; }
        public bool CanManageCompany { get; set; }
        public bool CanSetupCompany { get; set; }
        public bool CanSetupCompanyRepresentative { get; set; }
        public bool CanManageSales { get; set; }
        public bool CanEditSoldStock { get; set; }
        public bool CanSetupDailyExpenses { get; set; }
        public bool CanManageAccount { get; set; }
        public bool CanViewCompanyCreditorsList { get; set; }
        public bool CanViewCompanyDebtorsList { get; set; }
        public bool CanViewSupplierCreditorsList { get; set; }
        public bool CanViewSupplierDebtorsList { get; set; }
        public bool CanViewPaymentReport { get; set; }
        public bool CanSelectSoldDateOnSellStockPage { get; set; }

        public bool CanSetupStockReturnAction { get; set; }
        public bool CanSetupExpensesCategory { get; set; }
        public bool CanViewStockExpiryDateAlert { get; set; }
        public bool CanReviewStock { get; set; }
        public bool CanDeleteSalesTransaction { get; set; }
        public bool CanReturnStock { get; set; }
        public bool CanManageReplacedStock { get; set; }
        public bool CanReturnPurchasedStock { get; set; }

        public bool CanManagePeopleBasicSetup { get; set; }
        public bool CanManageReturns { get; set; }

        public bool CanViewStockReport { get; set; }
        public bool CanViewSalesReport { get; set; }

        public bool CanViewStockListReport { get; set; }
        public bool CanViewStockPackageReport { get; set; }
        public bool CanViewPackageRelationshipReport { get; set; }
        public bool CanViewStockPriceReport { get; set; }
        public bool CanViewStockPriceHistoryReport { get; set; }
        public bool CanViewStockPriceHistoryByStockReport { get; set; }
        public bool CanViewStockPurchaseDetailReport { get; set; }
        public bool CanViewStockPurchaseDetailByStockReport { get; set; }
        public bool CanViewStockPurchaseSummaryReport { get; set; }
        public bool CanViewStockAvailableOnShelfReport { get; set; }
        public bool CanViewStockInStoreReport { get; set; }
        public bool CanViewStockSalesAnalysisReport { get; set; }
        public bool CanViewStockSalesDetailsAnalysisReport { get; set; }
        public bool CanViewStockSalesDetailAnalysisByStockReport { get; set; }
        public bool CanViewStockYearlySummaryReport { get; set; }
        public bool CanViewStockYearlySummaryByStockReport { get; set; }
        public bool CanViewStockMonthlySummaryReport { get; set; }

        public bool CanManageStore { get; set; }
        public bool CanViewDailySales { get; set; }
        public bool CanViewStockPriceList { get; set; }
        public bool CanViewPurchaseReport { get; set; }
        public bool CanViewDailyTransactionReport { get; set; }
        public bool CanViewMiscellaneousReport { get; set; }
        
        public bool CanViewYearlyCustomerTransactionStatisticsReport { get; set; }
        public bool CanViewCustomerTransactionStatisticsByDateRangeReport { get; set; }
        public bool CanViewMonthlyStockStatisticsReport { get; set; }
        public bool CanViewStockStatisticsByDateRangeReport { get; set; }
        public bool CanViewYearlyStockStatisticsReport { get; set; }
        public bool CanViewDailyExpensesReport { get; set; }
        public bool CanViewMonthlyExpensesReport { get; set; }
        public bool CanViewYearlyExpensesReport { get; set; }
        public bool CanViewExpensesByDateRangeReport { get; set; }
        public bool CanViewYearlyStockReturnReport { get; set; }
        public bool CanViewStockReturnByDateRangeReport { get; set; }
        public bool CanViewPaymentHistoryReport { get; set; }
        public bool CanViewPaymentHistoryByPersonReport { get; set; }
        public bool CanViewStockListByTypeReport { get; set; }
        public bool CanViewExpensesReport { get; set; }
        public bool CanViewReturnsReport { get; set; }
        public bool CanManageSettings { get; set; }
        public bool CanSetBasicSetting { get; set; }
        public bool CanSetDB { get; set; }
        public bool CanSetupShopDetail { get; set; }
        public bool CanSetupCustomerLoyaltyProgram { get; set; }
        public bool CanMaintainDb { get; set; }
        public bool CanCompactDb { get; set; }
        public bool CanBackupDb { get; set; }
        public bool CanRestoreDb { get; set; }
        public bool CanUploadStoreLogo { get; set; }
        public bool CanChangeStockPrice { get; set; }
        public bool CanSetApplicationDate { get; set; }
        
        public void Set()
        {
            try
            {
                if (Rights != null)
                {
                    if (Rights.Count > 0)
                    {
                        foreach (Right right in Rights)
                        {
                            if (right == null)
                            {
                                continue;
                            }

                            switch (right.Id)
                            {
                                case 1:
                                    {
                                        CanSetupUser = true;
                                        break;
                                    }
                                case 2:
                                    {
                                        CanSetupLoginDetail = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        CanSetupRole = true;
                                        break;
                                    }
                                case 4:
                                    {
                                        CanSetupRight = true;
                                        break;
                                    }
                                case 5:
                                    {
                                        CanAssignRightToRole = true;
                                        break;
                                    }

                                case 6:
                                    {
                                        CanAssignRoleToPerson = true;
                                        break;
                                    }

                                case 7:
                                    {
                                        CanSetupPersonType = true;
                                        break;
                                    }
                                case 8:
                                    {
                                        CanSetupPaymentType = true;
                                        break;
                                    }
                                case 9:
                                    {
                                        CanSetupBank = true;
                                        break;
                                    }
                                case 10:
                                    {
                                        CanUpdatePayment = true;
                                        break;
                                    }
                                case 11:
                                    {
                                        CanSetupStockCategory = true;
                                        break;
                                    }
                                case 12:
                                    {
                                        CanSetupStockType = true;
                                        break;
                                    }
                                case 13:
                                    {
                                        CanSetupStock = true;
                                        break;
                                    }

                                case 14:
                                    {
                                        CanSetupPackageType = true;
                                        break;
                                    }
                                case 15:
                                    {
                                        CanSetupStockPackage = true;
                                        break;
                                    }
                                case 16:
                                    {
                                        CanSetupPackageTypeQuantity = true;
                                        break;
                                    }
                                case 17:
                                    {
                                        CanSetupStockPrice = true;
                                        break;
                                    }
                                case 18:
                                    {
                                        CanSetupReturnType = true;
                                        break;
                                    }
                                case 19:
                                    {
                                        CanSetupStockState = true;
                                        break;
                                    }
                                case 20:
                                    {
                                        CanSetupLocation = true;
                                        break;
                                    }
                                case 21:
                                    {
                                        CanCreateStockPurchaseBatch = true;
                                        break;
                                    }
                                case 22:
                                    {
                                        CanModifyPurchaseBatch = true;
                                        break;
                                    }
                                case 23:
                                    {
                                        CanRegisterPurchasedStock = true;
                                        break;
                                    }
                                case 24:
                                    {
                                        CanArrangeStockOnShelf = true;
                                        break;
                                    }
                                case 25:
                                    {
                                        CanRemoveShelfStock = true;
                                        break;
                                    }
                                case 26:
                                    {
                                        CanSellStock = true;
                                        break;
                                    }

                                case 28:
                                    {
                                        CanViewReport = true;
                                        break;
                                    }

                                case 29:
                                    {
                                        CanManageCompany = true;
                                        break;
                                    }
                                case 30:
                                    {
                                        CanSetupCompany = true;
                                        break;
                                    }
                                case 31:
                                    {
                                        CanSetupCompanyRepresentative = true;
                                        break;
                                    }
                                case 32:
                                    {
                                        CanEditSoldStock = true;
                                        break;
                                    }
                                case 33:
                                    {
                                        CanViewEnteredShelfStock = true;
                                        break;
                                    }
                                case 34:
                                    {
                                        CanSetupDailyExpenses = true;
                                        break;
                                    }
                                case 35:
                                    {
                                        CanViewCompanyCreditorsList = true;
                                        break;
                                    }
                                case 36:
                                    {
                                        CanViewCompanyDebtorsList = true;
                                        break;
                                    }
                                case 37:
                                    {
                                        CanViewSupplierCreditorsList = true;
                                        break;
                                    }
                                case 38:
                                    {
                                        CanViewSupplierDebtorsList = true;
                                        break;
                                    }
                                case 39:
                                    {
                                        CanSelectSoldDateOnSellStockPage = true;
                                        break;
                                    }
                                case 40:
                                    {
                                        CanSetupStockReturnAction = true;
                                        break;
                                    }
                                case 41:
                                    {
                                        CanSetupExpensesCategory = true;
                                        break;
                                    }
                                case 42:
                                    {
                                        CanViewStockExpiryDateAlert = true;
                                        break;
                                    }
                                case 43:
                                    {
                                        CanReviewStock = true;
                                        break;
                                    }
                                case 44:
                                    {
                                        CanDeleteSalesTransaction = true;
                                        break;
                                    }
                                case 45:
                                    {
                                        CanReturnStock = true;
                                        break;
                                    }
                                case 46:
                                    {
                                        CanManageReplacedStock = true;
                                        break;
                                    }
                                case 47:
                                    {
                                        CanReturnPurchasedStock = true;
                                        break;
                                    }
                                case 48:
                                    {
                                        CanViewStockListReport = true;
                                        break;
                                    }
                                case 49:
                                    {
                                        CanViewStockPackageReport = true;
                                        break;
                                    }
                                case 50:
                                    {
                                        CanViewPackageRelationshipReport = true;
                                        break;
                                    }
                                case 51:
                                    {
                                        CanViewStockPriceReport = true;
                                        break;
                                    }
                                case 52:
                                    {
                                        CanViewStockPriceHistoryReport = true;
                                        break;
                                    }
                                case 53:
                                    {
                                        CanViewStockPriceHistoryByStockReport = true;
                                        break;
                                    }
                                case 54:
                                    {
                                        CanViewStockPurchaseDetailReport = true;
                                        break;
                                    }
                                case 55:
                                    {
                                        CanViewStockPurchaseDetailByStockReport = true;
                                        break;
                                    }
                                case 56:
                                    {
                                        CanViewStockPurchaseSummaryReport = true;
                                        break;
                                    }
                                case 57:
                                    {
                                        CanViewStockAvailableOnShelfReport = true;
                                        break;
                                    }
                                case 58:
                                    {
                                        CanViewStockInStoreReport = true;
                                        break;
                                    }
                                case 59:
                                    {
                                        CanViewStockSalesAnalysisReport = true;
                                        break;
                                    }
                                case 60:
                                    {
                                        CanViewStockSalesDetailsAnalysisReport = true;
                                        break;
                                    }
                                case 61:
                                    {
                                        CanViewStockSalesDetailAnalysisByStockReport = true;
                                        break;
                                    }
                                case 62:
                                    {
                                        CanViewStockYearlySummaryReport = true;
                                        break;
                                    }
                                case 63:
                                    {
                                        CanViewStockYearlySummaryByStockReport = true;
                                        break;
                                    }
                                case 64:
                                    {
                                        CanViewStockMonthlySummaryReport = true;
                                        break;
                                    }
                                case 65:
                                    {
                                        CanViewStockPriceList = true;
                                        break;
                                    }
                                case 66:
                                    {
                                        CanViewDailySales = true;
                                        break;
                                    }
                                case 67:
                                    {
                                        CanViewDailyTransactionReport = true;
                                        break;
                                    }
                                case 68:
                                    {
                                        CanViewYearlyCustomerTransactionStatisticsReport = true;
                                        break;
                                    }
                                case 69:
                                    {
                                        CanViewCustomerTransactionStatisticsByDateRangeReport = true;
                                        break;
                                    }
                                case 70:
                                    {
                                        CanViewMonthlyStockStatisticsReport = true;
                                        break;
                                    }
                                case 71:
                                    {
                                        CanViewStockStatisticsByDateRangeReport = true;
                                        break;
                                    }
                                case 72:
                                    {
                                        CanViewYearlyStockStatisticsReport = true;
                                        break;
                                    }
                                case 73:
                                    {
                                        CanViewDailyExpensesReport = true;
                                        break;
                                    }
                                case 74:
                                    {
                                        CanViewMonthlyExpensesReport = true;
                                        break;
                                    }
                                case 75:
                                    {
                                        CanViewYearlyExpensesReport = true;
                                        break;
                                    }
                                case 76:
                                    {
                                        CanViewExpensesByDateRangeReport = true;
                                        break;
                                    }
                                case 77:
                                    {
                                        CanViewYearlyStockReturnReport = true;
                                        break;
                                    }
                                case 78:
                                    {
                                        CanViewStockReturnByDateRangeReport = true;
                                        break;
                                    }
                                case 79:
                                    {
                                        CanViewPaymentHistoryReport = true;
                                        break;
                                    }
                                case 80:
                                    {
                                        CanViewPaymentHistoryByPersonReport = true;
                                        break;
                                    }
                                case 81:
                                    {
                                        CanViewStockListByTypeReport = true;
                                        break;
                                    }
                                case 82:
                                    {
                                        CanSetBasicSetting = true;
                                        break;
                                    }
                                case 83:
                                    {
                                        CanSetDB = true;
                                        break;
                                    }
                                case 84:
                                    {
                                        CanSetupShopDetail = true;
                                        break;
                                    }
                                case 85:
                                    {
                                        CanSetupCustomerLoyaltyProgram = true;
                                        break;
                                    }
                                case 86:
                                    {
                                        CanCompactDb = true;
                                        break;
                                    }
                                case 87:
                                    {
                                        CanBackupDb = true;
                                        break;
                                    }
                                case 88:
                                    {
                                        CanRestoreDb = true;
                                        break;
                                    }
                                case 89:
                                    {
                                        CanUploadStoreLogo = true;
                                        break;
                                    }
                                case 90:
                                    {
                                        CanChangeStockPrice = true;
                                        break;
                                    }
                                case 91:
                                    {
                                        CanSetApplicationDate = true;
                                        break;
                                    }
                            }

                            //can manage stock setup
                            if (CanSetupStockCategory == false && CanSetupStockType == false && CanSetupStock == false && CanSetupPackageType == false && CanSetupStockPackage == false && CanSetupPackageTypeQuantity == false && CanSetupStockPrice == false && CanSetupStockState == false && CanSetupExpensesCategory == false && CanSetupStockReturnAction == false)
                            {
                                CanManageStockSetup = false;
                            }
                            else
                            {
                                CanManageStockSetup = true;
                            }

                            //can manage stock
                            if (CanSetupStockCategory == false && CanSetupStockType == false && CanSetupStock == false && CanSetupPackageType == false && CanSetupStockPackage == false && CanSetupPackageTypeQuantity == false && CanSetupStockPrice == false && CanSetupReturnType == false && CanSetupStockState == false && CanRegisterPurchasedStock == false && CanModifyPurchaseBatch == false && CanArrangeStockOnShelf == false && CanRemoveShelfStock == false && CanSellStock == false && CanViewEnteredShelfStock == false && CanViewStockExpiryDateAlert == false && CanReviewStock == false)
                            {
                                CanManageStock = false;
                            }
                            else
                            {
                                CanManageStock = true;
                            }

                            //can manage store
                            if (CanRegisterPurchasedStock == false && CanModifyPurchaseBatch == false && CanArrangeStockOnShelf == false && CanRemoveShelfStock == false && CanSellStock == false && CanViewEnteredShelfStock == false && CanViewStockExpiryDateAlert == false && CanReviewStock == false)
                            {
                                CanManageStore = false;
                            }
                            else
                            {
                                CanManageStore = true;
                            }

                            // can manage payment
                            if (CanSetupPaymentType == false && CanSetupBank == false)
                            {
                                CanManagePayment = false;
                            }
                            else
                            {
                                CanManagePayment = true;
                            }

                            //can manage user
                            if (CanSetupUser == false && CanSetupLoginDetail == false && CanSetupRole == false && CanSetupRight == false && CanAssignRightToRole == false && CanAssignRoleToPerson == false)
                            {
                                CanManagePerson = false;
                            }
                            else
                            {
                                CanManagePerson = true;
                            }

                            //can setup people basic Setup
                            if (CanSetupLocation == false && CanSetupPersonType == false)
                            {
                                CanManagePeopleBasicSetup = false;
                            }
                            else
                            {
                                CanManagePeopleBasicSetup = true;
                            }

                            //can manage company
                            if (CanSetupCompany == false && CanSetupCompanyRepresentative == false)
                            {
                                CanManageCompany = false;
                            }
                            else
                            {
                                CanManageCompany = true;
                            }

                            //can manage sales
                            if (CanEditSoldStock == false && CanSellStock == false && CanDeleteSalesTransaction == false && CanViewStockPriceList == false && CanViewDailySales == false)
                            {
                                CanManageSales = false;
                            }
                            else
                            {
                                CanManageSales = true;
                            }

                            //can manage returns
                            if (CanReturnStock == false && CanManageReplacedStock == false && CanReturnPurchasedStock == false)
                            {
                                CanManageReturns = false;
                            }
                            else
                            {
                                CanManageReturns = true;
                            }

                            // can setup expenses
                            if (CanSetupDailyExpenses == false)
                            {
                                CanManageAccount = false;
                            }
                            else
                            {
                                CanManageAccount = true;
                            }

                            //can view report
                            if (CanViewStockListReport == false && CanViewStockListByTypeReport == false && CanViewStockPackageReport == false && CanViewPackageRelationshipReport == false && CanViewStockPriceReport == false && CanViewStockPriceHistoryReport == false && CanViewStockPriceHistoryByStockReport == false && CanViewStockPurchaseDetailReport == false && CanViewStockPurchaseDetailByStockReport == false && CanViewStockPurchaseSummaryReport == false && CanViewStockAvailableOnShelfReport == false && CanViewStockInStoreReport == false && CanViewCompanyCreditorsList == false && CanViewCompanyDebtorsList == false && CanViewSupplierCreditorsList == false && CanViewSupplierDebtorsList == false && CanViewStockSalesAnalysisReport == false && CanViewStockSalesDetailsAnalysisReport == false && CanViewStockSalesDetailAnalysisByStockReport == false && CanViewStockYearlySummaryReport == false && CanViewStockYearlySummaryByStockReport == false && CanViewStockMonthlySummaryReport == false)
                            {
                                CanViewReport = false;
                            }
                            else
                            {
                                CanViewReport = true;
                            }

                            //can view purchase report
                            if (CanViewStockPurchaseDetailReport == false && CanViewStockPurchaseDetailByStockReport == false && CanViewStockPurchaseSummaryReport == false)
                            {
                                CanViewPurchaseReport = false;
                            }
                            else
                            {
                                CanViewPurchaseReport = true;
                            }

                            //can view payment report
                            if (CanViewCompanyCreditorsList == false && CanViewCompanyDebtorsList == false && CanViewSupplierCreditorsList == false && CanViewSupplierDebtorsList == false && CanViewPaymentHistoryReport == false && CanViewPaymentHistoryByPersonReport == false)
                            {
                                CanViewPaymentReport = false;
                            }
                            else
                            {
                                CanViewPaymentReport = true;
                            }

                            //can view stock report
                            if (CanViewStockListReport == false && CanViewStockPackageReport == false && CanViewPackageRelationshipReport == false && CanViewStockPriceReport == false && CanViewStockPriceHistoryReport == false && CanViewStockPriceHistoryByStockReport == false && CanViewStockAvailableOnShelfReport == false && CanViewStockInStoreReport == false)
                            {
                                CanViewStockReport = false;
                            }
                            else
                            {
                                CanViewStockReport = true;
                            }

                            //can view sales report
                            if (CanViewStockSalesAnalysisReport == false && CanViewStockSalesDetailsAnalysisReport == false && CanViewStockSalesDetailAnalysisByStockReport == false)
                            {
                                CanViewSalesReport = false;
                            }
                            else
                            {
                                CanViewSalesReport = true;
                            }

                            //can view miscellaneous report
                            if (CanViewDailyTransactionReport == false && CanViewStockYearlySummaryReport == false && CanViewStockYearlySummaryByStockReport == false && CanViewStockMonthlySummaryReport == false && CanViewYearlyCustomerTransactionStatisticsReport == false && CanViewCustomerTransactionStatisticsByDateRangeReport == false && CanViewMonthlyStockStatisticsReport == false && CanViewStockStatisticsByDateRangeReport == false && CanViewYearlyStockStatisticsReport == false)
                            {
                                CanViewMiscellaneousReport = false;
                            }
                            else
                            {
                                CanViewMiscellaneousReport = true;
                            }

                            //can view returns report
                            if (CanViewYearlyStockReturnReport == false && CanViewStockReturnByDateRangeReport == false)
                            {
                                CanViewReturnsReport = false;
                            }
                            else
                            {
                                CanViewReturnsReport = true;
                            }

                            //can view expenses report
                            if (CanViewDailyExpensesReport == false && CanViewMonthlyExpensesReport == false && CanViewYearlyExpensesReport == false && CanViewExpensesByDateRangeReport == false)
                            {
                                CanViewExpensesReport = false;
                            }
                            else
                            {
                                CanViewExpensesReport = true;
                            }

                            //can manage setting
                            if (CanSetBasicSetting == false && CanSetApplicationDate == false && CanSetDB == false && CanSetupShopDetail == false && CanUploadStoreLogo == false && CanSetupCustomerLoyaltyProgram == false && CanCompactDb == false && CanBackupDb == false && CanRestoreDb == false)
                            {
                                CanManageSettings = false;
                            }
                            else
                            {
                                CanManageSettings = true;
                            }

                            //can maintain db
                            if (CanCompactDb == false && CanBackupDb == false && CanRestoreDb == false)
                            {
                                CanMaintainDb = false;
                            }
                            else
                            {
                                CanMaintainDb = true;
                            }





                        }
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
