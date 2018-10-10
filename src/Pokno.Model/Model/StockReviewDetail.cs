using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Pokno.Model.Model
{
    
    public class StockReviewDetail
    {
        public long Id { get; set; }
        public long StockReviewId { get; set; }
        public long? StockPackageRelationshipId { get; set; }
        public decimal TempStockPackageUnitItem { get; set; }
        public string InitialStockBalance { get; set; }
        public decimal StockBalanceValue { get; set; }
        public decimal InitialStockBalanceValue { get; set; }
        public long StockId { get; set; }
        public string StockName { get; set; }
        public decimal? UnitCostPrice { get; set; }
        public decimal? Cost { get; set; }
        public long? TransactionMonth { get; set; }
        public long? TransactionYear { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? Discount { get; set; }
        public string MonthName { get; set; }
        public string QuantityPackagePurchased { get; set; }
        public string QuantityPackageSold { get; set; }
        public string StockPackageBalance { get; set; }
        public long QuantityPurchased { get; set; }
        public long QuantitySold { get; set; }
        public long StockBalance { get; set; }
        public decimal? Profit { get; set; }
        public long? MonthSold { get; set; }
        public long? YearSold { get; set; }
        public string RelationshipOfStockPackage { get; set; }
        public decimal? MonthlyTotalExpenses { get; set; }
        public decimal? MonthlyTransactionDiscount { get; set; }
        public decimal StockBalanceUnitItem { get; set; }

        public decimal? Profit2 { get; set; }

        //public long? StockPackageId { get; set; }
        //public long? PackageId { get; set; }
        //public string PackageName { get; set; }
        //public long? StockPurchaseBatchId { get; set; }
        //public decimal? UnitCost { get; set; }
        //public decimal? AmountPayable { get; set; }
        //public decimal? AmountPaid { get; set; }
        //public decimal? MiscExpenses { get; set; }
        //public DateTime? DatePurchased { get; set; }
        //public long? SoldStockBatchId { get; set; }
        //public decimal? TransactionDiscount { get; set; }
        //public decimal? ActualSellingPrice { get; set; }
        //public decimal? TotalAmountPaid { get; set; }
        //public string MonthYearSold { get; set; }

    }



}
