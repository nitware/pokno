using Pokno.People.ViewModel;
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

namespace Pokno.People.Views
{
    public partial class AccessControlSetupView : UserControl
    {
        private AccessControlSetupViewModel _viewModel;

        public AccessControlSetupView(AccessControlSetupViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            
            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;

                if (tcUserTab.Items.Count > 0)
                {
                    TabItem userTab = tcUserTab.ItemContainerGenerator.ContainerFromIndex(0) as TabItem;
                    userTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupUser;

                    TabItem userLoginTab = tcUserTab.ItemContainerGenerator.ContainerFromIndex(1) as TabItem;
                    userLoginTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupLoginDetail;

                    TabItem roleTab = tcUserTab.ItemContainerGenerator.ContainerFromIndex(2) as TabItem;
                    roleTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupRole;

                    TabItem rightTab = tcUserTab.ItemContainerGenerator.ContainerFromIndex(3) as TabItem;
                    rightTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupRight;

                    TabItem assignRightToRoleTab = tcUserTab.ItemContainerGenerator.ContainerFromIndex(4) as TabItem;
                    assignRightToRoleTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanAssignRightToRole;

                    TabItem assignRoleToUserTab = tcUserTab.ItemContainerGenerator.ContainerFromIndex(5) as TabItem;
                    assignRoleToUserTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanAssignRoleToPerson;
                    

                    if (userTab.IsEnabled)
                    {
                        userTab.IsSelected = true;
                    }
                    else if (userLoginTab.IsEnabled)
                    {
                        userLoginTab.IsSelected = true;
                    }
                    else if (roleTab.IsEnabled)
                    {
                        roleTab.IsSelected = true;
                    }
                    else if (rightTab.IsEnabled)
                    {
                        rightTab.IsSelected = true;
                    }
                    else if (assignRightToRoleTab.IsEnabled)
                    {
                        assignRightToRoleTab.IsSelected = true;
                    }
                    else if (assignRoleToUserTab.IsEnabled)
                    {
                        assignRoleToUserTab.IsSelected = true;
                    }


                }
            };


        }

        //private void tcUserTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.Source is TabControl)
        //    {
        //        _viewModel.OnTabItemSelectedCommand();
        //    }
        //}


    }


}
