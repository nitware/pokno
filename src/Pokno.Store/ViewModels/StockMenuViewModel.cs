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

using Pokno.Store.Views;
using Pokno.Infrastructure;
using System.Windows.Threading;

using Prism.Regions;
using Prism.Commands;
using Pokno.Store.Views.Setup;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Animation;
using Pokno.Infrastructure.Events;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.ViewModel;

namespace Pokno.Store.ViewModels
{
    public class StockMenuViewModel : BaseViewModel
    {
        private Dispatcher _dispatcher;
                
        private IRegion _contentRegion;
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private UserControl _currentView;

        public StockMenuViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;
            _dispatcher = Application.Current.Dispatcher;

            StockHomeCommand = new DelegateCommand(OnStockHomeCommand);
            StockSetupCommand = new DelegateCommand(OnStockSetupCommand, CanStockSetupCommand);
            StoreCommand = new DelegateCommand(OnStoreCommand, CanStoreCommand);
            SalesCommand = new DelegateCommand(OnSalesCommand, CanSalesCommand);
            ReturnsCommand = new DelegateCommand(OnReturnsCommand, CanReturnsCommand);

            //SettingsCommand = new DelegateCommand(OnSettingsCommand, CanSettingsCommand);
        }
        
        public DelegateCommand StockHomeCommand { get; private set; }
        public DelegateCommand StoreCommand { get; private set; }
        public DelegateCommand StockSetupCommand { get; private set; }
        public DelegateCommand ReturnsCommand { get; private set; }
        public DelegateCommand SalesCommand { get; private set; }
        public DelegateCommand SettingsCommand { get; private set; }
        private string RootWebAddress { get; set; }
               
        private bool CanStockSetupCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManageStockSetup;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanStoreCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManageStore;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanSalesCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManageSales;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        private bool CanReturnsCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManageReturns;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        private void OnStockSetupCommand()
        {
            try
            {
                StockSetupView view = _container.Resolve<StockSetupView>();
                ChangeContent(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnStoreCommand()
        {
            try
            {
                StockPurchasedView view = _container.Resolve<StockPurchasedView>();
                ChangeContent(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnSalesCommand()
        {
            try
            {
                SalesView view = _container.Resolve<SalesView>();
                ChangeContent(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnStockHomeCommand()
        {
            try
            {
                StockHomeView view = _container.Resolve<StockHomeView>();
                ChangeContent(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnReturnsCommand()
        {
            try
            {
                ReturnsView view = _container.Resolve<ReturnsView>();
                ChangeContent(view);
            }
            catch(Exception ex)
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

                //_dispatcher.BeginInvoke(DispatcherPriority.Normal, (System.Threading.ThreadStart)delegate()
                //{
                    _contentRegion = _regionManager.Regions[RegionContainer.Content];

                    if (_currentView != null)
                    {
                        if (_currentView.ToString() == view.ToString())
                        {
                            return;
                        }
                    }

                    if (view.ToString() == "Pokno.Store.Views.StockSetupView" || view.ToString() == "Pokno.Store.Views.StockPurchasedView" || view.ToString() == "Pokno.Store.Views.SalesView" || view.ToString() == "Pokno.Store.Views.ReturnsView")
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
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }





    }
}
