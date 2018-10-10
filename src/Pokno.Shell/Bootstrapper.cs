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

using Pokno.Home;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Pokno.People;
using Microsoft.Practices.ServiceLocation;
using Pokno.Shell.ViewModel;
using Prism.Unity;
using Pokno.Store;
using Pokno.Payment;
using Pokno.Account;
using Pokno.Report;
using Pokno.Settings;
using Pokno.Help;
using Pokno.Service;
using Pokno.Infrastructure.Models;

namespace Pokno.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {            
            //Container.RegisterType<IBusinessFacade, BusinessFacade>(new InjectionConstructor(Utility.DbPath));

            Container.RegisterType<IBusinessFacade, BusinessFacade>(new InjectionConstructor(Utility.GetDbPath()));
            Container.RegisterType<IShellViewModel, ShellViewModel>();

            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();



            //defined modules
            Type homeModule = typeof(HomeModule);
            Type settingsModule = typeof(SettingsModule);
            Type stockModule = typeof(StockModule);
            Type paymentModule = typeof(PaymentModule);
            Type peopleModule = typeof(PeopleModule);
            Type reportModule = typeof(ReportModule);
            Type accountModule = typeof(AccountModule);
            Type helpModule = typeof(HelpModule);
            
            //add modules to catalog
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = peopleModule.Name, ModuleType = peopleModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = homeModule.Name, ModuleType = homeModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = settingsModule.Name, ModuleType = settingsModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = stockModule.Name, ModuleType = stockModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = paymentModule.Name, ModuleType = paymentModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = reportModule.Name, ModuleType = reportModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = accountModule.Name, ModuleType = accountModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });
            this.ModuleCatalog.AddModule(new ModuleInfo() { ModuleName = helpModule.Name, ModuleType = helpModule.AssemblyQualifiedName, InitializationMode = InitializationMode.WhenAvailable });

        }


    }
}
