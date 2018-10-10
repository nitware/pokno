using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure;
using Pokno.Model;
using Pokno.Model.Model;
using Pokno.Infrastructure.Interfaces;
using Pokno.People.Interfaces;
using Pokno.Service;
using Pokno.People.Services;
using Pokno.Infratructure.Services;
using Pokno.People.Views;
using Pokno.Infrastructure.Models;

namespace Pokno.People
{
    public class PeopleModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        
        public PeopleModule(IRegionManager _regionManager, IUnityContainer _container)
        {
            container = _container;
            regionManager = _regionManager;
        }

        public void Initialize()
        {
            //container.RegisterType<IBusinessFacade, BusinessFacade>(new ContainerControlledLifetimeManager(), new InjectionConstructor(dbPath));
            //container.RegisterType<Pokno.Business.Interfaces.IRepository, Pokno.Data.Repository>(new InjectionConstructor(Utility.DbPath));
            //container.RegisterType<IBusinessFacade, BusinessFacade>();

            //container.RegisterType<IBusinessFacade, BusinessFacade>(new ContainerControlledLifetimeManager(), new InjectionConstructor(Utility.DbPath));
            container.RegisterType<ISetupService<PersonType>, PersonTypeService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISetupService<Person>, PersonService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISetupService<Role>, RoleService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISetupService<Right>, RightService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAssignRightToRoleService, AssignRightToRoleService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILoginService, LoginService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISetupService<Company>, CompanyService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISetupService<PersonCompany>, CompanyRepService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILoginDetailService, LoginDetailService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISetupService<Location>, LocationService>(new ContainerControlledLifetimeManager());

            regionManager.RegisterViewWithRegion(RegionContainer.Content, typeof(LoginView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonBasicSetupTab, typeof(LocationView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonBasicSetupTab, typeof(PersonTypeView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonTab, typeof(PersonView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonTab, typeof(LoginDetailsView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonTab, typeof(RoleView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonTab, typeof(RightView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonTab, typeof(AssignRightToRoleView));
            regionManager.RegisterViewWithRegion(RegionContainer.PersonTab, typeof(AssignRoleToPersonView));
            regionManager.RegisterViewWithRegion(RegionContainer.CompanySetupTab, typeof(CompanyView));
            regionManager.RegisterViewWithRegion(RegionContainer.CompanySetupTab, typeof(CompanyRepView));
        }





    }
}
