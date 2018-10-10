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
using Pokno.Infrastructure.Models;

namespace Pokno.Store.Views
{
    public partial class SellStockView : UserControl
    {
        public SellStockView(SellStockViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        
        private void treeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (treeView != null)
            //{
            //    ClearTreeViewItemsControlSelection(treeView.Items, treeView.ItemContainerGenerator);
            //}
            

            TreeViewOperation.ClearTreeViewSelection(treeView);
            //treeView.Focus();
        }
               
        //private static void ClearTreeViewItemsControlSelection(ItemCollection ic, ItemContainerGenerator icg)
        //{
        //    if ((ic != null) && (icg != null))
        //    {
        //        for (int i = 0; i < ic.Count; i++)
        //        {
        //            TreeViewItem tvi = icg.ContainerFromIndex(i) as TreeViewItem;
        //            if (tvi != null)
        //            {
        //                if (tvi.IsSelected)
        //                {
        //                    tvi.ExpandSubtree();
        //                }
        //            }
        //        }
        //    }
        //}

        
      


    }

}
