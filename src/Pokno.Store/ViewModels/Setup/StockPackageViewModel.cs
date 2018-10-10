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

using System.Linq;
using System.ComponentModel;
using Microsoft.Practices.Unity;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Pokno.Store.Interfaces;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Interfaces;
using Pokno.Store.Services;
using Pokno.Model;
using Prism.Events;
using Pokno.Infratructure.Services;
using Pokno.Service;
using Prism.Commands;

namespace Pokno.Store.ViewModels
{
    public class StockPackageViewModel : CollectibleViewModelBase<StockPackage>
    {
        private Package _package;
        private bool _canDeleteStockPackages;
        private ObservableCollection<Package> _packages;
        private PackageService _packageService;
        private bool _targetCollectionIsEmpty;
        private BackgroundWorker _worker;

        public StockPackageViewModel(IBusinessFacade businessFacade, ICollectibleService<StockPackage> service, IEventAggregator eventAggregator)
            : base(service, businessFacade)
        {
            ModelName = "Package Re-order Level";
            _packageService = new PackageService(businessFacade);
                        
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanDelete);
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);

            UpdateViewState(Edit.Mode.Loaded);
        }

        public DelegateCommand DeleteCommand { get; private set; }
                
        public string TabCaption
        {
            get { return ModelName; }
        }
        public bool CanDeleteStockPackages
        {
            get { return _canDeleteStockPackages; }
            set
            {
                _canDeleteStockPackages = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public bool TargetCollectionIsEmpty 
        {
            get { return _targetCollectionIsEmpty; }
            set
            {
                _targetCollectionIsEmpty = value;
                base.OnPropertyChanged("TargetCollectionIsEmpty");
            }
        }
        public ObservableCollection<Package> Packages
        {
            get { return _packages; }
            set
            {
                _packages = value;
                base.OnPropertyChanged("Packages");
            }
        }
        public Package Package
        {
            get { return _package; }
            set
            {
                _package = value;
                base.OnPropertyChanged("Package");
            }
        }
        public override Stock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (_stock != null && _stock.Id > 0)
                {
                    LoadStockPackageByStock(_stock);
                }
                else
                {
                    ClearViewHelper();
                }
            }
        }
        private bool NoSelectedStock()
        {
            try
            {
                if (Stock == null || Stock.Id <= 0)
                {
                    Utility.DisplayMessage("No stock selected! Please select stock");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void OnDeleteCommand()
        {
            try
            {
                if (NoSelectedStock())
                {
                    return;
                }

                MessageBoxResult response = Utility.DisplayMessage("This action will delete all package(s) associated with '" + Stock.Name + "'. Do you which to continue?", MessageBoxButton.YesNo);
                if (response == MessageBoxResult.No)
                {
                    return;
                }

                bool deleted = _businessFacade.DeleteStockPackagesBy(Stock);
                if (deleted)
                {
                    CanDeleteStockPackages = !_businessFacade.NoStockPackageExistFor(Stock);

                    ClearView();
                    Utility.DisplayMessage(ModelName + " have been successfully deleted");
                }
                else
                {
                    Utility.DisplayMessage(ModelName + " have not been deleted! Please try again");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool CanDelete()
        {
            return CanDeleteStockPackages;
        }

        private bool IsView(UI.StockSetup payload)
        {
            return payload == UI.StockSetup.PackageReOrderLevel;
        }
        public void OnInitialise(UI.StockSetup ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<Stock> stocks = base.GetAllStockHelper();// _businessFacade.GetAllStockWithDependant();
                        List<Package> packages = _packageService.LoadAll();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["packages"] = packages;
                        dictionary["stocks"] = stocks;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void LoadAllPackages()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _packageService.LoadAll();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void OnInitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<Stock> stocks = null;
                List<Package> packages = null;
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    packages = (List<Package>)dictionary["packages"];
                    stocks = (List<Stock>)dictionary["stocks"];
                }

                PopulateAllPackage(packages);
                base.LoadAllStockHelper(stocks);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateAllPackage(List<Package> packages)
        {
            try
            {
                if (packages == null)
                {
                    packages = new List<Package>();
                }

                packages = packages.Where(p => p.Id != 0).ToList();
                if (packages.Count > 0)
                {
                    packages.Insert(0, new Package() { Name = "<< Select Package >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    Packages = new ObservableCollection<Package>(packages);
                    Package = Packages.FirstOrDefault();
                });
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadStockPackageByStock(Stock stock)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadStockPackageByStockCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        bool noStockPackageExistFor = !_businessFacade.NoStockPackageExistFor(Stock);
                        List<StockPackage> stockPackages = _service.LoadByStock(stock);

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["noStockPackageExistFor"] = noStockPackageExistFor;
                        dictionary["stockPackages"] = stockPackages;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadStockPackageByStockCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<StockPackage> stockPackages = null;
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    CanDeleteStockPackages = (bool)dictionary["noStockPackageExistFor"];
                    stockPackages = (List<StockPackage>)dictionary["stockPackages"];
                }

                ClearInputSection();
                LoadModelsByStockHelper(stockPackages);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearInputSection()
        {
            try
            {
                TargetModel.ReOrderLevel = 0;
                TargetModel.ExpiryDaysAlert = 0;
                TargetModel.Description = "";

                if (Packages != null)
                {
                    Package = Packages.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
               
        protected override void OnSaveCommand()
        {
            try
            {
                if (DuplicateModelExist())
                {
                    return;
                }

                base.OnSaveCommand();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void ClearView()
        {
            try
            {
                _dispatcher.Invoke(() =>
                               {
                                   base.LoadAll();
                                   ClearViewHelper();
                                   ResetStockList();
                               });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearViewHelper()
        {
            try
            {
                TargetModel = new StockPackage();
                base.ClearTargetCollection();
                SetTotalItemCount();

                if (Packages != null)
                {
                    Package = Packages.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ResetStockList()
        {
            try
            {
                if (Stocks != null)
                {
                    Stock = Stocks.FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override bool IsRequiredDetailsEntered()
        {
            try
            {
                if (Stock == null || Stock.Id <= 0)
                {
                    Utility.DisplayMessage("Please select stock!");
                    return false;
                }
                else if (Package == null || Package.Id <= 0)
                {
                    Utility.DisplayMessage("Please select package!");
                    return false;
                }
                else if (TargetModel.ReOrderLevel == 0)
                {
                    Utility.DisplayMessage("Please enter re-order-level!");
                    return false;
                }
                else if (ModelAlreadyExist())
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override bool ModelAlreadyExist()
        {
            try
            {
                if (TargetCollection != null)
                {
                    foreach (StockPackage stockPackage in TargetCollection)
                    {
                        if (stockPackage.Package.Name == Package.Name)
                        {
                            Utility.DisplayMessage(Package.Name + " already exist! ");
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected bool DuplicateModelExist()
        {
            try
            {
                if (TargetCollection != null)
                {
                    int packageCount = 0;

                    foreach (StockPackage stockPackage in TargetCollection)
                    {
                        Package package = stockPackage.Package;
                        foreach (StockPackage controlStockPackage in TargetCollection)
                        {
                            if (controlStockPackage.Package.Name.ToLower().Trim() == package.Name.ToLower().Trim())
                            {
                                packageCount++;
                            }
                        }

                        if (packageCount > 1)
                        {
                            Utility.DisplayMessage(packageCount + " " + package.Name + "s detected! List must not contain more than one " + package.Name);
                            return true;
                        }

                        packageCount = 0;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override StockPackage GetNewModel()
        {
            try
            {
                StockPackage stockPackage = new StockPackage();
                stockPackage.Package = new Package();
                stockPackage.Stock = new Stock();

                stockPackage.Package.Id = Package.Id;
                stockPackage.Package.Name = Package.Name;
                stockPackage.Stock.Id = Stock.Id;
                stockPackage.Stock.Name = Stock.Name;
                stockPackage.ReOrderLevel = TargetModel.ReOrderLevel;
                stockPackage.ExpiryDaysAlert = TargetModel.ExpiryDaysAlert;
                stockPackage.Description = TargetModel.Description;

                return stockPackage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override sealed void UpdateViewState(Edit.Mode uiState)
        {
            try
            {
                base.UpdateViewState(uiState);
                CanDeleteStockPackages = Stock == null || Stock.Id <= 0 ? false : true;
                                
                ObservableCollection<StockPackage> models = null;
                if (TargetCollection != null)
                {
                    models = (ObservableCollection<StockPackage>)TargetCollection.SourceCollection;
                }

                TargetCollectionIsEmpty = models == null || models.Count <= 0 ? false : true;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

     



    }


}
