using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Regions;
using Prism.Commands;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Threading;
using Pokno.Infrastructure;
using Pokno.Settings.Views;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Microsoft.Practices.Unity;

namespace Pokno.Settings.ViewModels
{
    public class SettingsRootViewModel : BaseApplicationViewModel //ImageViewModel
    {
        protected Window PopUp;
        private readonly Dispatcher _dispatcher;
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private string _applicationIcon;

        public SettingsRootViewModel()
        {
            _dispatcher = Application.Current.Dispatcher;

            LoggedInUser = Utility.LoggedInUser;
            OkCommand = new DelegateCommand(OnOkCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);
            SetPopUpCommand = new DelegateCommand<object>(OnSetPopUpCommand);

            
            //ApplicationModeCommand = new DelegateCommand(OnApplicationModeCommand);
            BasicSettingsCommand = new DelegateCommand(OnBasicSettingsCommand, CanSetBasicSettings);
            SetDbCommand = new DelegateCommand(OnSetDbCommand, CanSetDb);
            ShopDetailCommand = new DelegateCommand(OnShopDetailCommand, CanSetupShopDetail);
            CustomerLoyaltyCommand = new DelegateCommand(OnCustomerLoyaltyCommand, CanSetupCustomerLoyalty);
            DbMaintenanceCommand = new DelegateCommand(OnDbMaintenanceCommand, CanMaintainDb);
            StoreLogoCommand = new DelegateCommand(OnStoreLogoCommand, CanUploadStoreLogo);
            ApplicationIcon = Utility.ApplicationRoot + @"Images\storepro-icon.ico";
        }
               
        public bool? UserResponse { get; private set; }
        public ICommand SetPopUpCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand OkCommand { get; private set; }

        public DelegateCommand ApplicationModeCommand { get; private set; }
        public DelegateCommand BasicSettingsCommand { get; private set; }
        public DelegateCommand ShopDetailCommand { get; private set; }
        public DelegateCommand CustomerLoyaltyCommand { get; private set; }
        public DelegateCommand DbMaintenanceCommand { get; private set; }
        public DelegateCommand StoreLogoCommand { get; private set; }
        public DelegateCommand SetDbCommand { get; private set; }


        private bool CanMaintainDb()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanMaintainDb;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        private bool CanSetupCustomerLoyalty()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanSetupCustomerLoyaltyProgram;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        private bool CanSetupShopDetail()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanSetupShopDetail;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        private bool CanSetDb()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanSetDB;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        public bool CanSetBasicSettings()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanSetBasicSetting;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        public bool CanUploadStoreLogo()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanUploadStoreLogo;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }


        public string ApplicationIcon
        {
            get { return _applicationIcon; }
            set
            {
                _applicationIcon = value;
                base.OnPropertyChanged("ApplicationIcon");
            }
        }
        public IRegionManager RegionManager
        {
            set { _regionManager = value; }
        }
        public IUnityContainer Container
        {
            set { _container = value; }
        }
                
        public void OnApplicationModeCommand()
        {
            try
            {
                ApplicationModeView view = _container.Resolve<ApplicationModeView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SettingsRegion);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        public void OnBasicSettingsCommand()
        {
            try
            {
                BasicSettingView view = _container.Resolve<BasicSettingView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SettingsRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        public void OnSetDbCommand()
        {
            try
            {
                DbPathView view = _container.Resolve<DbPathView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SettingsRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        public void OnShopDetailCommand()
        {
            try
            {
                StoreDetailView view = _container.Resolve<StoreDetailView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SettingsRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        public void OnCustomerLoyaltyCommand()
        {
            try
            {
                CustomerLoyaltyView view = _container.Resolve<CustomerLoyaltyView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SettingsRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        public void OnDbMaintenanceCommand()
        {
            try
            {
                DatabaseManagementView view = _container.Resolve<DatabaseManagementView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SettingsRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        public void OnStoreLogoCommand()
        {
            try
            {
                StoreLogoView view = _container.Resolve<StoreLogoView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.SettingsRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
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
        private bool CanSetPopUp(object param)
        {
            return true;
        }
        private void OnOkCommand()
        {
            try
            {
                //if (!IsAllDataEntered())
                //{
                //    return;
                //}

                PopUp.DialogResult = true;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
       




    }
}
