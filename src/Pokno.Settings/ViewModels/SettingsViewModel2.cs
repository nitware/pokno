using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Events;
using Pokno.Settings.Views;
using System.Windows;
using Pokno.Service;
using Prism.Commands;
using System.Windows.Input;

namespace Pokno.Settings.ViewModels
{
    public class SettingsViewModel2 : BaseApplicationViewModel // BaseViewModel
    {
        private int _selectedTabIndex;
        private IEventAggregator _eventAggregator;
        private IBusinessFacade _service;
        protected Window PopUp;

        public SettingsViewModel2()
        {
            LoggedInUser = Utility.LoggedInUser;

            OkCommand = new DelegateCommand(OnOkCommand);
            SetPopUpCommand = new DelegateCommand<object>(OnSetPopUpCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);

        }
        
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand OkCommand { get; private set; }
        public ICommand SetPopUpCommand { get; private set; }
        public bool? UserResponse { get; private set; }

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
                PopUp.DialogResult = true;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
       
        public IBusinessFacade BusinessFacade
        {
            set
            {
                _service = value;
            }
        }
        public IEventAggregator EventAggregator
        {
            set
            {
                _eventAggregator = value;
            }
        }
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                _selectedTabIndex = value;
                base.OnPropertyChanged("SelectedTabIndex");
                OnTabItemSelectedCommand(_selectedTabIndex);
            }
        }

        public void OnTabItemSelectedCommand(int selectedTabIndex)
        {
            switch (selectedTabIndex)
            {
                case 0:
                    {
                        _eventAggregator.GetEvent<SettingsEvent>().Publish(UI.Settings.ApplicationMode);
                        break;
                    }
                case 1:
                    {
                        _eventAggregator.GetEvent<SettingsEvent>().Publish(UI.Settings.BasicSetting);
                        break;
                    }
                case 2:
                    {
                        _eventAggregator.GetEvent<SettingsEvent>().Publish(UI.Settings.StoreDetail);
                        break;
                    }
                case 3:
                    {
                        _eventAggregator.GetEvent<SettingsEvent>().Publish(UI.Settings.CustomerLoyalty);
                        break;
                    }
                case 4:
                    {
                        _eventAggregator.GetEvent<SettingsEvent>().Publish(UI.Settings.DatabaseManagement);
                        break;
                    }
            }
        }







    }






}
