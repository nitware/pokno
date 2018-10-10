using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Infrastructure.ViewModel;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.Events;
using Pokno.People.Services;
using Prism.Commands;
using Prism.Events;
using Pokno.People.Interfaces;
using Pokno.Model.Model;
using Pokno.Service;
using System.Security;

namespace Pokno.People.ViewModel
{
    public class ChangePasswordPopUpViewModel : BaseViewModel 
    {
        private Window PopUp;

        private LoginDetail _loginDetail;
        private SecureString _newPassKey;
        private SecureString _confirmNewPassKey;
        private IBusinessFacade _service;

        public ChangePasswordPopUpViewModel()
        {
            OkCommand = new DelegateCommand(OnOkCommand, CanChangePassKey);
            SetPopUpCommand = new DelegateCommand<object>(OnSetPopUpCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);
        }

        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand OkCommand { get; private set; }
        public ICommand SetPopUpCommand { get; private set; }

        public IBusinessFacade BusinessFacade
        {
            set { _service = value; }
        }
      
        public SecureString NewPassKey
        {
            get { return _newPassKey; }
            set
            {
                _newPassKey = value;
                base.OnPropertyChanged("NewPassKey");
                OkCommand.RaiseCanExecuteChanged();
            }
        }
        public SecureString ConfirmNewPassKey
        {
            get { return _confirmNewPassKey; }
            set
            {
                _confirmNewPassKey = value;
                base.OnPropertyChanged("ConfirmNewPassKey");
                OkCommand.RaiseCanExecuteChanged();
            }
        }
        public LoginDetail LoginDetail
        {
            get { return _loginDetail; }
            set
            {
                _loginDetail = value;
                base.OnPropertyChanged("LoginDetail");
            }
        }
               
        private bool CanChangePassKey()
        {
            return !string.IsNullOrWhiteSpace(Utility.ConvertToUnsecureString(NewPassKey)) && !string.IsNullOrWhiteSpace(Utility.ConvertToUnsecureString(ConfirmNewPassKey));
        }

        public void OnOkCommand()
        {
            try
            {
                if (InvalidEntry())
                {
                    return;
                }

                LoginDetail loginDetail = _service.ChangePassword(Utility.LoggedInUser, Utility.ConvertToUnsecureString(NewPassKey));
                if (loginDetail != null)
                {
                    LoginDetail = loginDetail;
                }

                PopUp.DialogResult = true;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool InvalidEntry()
        {
            try
            {
                if (!Utility.IsEqual(NewPassKey, ConfirmNewPassKey))
                {
                    Utility.DisplayMessage("Mis-match detected between New Password and Confirm New Password entry!");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnCancelCommand()
        {
            PopUp.DialogResult = false;
        }

        private void OnSetPopUpCommand(object param)
        {
            PopUp = (Window)param;
        }
       



    }
}
