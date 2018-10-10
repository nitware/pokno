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

using Prism.Regions;
using Pokno.Settings.ViewModels;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure;
using Pokno.Model;

namespace Pokno.Settings.Views
{
    /// <summary>
    /// Interaction logic for SettingsRootView.xaml
    /// </summary>
    public partial class SettingsRootView : Window
    {
        private SettingsRootViewModel _viewModel;

        public SettingsRootView()
        {
            //InitializeComponent();
        }
    }

    public partial class SettingsRootView
    {
        public SettingsRootView(IRegionManager regionManager, IUnityContainer container)
        {
            InitializeComponent();

            if (regionManager != null )
            {
                regionManager.Regions.Remove(RegionContainer.SettingsRegion);
            }

            RegionManager.SetRegionName(ccSettingsRegion, RegionContainer.SettingsRegion);
            RegionManager.SetRegionManager(ccSettingsRegion, regionManager);
            RegionManager.SetRegionManager(this, regionManager);
            RegionManager.UpdateRegions();

            _viewModel = (SettingsRootViewModel)DataContext;
            _viewModel.RegionManager = regionManager;
            _viewModel.Container = container;
                                    
            Person person = Utility.LoggedInUser;
            if (person.Role.PersonRight.CanSetBasicSetting)
            {
                rbBasicSettings.IsChecked = true;
                _viewModel.OnBasicSettingsCommand();
            }
            else if (person.Role.PersonRight.CanSetDB)
            {
                rbSetDb.IsChecked = true;
                _viewModel.OnSetDbCommand();
            }
            else if (person.Role.PersonRight.CanSetupShopDetail)
            {
                rbSetupShopDetail.IsChecked = true;
                _viewModel.OnShopDetailCommand();
            }
            else if (person.Role.PersonRight.CanUploadStoreLogo)
            {
                rbUploadStoreLogo.IsChecked = true;
                _viewModel.OnStoreLogoCommand();
            }
            else if (person.Role.PersonRight.CanSetupCustomerLoyaltyProgram)
            {
                rbSetupCustomerLoyalty.IsChecked = true;
                _viewModel.OnCustomerLoyaltyCommand();
            }
            else if (person.Role.PersonRight.CanMaintainDb)
            {
                rbMaintainDb.IsChecked = true;
                _viewModel.OnDbMaintenanceCommand();
            }

               
        }
    }





}
