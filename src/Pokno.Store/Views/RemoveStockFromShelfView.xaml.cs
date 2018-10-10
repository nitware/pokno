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
    public partial class RemoveStockFromShelfView : UserControl
    {
        public RemoveStockFromShelfView(RemoveStockFromShelfViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            //SetSearchImage();
        }

        private void treeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TreeViewOperation.ClearTreeViewSelection(treeView);
            //treeView.Focus();
        }

        private void SetSearchImage()
        {
            

            string searchImagePath = System.Configuration.ConfigurationManager.AppSettings.Get("productLogoImagePath").ToString();
            //SetButtonImageSource(imgSearch, searchImagePath);
           
        }

        private void SetButtonImageSource(Image imgControl, string imagePath)
        {
            // Create a BitmapSource  
            System.Windows.Media.Imaging.BitmapImage bitmap = new System.Windows.Media.Imaging.BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();

            // Set Image.Source  
            imgControl.Source = bitmap;
        }






    }

}
