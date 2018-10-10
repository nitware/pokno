using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Prism.Regions;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Pokno.Infratructure.Services;
using Pokno.Infrastructure.Interfaces;
using Pokno.Model;
using Pokno.Infrastructure;
using Pokno.Payment.Views;

namespace Pokno.Payment
{
    public class PaymentModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        
        public PaymentModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ISetupService<PaymentType>, PaymentTypeService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<Bank>, BankService>(new ContainerControlledLifetimeManager());
            
            _regionManager.RegisterViewWithRegion(RegionContainer.PaymentSetupTab, typeof(PaymentTypeView));
            _regionManager.RegisterViewWithRegion(RegionContainer.PaymentSetupTab, typeof(BankView));
        }




    }
}
