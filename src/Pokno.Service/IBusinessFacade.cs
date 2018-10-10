using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model;
using Pokno.Model.Model;
using Pokno.Business.Helper;
using Pokno.Business.Interfaces;

namespace Pokno.Service
{
    public interface IBusinessFacade
    {
        #region Bank

        List<Bank> GetAllBanks();
        bool AddBank(Bank bank);
        bool RemoveBank(Bank bank);
        bool ModifyBank(Bank bank);
        int AddBanks(List<Bank> banks);

        #endregion

        #region Location Region

        bool AddLocation(Location location);
        int AddLocations(List<Location> locations);
        List<Location> GetAllLocations();
        bool RemoveLocation(Location location);
        bool ModifyLocation(Location location);

        #endregion

        #region Payment Type Region

        bool AddPaymentType(PaymentType paymentType);
        int AddPaymentTypes(List<PaymentType> paymentTypes);
        List<PaymentType> GetAllPaymentTypes();
        bool RemovePaymentType(PaymentType paymentType);
        bool ModifyPaymentType(PaymentType paymentType);

        #endregion

        #region Person Type Region

        bool AddPersonType(PersonType personType);
        int AddPersonTypes(List<PersonType> PersonTypes);
        List<PersonType> GetAllPersonTypes();
        bool RemovePersonType(PersonType personType);
        bool ModifyPersonType(PersonType personType);

        #endregion

        #region Stock Category Region

        bool AddStockCategory(StockCategory stockCategory);
        int AddStockCategorys(List<StockCategory> stockCategorys);
        List<StockCategory> GetAllStockCategorys();
        bool RemoveStockCategory(StockCategory stockCategory);
        bool ModifyStockCategory(StockCategory stockCategory);

        #endregion

        #region Stock Type Region

        bool AddStockType(StockType stockType);
        int AddStockTypes(List<StockType> stockTypes);
        List<StockType> GetAllStockTypes();
        bool RemoveStockType(StockType stockType);
        bool ModifyStockType(StockType stockType);

        #endregion

        #region Stock Region

        bool AddStock(Stock stock);
        int AddStocks(List<Stock> stocks);
        List<Stock> GetAllStocks();
        List<Stock> GetAllStockWithDependant();
        List<Stock> GetAllStocksWithPackageQuantity();
        bool RemoveStock(Stock stock);
        bool ModifyStock(Stock stock);
        List<StoreStock> GetStoreStocks();
        List<StoreStock> GetStoreStocksBy(StockType type);

        #endregion

        #region Stock Package Region

        bool AddStockPackages(List<StockPackage> stockPackages);
        List<StockPackage> GetAllStockPackages();
        List<StoreStock> GetAllStoreStock();
        List<StockPackage> GetStockPackages(Stock stock);
        bool ModifyStockPackages(List<StockPackage> stockPackages);
        bool DeleteStockPackagesBy(Stock stock);
        bool NoStockPackageExistFor(Stock stock);

        #endregion

        #region Stock ReturnType Region

        bool AddStockReturnType(StockReturnType stockReturnType);
        int AddStockReturnTypes(List<StockReturnType> stockReturnTypes);
        bool RemoveStockReturnType(StockReturnType stockReturnType);
        bool ModifyStockReturnType(StockReturnType stockReturnType);
        List<StockReturnType> GetAllStockReturnTypes();

        #endregion

        #region Stock Return Action Region

        bool AddStockReturnAction(StockReturnAction stockReturnAction);
        List<StockReturnAction> GetAllStockReturnActions();
        bool RemoveStockReturnAction(StockReturnAction stockReturnAction);
        bool ModifyStockReturnAction(StockReturnAction stockReturnAction);

        #endregion

        #region Stock State Region

        bool AddStockState(StockState stockState);
        int AddStockStates(List<StockState> stockStates);
        List<StockState> GetAllStockStates();
        bool RemoveStockState(StockState stockState);
        bool ModifyStockState(StockState stockState);

