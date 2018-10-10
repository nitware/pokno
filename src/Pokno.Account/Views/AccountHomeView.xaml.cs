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

using Pokno.Model.Model;
using Pokno.Account.ViewModels;
using Pokno.Infrastructure.Models;

namespace Pokno.Account.Views
{
    public partial class AccountHomeView : UserControl
    {
        public AccountHomeView(AccountHomeViewModel viewModel)
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
