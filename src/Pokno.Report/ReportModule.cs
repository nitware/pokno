using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Pokno.Infratructure.Services;
using Pokno.Common.Interfaces;
using Pokno.Model;
using Pokno.Infrastructure;
using Pokno.Report.Views;
using Pokno.Report.Models;
using Pokno.Infrastructure.Models;

namespace Pokno.Report
{
    public class ReportModule : IModule
    {
         private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public ReportModule(IRegionManager _regionManager, IUnityContainer _container)
        {
            container = _container;
            regionManager = _regionManager;
        }

        public void Initialize()
        {
            container.RegisterType<IBaseReportFactory, BaseReportFactory>(new ContainerControlledLifetimeManager());
                        

            //regionManager.RegisterViewWithRegion(RegionContainer.Content, typeof(LoginView));
            //regionManager.RegisterViewWithRegion(RegionContainer.PersonBasicSetupTab, typeof(LocationView));
            //regionManager.RegisterViewWithRegion(RegionContainer.PersonTab, typeof(AssignRoleToPersonView));


            //regionManager.RegisterViewWithRegion(RegionContainer.Content, typeof(StockReportView));
            //regionManager.RegisterViewWithRegion(RegionContainer.StockReportRegion, typeof(StockListReportView));
            //regionManager.RegisterViewWithRegion(RegionContainer.StockReportRegion, typeof(StockPackageReportView));
            //regionManager.RegisterViewWithRegion(RegionContainer.StockReportRegion, typeof(PackageQuantityReportView));

        }






    }
}
