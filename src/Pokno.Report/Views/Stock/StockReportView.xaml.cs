using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Report.ViewModels.Stock;
using Pokno.Infrastructure.Models;
using Pokno.Model;

namespace Pokno.Report.Views.Stock
{
    public partial class StockReportView : UserControl
    {
        public StockReportView(StockReportViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                Person person = Utility.LoggedInUser;
                if (person.Role.PersonRight.CanViewStockListByTypeReport)
                {
                    rbStockListByTypeReport.IsChecked = true;
                    viewModel.OnStockListByTypeReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockListReport)
                {
                    rbStockListReport.IsChecked = true;
                    viewModel.OnStockListReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockPackageReport)
                {
                    rbStockPackagesReport.IsChecked = true;
                    viewModel.OnStockPackagesReportCommand();
                }
                else if (person.Role.PersonRight.CanViewPackageRelationshipReport)
                {
                    rbPackageQuantityReport.IsChecked = true;
                    viewModel.OnPackageQuantityReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockPriceReport)
                {
                    rbStockPriceReport.IsChecked = true;
                    viewModel.OnStockPriceReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockPriceHistoryReport)
                {
                    rbStockPriceHistoryReport.IsChecked = true;
                    viewModel.OnStockPriceHistoryReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockPriceHistoryByStockReport)
                {
                    rbStockPriceHistoryByStockReport.IsChecked = true;
                    viewModel.OnStockPriceHistoryByStockReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockAvailableOnShelfReport)
                {
                    rbStockOnShelfReport.IsChecked = true;
                    viewModel.OnStockOnShelfReportCommand();
                }
                else if (person.Role.PersonRight.CanViewStockInStoreReport)
                {
                    rbStocksInStoreReport.IsChecked = true;
                    viewModel.OnStocksInStoreReportCommand();
                }

            };

            

        }
    }



}
