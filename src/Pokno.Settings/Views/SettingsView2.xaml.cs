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

using Pokno.Settings.ViewModels;
using Pokno.Service;

namespace Pokno.Settings.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView2 : Window
    {
        private SettingsViewModel2 _viewModel;

        public SettingsView2()
        {
            
        }
    }

    public partial class SettingsView2
    {
        public SettingsView2(IBusinessFacade service, Prism.Events.IEventAggregator eventAggregator)
        {
            InitializeComponent();

            _viewModel = (SettingsViewModel2)DataContext;
            _viewModel.EventAggregator = eventAggregator;
            _viewModel.BusinessFacade = service;

            if (tcSettingsTab.Items.Count > 0)
            {
                TabItem applicationModeTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(0) as TabItem;
                applicationModeTab.IsEnabled = _viewModel.LoggedInUser.Role.PersonRight.CanSetupUser;
                //applicationModeTab. = "App Mode";

                TabItem basicSettingsTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(1) as TabItem;
                basicSettingsTab.IsEnabled = _viewModel.LoggedInUser.Role.PersonRight.CanSetupLoginDetail;
                basicSettingsTab.Header = "basicSettingsTab";

                TabItem storeDetailTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(2) as TabItem;
                storeDetailTab.IsEnabled = _viewModel.LoggedInUser.Role.PersonRight.CanSetupRole;
                storeDetailTab.Header = "storeDetailTab";

                TabItem customerLoyaltyTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(3) as TabItem;
                customerLoyaltyTab.IsEnabled = _viewModel.LoggedInUser.Role.PersonRight.CanAssignRightToRole;
                customerLoyaltyTab.Header = "customerLoyaltyTab";

                TabItem dbManagementTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(4) as TabItem;
                dbManagementTab.IsEnabled = _viewModel.LoggedInUser.Role.PersonRight.CanSetupRight;
                dbManagementTab.Header = "dbManagementTab";
               
               
            }


            //_viewModel.OnTabItemSelectedCommand(2);
        }
    }





}
