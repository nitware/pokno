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

using Pokno.Store.ViewModels;

namespace Pokno.Store.Views
{
    public partial class StockSetupView : UserControl
    {
        private StockSetupViewModel _viewModel;

        public StockSetupView(StockSetupViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;

                int count = tcStockSetupTab.Items.Count;
                if (count > 0)
                {
                    TabItem stockCategoryTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(0);
                    stockCategoryTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupStockCategory;

                    TabItem stockTypeTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(1);
                    stockTypeTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupStockType;

                    TabItem stockTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(2);
                    stockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupStock;

                    TabItem packagingTypeTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(3);
                    packagingTypeTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupPackageType;

                    TabItem stockPackageTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(4);
                    stockPackageTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupStockPackage;

                    TabItem packagingRelationshipTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(5);
                    packagingRelationshipTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupPackageTypeQuantity;

                    TabItem stockPriceTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(6);
                    stockPriceTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupStockPrice;

                    TabItem expensesCategoryTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(7);
                    expensesCategoryTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupExpensesCategory;

                    TabItem stockStateTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(8);
                    stockStateTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupStockState;

                    TabItem stockReturnActionTab = (TabItem)tcStockSetupTab.ItemContainerGenerator.ContainerFromIndex(9);
                    stockReturnActionTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupStockReturnAction;

                    if (stockCategoryTab.IsEnabled)
                    {
                        stockCategoryTab.IsSelected = true;
                    }
                    else if (stockTypeTab.IsEnabled)
                    {
                        stockTypeTab.IsSelected = true;
                    }
                    else if (stockTab.IsEnabled)
                    {
                        stockTab.IsSelected = true;
                    }
                    else if (packagingTypeTab.IsEnabled)
                    {
                        packagingTypeTab.IsSelected = true;
                    }
                    else if (stockPackageTab.IsEnabled)
                    {
                        stockPackageTab.IsSelected = true;
                    }
                    else if (packagingRelationshipTab.IsEnabled)
                    {
                        packagingRelationshipTab.IsSelected = true;
                    }
                    else if (stockPriceTab.IsEnabled)
                    {
                        stockPriceTab.IsSelected = true;
                    }
                    else if (expensesCategoryTab.IsEnabled)
                    {
                        expensesCategoryTab.IsSelected = true;
                    }
                    else if (stockStateTab.IsEnabled)
                    {
                        stockStateTab.IsSelected = true;
                    }
                    else if (stockReturnActionTab.IsEnabled)
                    {
                        stockReturnActionTab.IsSelected = true;
                    }

                }
            };
        }

        //private void tcStockSetupTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.Source is TabControl)
        //    {
        //        _viewModel.OnTabItemSelectedCommand();
        //    }
        //}

       



    }
}