        #endregion

        #region Stock PurchaseBatch Region

        bool AddStockPurchaseBatch(StockPurchaseBatch stockPurchaseBatch);
        List<StockPurchaseBatch> GetAllStockPurchaseBatches();
        bool RemoveStockPurchaseBatch(StockPurchaseBatch stockPurchaseBatch);
        bool ModifyStockPurchaseBatch(StockPurchaseBatch stockPurchaseBatch);
        StockPurchaseBatch LoadBatchStockPurchaseAndPaymentInformation(StockPurchaseBatch stockPurchaseBatch);
        List<StockPurchaseBatch> GetPurchaseBatchNotOnShelf();

        #endregion

        #region StockPurchased Region

        bool AddStockPurchased(StockPurchased stockPurchased);
        bool AddStockPurchases(List<StockPurchased> stockPurchases);
        List<StockPurchased> GetAllStockPurchases();
        //bool RemoveStockPurchased(StockPurchased stockPurchased);
        bool ModifyStockPurchased(StockPurchased stockPurchased);
        List<StockPurchased> LoadStockPurchaseByBatch(StockPurchaseBatch stockPurchaseBatch);
        bool ModifyStockPurchases(StockPurchaseBatch purchaseBatch);
        List<StockPurchasedAtHand> GetStockPurchasedAtHand();
        List<StoreStockPurchased> GetStoreStockPurchasedByDateRange(DateTime startDate, DateTime endDate);
        List<StoreStockPurchased> GetStoreStockPurchasedSummaryByDateRange(DateTime startDate, DateTime endDate);
        List<StoreStockPurchased> GetStoreStockPurchasedByStockAndDateRange(DateTime startDate, DateTime endDate, Stock stock);
        List<StoreStock> GetStocksInStore();
        //List<StockReviewDetail> GetMonthlyStockSummary(int month, int year);
        //List<StockReviewDetail> GetYearlyStockSummary(int year);

        #endregion

        #region Person Region

        LoginDetail ValidateUser(string userName, string password);
        List<Person> GetUsers(Person person);
        Person GetUserByUserName(string userName);
        bool AddPerson(Person person);
        bool AddPeople(List<Person> People);
        List<Person> GetAllPeople();
        bool RemovePerson(Person person);
        bool ModifyPerson(Person person);
        List<Person> GetPersonsByType(PersonType personType);
        Person GetPersonById(long id);
        List<Person> GetUsersBy(Person person);
        List<Person> GetAllCustomerAndSupplier();

        #endregion

        #region Package Region

        bool AddPackage(Package package);
        bool AddPackages(List<Package> packages);
        List<Package> GetAllPackages();
        bool RemovePackage(Package package);
        bool ModifyPackage(Package package);
        List<Package> GetPackagesForStock(Stock stock);
        List<StorePackage> GetAllStorePackage();

        #endregion

        #region Package Relationship

        bool AddPackageQuantity(PackageRelationship packageQuantity);
        bool AddPackageQuantities(List<PackageRelationship> packageQuantities);
        List<PackageRelationship> GetAllPackageQuantities();
        List<PackageRelationship> GetByStock(Stock stock);
        List<StockPackage> GetStockPackagesBy(Stock stock, StockPackageRelationship stockPackageRelationship);

        #endregion

        #region Stock Package Relationship

        bool AddStockPackageRelationship(StockPackageRelationship stockPackageRelationship);
        bool ModifyStockPackageRelationship(StockPackageRelationship stockPackageRelationship);
        bool DeleteStockPackageRelationshipBy(Stock stock);
        bool NoPackageRelationshipExist(Stock stock);

        #endregion

        #region Stock Price

