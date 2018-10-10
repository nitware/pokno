using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Common.Models;
using Pokno.Common.Interfaces;
using Pokno.Report.Models.Stock;
using Pokno.Report.Models.Purchase;
using Pokno.Report.Models.Sales;
using Pokno.Report.Models.Payment;
using Pokno.Report.Models.Miscellaneous;
using Pokno.Report.Models.Expenses;
using Pokno.Report.Models.Returns;

namespace Pokno.Infrastructure.Models
{
    public class BaseReportFactory : IBaseReportFactory
    {
        private IBusinessFacade _businessFacade;

        public BaseReportFactory(IBusinessFacade businessFacade)
        {
            _businessFacade = businessFacade;
        }

        public BaseReport Create(ReportType type)
        {
            try
            {
                switch (type)
                {
                    case ReportType.StockListByType:
                        {
                            return new StockListByTypeReport(_businessFacade);
                        }
                    case ReportType.StockList:
                        {
                            return new StockListReport(_businessFacade);
                        }
                    case ReportType.StockPackage:
                        {
                            return new StockPackageReport(_businessFacade);
                        }
                    case ReportType.PackageQuantity:
                        {
                            return new PackageRelationshipReport(_businessFacade);
                        }
                    case ReportType.StockPrice:
                        {
                            return new StockPriceReport(_businessFacade);
                        }
                    case ReportType.StockPriceHistory:
                        {
                            return new StockPriceHistoryReport(_businessFacade);
                        }
                    case ReportType.RemainingStockOnShelf:
                        {
                            return new RemainingStockOnShelfReport(_businessFacade);
                        }
                    case ReportType.StocksInStore:
                        {
                            return new StocksInStoreReport(_businessFacade);
                        }
                    case ReportType.YearlyStockSummary:
                        {
                            return new YearlyStockSummaryReport(_businessFacade);
                        }
                    case ReportType.StockPriceHistoryByStock:
                        {
                            return new StockPriceHistoryByStockReport(_businessFacade);
                        }
                    case ReportType.StockPurchaseDetail:
                        {
                            return new StockPurchaseDetailReport(_businessFacade);
                        }
                    case ReportType.StockPurchaseSummary:
                        {
                            return new StockPurchaseSummaryReport(_businessFacade);
                        }
                    case ReportType.StockPurchaseDetailByStock:
                        {
                            return new StockPurchaseDetailByStockReport(_businessFacade);
                        }
                    case ReportType.SoldStockDetailAnalysis:
                        {
                            return new SoldStockDetailAnalysisReport(_businessFacade);
                        }
                    case ReportType.SoldStockAnalysis:
                        {
                            return new SoldStockAnalysisReport(_businessFacade);
                        }
                    case ReportType.SoldStockDetailAnalysisByStock:
                        {
                            return new SoldStockDetailAnalysisByStockReport(_businessFacade);
                        }
                    case ReportType.CompanyCreditorsList:
                        {
                            return new CompanyCreditorsListReport(_businessFacade);
                        }
                    case ReportType.CompanyDebtorsList:
                        {
                            return new CompanyDebtorsListReport(_businessFacade);
                        }
                    case ReportType.SupplierCreditorsList:
                        {
                            return new SupplierCreditorsListReport(_businessFacade);
                        }
                    case ReportType.SupplierDebtorsList:
                        {
                            return new SupplierDebtorsListReport(_businessFacade);
                        }
                    case ReportType.MonthlyStockSummary:
                        {
                            return new MonthlyStockSummaryReport(_businessFacade);
                        }
                    case ReportType.YearlyStockSummaryByStock:
                        {
                            return new YearlyStockSummaryByStockReport(_businessFacade);
                        }
                    case ReportType.DailyTransaction:
                        {
                            return new DailyTransactionReport(_businessFacade);
                        }
                    case ReportType.MonthlyExpenses:
                        {
                            return new MonthlyExpensesReport(_businessFacade);
                        }
                    case ReportType.DailyExpenses:
                        {
                            return new DailyExpensesReport(_businessFacade);
                        }
                    case ReportType.YearlyExpenses:
                        {
                            return new YearlyExpensesReport(_businessFacade);
                        }
                    case ReportType.ExpensesByDateRange:
                        {
                            return new ExpensesByDateRangeReport(_businessFacade);
                        }
                    case ReportType.PaymentHistory:
                        {
                            return new PaymentHistoryReport(_businessFacade);
                        }
                    case ReportType.PaymentHistoryByPerson:
                        {
                            return new PaymentHistoryByPersonReport(_businessFacade);
                        }
                    case ReportType.YearlyStockStatistics:
                        {
                            return new YearlyStockStatisticsReport(_businessFacade);
                        }
                    case ReportType.MonthlyStockStatistics:
                        {
                            return new MonthlyStockStatisticsReport(_businessFacade);
                        }
                    case ReportType.StockStatisticsByDateRange:
                        {
                            return new StockStatisticsByDateRangeReport(_businessFacade);
                        }
                    case ReportType.YearlyCustomerTransactionStatistics:
                        {
                            return new YearlyCustomerTransactionStatisticsReport(_businessFacade);
                        }
                    case ReportType.CustomerTransactionStatisticsByDateRange:
                        {
                            return new CustomerTransactionStatisticsByDateRangeReport(_businessFacade);
                        }
                    case ReportType.StockReturnByDateRange:
                        {
                            return new StockReturnByDateRangeReport(_businessFacade);
                        }
                    case ReportType.YearlyStockReturn:
                        {
                            return new YearlyStockReturnReport(_businessFacade);
                        }
                    default:
                        {
                            throw new NotImplementedException();
                        }
                }
            }
            catch(Exception)
            {
                throw;
            }

        }




       
    }


}
