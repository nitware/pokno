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

using Prism.Regions;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Commands;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure;
using Pokno.Report.Views;
using Pokno.Infrastructure.Events;
using Pokno.Report.Views.Purchase;
using Pokno.Report.Views.Sales;
using Pokno.Report.Views.Miscellaneous;
using Pokno.Report.Views.Stock;
using Pokno.Report.Views.Payment;
using Pokno.Report.Views.Expenses;
using Pokno.Report.Views.Returns;

namespace Pokno.Report.ViewModels
{
    public class ReportMenuViewModel
    {
        private UserControl currentView;
        private IRegion contentRegion;
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        private Dispatcher _dispatcher;

        public ReportMenuViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dispatcher = Application.Current.Dispatcher;

            ReportHomeCommand = new DelegateCommand(OnReportHomeCommand);
            StockCommand = new DelegateCommand(OnStockCommand, CanViewStockReportCommand);
            PurchaseReportCommand = new DelegateCommand(OnPurchaseReportCommand, CanViewPurchaseReport);
            SalesReportCommand = new DelegateCommand(OnSalesReportCommand, CanViewSalesReportCommand);
            ExpensesReportCommand = new DelegateCommand(OnExpensesReportCommand, CanViewExpensesReport);
            PaymentCommand = new DelegateCommand(OnPaymentCommand, CanViewPaymentReport);
            MiscReportCommand = new DelegateCommand(OnMiscReportCommand, CanViewMiscReport);
            ReturnsReportCommand = new DelegateCommand(OnReturnsReportCommand, CanViewReturnsReport);
        }

        public DelegateCommand StockCommand { get; private set; }
        public DelegateCommand SalesReportCommand { get; private set; }
        public DelegateCommand PaymentCommand { get; private set; }
        public DelegateCommand ReportHomeCommand { get; private set; }
        public DelegateCommand MiscReportCommand { get; private set; }
        public DelegateCommand PurchaseReportCommand { get; private set; }
        public DelegateCommand ExpensesReportCommand { get; private set; }
        public DelegateCommand ReturnsReportCommand { get; private set; }
                
        private bool CanViewMiscReport()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanViewMiscellaneousReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewStockReportCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanViewStockReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewPurchaseReport()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanViewPurchaseReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewSalesReportCommand()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanViewSalesReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewExpensesReport()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanViewExpensesReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewPaymentReport()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanViewPaymentReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewReturnsReport()
        {
            try
            {
                if (Utility.LoggedInUser != null)
                {
                    return Utility.LoggedInUser.Role.PersonRight.CanViewReturnsReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }



        private void OnReportHomeCommand()
        {
            try
            {
                ReportHomeView view = _container.Resolve<ReportHomeView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnStockCommand()
        {
            try
            {
                StockReportView view = _container.Resolve<StockReportView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnPurchaseReportCommand()
        {
            try
            {
                StockPurchaseReportView view = _container.Resolve<StockPurchaseReportView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnSalesReportCommand()
        {
            try
            {
                SalesReportView view = _container.Resolve<SalesReportView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnReturnsReportCommand()
        {
            try
            {
                ReturnedStockReportView view = _container.Resolve<ReturnedStockReportView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnExpensesReportCommand()
        {
            try
            {
                ExpensesReportView view = _container.Resolve<ExpensesReportView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnPaymentCommand()
        {
            try
            {
                PaymentReportView view = _container.Resolve<PaymentReportView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnMiscReportCommand()
        {
            try
            {
                MiscellaneousReportView view = _container.Resolve<MiscellaneousReportView>();
                SwitchView(view);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



        private void SwitchView(UserControl view)
        {
            try
            {
                _dispatcher.Invoke(() =>
                {
                    contentRegion = _regionManager.Regions[RegionContainer.Content];

                    if (currentView != null)
                    {
                        if (currentView.ToString() == view.ToString())
                        {
                            return;
                        }
                    }

                    contentRegion.Add(view);
                    currentView = view;
                    contentRegion.Activate(view);

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
