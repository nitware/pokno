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

using Prism.Events;
using Prism.Commands;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Prism.Regions;
using Microsoft.Practices.Unity;
using System.Windows.Threading;
using Pokno.Infrastructure;
using Pokno.Report.Views.Payment;

namespace Pokno.Report.ViewModels.Payment
{
    public class PaymentReportViewModel : BaseViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public PaymentReportViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _container = container;
            _regionManager = regionManager;

            LoggedInUser = Utility.LoggedInUser;
            CompanyCreditorsListReportCommand = new DelegateCommand(OnCompanyCreditorsListReportCommand, CanViewCompanyCreditorsListReport);
            CompanyDebtorsListReportCommand = new DelegateCommand(OnCompanyDebtorsListReportCommand, CanViewCompanyDebtorsListReport);
            SupplierCreditorsListReportCommand = new DelegateCommand(OnSupplierCreditorsListReportCommand, CanViewSupplierCreditorsListReport);
            SupplierDebtorsListReportCommand = new DelegateCommand(OnSupplierDebtorsListReportCommand, CanViewSupplierDebtorsListReport);
            PaymentHistoryReportCommand = new DelegateCommand(OnPaymentHistoryReportCommand, CanViewPaymentHistoryReport);
            PaymentHistoryByPersonReportCommand = new DelegateCommand(OnPaymentHistoryByPersonReportCommand, CanViewPaymentHistoryByPersonReport);

            _regionManager.Regions.Remove(RegionContainer.PaymentReportRegion);
        }
                
        public DelegateCommand CompanyCreditorsListReportCommand { get; private set; }
        public DelegateCommand SupplierCreditorsListReportCommand { get; private set; }
        public DelegateCommand SupplierDebtorsListReportCommand { get; private set; }
        public DelegateCommand CompanyDebtorsListReportCommand { get; private set; }
        public DelegateCommand PaymentHistoryReportCommand { get; private set; }
        public DelegateCommand PaymentHistoryByPersonReportCommand { get; private set; }

        private bool CanViewCompanyCreditorsListReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewCompanyCreditorsList;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewCompanyDebtorsListReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewCompanyDebtorsList;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewSupplierCreditorsListReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewSupplierCreditorsList;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewSupplierDebtorsListReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewSupplierDebtorsList;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewPaymentHistoryReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewPaymentHistoryReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }
        private bool CanViewPaymentHistoryByPersonReport()
        {
            try
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Role.PersonRight.CanViewPaymentHistoryByPersonReport;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return false;
        }

        public void OnCompanyCreditorsListReportCommand()
        {
            try
            {
                CompanyCreditorsListReportView view = _container.Resolve<CompanyCreditorsListReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PaymentReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnCompanyDebtorsListReportCommand()
        {
            try
            {
                CompanyDebtorsListReportView view = _container.Resolve<CompanyDebtorsListReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PaymentReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnSupplierCreditorsListReportCommand()
        {
            try
            {
                SupplierCreditorsListReportView view = _container.Resolve<SupplierCreditorsListReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PaymentReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnSupplierDebtorsListReportCommand()
        {
            try
            {
                SupplierDebtorsListReportView view = _container.Resolve<SupplierDebtorsListReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PaymentReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnPaymentHistoryReportCommand()
        {
            try
            {
                PaymentHistoryReportView view = _container.Resolve<PaymentHistoryReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PaymentReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public void OnPaymentHistoryByPersonReportCommand()
        {
            try
            {
                PaymentHistoryByPersonReportView view = _container.Resolve<PaymentHistoryByPersonReportView>();
                Navigation.SwitchToReportView(view, _regionManager, RegionContainer.PaymentReportRegion);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



    }

}
