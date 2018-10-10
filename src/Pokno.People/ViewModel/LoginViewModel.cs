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

using Microsoft.Practices.Unity;
using System.Windows.Threading;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Animation;
using Pokno.Infrastructure.Events;
using Prism.Commands;
using Prism.Regions;
using Prism.Events;
using Pokno.People.Interfaces;
using Pokno.Model;
using Pokno.Model.Model;
using Pokno.Infrastructure;
using System.Security;
using System.Runtime.InteropServices;
using Pokno.People.Views.Popups;
using Pokno.Service;
using LogicNP.CryptoLicensing;
using System.Text;
using System.ComponentModel;

namespace Pokno.People.ViewModel
{
    public class LoginViewModel : ImageViewModel
    {
        protected Window PopUp;
        private Dispatcher _dispatcher;

        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IBusinessFacade _service;

        private Person _user;
        private string _userName;
        private bool _isProcessing;

        private SecureString _passKey;
        private CryptoLicense _lic;

        public LoginViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventAggregator, IBusinessFacade service)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _service = service;

            _dispatcher = Application.Current.Dispatcher;
            LoginCommand = new DelegateCommand(OnLoginCommand, CanLogin);
            
            Initialise();
        }
                
        public LoginDetail LoginDetail { get; set; }
        public DelegateCommand LoginCommand { get; private set; }
               
        public string UserName
        {
            get {return _userName;}
            set
            {
                _userName = value;
                base.OnPropertyChanged("UserName");
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
    
        public SecureString PassKey
        {
            get { return _passKey; }
            set
            {
                _passKey = value;
                base.OnPropertyChanged("PassKey");
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        public Person User
        {
            get { return _user; }
            set
            {
                _user = value;
                base.OnPropertyChanged("User");
            }
        }
        public bool IsProcessing
        {
            get { return _isProcessing; }
            set
            {
                _isProcessing = value;
                base.OnPropertyChanged("IsProcessing");
            }
        }

        private bool IsEnabled()
        {
            return true;
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Utility.ConvertToUnsecureString(PassKey));
        }

        private void Initialise()
        {
            try
            {
                Utility.Store = _service.GetStore();
                Utility.Setting = _service.GetSetting();

                DisplayLogo();
                if (Utility.Setting != null && Utility.Setting.Id > 0)
                {
                    SetApplicationModeImages(Utility.Setting.ApplicationMode);
                }

                if (Utility.Store != null)
                {
                    if (!string.IsNullOrWhiteSpace(Utility.Store.Name))
                    {
                        _eventAggregator.GetEvent<StoreNameEvent>().Publish(Utility.Store.Name);
                    }
                    if (!string.IsNullOrWhiteSpace(Utility.Store.LogoFileName))
                    {
                        string logoPath = Utility.ApplicationRoot + @"Images\Logo\" + Utility.Store.LogoFileName;
                        _eventAggregator.GetEvent<StoreLogoEvent>().Publish(logoPath);
                    }
                }

                ValidateEsnecil();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);

                //Utility.DisplayMessage(ex.Message + "\n\n" + ex.InnerException.Message + "\n\n" + ex.StackTrace);
            }
        }
        private void ValidateEsnecil()
        {
            try
            {
                _lic = new CryptoLicense();
                _lic.StorageMode = LicenseStorageMode.ToRegistry;
                _lic.RegistryStoragePath = _lic.RegistryStoragePath + "__splic";
                _lic.OnIsMachineCodeValid += new IsMachineCodeValidEventHandler(MachineCodeValidationCompleted);
                
                Esnecil esnecil = _service.GetEsnecil();
                if (esnecil == null)
                {
                    throw new Exception("Loading local esnecil failed!");
                }

                //_lic.Remove();
                EsnecilStatus esnecilStatus = new EsnecilStatus();
                if (_lic.Load())
                {
                    esnecilStatus.IsConsistent = esnecil.EsnecilCode == _lic.LicenseCode ? true : false;
                }
                else
                {
                    esnecil.ActivationDate = Utility.GetDate();
                    bool esnecilUpdated = _service.ModifyEsnecil(esnecil);
                    if (esnecilUpdated == false)
                    {
                        throw new Exception("Esnecil update operation failed!");
                    }

                    esnecilStatus.IsConsistent = true;
                    _lic.LicenseCode = esnecil.EsnecilCode;
                    _lic.Save();
                }

                _lic.ValidationKey = esnecil.ValidationKey;
                LicenseStatus status = _lic.Status;

                ////string ex = GetAllStatusExceptionsAsString(_lic);
                //esnecilStatus.IsEvaluationExpired = _lic.RemainingUsageDays <= 0 ? true : false;
                //esnecilStatus.RemainingUsageDays = _lic.RemainingUsageDays;
                //esnecilStatus.IsEvaluation = _lic.IsEvaluationLicense();
                //esnecilStatus.MaxUsageDays = _lic.MaxUsageDays;
                //esnecilStatus.State = status;

                
                esnecilStatus.IsEvaluationExpired = false;
                esnecilStatus.RemainingUsageDays = 20;
                esnecilStatus.IsEvaluation = true;
                esnecilStatus.MaxUsageDays = 29;
                esnecilStatus.State = LicenseStatus.Valid;

                Utility.EsnecilStatus = esnecilStatus;
                _eventAggregator.GetEvent<LicenseEvent>().Publish(esnecilStatus);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_lic != null)
                {
                    _lic.Dispose();
                }
            }
        }
        private string GetAllStatusExceptionsAsString(CryptoLicense license)
        {
            LicenseStatus[] status = (LicenseStatus[])Enum.GetValues(typeof(LicenseStatus));
            StringBuilder sb = new StringBuilder();
            foreach (LicenseStatus ls in status)
            {
                Exception ex = license.GetStatusException(ls);
                if (ex != null) // Additional info available for the status
                {
                    if (sb.Length > 0)
                        sb.Append("\n");

                    sb.Append(ls.ToString());
                    sb.Append(": ");
                    sb.Append(ex.Message);
                }
            }

            return sb.ToString();
        }
        private void MachineCodeValidationCompleted(object sender, IsMachineCodeValidEventArgs e)
        {
            try
            {
                if (_lic.IsEvaluationLicense())
                {
                    e.Handled = true;
                    return;
                }
                
                byte[] licenseMachineCode = e.LicenseMachineCode;
                string storedMachineCodeString = GetBase64StringMachineCode();
                string licensemachineCodeString = Convert.ToBase64String(licenseMachineCode);

                e.IsValid = licensemachineCodeString == storedMachineCodeString ? true : false;
                e.Handled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string GetBase64StringMachineCode()
        {
            try
            {
                string uuid = string.Empty;

                System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_ComputerSystemProduct");
                System.Management.ManagementObjectCollection moc = mc.GetInstances();

                foreach (System.Management.ManagementObject mo in moc)
                {
                    uuid = mo.Properties["UUID"].Value.ToString();
                    break;
                }

                byte[] machineCodeBytes = Encoding.UTF8.GetBytes(uuid);
                string machineCode = Convert.ToBase64String(machineCodeBytes);
                return machineCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
   
        public void OnLoginCommand()
        {
            try
            {
                IsProcessing = true;
                using (BackgroundWorker worker = new BackgroundWorker())
                {
                    worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(OnLoginCompleted);
                    worker.DoWork += (s, e) =>
                    {
                        LoginDetail = _service.ValidateUser(UserName, Utility.ConvertToUnsecureString(PassKey));
                    };
                    worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                IsProcessing = false;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoginCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsProcessing = false;
                
                if (e.Error != null && !string.IsNullOrWhiteSpace(e.Error.Message))
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                _dispatcher.Invoke(() =>
                                {
                                    if (LoginDetail != null)
                                    {
                                        User = LoginDetail.Person;
                                        Utility.LoggedInUser = LoginDetail.Person;

                                        if (LoginDetail.IsFirstLogon)
                                        {
                                            PopUp = new ChangePasswordPopUpView(_service);
                                            PopUp.Closed += new EventHandler(PopUpView_Closed);

                                            PopUp.ShowDialog();
                                        }
                                        else
                                        {
                                            if (UserAccountIsActive(LoginDetail.IsActivated, LoginDetail.IsLocked))
                                            {
                                                Login();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Utility.DisplayMessage("Invalid Username or Password! Please try again.");
                                    }
                                });
            }
            catch (Exception ex)
            {
                IsProcessing = false;
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void PopUpView_Closed(object sender, EventArgs e)
        {
            try
            {
                if (PopUp.DialogResult != null)
                {
                    bool result = (PopUp.DialogResult != null) ? Convert.ToBoolean(PopUp.DialogResult) : false;
                    ChangePasswordPopUpViewModel popupDialogViewModel = (ChangePasswordPopUpViewModel)PopUp.DataContext;

                    if (result)
                    {
                        if (popupDialogViewModel.LoginDetail != null)
                        {
                            if (UserAccountIsActive(popupDialogViewModel.LoginDetail.IsActivated, popupDialogViewModel.LoginDetail.IsLocked))
                            {
                                User = popupDialogViewModel.LoginDetail.Person;
                                Login();
                            }
                            else
                            {
                                Utility.DisplayMessage("Your account is either de-activated or locked! Please contact your system administrator to activate your account.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void Login()
        {
            try
            {
                NavigateToHomePage();
                _eventAggregator.GetEvent<UserEvent>().Publish(User);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void NavigateToHomePage()
        {
            try
            {
                Uri homeViewUri = new Uri("HomeView", UriKind.Relative);
                _regionManager.RequestNavigate(RegionContainer.Content, homeViewUri);

                //Animation.SwitchToPage();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool UserAccountIsActive(bool isActive, bool isLocked)
        {
            try
            {
                if (isActive == true && isLocked == false)
                {
                    return true;
                }

                Utility.DisplayMessage("Your account is either de-activated or locked! Please contact your system administrator to activate or unlock your account");
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }






    }


}
