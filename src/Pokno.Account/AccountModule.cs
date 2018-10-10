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

using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Pokno.Account.Interfaces;
using Pokno.Infrastructure;
using Pokno.Account.Views;

namespace Pokno.Account
{
    public class AccountModule : IModule
    {
        private IRegionManager regionManager;
        private IUnityContainer container;

        public AccountModule(IRegionManager _regionManager, IUnityContainer _container)
        {
            regionManager = _regionManager;
            container = _container;
        }

        public void Initialize()
        {
            //container.RegisterType<IExpensisService, ExpensisService>(new ContainerControlledLifetimeManager());
                     
            regionManager.RegisterViewWithRegion(RegionContainer.ExpensisTab, typeof(DailyExpensesView));

        }


    }
}
