using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Microsoft.Practices.Unity;
using Pokno.Infrastructure;
using Pokno.Store.Views;
using Pokno.Store.Services;
using Pokno.Infrastructure.Interfaces;
using Pokno.Store.Views.Setup;
using Pokno.Store.Interfaces;
using Pokno.Infrastructure.Services;
using Pokno.Infratructure.Services;
using Pokno.Model;
using Prism.Modularity;
using Prism.Regions;
using Prism.Events;
using Pokno.Service;
using Pokno.Model.Model;

namespace Pokno.Store
{
    public class StockModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        
        public StockModule(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            _container.RegisterType<IPosService, PosService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<StockCategory>, StockCategoryService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<StockType>, StockTypeService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<Stock>, StockService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<Package>, PackageService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICollectibleService<StockPackage>, StockPackageService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICollectibleService<PackageRelationship>, PackageRelationshipService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICollectibleService<StockPrice>, StockPriceService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<StockReturnAction>, StockReturnActionService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<StockReturnType>, StockReturnTypeService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<ExpensesCategory>, ExpensesCategoryService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<StockState>, StockStateService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<Location>, LocationService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IStockPurchaseBatchService, StockPurchaseBatchService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IRegisterPurchasedStockService, RegisterPurchasedStockService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IShelfService, ShelfService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISellStockService, SellStockService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IPaymentService , PaymentService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IModifyStockPurchasedBatchService, ModifyStockPurchasedBatchService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISoldStockService, SoldStockService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IExpiryDateAlertService, ExpiryDateAlertService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ITakeStockService, TakeStockService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<PaymentType>, PaymentTypeService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<Person>, PersonService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDeletedStockOnShelfService, DeletedStockOnShelfService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISetupService<ApplicationMode>, ApplicationModeService>(new ContainerControlledLifetimeManager());
            
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(StockCategoryView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(StockTypeView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(Pokno.Store.Views.StockView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(PackageView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(StockPackageView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(PackageRelationshipView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(StockPriceView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(ExpensesCategoryView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(StockStateView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockSetupTab, typeof(StockReturnActionView));

            _regionManager.RegisterViewWithRegion(RegionContainer.StockPurchaseTab, typeof(ExpiryDateAlertView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockPurchaseTab, typeof(RegisterPurchasedStockView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockPurchaseTab, typeof(ModifyPurchasedStockView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockPurchaseTab, typeof(ArrangeStockOnShelfView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockPurchaseTab, typeof(EnteredShelfStockView));
            _regionManager.RegisterViewWithRegion(RegionContainer.StockPurchaseTab, typeof(RemoveStockFromShelfView));
            
            _regionManager.RegisterViewWithRegion(RegionContainer.StockPurchaseTab, typeof(TakeStockView));

            _regionManager.RegisterViewWithRegion(RegionContainer.SalesTab, typeof(SellStockView));
            _regionManager.RegisterViewWithRegion(RegionContainer.SalesTab, typeof(EditSoldStockView));
            //_regionManager.RegisterViewWithRegion(RegionContainer.SalesTab, typeof(DeleteSalesTransactionView));
            _regionManager.RegisterViewWithRegion(RegionContainer.SalesTab, typeof(StockPriceCheckView));
            _regionManager.RegisterViewWithRegion(RegionContainer.SalesTab, typeof(DailySalesView));

            _regionManager.RegisterViewWithRegion(RegionContainer.ReturnsTab, typeof(StockReturnView));
            _regionManager.RegisterViewWithRegion(RegionContainer.ReturnsTab, typeof(ManageReplacedStockView));
            _regionManager.RegisterViewWithRegion(RegionContainer.ReturnsTab, typeof(PurchasedStockReturnView));



        }

    }



}