        bool AddStockPrice(StockPrice stockPrice);
        bool AddStockPrices(List<StockPrice> stockPrices);
        List<StockPrice> GetAllStockPrice();
        bool ModifyStockPrices(List<StockPrice> stockPrices);
        List<StockPrice> GetStockPriceByStock(Stock stock);
        StockPrice GetStockPriceByStockPackage(StockPackage stockPackage);
        List<StoreStockPrice> GetAllStoreStockPrice();
        List<StoreStockPrice> GetAllStoreStockPriceHistory();
        List<StoreStockPrice> GetAllStoreStockPriceHistoryByStock(Stock stock);
        List<StoreProfitableStock> GetProfitableStockBy(bool isTop5);
        bool DeleteStockPriceByStock(Stock stock);
        bool NoStockPriceExistFor(Stock stock);

        #endregion

        #region SupplierPaymentHistory

        List<StockPurchasePayment> GetSupplierPaymentHistory(Person person);

        #endregion

        #region Stock On Shelf Batch

        int ArrangeStockOnShelf(Shelf shelf);
        List<Shelf> GetAllUntouched();

        #endregion

        #region Stock On Shelf

        bool RemoveStockOnShelf(Shelf shelf);
        StockForSale GetStockForSale(StockPackage stockPackage, int stockPackageRelationshipId);
        List<StockAtHand> GetStocksAtHand(Stock stock);
        List<StockOnShelfAtHand> GetStockOnShelfAtHand();
        List<StoreStock> GetRemainingStockOnShelf();
        List<Shelf> GetLatestHundredStocksOnShelf();
        List<Shelf> GetStocksOnShelfByDateRange(DateTime fromDate, DateTime toDate);
        List<ExpiryDateAlert> GetAboutToExpiredStock();

        //StockForSale GetStockForSale(StockPackage stockPackage);
        //List<StockOnShelfAtHand> GetStockOnShelfAtHand();
        //bool RemoveStockOnShelf(StockOnShelf stockOnShelf);
        //List<StockAtHand> GetStocksAtHand(Stock stock);
        //List<StoreStock> GetRemainingStockOnShelf();
        //List<StockOnShelf> GetLatestHundredStocksOnShelf();
        //List<StockOnShelf> GetStocksOnShelfByDateRange(DateTime fromDate, DateTime toDate);


        #endregion

        #region Sold Stock Batch

        decimal GetYearlySalesDiscount(int year);
        decimal GetMonthlySalesDiscount(int year, int month);
        SoldStockBatch SellStock(SoldStockBatch outgoingStockBatch);
        List<SalesInvoice> GetSalesInvoiceBySoldStockBatch(SoldStockBatch soldStockBatch);
        List<SoldStockBatch> GetAllSoldStockBatch();
        bool RemoveSoldStockBatch(SoldStockBatch soldStockBatch);
        bool ModifySoldStock(SoldStockBatch soldStockBatch);
        List<SoldStockBatch> GetSoldStockBatchByDateRange(DateTime fromDate, DateTime toDate);
        List<SoldStockBatch> GetSoldStockByBatchInvoiceNumber(string invoiceNo);

        //List<SoldStockBatch> GetSoldStockByBatchReceiptNumber(long receiptNumber);

        #endregion

        #region Outgoing Stock

        List<SoldStockView> GetSoldStockByDateRange(DateTime startDate, DateTime endDate);
        List<SoldStock> GetOutgoingStockByBatch(SoldStockBatch outgoingStockBatch);
        List<SoldStockView> GetSoldStockDetailsByDateRange(DateTime startDate, DateTime endDate);
        List<SoldStockView> GetSoldStockDetailsByDateRangeAndStock(DateTime startDate, DateTime endDate, Stock stock);
        List<SoldStock> GetSoldStockByInvoiceNo(string invoiceNo);
        List<StoreSalesFrequency> GetStockSalesFrequencyBy(bool isTop5, int year);
        List<StoreSalesFrequency> GetTopProfitableStockBy(bool isTop5, int year);

