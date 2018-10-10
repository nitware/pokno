using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure;
using Pokno.Home.Views;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace Pokno.Home
{
    public class HomeModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public HomeModule(IRegionManager _regionManager, IUnityContainer _container)
        {
            container = _container;
            regionManager = _regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion(RegionContainer.Content, typeof(HomeView));
            regionManager.RegisterViewWithRegion(RegionContainer.SubMenu, typeof(HomeMenuView));
        }




    }
}
