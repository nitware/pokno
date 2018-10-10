using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Business;
using Pokno.Model;
using Pokno.Model.Model;
using Pokno.Business.Helper;
using System.Collections.ObjectModel;
using Pokno.Business.Interfaces;
using Pokno.Data;

namespace Pokno.Service
{
    public class BusinessFacade : IBusinessFacade
    {
        private BankLogic bankLogic;
        private LocationLogic locationLogic;
        private PaymentTypeLogic paymentTypeLogic;
        private PersonTypeLogic personTypeLogic;
        private StockCategoryLogic stockCategoryLogic;
        private StockTypeLogic stockTypeLogic;
        private StockLogic stockLogic;
        private PackageLogic packageLogic;
        private StockPackageLogic stockPackageLogic;
        private StockReturnTypeLogic stockReturnTypeLogic;
        private StockStateLogic stockStateLogic;
        private StockPurchasedLogic stockPurchasedLogic;
        private StockPurchaseBatchLogic stockPurchaseBatchLogic;
        private PersonLogic personLogic;
        private PackageRelationshipLogic packageQuantityLogic;
        private StockPriceLogic stockPriceLogic;
        private StockPurchasePaymentLogic stockPurchasePaymentLogic;
        private ShelfLogic stockOnShelfLogic;
        private SoldStockLogic outgoingStockLogic;
        private SoldStockBatchLogic soldStockBatchLogic;
        private RoleLogic roleLogic;
        private RightLogic rightLogic;
        private DeletedShelfStockLogic deletedStockOnShelfLogic;
        private PaymentLogic paymentLogic;
        private PaymentDetailLogic paymentDetailLogic;
        private CompanyLogic companyLogic;
        private PersonCompanyLogic personCompanyLogic;
        private LoginDetailLogic loginDetailLogic;
        private ExpensesLogic expensisLogic;
        private StockReviewDetailLogic stockReviewDetailLogic;

        private ReturnedStockLogic _returnedStockLogic;
        private StockReturnActionLogic stockReturnActionLogic;
        private ReplacedStockActionLogic replacedStockActionLogic;
        private ReturnedStockReplacementLogic returnedStockReplacementLogic;
        private StockPackageRelationshipLogic stockPackageRelationshipLogic;
        private DeletedSoldStockBatchLogic _deletedSoldStockBatchLogic;
        private PurchasedStockReturnLogic _stockPurchasedReturnLogic;
        private ExpensesCategoryLogic _expensesCategoryLogic;
        private ApplicationModeLogic _applicationModeLogic;
        private CurrentEsnecilLogic _currentEsnecilLogic;
        private StoreLogic _storeLogic;
        private SettingLogic _settingLogic;
        private EsnecilLogic _esnecilLogic;
        

        private string _dbPath;
        private IRepository _repository;

        public BusinessFacade(string dbPath)
        {
            _dbPath = dbPath;
            _repository = new Repository(dbPath);
        }

        //public BusinessFacade(IRepository repository)
        //{
        //    _repository = repository;
        //}

        #region Bank Region

