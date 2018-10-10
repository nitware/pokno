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

using Pokno.Shell.ViewModel;
using Pokno.Infrastructure.Models;
using Microsoft.Practices.Unity;
using FirstFloor.ModernUI.Windows.Controls;
using System.Configuration;
using System.Diagnostics;
using System.ComponentModel;

namespace Pokno.Shell
{
    public partial class Shell : ModernWindow
    {
        public Shell()
        {
            InitializeComponent();
            DisplayMainMenuImages();

            //Pokno.Infrastructure.Animation.Animation.Init(this.Resources);
            //Pokno.Infrastructure.Animation.Animation.SwitchToPage();

            //FirstFloor.ModernUI.Presentation.AppearanceManager.Current.AccentColor = Colors.Pink;
            
            this.Closing += Shell_Closing;
        }

        private void Shell_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult response = Utility.DisplayMessage("Are you sure you want to close storepro?", MessageBoxButton.YesNo);
            if (response == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        
        private void DisplayMainMenuImages()
        {
            try
            {
                string stockImagePath = Utility.ApplicationRoot + @"\Images\Android-Store-64.png";
                string paymentImagePath = Utility.ApplicationRoot + @"\Images\credit-card-icon.png";
                string accountImagePath = Utility.ApplicationRoot + @"\Images\chart_4.png";
                string peopleImagePath = Utility.ApplicationRoot + @"\Images\user_group_icon.png";
                string reportsImagePath = Utility.ApplicationRoot + @"\Images\reports.png";
                string productLogoImagePath = Utility.ApplicationRoot + @"\Images\storepro_logo_white.jpg";

                SetButtonImageSource(imgStock, stockImagePath);
                SetButtonImageSource(imgPayment, paymentImagePath);
                SetButtonImageSource(imgAccount, accountImagePath);
                SetButtonImageSource(imgPeople, peopleImagePath);
                SetButtonImageSource(imgReport, reportsImagePath);
                SetButtonImageSource(imgProductLogo, productLogoImagePath);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SetButtonImageSource(Image imgControl, string imagePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imagePath))
                {
                    return;
                }

                // Create a BitmapSource  
                System.Windows.Media.Imaging.BitmapImage bitmap = new System.Windows.Media.Imaging.BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(imagePath);
                bitmap.EndInit();

                // Set Image.Source  
                imgControl.Source = bitmap;
            }
            catch(Exception)
            {

            }
        }

        [Dependency]
        public ShellViewModel ViewModel
        {
            set { this.DataContext = value; }
        }

        private void rbPurchase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://www.nitware.com.ng/Product.aspx");
            }
            catch(Exception)
            {

            }
        }

        private void rbHomePage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://www.nitware.com.ng");
            }
            catch(Exception)
            {

            }
        }
        private void rbSupport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://www.nitware.com.ng/Contact.aspx");
            }
            catch (Exception)
            {

            }
            
        }
        private void rbHelp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Process.Start(@"C:\Users\Dan\Documents\library\Books\CryptoLicensing.chm");
                Process.Start(Utility.ApplicationRoot + @"\Resources\storepro_userguide.pdf");
            }
            catch (Exception)
            {

            }
        }

       

        



    }
}
