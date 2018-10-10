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

using Pokno.People.ViewModel;

namespace Pokno.People.Views
{

    public partial class PersonBasicSetupView : UserControl
    {
        private PersonBasicSetupViewModel _viewModel;

        public PersonBasicSetupView(PersonBasicSetupViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;

                if (tcPersonBasicSetupTab.Items.Count > 0)
                {
                    TabItem locationTab = tcPersonBasicSetupTab.ItemContainerGenerator.ContainerFromIndex(0) as TabItem;
                    locationTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupLocation;

                    TabItem personTypeTab = tcPersonBasicSetupTab.ItemContainerGenerator.ContainerFromIndex(1) as TabItem;
                    personTypeTab.IsEnabled = viewModel.LoggedInUser.Role.PersonRight.CanSetupPersonType;

                    if (locationTab.IsEnabled)
                    {
                        locationTab.IsSelected = true;
                    }
                    else if (personTypeTab.IsEnabled)
                    {
                        personTypeTab.IsSelected = true;
                    }


                }
            };
        }



    }
}