        public bool AddBank(Bank bank)
        {
            try
            {
                RefreshDatabase(_dbPath);
                bankLogic = new BankLogic(_repository);
                Bank newBank = bankLogic.Add(bank);
                return (newBank.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Bank> GetAllBanks()
        {
            try
            {
                RefreshDatabase(_dbPath);
                bankLogic = new BankLogic(_repository);
                return bankLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveBank(Bank bank)
        {
            try
            {
                RefreshDatabase(_dbPath);
                bankLogic = new BankLogic(_repository);
                return bankLogic.Remove(bank);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyBank(Bank bank)
        {
            try
            {
                RefreshDatabase(_dbPath);
                bankLogic = new BankLogic(_repository);
                return bankLogic.Modify(bank);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddBanks(List<Bank> banks)
        {
            try
            {
                RefreshDatabase(_dbPath);
                bankLogic = new BankLogic(_repository);
                return bankLogic.Add(banks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region  Location Region

        public bool AddLocation(Location location)
        {
            try
            {
                RefreshDatabase(_dbPath);
                locationLogic = new LocationLogic(_repository);
                Location mylocation = locationLogic.Add(location);
                return (mylocation.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddLocations(List<Location> locations)
        {
            try
            {
                RefreshDatabase(_dbPath);
                locationLogic = new LocationLogic(_repository);
                return locationLogic.Add(locations);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Location> GetAllLocations()
        {
            try
            {
                RefreshDatabase(_dbPath);
                locationLogic = new LocationLogic(_repository);
                return locationLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveLocation(Location location)
        {
            try
            {
                RefreshDatabase(_dbPath);
                locationLogic = new LocationLogic(_repository);
                return locationLogic.Remove(location);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyLocation(Location location)
        {
            try
            {
                RefreshDatabase(_dbPath);
                locationLogic = new LocationLogic(_repository);
                return locationLogic.Modify(location);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region PaymentType Region

        public bool AddPaymentType(PaymentType paymentType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentTypeLogic = new PaymentTypeLogic(_repository);
                PaymentType mypaymentType = paymentTypeLogic.Add(paymentType);
                return (mypaymentType.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddPaymentTypes(List<PaymentType> paymentTypes)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentTypeLogic = new PaymentTypeLogic(_repository);
                return paymentTypeLogic.Add(paymentTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<PaymentType> GetAllPaymentTypes()
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentTypeLogic = new PaymentTypeLogic(_repository);
                return paymentTypeLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemovePaymentType(PaymentType paymentType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentTypeLogic = new PaymentTypeLogic(_repository);
                return paymentTypeLogic.Remove(paymentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyPaymentType(PaymentType paymentType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentTypeLogic = new PaymentTypeLogic(_repository);
                return paymentTypeLogic.Modify(paymentType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region PersonType Region

        public bool AddPersonType(PersonType personType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personTypeLogic = new PersonTypeLogic(_repository);
                PersonType myPersonType = personTypeLogic.Add(personType);
                return (myPersonType.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddPersonTypes(List<PersonType> PersonTypes)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personTypeLogic = new PersonTypeLogic(_repository);
                return personTypeLogic.Add(PersonTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<PersonType> GetAllPersonTypes()
        {
            try
            {
                RefreshDatabase(_dbPath);
                personTypeLogic = new PersonTypeLogic(_repository);
                return personTypeLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemovePersonType(PersonType personType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personTypeLogic = new PersonTypeLogic(_repository);
                return personTypeLogic.Remove(personType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyPersonType(PersonType personType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personTypeLogic = new PersonTypeLogic(_repository);
                return personTypeLogic.Modify(personType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region StockCategory Region

        public bool AddStockCategory(StockCategory stockCategory)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockCategoryLogic = new StockCategoryLogic(_repository);
                StockCategory myStockCategory = stockCategoryLogic.Add(stockCategory);
                return (myStockCategory.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddStockCategorys(List<StockCategory> stockCategorys)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockCategoryLogic = new StockCategoryLogic(_repository);
                return stockCategoryLogic.Add(stockCategorys);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockCategory> GetAllStockCategorys()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockCategoryLogic = new StockCategoryLogic(_repository);
                return stockCategoryLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveStockCategory(StockCategory stockCategory)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockCategoryLogic = new StockCategoryLogic(_repository);
                return stockCategoryLogic.Remove(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStockCategory(StockCategory stockCategory)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockCategoryLogic = new StockCategoryLogic(_repository);
                return stockCategoryLogic.Modify(stockCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Type Region

        public bool AddStockType(StockType stockType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockTypeLogic = new StockTypeLogic(_repository);
                StockType myStockType = stockTypeLogic.Add(stockType);
                return (myStockType.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddStockTypes(List<StockType> stockTypes)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockTypeLogic = new StockTypeLogic(_repository);
                return stockTypeLogic.Add(stockTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockType> GetAllStockTypes()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockTypeLogic = new StockTypeLogic(_repository);
                return stockTypeLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveStockType(StockType stockType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockTypeLogic = new StockTypeLogic(_repository);
                return stockTypeLogic.Remove(stockType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStockType(StockType stockType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockTypeLogic = new StockTypeLogic(_repository);
                return stockTypeLogic.Modify(stockType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Region

        public bool AddStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                Stock myStock = stockLogic.Add(stock);
                return (myStock.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddStocks(List<Stock> stocks)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.Add(stocks);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Stock> GetAllStocks()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Stock> GetAllStockWithDependant()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.GetAllWithDependant();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStock> GetStoreStocks()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStock> GetStoreStocksBy(StockType type)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.GetBy(type);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Stock> GetAllStocksWithPackageQuantity()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.GetAllWithPackageQuantity();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.Remove(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockLogic = new StockLogic(_repository);
                return stockLogic.Modify(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion End Of Stock Region

        #region Stock Package Region

        public bool AddStockPackages(List<StockPackage> stockPackages)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageLogic = new StockPackageLogic(_repository);
                int addedRowCount = stockPackageLogic.Add(stockPackages);
                return (addedRowCount > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPackage> GetAllStockPackages()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageLogic = new StockPackageLogic(_repository);
                return stockPackageLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStock> GetAllStoreStock()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageLogic = new StockPackageLogic(_repository);
                return stockPackageLogic.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPackage> GetStockPackages(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageLogic = new StockPackageLogic(_repository);
                return stockPackageLogic.GetBy(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyStockPackages(List<StockPackage> stockPackages)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageLogic = new StockPackageLogic(_repository);
                return stockPackageLogic.Modify(stockPackages);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteStockPackagesBy(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageLogic = new StockPackageLogic(_repository);
                return stockPackageLogic.Delete(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool NoStockPackageExistFor(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageLogic = new StockPackageLogic(_repository);
                return stockPackageLogic.NoPackageExistFor(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Return Type Region

        public bool AddStockReturnType(StockReturnType stockReturnType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnTypeLogic = new StockReturnTypeLogic(_repository);
                StockReturnType myStockReturnType = stockReturnTypeLogic.Add(stockReturnType);
                return (myStockReturnType.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddStockReturnTypes(List<StockReturnType> stockReturnTypes)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnTypeLogic = new StockReturnTypeLogic(_repository);
                return stockReturnTypeLogic.Add(stockReturnTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockReturnType> GetAllStockReturnTypes()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnTypeLogic = new StockReturnTypeLogic(_repository);
                return stockReturnTypeLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveStockReturnType(StockReturnType stockReturnType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnTypeLogic = new StockReturnTypeLogic(_repository);
                return stockReturnTypeLogic.Remove(stockReturnType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStockReturnType(StockReturnType stockReturnType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnTypeLogic = new StockReturnTypeLogic(_repository);
                return stockReturnTypeLogic.Modify(stockReturnType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock State Region

        public bool AddStockState(StockState stockState)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockStateLogic = new StockStateLogic(_repository);
                StockState myStockState = stockStateLogic.Add(stockState);
                return (myStockState.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddStockStates(List<StockState> stockStates)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockStateLogic = new StockStateLogic(_repository);
                return stockStateLogic.Add(stockStates);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockState> GetAllStockStates()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockStateLogic = new StockStateLogic(_repository);
                return stockStateLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveStockState(StockState stockState)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockStateLogic = new StockStateLogic(_repository);
                return stockStateLogic.Remove(stockState);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStockState(StockState stockState)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockStateLogic = new StockStateLogic(_repository);
                return stockStateLogic.Modify(stockState);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Purchase Batch Region

        public bool AddStockPurchaseBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchaseBatchLogic = new StockPurchaseBatchLogic(_repository);
                stockPurchaseBatch = stockPurchaseBatchLogic.Add(stockPurchaseBatch);
                return (stockPurchaseBatch.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddStockPurchaseBatches(List<StockPurchaseBatch> stockPurchaseBatches)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchaseBatchLogic = new StockPurchaseBatchLogic(_repository);
                return stockPurchaseBatchLogic.Add(stockPurchaseBatches);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPurchaseBatch> GetAllStockPurchaseBatches()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchaseBatchLogic = new StockPurchaseBatchLogic(_repository);
                return stockPurchaseBatchLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPurchaseBatch> GetPurchaseBatchNotOnShelf()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchaseBatchLogic = new StockPurchaseBatchLogic(_repository);
                return stockPurchaseBatchLogic.GetPurchaseBatchNotOnShelf();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveStockPurchaseBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchaseBatchLogic = new StockPurchaseBatchLogic(_repository);
                return stockPurchaseBatchLogic.Remove(stockPurchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStockPurchaseBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchaseBatchLogic = new StockPurchaseBatchLogic(_repository);
                return stockPurchaseBatchLogic.Modify(stockPurchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StockPurchaseBatch LoadBatchStockPurchaseAndPaymentInformation(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchaseBatchLogic = new StockPurchaseBatchLogic(_repository);
                return stockPurchaseBatchLogic.LoadBatchStockPurchaseAndPaymentInformation(stockPurchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Purchase Region

        public bool AddStockPurchased(StockPurchased stockPurchased)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                stockPurchased = stockPurchasedLogic.Add(stockPurchased);
                return (stockPurchased.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddStockPurchases(List<StockPurchased> stockPurchases)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                int changeCount = stockPurchasedLogic.Add(stockPurchases);
                return (changeCount > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStockPurchased> GetStoreStockPurchasedByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.GetByDatePurchasedRange(startDate, endDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStockPurchased> GetStoreStockPurchasedByStockAndDateRange(DateTime startDate, DateTime endDate, Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.GetByStockAndDatePurchasedRange(startDate, endDate, stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStockPurchased> GetStoreStockPurchasedSummaryByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.GetSummaryByDatePurchasedRange(startDate, endDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPurchased> GetAllStockPurchases()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPurchased> LoadStockPurchaseByBatch(StockPurchaseBatch stockPurchaseBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                StockPurchaseBatch purchaseBatch = stockPurchasedLogic.LoadStockPurchaseByBatch(stockPurchaseBatch);
                return purchaseBatch.StockPurchases;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStockPurchased(StockPurchased stockPurchased)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.Modify(stockPurchased);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyStockPurchases(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.Modify(purchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreStock> GetStocksInStore()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.GetStocksInStore();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockPurchasedAtHand> GetStockPurchasedAtHand()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasedLogic = new StockPurchasedLogic(_repository);
                return stockPurchasedLogic.GetStockPurchasedAtHand();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Person Region

        public LoginDetail ValidateUser(string userName, string password)
        {
            try
            {
                RefreshDatabase(_dbPath);
                loginDetailLogic = new LoginDetailLogic(_repository);
                return loginDetailLogic.Get(userName, password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> GetUsers(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.GetAll(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Person> GetUsersBy(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.GetUsersBy(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person GetPersonById(long id)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.GetBy(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person GetUserByUserName(string userName)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.GetBy(userName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddPerson(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                person = personLogic.Add(person);
                return (person.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddPeople(List<Person> People)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                int changeCount = personLogic.Add(People);
                bool suceeded = (changeCount > 0 ? true : false);
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Person> GetAllPeople()
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemovePerson(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.Remove(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyPerson(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.Modify(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Person> GetPersonsByType(PersonType personType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.GetPersonsByType(personType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> GetAllCustomerAndSupplier()
        {
            try
            {
                RefreshDatabase(_dbPath);
                personLogic = new PersonLogic(_repository);
                return personLogic.GetAllCustomerAndSupplier();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Package

        public bool AddPackage(Package package)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageLogic = new PackageLogic(_repository);
                package = packageLogic.Add(package);
                return (package.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddPackages(List<Package> packages)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageLogic = new PackageLogic(_repository);
                int changeCount = packageLogic.Add(packages);
                bool suceeded = (changeCount > 0 ? true : false);
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Package> GetAllPackages()
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageLogic = new PackageLogic(_repository);
                return packageLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Package> GetPackagesForStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageLogic = new PackageLogic(_repository);
                return packageLogic.GetPackageForStock(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemovePackage(Package package)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageLogic = new PackageLogic(_repository);
                return packageLogic.Remove(package);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyPackage(Package package)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageLogic = new PackageLogic(_repository);
                return packageLogic.Modify(package);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Package Relationship Region

        public bool AddPackageQuantity(PackageRelationship packageQuantity)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageQuantityLogic = new PackageRelationshipLogic(_repository);
                packageQuantity = packageQuantityLogic.Add(packageQuantity);
                return (packageQuantity.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddPackageQuantities(List<PackageRelationship> packageQuantities)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageQuantityLogic = new PackageRelationshipLogic(_repository);
                int changeCount = packageQuantityLogic.Add(packageQuantities);
                return (changeCount > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StorePackage> GetAllStorePackage()
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageQuantityLogic = new PackageRelationshipLogic(_repository);
                return packageQuantityLogic.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PackageRelationship> GetByStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageQuantityLogic = new PackageRelationshipLogic(_repository);
                return packageQuantityLogic.GetBy(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PackageRelationship> GetAllPackageQuantities()
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageQuantityLogic = new PackageRelationshipLogic(_repository);
                return packageQuantityLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPackage> GetStockPackagesBy(Stock stock, StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                RefreshDatabase(_dbPath);
                packageQuantityLogic = new PackageRelationshipLogic(_repository);
                return packageQuantityLogic.GetBy(stock, stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Package Relationship

        public bool AddStockPackageRelationship(StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageRelationshipLogic = new StockPackageRelationshipLogic(_repository);
                StockPackageRelationship newStockPackageRelationship = stockPackageRelationshipLogic.Add(stockPackageRelationship);

                return (newStockPackageRelationship != null && newStockPackageRelationship.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyStockPackageRelationship(StockPackageRelationship stockPackageRelationship)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageRelationshipLogic = new StockPackageRelationshipLogic(_repository);
                return stockPackageRelationshipLogic.Modify(stockPackageRelationship);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteStockPackageRelationshipBy(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageRelationshipLogic = new StockPackageRelationshipLogic(_repository);
                return stockPackageRelationshipLogic.Delete(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool NoPackageRelationshipExist(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPackageRelationshipLogic = new StockPackageRelationshipLogic(_repository);
                return stockPackageRelationshipLogic.NoPackageRelationshipExist(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Return Action Region

        public bool AddStockReturnAction(StockReturnAction stockReturnAction)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnActionLogic = new StockReturnActionLogic(_repository);
                StockReturnAction newStockReturnAction = stockReturnActionLogic.Add(stockReturnAction);
                return (newStockReturnAction.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReturnAction> GetAllStockReturnActions()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnActionLogic = new StockReturnActionLogic(_repository);
                return stockReturnActionLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveStockReturnAction(StockReturnAction stockReturnAction)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnActionLogic = new StockReturnActionLogic(_repository);
                return stockReturnActionLogic.Remove(stockReturnAction);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyStockReturnAction(StockReturnAction stockReturnAction)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReturnActionLogic = new StockReturnActionLogic(_repository);
                return stockReturnActionLogic.Modify(stockReturnAction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Price Region

        public bool AddStockPrice(StockPrice stockPrice)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                stockPrice = stockPriceLogic.Add(stockPrice);
                return (stockPrice.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddStockPrices(List<StockPrice> stockPrices)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                int changeCount = stockPriceLogic.Add(stockPrices);
                return (changeCount > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPrice> GetAllStockPrice()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStockPrice> GetAllStoreStockPrice()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStockPrice> GetAllStoreStockPriceHistory()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.GetHistory();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreStockPrice> GetAllStoreStockPriceHistoryByStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.GetHistory(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StockPrice GetStockPriceByStockPackage(StockPackage stockPackage)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.Get(stockPackage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyStockPrices(List<StockPrice> stockPrices)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.Modify(stockPrices);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StockPrice> GetStockPriceByStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.GetBy(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteStockPriceByStock(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.Delete(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool NoStockPriceExistFor(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.NoStockPriceExistFor(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreProfitableStock> GetProfitableStockBy(bool isTop5)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPriceLogic = new StockPriceLogic(_repository);
                return stockPriceLogic.GetProfitableStockBy(isTop5);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region SupplierPaymentHistory Region

        public List<StockPurchasePayment> GetSupplierPaymentHistory(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockPurchasePaymentLogic = new StockPurchasePaymentLogic(_repository);
                return stockPurchasePaymentLogic.GetSupplierPaymentHistory(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock On Shelf

        public int ArrangeStockOnShelf(Shelf shelf)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.ArrangeOnShelf(shelf);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Shelf> GetAllUntouched()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetAllUntouched();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveStockOnShelf(Shelf shelf)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.Remove(shelf);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StockForSale GetStockForSale(StockPackage stockPackage, int stockPackageRelationshipId)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetStockForSale(stockPackage, stockPackageRelationshipId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockAtHand> GetStocksAtHand(Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetStocksAtHand(stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockOnShelfAtHand> GetStockOnShelfAtHand()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetUnsoldStocks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreStock> GetRemainingStockOnShelf()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetRemainingStockOnShelf();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Shelf> GetLatestHundredStocksOnShelf()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetLatestHundred();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Shelf> GetStocksOnShelfByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetByEnteredDateRange(fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ExpiryDateAlert> GetAboutToExpiredStock()
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockOnShelfLogic = new ShelfLogic(_repository);
                return stockOnShelfLogic.GetAboutToExpiredStock();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Sold Stock Batch

        public decimal GetMonthlySalesDiscount(int year, int month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.GetMonthlySalesDiscount(year, month);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public decimal GetYearlySalesDiscount(int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.GetYearlySalesDiscount(year);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<SoldStockBatch> GetAllSoldStockBatch()
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveSoldStockBatch(SoldStockBatch soldStockBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.Remove(soldStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifySoldStock(SoldStockBatch soldStockBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.Modify(soldStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStockBatch> GetSoldStockBatchByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.GetByDateRange(fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<SoldStockBatch> GetSoldStockByBatchInvoiceNumber(string invoiceNo)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.GetBy(invoiceNo);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //public List<SoldStockBatch> GetSoldStockByBatchReceiptNumber(long receiptNumber)
        //{
        //    try
        //    {
        //        RefreshDatabase(_dbPath);
        //        soldStockBatchLogic = new SoldStockBatchLogic(_repository);
        //        return soldStockBatchLogic.GetBy(receiptNumber);
        //    }
        //    catch (Exception)
        //    {
        //        throw; 
        //    }
        //}

        #endregion

        #region Sold Stock

        public List<SoldStock> GetOutgoingStockByBatch(SoldStockBatch outgoingStockBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetByBatch(outgoingStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStock> GetSoldStockByInvoiceNo(string invoiceNo)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetBy(invoiceNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SoldStockBatch SellStock(SoldStockBatch outgoingStockBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.SellStock(outgoingStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SoldStockView> GetSoldStockByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetSoldStockByDateRange(startDate, endDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<SoldStockView> GetSoldStockDetailsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetSoldStockDetailByDateRange(startDate, endDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<SoldStockView> GetSoldStockDetailsByDateRangeAndStock(DateTime startDate, DateTime endDate, Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetSoldStockDetailByDateRangeAndStock(startDate, endDate, stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SalesInvoice> GetSalesInvoiceBySoldStockBatch(SoldStockBatch soldStockBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                soldStockBatchLogic = new SoldStockBatchLogic(_repository);
                return soldStockBatchLogic.GetSalesInvoiceBy(soldStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreSalesFrequency> GetStockSalesFrequencyBy(bool isTop5, int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetSalesFrequencyBy(isTop5, year);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreSalesFrequency> GetTopProfitableStockBy(bool isTop5, int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetTopProfitableStockBy(isTop5, year);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreSalesFrequency> GetMonthlyStockSalesFrequencyBy(bool isTop5, int year, int month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetSalesFrequencyBy(isTop5, year, month);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreSalesFrequency> GetMonthlyTopProfitableStockBy(bool isTop5, int year, int month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetTopProfitableStockBy(isTop5, year, month);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreSalesFrequency> GetStockSalesFrequencyByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetSalesFrequencyBy(isTop5, fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreSalesFrequency> GetTopProfitableStockByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetTopProfitableStockBy(isTop5, fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreCustomerStatistics> GetYearlyTopCustomerTransactionFrequency(bool isTop5, int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetTopCustomerTransactionFrequencyBy(isTop5, year);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreCustomerStatistics> GetTopYearlyCustomerTransactionVolumeBy(bool isTop5, int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetTopCustomerTransactionVolumeBy(isTop5, year);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreCustomerStatistics> GetYearlyCustomerTransactionProfitBy(bool isTop5, int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetCustomerTransactionProfitBy(isTop5, year);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreCustomerStatistics> GetCustomerTransactionFrequencyByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetCustomerTransactionFrequencyByDateRange(isTop5, fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreCustomerStatistics> GetCustomerTransactionVolumeByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetCustomerTransactionVolumeByDateRange(isTop5, fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreCustomerStatistics> GetCustomerTransactionProfitByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                outgoingStockLogic = new SoldStockLogic(_repository);
                return outgoingStockLogic.GetCustomerTransactionProfitByDateRange(isTop5, fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Role Region

        public List<Role> GetRoles(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                roleLogic = new RoleLogic(_repository);
                return roleLogic.GetAll(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Role> GetAllRoles()
        {
            try
            {
                RefreshDatabase(_dbPath);
                roleLogic = new RoleLogic(_repository);
                return roleLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddRole(Role role)
        {
            try
            {
                RefreshDatabase(_dbPath);
                roleLogic = new RoleLogic(_repository);
                Role newRole = roleLogic.Add(role);
                return newRole != null ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AssignRightToRole(Role role)
        {
            try
            {
                RefreshDatabase(_dbPath);
                roleLogic = new RoleLogic(_repository);
                return roleLogic.AssignRightToRole(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyRole(Role role)
        {
            try
            {
                RefreshDatabase(_dbPath);
                roleLogic = new RoleLogic(_repository);
                return roleLogic.Modify(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveRole(Role role)
        {
            try
            {
                RefreshDatabase(_dbPath);
                roleLogic = new RoleLogic(_repository);
                return roleLogic.Remove(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Right Region

        public List<Right> GetAllRights()
        {
            try
            {
                RefreshDatabase(_dbPath);
                rightLogic = new RightLogic(_repository);
                return rightLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddRight(Right right)
        {
            try
            {
                RefreshDatabase(_dbPath);
                rightLogic = new RightLogic(_repository);
                Right newRight = rightLogic.Add(right);
                return newRight != null ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyRight(Right right)
        {
            try
            {
                RefreshDatabase(_dbPath);
                rightLogic = new RightLogic(_repository);
                return rightLogic.Modify(right);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveRight(Right right)
        {
            try
            {
                RefreshDatabase(_dbPath);
                rightLogic = new RightLogic(_repository);
                return rightLogic.Remove(right);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Deleted Stock On Shelf

        public bool AddDeletedStockOnShelf(List<DeletedShelfStock> deletedStockOnShelfs)
        {
            try
            {
                RefreshDatabase(_dbPath);
                deletedStockOnShelfLogic = new DeletedShelfStockLogic(_repository);
                int noOfrowsAffected = deletedStockOnShelfLogic.Add(deletedStockOnShelfs);
                return noOfrowsAffected > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Payment

        public List<PaymentHistory> GetPaymentHistory()
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetHistory();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaymentHistory> GetPaymentHistoryByPerson(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetHistoryBy(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<PaymentHistory> GetPaymentHistoryByPersonType(PersonType personType)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetHistoryBy(personType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaymentStatus> GetDailyPaymentTransactions(DateTime date)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetDailyTransaction(date);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Payment> GetPaymentTransactions(Person person)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetAllTransaction(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaymentStatus> GetTradeStatus(Trade trade)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetTradeStatus(trade);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaymentStatus> GetDeptors(Trader trader)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetDeptors(trader);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaymentStatus> GetCreditors(Trader trader)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.GetCreditors(trader);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyPayment(Payment payment)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentLogic = new PaymentLogic(_repository);
                return paymentLogic.Modify(payment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Payment Detail

        public List<PaymentDetail> GetPaymentDetails(Payment payment)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentDetailLogic = new PaymentDetailLogic(_repository);
                return paymentDetailLogic.GetByPaymentId(payment.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyPaymentDetail(List<PaymentDetail> paymentDetails)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentDetailLogic = new PaymentDetailLogic(_repository);
                return paymentDetailLogic.Modify(paymentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdatePaymentDetail(List<PaymentDetail> paymentDetails)
        {
            try
            {
                RefreshDatabase(_dbPath);
                paymentDetailLogic = new PaymentDetailLogic(_repository);
                return paymentDetailLogic.Update(paymentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Company Region

        public bool AddCompany(Company company)
        {
            try
            {
                RefreshDatabase(_dbPath);
                companyLogic = new CompanyLogic(_repository);
                Company newCompany = companyLogic.Add(company);
                return (newCompany.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Company> GetAllCompany()
        {
            try
            {
                RefreshDatabase(_dbPath);
                companyLogic = new CompanyLogic(_repository);
                return companyLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveCompany(Company company)
        {
            try
            {
                RefreshDatabase(_dbPath);
                companyLogic = new CompanyLogic(_repository);
                return companyLogic.Remove(company);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyCompany(Company company)
        {
            try
            {
                RefreshDatabase(_dbPath);
                companyLogic = new CompanyLogic(_repository);
                return companyLogic.Modify(company);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Person Company Region

        public bool AddPersonCompany(PersonCompany personCompany)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personCompanyLogic = new PersonCompanyLogic(_repository);
                PersonCompany newPersonCompany = personCompanyLogic.Add(personCompany);
                return (newPersonCompany != null ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PersonCompany> GetAllPersonCompany()
        {
            try
            {
                RefreshDatabase(_dbPath);
                personCompanyLogic = new PersonCompanyLogic(_repository);
                return personCompanyLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemovePersonCompany(PersonCompany personCompany)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personCompanyLogic = new PersonCompanyLogic(_repository);
                return personCompanyLogic.Remove(personCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyPersonCompany(PersonCompany personCompany)
        {
            try
            {
                RefreshDatabase(_dbPath);
                personCompanyLogic = new PersonCompanyLogic(_repository);
                return personCompanyLogic.Modify(personCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Login Detail Region

        public List<LoginDetail> GetAllLoginDetails()
        {
            try
            {
                RefreshDatabase(_dbPath);
                loginDetailLogic = new LoginDetailLogic(_repository);
                return loginDetailLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetLoginDetailPassword(LoginDetail loginDetail)
        {
            try
            {
                RefreshDatabase(_dbPath);
                loginDetailLogic = new LoginDetailLogic(_repository);
                return loginDetailLogic.ResetPassword(loginDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyLoginDetail(LoginDetail loginDetail)
        {
            try
            {
                RefreshDatabase(_dbPath);
                loginDetailLogic = new LoginDetailLogic(_repository);
                return loginDetailLogic.Modify(loginDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LoginDetail ChangePassword(Person person, string password)
        {
            try
            {
                RefreshDatabase(_dbPath);
                loginDetailLogic = new LoginDetailLogic(_repository);
                return loginDetailLogic.ChangePassword(person, password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Expenses Region

        public decimal GetSupplierExpensesBy(DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.GetSupplierExpensesBy(fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public decimal GetTotalYearlyExpenses(int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.GetYearlyTotal(year);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public decimal GetTotalMonthlyExpenses(int year, int month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.GetMonthlyTotal(year, month);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreExpenses> GetDailyExpensesByDate(DateTime expensesDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.GetBy(expensesDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Expenses GetExpensisByDate(DateTime expensisDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.Get(expensisDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddExpensis(Expenses expenses)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                Expenses newExpensis = expensisLogic.Add(expenses);
                return (newExpensis.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreExpenses> GetMonthlyExpenses(int year, int month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.GetMonthly(year, month);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreExpenses> GetYearlyExpenses(int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.GetYearly(year);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreExpenses> GetExpensesByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                expensisLogic = new ExpensesLogic(_repository);
                return expensisLogic.GetByDateRange(fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Expenses category

        public bool AddExpensesCategory(ExpensesCategory expensesCategory)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _expensesCategoryLogic = new ExpensesCategoryLogic(_repository);
                ExpensesCategory newExpensesCategory = _expensesCategoryLogic.Add(expensesCategory);
                return (newExpensesCategory.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ExpensesCategory> GetAllExpensesCategories()
        {
            try
            {
                RefreshDatabase(_dbPath);
                _expensesCategoryLogic = new ExpensesCategoryLogic(_repository);
                return _expensesCategoryLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveExpensesCategory(ExpensesCategory expensesCategory)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _expensesCategoryLogic = new ExpensesCategoryLogic(_repository);
                return _expensesCategoryLogic.Remove(expensesCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyExpensesCategory(ExpensesCategory expensesCategory)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _expensesCategoryLogic = new ExpensesCategoryLogic(_repository);
                return _expensesCategoryLogic.Modify(expensesCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Return

        public bool ReturnSoldStock(ReturnedStock soldStockToReturn)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _returnedStockLogic = new ReturnedStockLogic(_repository);
                ReturnedStock returnedStock = _returnedStockLogic.Add(soldStockToReturn);
                return returnedStock != null && returnedStock.Id > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreReturnStock> GetYearlyReturnedStockStatisticsBy(bool isTop5, int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _returnedStockLogic = new ReturnedStockLogic(_repository);
                return _returnedStockLogic.GetReturnedStockBy(isTop5, year);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StoreReturnStock> GetMonthlyReturnedStockStatisticsBy(bool isTop5, int year, int month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _returnedStockLogic = new ReturnedStockLogic(_repository);
                return _returnedStockLogic.GetReturnedStockBy(isTop5, year, month);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreReturnStock> GetReturnedStockStatisticsByDateRange(bool isTop5, DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _returnedStockLogic = new ReturnedStockLogic(_repository);
                return _returnedStockLogic.GetReturnedStockBy(isTop5, fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreReturnStock> GetReturnedStockByYear(int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _returnedStockLogic = new ReturnedStockLogic(_repository);
                return _returnedStockLogic.GetReturnedStockBy(year);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<StoreReturnStock> GetReturnedStockByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _returnedStockLogic = new ReturnedStockLogic(_repository);
                return _returnedStockLogic.GetReturnedStockBy(fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Returned Stock Replacement

        public List<ReplacedStockAction> GetAllReplacedStockAction()
        {
            try
            {
                RefreshDatabase(_dbPath);
                replacedStockActionLogic = new ReplacedStockActionLogic(_repository);
                return replacedStockActionLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReturnedStockReplacement> GetAllUntreatedStockReplacement()
        {
            try
            {
                RefreshDatabase(_dbPath);
                returnedStockReplacementLogic = new ReturnedStockReplacementLogic(_repository);
                return returnedStockReplacementLogic.GetAllUntreated();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool TreatReplacedStock(List<ReturnedStockReplacement> replacedStocks)
        {
            try
            {
                RefreshDatabase(_dbPath);
                returnedStockReplacementLogic = new ReturnedStockReplacementLogic(_repository);
                return returnedStockReplacementLogic.Treat(replacedStocks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Review

        public bool AddStockReview(StockReview stockReview)
        {
            try
            {
                RefreshDatabase(_dbPath);
                StockReviewLogic stockReviewLogic2 = new StockReviewLogic(_repository);
                StockReview newStockReview = stockReviewLogic2.Add(stockReview);
                return (newStockReview != null && newStockReview.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Year> GetTotalYears()
        {
            try
            {
                RefreshDatabase(_dbPath);
                StockReviewLogic stockReviewLogic = new StockReviewLogic(_repository);
                return stockReviewLogic.GetTotalYears();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReviewDetail> GetYearlyStockReview(int year)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReviewDetailLogic = new StockReviewDetailLogic(_repository);
                return stockReviewDetailLogic.GetPreviousYear(year);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReviewDetail> GetYearlyStockSummaryBy(int year, Stock stock)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReviewDetailLogic = new StockReviewDetailLogic(_repository);
                return stockReviewDetailLogic.GetYearlyStockSummaryBy(year, stock);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReviewDetail> GetMonthlyStockSummaryBy(int year, int month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReviewDetailLogic = new StockReviewDetailLogic(_repository);
                return stockReviewDetailLogic.GetMonthlyStockSummaryBy(year, month);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockReviewDetail> GetMonthlyStockReview(CalendarMonth month)
        {
            try
            {
                RefreshDatabase(_dbPath);
                stockReviewDetailLogic = new StockReviewDetailLogic(_repository);
                return stockReviewDetailLogic.GetMonthStockReview(month);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Deleted Sold Stock Batch

        public DeletedSoldStockBatch AddDeletedSoldStockBatch(DeletedSoldStockBatch deletedSoldStockBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _deletedSoldStockBatchLogic = new DeletedSoldStockBatchLogic(_repository);
                return _deletedSoldStockBatchLogic.Add(deletedSoldStockBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Stock Purchased Return

        public bool AddReturnBoundPurchasedStock(List<PurchasedStockReturn> returnBoundPurchasedStocks)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _stockPurchasedReturnLogic = new PurchasedStockReturnLogic(_repository);
                int rowsAdded = _stockPurchasedReturnLogic.Add(returnBoundPurchasedStocks);
                return rowsAdded > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PurchasedStockReturn> GetReturnBoundPurchasedStockBy(StockPurchaseBatch purchaseBatch)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _stockPurchasedReturnLogic = new PurchasedStockReturnLogic(_repository);
                return _stockPurchasedReturnLogic.GetBy(purchaseBatch);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyReturnBoundPurchasedStocks(List<PurchasedStockReturn> returnBoundPurchasedStocks)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _stockPurchasedReturnLogic = new PurchasedStockReturnLogic(_repository);
                return _stockPurchasedReturnLogic.Modify(returnBoundPurchasedStocks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Store

        public Store GetStore()
        {
            try
            {
                RefreshDatabase(_dbPath);
                _storeLogic = new StoreLogic(_repository);
                return _storeLogic.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddStore(Store store)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _storeLogic = new StoreLogic(_repository);
                Store newStore = _storeLogic.Add(store);
                return newStore != null ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UploadStoreLogo(Store store, string destinationFolder, string sourceFilePath, IFileManager fileManager)
        {
            try
            {
                if (fileManager == null)
                {
                    throw new ArgumentNullException("fileManager");
                }

                RefreshDatabase(_dbPath);
                _storeLogic = new StoreLogic(_repository);
                return _storeLogic.Add(store, destinationFolder, sourceFilePath, fileManager);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteStoreLogo(Store store, string destinationFolder, IFileManager fileManager)
        {
            try
            {
                if (fileManager == null)
                {
                    throw new ArgumentNullException("fileManager");
                }

                RefreshDatabase(_dbPath);
                _storeLogic = new StoreLogic(_repository);
                return _storeLogic.DeleteLogo(store, destinationFolder, fileManager);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Settings Region

        public Setting GetSetting()
        {
            try
            {
                RefreshDatabase(_dbPath);
                _settingLogic = new SettingLogic(_repository);
                return _settingLogic.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddSetting(Setting setting)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _settingLogic = new SettingLogic(_repository);
                Setting newSetting = _settingLogic.Add(setting);
                return newSetting != null ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Appication Mode Region

        public List<ApplicationMode> GetAllApplicationModes()
        {
            try
            {
                RefreshDatabase(_dbPath);
                _applicationModeLogic = new ApplicationModeLogic(_repository);
                return _applicationModeLogic.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddApplicationMode(ApplicationMode applicationMode)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _applicationModeLogic = new ApplicationModeLogic(_repository);
                ApplicationMode newApplicationMode = _applicationModeLogic.Add(applicationMode);
                return (newApplicationMode.Id > 0 ? true : false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool RemoveApplicationMode(ApplicationMode applicationMode)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _applicationModeLogic = new ApplicationModeLogic(_repository);
                return _applicationModeLogic.Remove(applicationMode);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ModifyApplicationMode(ApplicationMode applicationMode)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _applicationModeLogic = new ApplicationModeLogic(_repository);
                return _applicationModeLogic.Modify(applicationMode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Esnecil Region

        public Esnecil GetEsnecil()
        {
            try
            {
                RefreshDatabase(_dbPath);
                _currentEsnecilLogic = new CurrentEsnecilLogic(_repository);
                return _currentEsnecilLogic.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveEsnecil(Esnecil esnecil)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _esnecilLogic = new EsnecilLogic(_repository);
                Esnecil newEsnecil = _esnecilLogic.Add(esnecil);
                return newEsnecil != null && newEsnecil.Id > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModifyEsnecil(Esnecil esnecil)
        {
            try
            {
                RefreshDatabase(_dbPath);
                _esnecilLogic = new EsnecilLogic(_repository);
                return _esnecilLogic.Modify(esnecil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        public void RefreshDatabase(string dbPath)
        {
            try
            {
                _repository = new Repository(dbPath);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
