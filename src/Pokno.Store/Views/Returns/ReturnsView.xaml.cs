using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Pokno.Store.ViewModels;

namespace Pokno.Store.Views
{
    /// <summary>
    /// Interaction logic for ReturnsView.xaml
    /// </summary>
    public partial class ReturnsView : UserControl
    {
        public ReturnsView(ReturnsViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                int count = tcReturnsTab.Items.Count;
                if (count > 0)
                {
                    TabItem stockReturnTab = (TabItem)tcReturnsTab.ItemContainerGenerator.ContainerFromIndex(0);
                    stockReturnTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanReturnStock;

                    TabItem manageReplacedStockTab = (TabItem)tcReturnsTab.ItemContainerGenerator.ContainerFromIndex(1);
                    manageReplacedStockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanManageReplacedStock;

                    TabItem returnPurchasedStockTab = (TabItem)tcReturnsTab.ItemContainerGenerator.ContainerFromIndex(2);
                    returnPurchasedStockTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanReturnPurchasedStock;
                    
                    if (stockReturnTab.IsEnabled)
                    {
                        stockReturnTab.IsSelected = true;
                    }
                    else if (manageReplacedStockTab.IsEnabled)
                    {
                        manageReplacedStockTab.IsSelected = true;
                    }
                    else if (returnPurchasedStockTab.IsEnabled)
                    {
                        returnPurchasedStockTab.IsSelected = true;
                    }
                   
                }

                
                


            };
        }



    }




}