        List<StoreSalesFrequency> GetMonthlyStockSalesFrequencyBy(bool isTop5, int year, int month);
        List<StoreSalesFrequency> GetMonthlyTopProfitableStockBy(bool isTop5, int year, int month);
        List<StoreSalesFrequency> GetStockSalesFrequencyByDateRange(bool isTop5, DateTime fromDate, DateTime toDate);
        List<StoreSalesFrequency> GetTopProfitableStockByDateRange(bool isTop5, DateTime fromDate, DateTime toDate);

        List<StoreCustomerStatistics> GetYearlyTopCustomerTransactionFrequency(bool isTop5, int year);
        List<StoreCustomerStatistics> GetTopYearlyCustomerTransactionVolumeBy(bool isTop5, int year);
        List<StoreCustomerStatistics> GetYearlyCustomerTransactionProfitBy(bool isTop5, int year);

        List<StoreCustomerStatistics> GetCustomerTransactionFrequencyByDateRange(bool isTop5, DateTime fromDate, DateTime toDate);
        List<StoreCustomerStatistics> GetCustomerTransactionVolumeByDateRange(bool isTop5, DateTime fromDate, DateTime toDate);
        List<StoreCustomerStatistics> GetCustomerTransactionProfitByDateRange(bool isTop5, DateTime fromDate, DateTime toDate);

        //List<StoreCustomerStatistics> GetMonthlyCustomerTransactionFrequencyBy(bool isTop5, int year, int month);
        //List<StoreCustomerStatistics> GetMonthlyCustomerTransactionVolumeBy(bool isTop5, int year, int month);
        //List<StoreCustomerStatistics> GetMonthlyCustomerTransactionProfitBy(bool isTop5, int year, int month);

        #endregion

        #region Role Region

        List<Role> GetRoles(Person person);
        List<Role> GetAllRoles();
        bool AddRole(Role role);
        bool AssignRightToRole(Role role);
        bool ModifyRole(Role role);
        bool RemoveRole(Role role);

        #endregion

        #region Right Region

        List<Right> GetAllRights();
        bool AddRight(Right right);
        bool ModifyRight(Right right);
        bool RemoveRight(Right right);

        #endregion

        #region Deleted Stock On Shelf

        bool AddDeletedStockOnShelf(List<DeletedShelfStock> deletedStockOnShelfs);

        #endregion

        #region Payment

        bool ModifyPayment(Payment payment);
        List<Payment> GetPaymentTransactions(Person person);
        List<PaymentStatus> GetDailyPaymentTransactions(DateTime date);
        List<PaymentHistory> GetPaymentHistoryByPersonType(PersonType personType);
        List<PaymentHistory> GetPaymentHistoryByPerson(Person person);
        List<PaymentHistory> GetPaymentHistory();

        #endregion

        #region Payment Detail

        List<PaymentDetail> GetPaymentDetails(Payment payment);
        bool ModifyPaymentDetail(List<PaymentDetail> paymentDetails);
        List<PaymentStatus> GetTradeStatus(Trade trade);
        List<PaymentStatus> GetDeptors(Trader trader);
        List<PaymentStatus> GetCreditors(Trader trader);
        bool UpdatePaymentDetail(List<PaymentDetail> paymentDetails);

        #endregion

        #region Company Region

        bool AddCompany(Company company);
        List<Company> GetAllCompany();
        bool RemoveCompany(Company company);
        bool ModifyCompany(Company company);

        #endregion

        #region Person Company Region

        List<PersonCompany> GetAllPersonCompany();
        bool AddPersonCompany(PersonCompany personCompany);
        bool RemovePersonCompany(PersonCompany personCompany);
        bool ModifyPersonCompany(PersonCompany personCompany);

        #endregion

        #region Login Detail Region

        List<LoginDetail> GetAllLoginDetails();
        bool ResetLoginDetailPassword(LoginDetail loginDetail);
        bool ModifyLoginDetail(LoginDetail loginDetail);
        LoginDetail ChangePassword(Person person, string password);

        #endregion

        #region Expenses Region

