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

using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Commands;
using Pokno.Account.Views;
using Pokno.Infrastructure;
using Pokno.Infrastructure.Models;

namespace Pokno.Account.ViewModels
{
    public class AccountMenuViewModel
    {
        private Dispatcher _dispatcher;
                
        private IRegion _contentRegion;
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private UserControl _currentView;

        public AccountMenuViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _dispatcher = Application.Current.Dispatcher;

            _regionManager = regionManager;
            _container = container;

            AccountHomeCommand = new DelegateCommand(OnAccountHomeCommand);
            ExpensesCommand = new DelegateCommand(OnExpensesCommand, CanRegisterExpensesCommand);
        }

        public DelegateCommand AccountHomeCommand { get; private set; }
        public DelegateCommand ExpensesCommand { get; private set; }
        private string RootWebAddress { get; set; }

        private bool CanRegisterExpensesCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManageAccount;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        private void OnAccountHomeCommand()
        {
            AccountHomeView view = _container.Resolve<AccountHomeView>();
            ChangeContent(view);
        }
        private void OnExpensesCommand()
        {
            ExpensesView view = _container.Resolve<ExpensesView>();
            ChangeContent(view);
        }
             
        private void ChangeContent(UserControl view)
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

                if (view.ToString() == "Pokno.Account.Views.ExpensesView")
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


    }


}
