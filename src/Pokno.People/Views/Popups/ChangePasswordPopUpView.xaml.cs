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
using Microsoft.Practices.Unity;
using Pokno.People.Interfaces;

namespace Pokno.People.Views.Popups
{
    public partial class ChangePasswordPopUpView : Window
    {
        private ChangePasswordPopUpViewModel _viewModel;

        public ChangePasswordPopUpView()
        {

        }

        private void pbNewPassKey_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.NewPassKey = pbNewPassKey.SecurePassword;
        }

        private void pbConfirmPassKey_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.ConfirmNewPassKey = pbConfirmPassKey.SecurePassword;
        }
    }

    public partial class ChangePasswordPopUpView
    {
        public ChangePasswordPopUpView(Pokno.Service.IBusinessFacade service)
        {
            InitializeComponent();

            _viewModel = (ChangePasswordPopUpViewModel)DataContext;
            _viewModel.BusinessFacade = service;
            

            pbNewPassKey.Focus();
        }
    }



}

