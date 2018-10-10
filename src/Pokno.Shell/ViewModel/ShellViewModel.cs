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
using Prism.Commands;
using System.Windows.Threading;

using Microsoft.VisualBasic;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.Shell.Model;
using Pokno.Home.Views;
using Pokno.Infrastructure;
using Pokno.Infrastructure.Animation;
using Pokno.Model;
using Pokno.People.Views;
using Prism.Regions;
using Prism.Events;
using FirstFloor.ModernUI.Presentation;
using Pokno.Store.Views;
using Pokno.Payment.Views;
using Pokno.Account.Views;
using Pokno.Report.Views;
using Pokno.Settings.Views;
using Pokno.Service;
using Pokno.Help.Views;
using LogicNP.CryptoLicensing;
using System.Windows.Media.Imaging;

namespace Pokno.Shell.ViewModel
{
    public class ShellViewModel : ImageViewModel, IShellViewModel
    {
        private Window PopUp;
        private Dispatcher _dispatcher;

        private IRegion _menuRegion;
        private IRegion _contentRegion;
        private UserControl _currentView;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private bool _isSettingsManagable;
        private bool _isPaymentManagable;
        private bool _isStockManagable;
        private bool _isAccountManagable;
        private bool _isPeopleManagable;
        private bool _isReportViewable;

        private string _storeName;
        private BitmapImage _storeLogo;

        private bool _hideMainMenu;
        private bool _isUserLoggedIn;
        private string _loginStatus;
        private string _youAreHere;
        private string _activationStatus;
        private bool _isValidEsnecil;
        private string _colour;
        
        private const string LOGIN = "Login";
        private const string LOGOUT = "Logout";

        public ShellViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dispatcher = Application.Current.Dispatcher;

            HomeCommand = new DelegateCommand(OnHomeCommand);
            PaymentCommand = new DelegateCommand(OnPaymentCommand, CanManagePayment);
            StockCommand = new DelegateCommand(OnStockCommand, CanManageStock);
            PeopleCommand = new DelegateCommand(OnPeopleCommand, CanManagePeople);
            ReportCommand = new DelegateCommand(OnReportCommand, CanViewReport);
            AccountCommand = new DelegateCommand(OnAccountCommand, CanManageAccount);
            SettingsCommand = new DelegateCommand(OnSettingsCommand, CanManageSettings);
            ActivateCommand = new DelegateCommand(OnActivateCommand);
            
            HideMainMenu = true;
            ResetLoggedInUser();
           
            eventAggregator.GetEvent<StoreLogoEvent>().Subscribe(DisplayStoreLogo, ThreadOption.UIThread);
            eventAggregator.GetEvent<StoreNameEvent>().Subscribe(DisplayStoreName, ThreadOption.UIThread);
            eventAggregator.GetEvent<UserEvent>().Subscribe(OnUserLogin, ThreadOption.UIThread);
            eventAggregator.GetEvent<LicenseEvent>().Subscribe(OnValidateEsnecilCompleted, ThreadOption.UIThread);
            eventAggregator.GetEvent<LicStateEvent>().Subscribe(SetEsnecilState, ThreadOption.UIThread);

            LoginStatus = LOGIN;
            YouAreHere = CurrentModule.LOGIN.ToString();
            LogOutLinkButtonCommand = new DelegateCommand(OnLogOutLinkButtonCommand);
            StoreName = "[Store Name]";

            //Db = Utility.GetDbPath();
        }

        public string Db { get; set; }

        public DelegateCommand HomeCommand { get; private set; }
        public DelegateCommand PaymentCommand { get; private set; }
        public DelegateCommand ReportCommand { get; private set; }
        public DelegateCommand PeopleCommand { get; private set; }
        public DelegateCommand StockCommand { get; private set; }
        public DelegateCommand LogOutLinkButtonCommand { get; private set; }
        public DelegateCommand AccountCommand { get; private set; }
        public DelegateCommand SettingsCommand { get; private set; }
        public DelegateCommand ActivateCommand { get; private set; }

