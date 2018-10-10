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

using System.Windows.Threading;
using Pokno.Infrastructure;
using Pokno.Infrastructure.Animation;
using Prism.Regions;
using Prism.Commands;
using Microsoft.Practices.Unity;
using Pokno.People.Views;
using Pokno.Infrastructure.Models;

namespace Pokno.People.ViewModel
{
    public class PersonMenuViewModel
    {
        private Dispatcher _dispatcher;

        private UserControl _currentView;
        private IRegion _contentRegion;
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public PersonMenuViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _dispatcher = Application.Current.Dispatcher;

            _contentRegion = new Region();
            _regionManager = regionManager;
            _container = container;

            PersonHomeCommand = new DelegateCommand(OnPersonHomeCommand);
            PersonBasicSetupCommand = new DelegateCommand(OnPersonBasicSetupCommand, CanSetupPersonBasicCommand);
            AccessControlCommand = new DelegateCommand(OnAccessControlCommand, CanSetupAccessControlCommand);
            CompanyCommand = new DelegateCommand(OnCompanyCommand, CanSetupCompanyCommand);
        }

        public DelegateCommand PersonBasicSetupCommand { get; private set; }
        public DelegateCommand PersonHomeCommand { get; private set; }
        public DelegateCommand AccessControlCommand { get; private set; }
        public DelegateCommand CompanyCommand { get; private set; }

        private bool CanSetupPersonBasicCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManagePeopleBasicSetup;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanSetupAccessControlCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManagePerson;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanSetupCompanyCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManageCompany;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
                
        private void OnPersonBasicSetupCommand()
        {
            PersonBasicSetupView view = _container.Resolve<PersonBasicSetupView>();
            SwitchView(view);
        }
        private void OnPersonHomeCommand()
        {
            PersonHomeView view = _container.Resolve<PersonHomeView>();
            SwitchView(view);
        }
        private void OnAccessControlCommand()
        {
            AccessControlSetupView view = _container.Resolve<AccessControlSetupView>();
            SwitchView(view);
        }
        private void OnCompanyCommand()
        {
            CompanySetupView view = _container.Resolve<CompanySetupView>();
            SwitchView(view);
        }

        private void SwitchView(UserControl view)
        {
            try
            {
                _dispatcher.Invoke(() =>
                  {
                      _contentRegion = _regionManager.Regions[RegionContainer.Content];

                      if (_currentView != null)
                      {
                          if (_currentView.ToString() == view.ToString())
                          {
                              return;
                          }
                      }

                      if (view.ToString() == "Pokno.People.Views.AccessControlSetupView" || view.ToString() == "Pokno.People.Views.CompanySetupView" || view.ToString() == "Pokno.People.Views.PersonBasicSetupView")
                      {
                          if (_contentRegion.GetView(view.ToString()) == null)
                          {
                              _contentRegion.Add(view, null, true); //create a scoped region
                          }
                      }
                      else
                      {
                          _contentRegion.Add(view);
                      }

                      _currentView = view;
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
