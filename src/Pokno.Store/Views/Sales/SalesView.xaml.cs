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
    public partial class SalesView : UserControl
    {
        public SalesView(SalesViewModel viewModel)
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;

                int count = tcManagePOSTab.Items.Count;
                if (count > 0)
                {
                    TabItem sellStockTab = (TabItem)tcManagePOSTab.ItemContainerGenerator.ContainerFromIndex(0);
                    sellStockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSellStock;

                    TabItem editSoldStockTab = (TabItem)tcManagePOSTab.ItemContainerGenerator.ContainerFromIndex(1);
                    editSoldStockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanEditSoldStock;

                    //TabItem deleteSalesTransactionTab = (TabItem)tcManagePOSTab.ItemContainerGenerator.ContainerFromIndex(2);
                    //deleteSalesTransactionTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanDeleteSalesTransaction;

                    TabItem stockPriceTab = (TabItem)tcManagePOSTab.ItemContainerGenerator.ContainerFromIndex(2);
                    stockPriceTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanViewStockPriceList;

                    TabItem dailySalesTab = (TabItem)tcManagePOSTab.ItemContainerGenerator.ContainerFromIndex(3);
                    dailySalesTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanViewDailySales;

                    if (sellStockTab.IsEnabled)
                    {
                        sellStockTab.IsSelected = true;
                    }
                    else if (editSoldStockTab.IsEnabled)
                    {
                        editSoldStockTab.IsSelected = true;
                    }
                    //else if (deleteSalesTransactionTab.IsEnabled)
                    //{
                    //    deleteSalesTransactionTab.IsSelected = true;
                    //}
                    else if (stockPriceTab.IsEnabled)
                    {
                        stockPriceTab.IsSelected = true;
                    }
                    else if (dailySalesTab.IsEnabled)
                    {
                        dailySalesTab.IsSelected = true;
                    }
                    

                }
            };
        }



    }

}