        public bool IsSettingsManagable
        {
            get { return _isSettingsManagable; }
            set
            {
                _isSettingsManagable = value;
                base.OnPropertyChanged("IsSettingsManagable");

                SettingsCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsPaymentManagable
        {
            get { return _isPaymentManagable; }
            set
            {
                _isPaymentManagable = value;
                base.OnPropertyChanged("IsPaymentManagable");

                PaymentCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsStockManagable
        {
            get { return _isStockManagable; }
            set
            {
               _isStockManagable = value;
                base.OnPropertyChanged("IsStockManagable");

                StockCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsAccountManagable
        {
            get { return _isAccountManagable; }
            set
            {
                _isAccountManagable = value;
                base.OnPropertyChanged("IsAccountManagable");

                AccountCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsPeopleManagable
        {
            get { return _isPeopleManagable; }
            set
            {
                _isPeopleManagable = value;
                base.OnPropertyChanged("IsPeopleManagable");

                PeopleCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsReportViewable
        {
            get { return _isReportViewable; }
            set
            {
                _isReportViewable = value;
                base.OnPropertyChanged("IsReportViewable");

                ReportCommand.RaiseCanExecuteChanged();
            }
        }
        public string ActivationStatus 
        {
            get { return _activationStatus; }
            set
            {
                _activationStatus = value;
                base.OnPropertyChanged("ActivationStatus");
            }
        }
        public string Colour 
        {
            get { return _colour; }
            set
            {
                _colour = value;
                base.OnPropertyChanged("Colour");
            }
        }
        public bool IsValidEsnecil
        {
            get { return _isValidEsnecil; }
            set
            {
                _isValidEsnecil = value;
                base.OnPropertyChanged("IsValidEsnecil");
            }
        }
        public string YouAreHere
        {
            get { return _youAreHere; }
            set
            {
                _youAreHere = value;
                base.OnPropertyChanged("YouAreHere");
            }
        }
        public string StoreName
        {
            get { return _storeName; }
            set
            {
                _storeName = value;
                base.OnPropertyChanged("StoreName");
            }
        }
        public string LoginStatus
        {
            get { return _loginStatus; }
            set
            {
                _loginStatus = value;
                base.OnPropertyChanged("LoginStatus");
            }
        }
        public bool IsUserLoggedIn
        {
            get { return _isUserLoggedIn; }
            set
            {
                _isUserLoggedIn = value;
                HideMainMenu = !_isUserLoggedIn;
                base.OnPropertyChanged("IsUserLoggedIn");
            }
        }
        public bool HideMainMenu
        {
            get { return _hideMainMenu; }
            set
            {
                _hideMainMenu = value;
                base.OnPropertyChanged("HideMainMenu");
            }
        }
        public BitmapImage StoreLogo
        {
            get { return _storeLogo; }
            set
            {
                _storeLogo = value;
                base.OnPropertyChanged("StoreLogo");
            }
        }

        private bool CanManageSettings()
        {
            return IsSettingsManagable;
        }
        private bool CanManagePayment()
        {
            return IsPaymentManagable;
        }
        private bool CanManageStock()
        {
            return IsStockManagable;
        }
        private bool CanManagePeople()
        {
            return IsPeopleManagable;
        }
        private bool CanViewReport()
        {
            return IsReportViewable;
        }
        private bool CanManageAccount()
        {
            return IsAccountManagable;
        }
               
        private void OnValidateEsnecilCompleted(EsnecilStatus status)
        {
            try
            {
                if (status == null)
                {
                    SetEsnecilState(LicState.NULL_LIC);
                    NavigateToActivationView();

                    return;
                }

                if (status.IsEvaluation)
                {
                    Colour = "Red";
                    if (status.IsEvaluationExpired)
                    {
                        SetEsnecilState(LicState.EVALUATION_EXPIRED);
                    }
                    else
                    {
                        if (IsConsistent(status))
                        {
                            if (status.State == LicenseStatus.Valid)
                            {
                                SetEsnecilState(LicState.VALID_LIC);
                            }
                            else
                            {
                                SetEsnecilState(LicState.INVALID_LIC);
                            }
                        }
                        else
                        {
                            SetEsnecilState(LicState.UNAUTHORISED_TAMPERING);
                        }
                    }

                    NavigateToActivationView();
                }
                else
                {
                    if (IsConsistent(status))
                    {
                        SetEsnecilState(LicState.VALID_PRODUCT_LIC);
                    }
                    else
                    {
                        SetEsnecilState(LicState.UNAUTHORISED_TAMPERING);
                        NavigateToActivationView();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SetEsnecilState(LicState licState)
        {
            try
            {
                switch (licState)
                {
                    case LicState.NULL_LIC:
                        {
                            Colour = "Red";
                            IsValidEsnecil = false;
                            ActivationStatus = "Null Licence Status!";

                            break;
                        }
                    case LicState.EVALUATION_EXPIRED:
                        {
                            Colour = "Red";
                            IsValidEsnecil = false;
                            ActivationStatus = "Evaluation Expired!";

                            break;
                        }
                    case LicState.VALID_LIC:
                        {
                            const string EVALUATION = "Evaluation Copy (";

                            IsValidEsnecil = true;
                            EsnecilStatus status = Utility.EsnecilStatus;
                            if (status.RemainingUsageDays > 1)
                            {
                                ActivationStatus = EVALUATION + status.RemainingUsageDays + " days)";
                            }
                            else
                            {
                                ActivationStatus = EVALUATION + status.RemainingUsageDays + " day)";
                            }

                            break;
                        }
                    case LicState.INVALID_LIC:
                        {
                            Colour = "Red";
                            IsValidEsnecil = false;
                            ActivationStatus = "Invalid License";

                            break;
                        }
                    case LicState.UNAUTHORISED_TAMPERING:
                        {
                            Colour = "Red";
                            ActivationStatus = "Unauthorised Tampering!";
                            IsValidEsnecil = false;

                            break;
                        }
                    case LicState.VALID_PRODUCT_LIC:
                        {
                            Colour = "Green";
                            ActivationStatus = "Activated";
                            IsValidEsnecil = true;

                            break;
                        }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void NavigateToActivationView()
        {
            try
            {
                HideMainMenu = true;
                IsSettingsManagable = false;

                Uri menuViewUri = new Uri("HomeMenuView", UriKind.Relative);
                Uri mainViewUri = new Uri("ActivationView", UriKind.Relative);
                _regionManager.RequestNavigate(RegionContainer.SubMenu, menuViewUri);
                _regionManager.RequestNavigate(RegionContainer.Content, mainViewUri);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool IsConsistent(EsnecilStatus status)
        {
            try
            {
                if (!status.IsConsistent)
                {
                    Colour = "Red";
                    ActivationStatus = "Inconsistency Detected!";
                }

                return status.IsConsistent;
            }
            catch(Exception)
            {
                throw;
            }
        }
        private void OnActivateCommand()
        {
            try
            {
                Uri menuViewUri = new Uri("HomeMenuView", UriKind.Relative);
                Uri mainViewUri = new Uri("ActivationView", UriKind.Relative);

                _regionManager.RequestNavigate(RegionContainer.SubMenu, menuViewUri);
                _regionManager.RequestNavigate(RegionContainer.Content, mainViewUri);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSettingsCommand()
        {
            try
            {
                PopUp = new SettingsRootView(_regionManager, _container);

                PopUp.ShowDialog();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected void PopUpView_Closed(object sender, EventArgs e)
        {
            try
            {
                if (PopUp.DialogResult != null)
                {
                    //bool result = (PopUp.DialogResult != null) ? Convert.ToBoolean(PopUp.DialogResult) : false;
                    //BankAccountDetailPopUpViewModel popupDialogViewModel = (BankAccountDetailPopUpViewModel)PopUp.DataContext;

                    //if (result)
                    //{
                    //    TargetModel.Cheque = popupDialogViewModel.Cheque;
                    //    UpdatePaymentDetails(TargetModel.Cheque);
                    //    ComputeBalance();
                    //}

                    //SetUserViewRight();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
              
        private void OnPaymentCommand()
        {
            try
            {
                PaymentHomeView view = _container.Resolve<PaymentHomeView>();
                PaymentMenuView menuView = _container.Resolve<PaymentMenuView>();

                ChangeMenu(menuView);
                ChangeContent(view);

                YouAreHere = CurrentModule.PAYMENT.ToString();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnHomeCommand()
        {
            try
            {
                HomeView view = _container.Resolve<HomeView>();
                HomeMenuView menuView = _container.Resolve<HomeMenuView>();

                ChangeMenu(menuView);
                ChangeContent(view);

                YouAreHere = CurrentModule.HOME.ToString();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnStockCommand()
        {
            try
            {
                StockHomeView view = _container.Resolve<StockHomeView>();
                StockMenuView menuView = _container.Resolve<StockMenuView>();

                ChangeMenu(menuView);
                ChangeContent(view);

                YouAreHere = CurrentModule.STOCK.ToString();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnPeopleCommand()
        {
            try
            {
                PersonHomeView view = _container.Resolve<PersonHomeView>();
                PersonMenuView menuView = _container.Resolve<PersonMenuView>();

                ChangeMenu(menuView);
                ChangeContent(view);

                YouAreHere = CurrentModule.PEOPLE.ToString();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnReportCommand()
        {
            try
            {
                ReportHomeView view = _container.Resolve<ReportHomeView>();
                ReportMenuView menuView = _container.Resolve<ReportMenuView>();

                ChangeMenu(menuView);
                ChangeContent(view);

                YouAreHere = CurrentModule.REPORT.ToString();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnAccountCommand()
        {
            try
            {
                AccountHomeView view = _container.Resolve<AccountHomeView>();
                AccountMenuView menuView = _container.Resolve<AccountMenuView>();

                ChangeMenu(menuView);
                ChangeContent(view);

                YouAreHere = CurrentModule.ACCOUNT.ToString();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
              
        private void DisplayStoreLogo(string logoFilePath)
        {
            try
            {
                StoreLogo = Utility.SetImageSource(logoFilePath);
            }
            catch(Exception)
            {

            }
        }
        private void DisplayStoreName(string storeName)
        {
            StoreName = storeName;
        }

        private void OnUserLogin(Person user)
        {
            try
            {
                LoggedInUser = user;
                Utility.LoggedInUser = user;

                if (user != null)
                {
                    LoginStatus = LOGOUT;
                    IsUserLoggedIn = true;
                    IsValidEsnecil = true;
                    YouAreHere = CurrentModule.HOME.ToString();
                }
                else
                {
                    IsUserLoggedIn = false;
                }

                UpdateMenuState();

                //RaiseButtonCanExecuteEvent();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void ResetLoggedInUser()
        {
            try
            {
                LoggedInUser = new Person();
                LoggedInUser.Role = new Role();
                LoggedInUser.Role.PersonRight = new PersonRight();
                LoggedInUser.Name = "Guest";
                LoggedInUser.Role.Name = "Guest";
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLogOutLinkButtonCommand()
        {
            try
            {
                HomeMenuView menuView = _container.Resolve<HomeMenuView>();
                LoginView view = _container.Resolve<LoginView>();

                LoggedInUser = null;
                LoginStatus = LOGIN;
                IsUserLoggedIn = false;
                _currentView = null;

                ResetLoggedInUser();

                ChangeMenu(menuView);
                ChangeContent(view);

                UpdateMenuState();

                //RaiseButtonCanExecuteEvent();

                YouAreHere = CurrentModule.LOGIN.ToString();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        //private void RaiseButtonCanExecuteEvent()
        //{
        //    try
        //    {
        //        //PaymentCommand.RaiseCanExecuteChanged();
        //        //ReportCommand.RaiseCanExecuteChanged();
        //        //PeopleCommand.RaiseCanExecuteChanged();
        //        //StockCommand.RaiseCanExecuteChanged();
        //        //AccountCommand.RaiseCanExecuteChanged();

        //        UpdateSettingsMenuState();
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void UpdateMenuState()
        {
            try
            {
                if (LoggedInUser != null && LoggedInUser.Role != null && LoggedInUser.Role.PersonRight != null)
                {
                    IsSettingsManagable = LoggedInUser.Role.PersonRight.CanManageSettings;
                    IsPaymentManagable = LoggedInUser.Role.PersonRight.CanManagePayment;
                    IsStockManagable = LoggedInUser.Role.PersonRight.CanManageStock;
                    IsAccountManagable = LoggedInUser.Role.PersonRight.CanManageAccount;
                    IsPeopleManagable = LoggedInUser.Role.PersonRight.CanManagePerson;
                    IsReportViewable = LoggedInUser.Role.PersonRight.CanViewReport;
                }
                else
                {
                    IsSettingsManagable = false;
                    IsPaymentManagable = false;
                    IsStockManagable = false;
                    IsAccountManagable = false;
                    IsPeopleManagable = false;
                    IsReportViewable = false;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ChangeMenu(UserControl view)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (_menuRegion == null)
                    {
                        _menuRegion = _regionManager.Regions[RegionContainer.SubMenu];
                    }

                    if (_currentView != null)
                    {
                        if (_currentView.ToString() == view.ToString())
                        {
                            return;
                        }
                    }

                    _currentView = view;
                    _menuRegion.Add(view);
                    _menuRegion.Activate(view);
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SwitchView(UserControl view, IRegion region)
        {
            try
            {
                _dispatcher.Invoke(() =>
               {
                   if (region == null)
                   {
                       _menuRegion = _regionManager.Regions[RegionContainer.SubMenu];
                   }

                   if (_currentView != null)
                   {
                       if (_currentView.ToString() == view.ToString())
                       {
                           return;
                       }
                   }

                   _currentView = view;
                   _menuRegion.Add(view);
                   _menuRegion.Activate(view);
               });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ChangeContent(UserControl view)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    if (_contentRegion == null)
                    {
                        _contentRegion = _regionManager.Regions[RegionContainer.Content];
                    }

                    if (_currentView != null)
                    {
                        if (_currentView.ToString() == view.ToString())
                        {
                            return;
                        }
                    }

                    _currentView = view;
                    _contentRegion.Add(view);
                    _contentRegion.Activate(view);

                    //Animation.SwitchToPage();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }










        
    }

}
