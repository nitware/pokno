using Pokno.Infrastructure.Models;
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
    public partial class LoginView : UserControl
    {
        private LoginViewModel _viewModel;

        public LoginView(LoginViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            this.Loaded += (s, e) =>
            {
                this.DataContext = viewModel;

                pbPassword.Clear();
                txtUserName.Text = "";
                txtUserName.Focus();
            };
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.PassKey = pbPassword.SecurePassword;
        }


       
    }


}
