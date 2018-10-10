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
    public partial class CompanySetupView : UserControl
    {
        public CompanySetupView(CompanySetupViewModel viewModel)
        {
            InitializeComponent();
           
            this.Loaded += (s, e) =>
            {
                DataContext = viewModel;

                int count = tcCompanyTab.Items.Count;
                if (count > 0)
                {
                    TabItem companyTab = tcCompanyTab.ItemContainerGenerator.ContainerFromIndex(0) as TabItem;
                    companyTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupCompany;

                    TabItem companyRepTab = tcCompanyTab.ItemContainerGenerator.ContainerFromIndex(1) as TabItem;
                    companyRepTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupCompanyRepresentative;

                    if (companyTab.IsEnabled)
                    {
                        companyTab.IsSelected = true;
                    }
                    else if (companyRepTab.IsEnabled)
                    {
                        companyRepTab.IsSelected = true;
                    }
                }
            };
        }

        


    }
}
