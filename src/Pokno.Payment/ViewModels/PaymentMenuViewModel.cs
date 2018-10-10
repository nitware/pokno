using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using Prism.Regions;
using Prism.Commands;
using Pokno.Payment.Views;
using Pokno.Infrastructure;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.Models;

namespace Pokno.Payment.ViewModels
{
    public class PaymentMenuViewModel
    {
        private IRegion _contentRegion;
        private UserControl _currentView;
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        private Dispatcher _dispatcher;

        public PaymentMenuViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _dispatcher = Application.Current.Dispatcher;
            _regionManager = regionManager;
            _container = container;

            HomeCommand = new DelegateCommand(OnHomeCommand);
            PaymentSetupCommand = new DelegateCommand(OnPaymentSetupCommand, CanSetupPaymentSetupCommand);
            UpdatePaymentCommand = new DelegateCommand(OnUpdatePaymentCommand, CanUpdatePaymentCommand);
        }

        public DelegateCommand BankCommand { get; private set; }
        public DelegateCommand HomeCommand { get; private set; }
        public DelegateCommand PaymentTypeCommand { get; private set; }
        public DelegateCommand UpdatePaymentCommand { get; private set; }
        public DelegateCommand PaymentSetupCommand { get; private set; }

        private bool CanSetupPaymentSetupCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanManagePayment;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanUpdatePaymentCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanUpdatePayment;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        private void OnPaymentTypeCommand()
        {
            PaymentTypeView view = _container.Resolve<PaymentTypeView>();
            SwitchView(view);
        }
        private void OnBankCommand()
        {
            BankView view = _container.Resolve<BankView>();
            SwitchView(view);
        }
        private void OnHomeCommand()
        {
            PaymentHomeView view = _container.Resolve<PaymentHomeView>();
            SwitchView(view);
        }
        private void OnUpdatePaymentCommand()
        {
            UpdatePaymentView view = _container.Resolve<UpdatePaymentView>();
            SwitchView(view);
        }
        private void OnPaymentSetupCommand()
        {
            PaymentSetupView view = _container.Resolve<PaymentSetupView>();
            SwitchView(view);
        }

        private void SwitchView(UserControl view)
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

                if (view.ToString() == "Pokno.Payment.Views.PaymentSetupView")
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
