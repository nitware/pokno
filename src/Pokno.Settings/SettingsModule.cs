using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Pokno.Infrastructure;
using Pokno.Settings.Views;
using Pokno.Model.Model;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infratructure.Services;
using Pokno.Business.Interfaces;
using Pokno.Business;

namespace Pokno.Settings
{
    public class SettingsModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public SettingsModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ISetupService<ApplicationMode>, ApplicationModeService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IFileManager, FileManager>(new ContainerControlledLifetimeManager());
                        
            //_regionManager.RegisterViewWithRegion(RegionContainer.SettingsRegion, typeof(SettingsView));

            
        }





    }
}
