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

using Pokno.People.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Model.Model;

namespace Pokno.People.Views
{
    public partial class PersonHomeView : UserControl
    {
        public PersonHomeView(PersonHomeViewModel viewModel)
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                DataContext = viewModel;

                Setting setting = Utility.Setting;
                if (setting != null && setting.Id > 0)
                {
                    viewModel.SetApplicationModeImages(setting.ApplicationMode);
                }
            };
        }
    }
}
