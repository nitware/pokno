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
    public partial class SettingsView : UserControl
    {
        //private SettingsViewModel _viewModel;

        public SettingsView(SettingsViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
                {
                    DataContext = viewModel;

                    if (tcSettingsTab.Items.Count > 0)
                    {
                        TabItem applicationModeTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(0) as TabItem;
                        applicationModeTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupUser;

                        TabItem basicSettingsTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(1) as TabItem;
                        basicSettingsTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupLoginDetail;

                        TabItem storeDetailTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(2) as TabItem;
                        storeDetailTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupRole;

                        TabItem customerLoyaltyTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(3) as TabItem;
                        customerLoyaltyTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanAssignRightToRole;

                        TabItem dbManagementTab = tcSettingsTab.ItemContainerGenerator.ContainerFromIndex(4) as TabItem;
                        dbManagementTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupRight;

                    }
                };
        }
    }







}
