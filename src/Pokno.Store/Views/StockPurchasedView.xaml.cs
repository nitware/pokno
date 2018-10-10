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
    public partial class StockPurchasedView : UserControl
    {
        private StockPurchasedViewModel _viewModel;

        public StockPurchasedView(StockPurchasedViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;

                tcStockPurchasedTab.Loaded += new RoutedEventHandler(Tab_Loaded);

                int count = tcStockPurchasedTab.Items.Count;
                if (count > 0)
                {
                    TabItem stockAboutToExpireTab = (TabItem)tcStockPurchasedTab.ItemContainerGenerator.ContainerFromIndex(0);
                    stockAboutToExpireTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanViewStockExpiryDateAlert;

                    TabItem registerPurchasedStockTab = (TabItem)tcStockPurchasedTab.ItemContainerGenerator.ContainerFromIndex(1);
                    registerPurchasedStockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanRegisterPurchasedStock;

                    TabItem modifyPurchasedBatchTab = (TabItem)tcStockPurchasedTab.ItemContainerGenerator.ContainerFromIndex(2);
                    modifyPurchasedBatchTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanModifyPurchaseBatch;

                    TabItem arrangeStockOnShelfTab = (TabItem)tcStockPurchasedTab.ItemContainerGenerator.ContainerFromIndex(3);
                    arrangeStockOnShelfTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanArrangeStockOnShelf;

                    TabItem enteredShelfStockTab = (TabItem)tcStockPurchasedTab.ItemContainerGenerator.ContainerFromIndex(4);
                    enteredShelfStockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanViewEnteredShelfStock;

                    TabItem removeShelfStockTab = (TabItem)tcStockPurchasedTab.ItemContainerGenerator.ContainerFromIndex(5);
                    removeShelfStockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanRemoveShelfStock;
                    
                    TabItem stockReviewTab = (TabItem)tcStockPurchasedTab.ItemContainerGenerator.ContainerFromIndex(6);
                    stockReviewTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanReviewStock;

                    if (stockAboutToExpireTab.IsEnabled)
                    {
                        stockAboutToExpireTab.IsSelected = true;
                    }
                    else if (registerPurchasedStockTab.IsEnabled)
                    {
                        registerPurchasedStockTab.IsSelected = true;
                    }
                    else if (modifyPurchasedBatchTab.IsEnabled)
                    {
                        modifyPurchasedBatchTab.IsSelected = true;
                    }
                    else if (arrangeStockOnShelfTab.IsEnabled)
                    {
                        arrangeStockOnShelfTab.IsSelected = true;
                    }
                    else if (enteredShelfStockTab.IsEnabled)
                    {
                        enteredShelfStockTab.IsSelected = true;
                    }
                    else if (removeShelfStockTab.IsEnabled)
                    {
                        removeShelfStockTab.IsSelected = true;
                    }
                    else if (stockReviewTab.IsEnabled)
                    {
                        stockReviewTab.IsSelected = true;
                    }
                    
                }
            };



        }

        protected void Tab_Loaded(object sender, EventArgs e)
        {
            ItemCollection tabItems = tcStockPurchasedTab.Items;
            tabItems.CurrentChanged += new EventHandler(StockPurchasedTabItems_CurrentChanged);
        }
        protected void StockPurchasedTabItems_CurrentChanged(object sender, EventArgs e)
        {
            //_viewModel.OnTabItemSelectedCommand();
        }

        private void tcStockPurchasedTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (e.Source is TabControl)

            if (ReferenceEquals(e.OriginalSource, tcStockPurchasedTab))
            {
                //_viewModel.OnTabItemSelectedCommand();
            }
        }
    }



}
