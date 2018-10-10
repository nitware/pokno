using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Regions;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Pokno.Service;
using Pokno.Help.Views;
using Pokno.Infrastructure;

namespace Pokno.Help
{
    public class HelpModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public HelpModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {           
            _regionManager.RegisterViewWithRegion(RegionContainer.Content, typeof(ActivationView));

            //_regionManager.RegisterViewWithRegion(RegionContainer.Content, typeof(InvalidEsnecilView));
            
        }

    }
}
