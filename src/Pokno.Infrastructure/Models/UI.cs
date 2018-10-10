using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Infrastructure.Models
{
    public class UI
    {
        public enum StockSetup
        {
            Category,
            Type,
            Product,
            Package,
            PackageReOrderLevel,
            PackageQuantity,
            Price,
            ExpensesCategory,
            State,
            ReturnAction
        }

        public enum Store
        {
            RegisterPurchasedStock,
            ModifyPurchasedStock,
            ArrangeStockOnShelf,
            ViewStockOnShelf,
            RemoveStockFromShelf,
            ExpiredStocks,
            YearlyStockSummary,
        }

        public enum PeopleSetup
        {
            Location,
            PersonType,
        }

        public enum PaymentSetup
        {
            PaymentType,
            Bank,
        }

        public enum PeopleCompany
        {
            Company,
            CompanyRepresentative,
        }

        public enum PeopleAccessControl
        {
            Person,
            LoginDetail,
            Role,
            Right,
            AssignRightToRole,
            AssignRoleToPerson,
        }

        public enum Sales
        {
            SellStock,
            EditSoldItems,
            DeleteSalesTransaction,
            StockPriceCheck,
            DailySales
        }

        public enum Returns
        {
            Return,
            ManageReplacedItems,
            PurchaseReturn,
        }

        public enum Settings
        {
            ApplicationMode,
            BasicSetting,
            StoreDetail,
            CustomerLoyalty,
            DatabaseManagement
        }


    }



}