        decimal GetTotalYearlyExpenses(int year);
        decimal GetTotalMonthlyExpenses(int year, int month);
        decimal GetSupplierExpensesBy(DateTime fromDate, DateTime toDate);
        List<StoreExpenses> GetDailyExpensesByDate(DateTime expensesDate);
        Expenses GetExpensisByDate(DateTime expensisDate);
        bool AddExpensis(Expenses expensis);
        List<StoreExpenses> GetMonthlyExpenses(int year, int month);
        List<StoreExpenses> GetExpensesByDateRange(DateTime fromDate, DateTime toDate);
        List<StoreExpenses> GetYearlyExpenses(int year);

        #endregion

        #region Expenses category

        List<ExpensesCategory> GetAllExpensesCategories();
        bool AddExpensesCategory(ExpensesCategory expensesCategory);
        bool RemoveExpensesCategory(ExpensesCategory expensesCategory);
        bool ModifyExpensesCategory(ExpensesCategory expensesCategory);

        #endregion

        #region Stock Review Region

        bool AddStockReview(StockReview stockReview);
        List<Year> GetTotalYears();
        List<StockReviewDetail> GetYearlyStockReview(int year);
        List<StockReviewDetail> GetMonthlyStockReview(CalendarMonth month);
        List<StockReviewDetail> GetMonthlyStockSummaryBy(int year, int month);
        List<StockReviewDetail> GetYearlyStockSummaryBy(int year, Stock stock);

        #endregion

        #region Stock Return

        bool ReturnSoldStock(ReturnedStock soldStockToReturn);
        List<StoreReturnStock> GetYearlyReturnedStockStatisticsBy(bool isTop5, int year);
        List<StoreReturnStock> GetMonthlyReturnedStockStatisticsBy(bool isTop5, int year, int month);
        List<StoreReturnStock> GetReturnedStockStatisticsByDateRange(bool isTop5, DateTime fromDate, DateTime toDate);

        List<StoreReturnStock> GetReturnedStockByDateRange(DateTime fromDate, DateTime toDate);
        List<StoreReturnStock> GetReturnedStockByYear(int year);

        #endregion

        #region Returned Stock Replacement

        List<ReplacedStockAction> GetAllReplacedStockAction();
        List<ReturnedStockReplacement> GetAllUntreatedStockReplacement();
        bool TreatReplacedStock(List<ReturnedStockReplacement> replacedStocks);

        #endregion

        #region Deleted Sold Stock Batch

        DeletedSoldStockBatch AddDeletedSoldStockBatch(DeletedSoldStockBatch deletedSoldStockBatch);

        #endregion

        #region Stock Purchased Return

        bool AddReturnBoundPurchasedStock(List<PurchasedStockReturn> returnBoundPurchasedStocks);
        List<PurchasedStockReturn> GetReturnBoundPurchasedStockBy(StockPurchaseBatch purchaseBatch);
        bool ModifyReturnBoundPurchasedStocks(List<PurchasedStockReturn> returnBoundPurchasedStocks);

        #endregion

        #region Store

        Store GetStore();
        bool AddStore(Store store);
        bool UploadStoreLogo(Store store, string destinationFolder, string sourceFilePath, IFileManager fileManager);
        bool DeleteStoreLogo(Store store, string destinationFolder, IFileManager fileManager);

        #endregion

        #region Settings Region

        Setting GetSetting();
        bool AddSetting(Setting setting);

        #endregion

        #region Appication Mode Region

        List<ApplicationMode> GetAllApplicationModes();
        bool AddApplicationMode(ApplicationMode applicationMode);
        bool RemoveApplicationMode(ApplicationMode applicationMode);
        bool ModifyApplicationMode(ApplicationMode applicationMode);

        #endregion

        #region Esnecil Region

        Esnecil GetEsnecil();
        bool SaveEsnecil(Esnecil esnecil);
        bool ModifyEsnecil(Esnecil esnecil);
       
        #endregion

        void RefreshDatabase(string dbPath);
        

    }


}
