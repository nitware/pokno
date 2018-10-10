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
    public partial class ArrangeStockOnShelfView : UserControl
    {
        public ArrangeStockOnShelfView(ArrangeStockOnShelfViewModel viewModel)
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;
            };

            //treeView.ExpandAll();
            
           
        }

        private void treeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TreeViewOperation.ClearTreeViewSelection(treeView);
        }

      
    }
}
