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
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.Events;
using Pokno.Infrastructure.Models;
using Pokno.Store.Interfaces;
using Pokno.Infrastructure.Interfaces;
using Pokno.Store.Services;
using Pokno.Model;
using Prism.Events;
using Pokno.Service;
using Prism.Commands;
using Pokno.Model.Model;

namespace Pokno.Store.ViewModels
{
    public class PackageRelationshipViewModel : CollectibleViewModelBase<PackageRelationship>
    {
        private bool _canBeMovedUp;
        private bool _canBeMovedDown;

        private StockPackage _package;
        private bool _canDeletePackageRelationships;
        private ObservableCollection<StockPackage> _packages;
        private ObservableCollection<StockPackage> _subPackages;
        private StockPackage _subPackage;
        private bool _isQuantityEnabled;

        private StockPackageService _stockPackageService;
        private StockPackageRelationship _stockPackageRelationship;

        private BackgroundWorker _worker;

        public PackageRelationshipViewModel(IBusinessFacade businessService, ICollectibleService<PackageRelationship> service, IEventAggregator eventAggregator)
            : base(service, businessService)
        {
            IsQuantityEnabled = true;
            ModelName = "Package Relationship Qty";
            _stockPackageService = new StockPackageService(businessService);
                        
            UpCommand = new DelegateCommand(OnUpCommand, CanMoveUp);
            DownCommand = new DelegateCommand(OnDownCommand, CanMoveDown);
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanDelete);

            UpdateViewState(Edit.Mode.Loaded);
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }
                
        public DelegateCommand UpCommand { get; protected set; }
        public DelegateCommand DownCommand { get; protected set; }
        public DelegateCommand DeleteCommand { get; private set; }

        public string TabCaption
        {
            get { return "Package Relationship"; }
            //get { return "Package Relationship Qty"; }
        }
        public bool CanDeletePackageRelationships
        {
            get { return _canDeletePackageRelationships; }
            set
            {
                _canDeletePackageRelationships = value;
                DeleteCommand.RaiseCanExecuteChanged();
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
                    base.ClearTargetCollection();
                    LoadPackageRelationshipByStock(_stock);
                }
                else
                {
                    ClearViewHelper();
                }
            }
        }
        public bool IsQuantityEnabled
        {
            get { return _isQuantityEnabled; }
            set
            {
                _isQuantityEnabled = value;
                base.OnPropertyChanged("IsQuantityEnabled");
            }
        }
        public ObservableCollection<StockPackage> Packages
        {
            get { return _packages; }
            set
            {
                _packages = value;
                base.OnPropertyChanged("Packages");
            }
        }
        public ObservableCollection<StockPackage> SubPackages
        {
            get { return _subPackages; }
            set
            {
                _subPackages = value;
                base.OnPropertyChanged("SubPackages");
            }
        }
        public StockPackage Package
        {
            get { return _package; }
            set
            {
                _package = value;
                base.OnPropertyChanged("Package");
            }
        }
        public StockPackage SubPackage
        {
            get { return _subPackage; }
            set
            {
                _subPackage = value;
                base.OnPropertyChanged("SubPackage");

                if (_subPackage != null && _subPackage.Package.Id == 0)
                {
                    IsQuantityEnabled = false;
                    TargetModel.Quantity = 1;
                }
                else
                {
                    IsQuantityEnabled = true;
                }
            }
        }
        public StockPackageRelationship StockPackageRelationship
        {
            get { return _stockPackageRelationship; }
            set
            {
                _stockPackageRelationship = value;
                base.OnPropertyChanged("StockPackageRelationship");
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

                MessageBoxResult response = Utility.DisplayMessage("This action will delete all package relationship saved for '" + Stock.Name + "'. Do you which to continue?", MessageBoxButton.YesNo);
                if (response == MessageBoxResult.No)
                {
                    return;
                }

                bool deleted = _businessFacade.DeleteStockPackageRelationshipBy(Stock);
                if (deleted)
                {
                    CanDeletePackageRelationships = !_businessFacade.NoPackageRelationshipExist(Stock);

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
            return CanDeletePackageRelationships;
        }
        private bool IsView(UI.StockSetup payload)
        {
            return payload == UI.StockSetup.PackageQuantity;
        }

        public void OnInitialise(UI.StockSetup payload)
        {
            try
            {
                base.LoadAll();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadPackageRelationshipByStock(Stock stock)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadPackageRelationshipByStockCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<PackageRelationship> packageRelationships = _service.LoadByStock(stock);
                        List<StockPackage> stockPackages = _stockPackageService.LoadByStock(stock);
                        bool noPackageRelationshipExist = _businessFacade.NoPackageRelationshipExist(stock);

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["noPackageRelationshipExist"] = noPackageRelationshipExist;
                        dictionary["packageRelationships"] = packageRelationships;
                        dictionary["stockPackages"] = stockPackages;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadPackageRelationshipByStockCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<StockPackage> stockPackages = null;
                List<PackageRelationship> packageQuantities = null;
                bool noPackageRelationshipExist = false;
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    noPackageRelationshipExist = (bool)dictionary["noPackageRelationshipExist"];
                    packageQuantities = (List<PackageRelationship>)dictionary["packageRelationships"];
                    stockPackages = (List<StockPackage>)dictionary["stockPackages"];

                    if (packageQuantities != null && packageQuantities.Count > 0)
                    {
                        StockPackageRelationship = packageQuantities[0].StockPackageRelationship;
                    }

                    CanDeletePackageRelationships = !noPackageRelationshipExist;
                }

                //clear user input section
                TargetModel.Quantity = 0;
                if (Packages != null)
                {
                    Package = Packages.FirstOrDefault();
                }
                if (SubPackages != null)
                {
                    SubPackage = SubPackages.FirstOrDefault();
                }


                LoadModelsByStockHelper(packageQuantities);
                PopulateStockPackage(stockPackages);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
                
        public bool CanMoveUp()
        {
            return CanBeMovedUp;
        }
        public bool CanMoveDown()
        {
            return CanBeMovedDown;
        }

        public bool CanBeMovedUp
        {
            get { return _canBeMovedUp; }
            set
            {
                _canBeMovedUp = value;
                if (UpCommand != null)
                {
                    UpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public bool CanBeMovedDown
        {
            get { return _canBeMovedDown; }
            set
            {
                _canBeMovedDown = value;
                if (DownCommand != null)
                {
                    DownCommand.RaiseCanExecuteChanged();
                }
            }
        }

        protected override void OnRemoveCommand()
        {
            try
            {
                int index = TargetCollection.CurrentPosition;
                if (index > -1)
                {
                    collectionManager.Collection.RemoveAt(index);
                    ReAssignRank();
                    RefreshModelCollection();
                }
                else
                {
                    Utility.DisplayMessage("No selection made! Please select a row for removal");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ReAssignRank()
        {
            try
            {
                for (int i = 0; i < collectionManager.Collection.Count; i++)
                {
                    collectionManager.Collection[i].Rank = i + 1;
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnUpCommand()
        {
            try
            {
                int currentIndex = TargetCollection.CurrentPosition;
                ObservableCollection<PackageRelationship> packageQuantities = (ObservableCollection<PackageRelationship>)TargetCollection.SourceCollection;
                SwapPackageQuantity(packageQuantities, currentIndex, currentIndex - 1);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void OnDownCommand()
        {
            try
            {
                int currentIndex = TargetCollection.CurrentPosition;

                //PackageRelationship packageRelationship = TargetCollection.CurrentItem as PackageRelationship;
                //int currentIndex = packageRelationship.Rank > 0 ? (int)packageRelationship.Rank : TargetCollection.CurrentPosition;

                ObservableCollection<PackageRelationship> packageQuantities = (ObservableCollection<PackageRelationship>)TargetCollection.SourceCollection;
                SwapPackageQuantity(packageQuantities, currentIndex, currentIndex + 1);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SwapPackageQuantity(ObservableCollection<PackageRelationship> packageQuantities, int currentIndex, int nextIndex)
        {
            try
            {
                PackageRelationship selectedPackageQuantity = packageQuantities[currentIndex];
                PackageRelationship nextPackageQuantity = packageQuantities[nextIndex];

                //long selectedRank = selectedPackageQuantity.Rank;
                //long nextRank = nextPackageQuantity.Rank;

                long selectedRank = currentIndex + 1;
                long nextRank = nextIndex + 1;

                ObservableCollection<PackageRelationship> newPackageQuantities = new ObservableCollection<PackageRelationship>();
                for (int i = 0; i < packageQuantities.Count; i++)
                {
                    if (i == currentIndex)
                    {
                        nextPackageQuantity.Rank = selectedRank;
                        newPackageQuantities.Add(nextPackageQuantity);
                    }
                    else if (i == nextIndex)
                    {
                        selectedPackageQuantity.Rank = nextRank;
                        newPackageQuantities.Add(selectedPackageQuantity);
                    }
                    else
                    {
                        packageQuantities[i].Rank = i + 1;
                        newPackageQuantities.Add(packageQuantities[i]);
                    }
                }

                collectionManager.Collection = newPackageQuantities;
                SetCurrentTargetCollection(newPackageQuantities);
                //TargetCollection = new ListCollectionView(collectionManager.Collection);

                UpdateViewState(Edit.Mode.Adding);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //protected override void ClearView()
        //{
        //    try
        //    {
        //        TargetModel = new PackageRelationship();
        //        base.ClearTargetCollection();

        //        base.LoadAll();
        //        if (Packages != null)
        //        {
        //            Package = Packages.FirstOrDefault();
        //        }
        //        if (SubPackages != null)
        //        {
        //            SubPackage = SubPackages.FirstOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

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
                TargetModel = new PackageRelationship();
                base.ClearTargetCollection();
                SetTotalItemCount();

                if (Packages != null)
                {
                    Package = Packages.FirstOrDefault();
                }
                if (SubPackages != null)
                {
                    SubPackage = SubPackages.FirstOrDefault();
                }
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
                else if (Package == null || Package.Id == -1)
                {
                    Utility.DisplayMessage("Please select package!");
                    return false;
                }
                else if (Package.Package.Id == 0)
                {
                    Utility.DisplayMessage("'" + Package.Package.Name + "' can only be selected for Sub Package. Please modify.");
                    return false;
                }
                else if (SubPackage == null || SubPackage.Id == -1)
                {
                    if (Packages != null && Packages.Count > 0)
                    {
                        List<StockPackage> packages = Packages.Where(s => s.Id > 0).ToList();
                        if (packages != null && packages.Count > 0)
                        {
                            if (packages.Count > 1)
                            {
                                Utility.DisplayMessage("No Sub Package selected! Please select sub-package.");
                                return false;
                            }
                        }
                    }
                }
                //else if (SubPackage == null || SubPackage.Id == -1)
                //{
                //    ObservableCollection<StockPackage> stockPackages = (ObservableCollection<StockPackage>)Packages.SourceCollection;
                //    if (stockPackages != null && stockPackages.Count > 0)
                //    {
                //        List<StockPackage> packages = stockPackages.Where(s => s.Id > 0).ToList();
                //        if (packages != null && packages.Count > 0)
                //        {
                //            if (packages.Count > 1)
                //            {
                //                Utility.DisplayMessage("No Sub Package selected! Please select sub-package.");
                //                return false;
                //            }
                //        }
                //    }
                //}
                else if (Package.Package.Name == SubPackage.Package.Name)
                {
                    Utility.DisplayMessage("Sub-package cannot be the same as package! Please modify.");
                    return false;
                }
                else if (TargetModel.Quantity == 0)
                {
                    Utility.DisplayMessage("Please enter quantity!");
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
        protected bool IncompleteUserInput(ObservableCollection<PackageRelationship> models)
        {
            try
            {
                if (models == null)
                {
                    Utility.DisplayMessage("No item to save!");
                    return true;
                }
                else if (RelationshipNotSetForAllPackages(models))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool RelationshipNotSetForAllPackages(ObservableCollection<PackageRelationship> models)
        {
            try
            {
                if (models.Count != (Packages.Count - 2))
                {
                    Utility.DisplayMessage("Relationship for one or more package(s) has not been set! Please create relationship for all available " + Stock.Name + " packages.");
                    return true;
                }

                return false;
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
                    IEnumerable<PackageRelationship> packageQuantities = (IEnumerable<PackageRelationship>)TargetCollection.SourceCollection;

                    foreach (PackageRelationship packageQuantity in TargetCollection)
                    {
                        if (packageQuantity.Package.Package.Name == Package.Package.Name)
                        {
                            Utility.DisplayMessage("Package [ " + Package.Package.Name + " ] already exist! Please change");
                            return true;
                        }
                        else if ((packageQuantity.Package.Package.Name == Package.Package.Name) && (packageQuantity.SubPackage.Package.Name == SubPackage.Package.Name))
                        {
                            Utility.DisplayMessage(Package.Package.Name + " and " + SubPackage.Package.Name + " already exist! Please change package or sub-package to continue");
                            return true;
                        }
                        else if (packageQuantities.Where(pq => pq.Package.Package.Name == packageQuantity.Package.Package.Name).Count() > 1)
                        {
                            Utility.DisplayMessage("Multiple entry of " + Package.Package.Name + " detected! Please change package or sub-package to continue");
                            return true;
                        }
                        else if (packageQuantities.Where(pq => pq.SubPackage.Package.Name == packageQuantity.SubPackage.Package.Name).Count() > 1)
                        {
                            Utility.DisplayMessage("Multiple entry of " + packageQuantity.SubPackage.Package.Name + " detected! Please change package or sub-package to continue");
                            return true;
                        }
                        else if (packageQuantities.Where(pq => pq.Package.Package.Name == SubPackage.Package.Name).Count() >= 1)
                        {
                            Utility.DisplayMessage(SubPackage.Package.Name + " already exist as a Package on the list, and cannot be set as a sub-package at this time! Please change package or sub-package to continue");
                            return true;
                        }



                        //else if (packageQuantities.Where(pq => pq.Package.Package.Id == packageQuantity.Package.Package.Id).Count() > 1)
                        //{
                        //    Utility.DisplayMessage("Multiple entry of " + Package.Package.Name + " detected! Please change package or sub-package to continue");
                        //    return true;
                        //}
                        //else if (packageQuantities.Where(pq => pq.SubPackage.Package.Id == packageQuantity.SubPackage.Package.Id).Count() > 1)
                        //{
                        //    Utility.DisplayMessage("Multiple entry of " + packageQuantity.SubPackage.Package.Name + " detected! Please change package or sub-package to continue");
                        //    return true;
                        //}
                        //else if (packageQuantities.Where(pq => pq.Package.Package.Id == SubPackage.Package.Id).Count() >= 1)
                        //{
                        //    Utility.DisplayMessage(SubPackage.Package.Name + " already exist as a Package on the list, and cannot be set as a sub-package at this time! Please change package or sub-package to continue");
                        //    return true;
                        //}
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override PackageRelationship GetNewModel()
        {
            try
            {
                PackageRelationship packageRelationship = new PackageRelationship();
                StockPackage stockPackage = new StockPackage();
                Package package = new Package();

                packageRelationship.Package = new StockPackage();
                packageRelationship.Package.Package = new Package();
                packageRelationship.SubPackage = new StockPackage();
                packageRelationship.SubPackage.Package = new Package();

                packageRelationship.Package.Stock = Stock;
                packageRelationship.Package.Id = Package.Id;
                packageRelationship.Package.Package.Name = Package.Package.Name;

                if (SubPackage != null && SubPackage.Id > 0)
                {
                    packageRelationship.SubPackage.Id = SubPackage.Id;
                    packageRelationship.SubPackage.Package.Name = SubPackage.Package.Name;
                    packageRelationship.Quantity = TargetModel.Quantity;
                }
                else
                {
                    packageRelationship.Quantity = 1;
                }

                packageRelationship.Rank = Convert.ToInt16(collectionManager.Collection.Count + 1);
                packageRelationship.Date = Utility.GetDate();

                return packageRelationship;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private void LoadAllStockPackageBy(Stock stock)
        //{
        //    try
        //    {
        //        using(_worker = new BackgroundWorker())
        //        {
        //            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllStockPackageByCompleted);
        //            _worker.DoWork += (s, e) =>
        //                {
        //                    e.Result = _stockPackageService.LoadByStock(stock);
        //                };
        //            _worker.RunWorkerAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        private void OnLoadAllStockPackageByCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    List<StockPackage> stockPackages = e.Result as List<StockPackage>;
                    PopulateStockPackage(stockPackages);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStockPackage(List<StockPackage> stockPackages)
        {
            try
            {
                if (stockPackages == null)
                {
                    stockPackages = new List<StockPackage>();
                }

                if (stockPackages.Count > 0)
                {
                    stockPackages.Insert(0, new StockPackage() { Id = -1, Package = new Package() { Id = -1, Name = "<< Select Package >>" } });
                }

                _dispatcher.Invoke(() =>
                {
                    Packages = new ObservableCollection<StockPackage>(stockPackages);
                    SubPackages = new ObservableCollection<StockPackage>(stockPackages);
                    SubPackage = SubPackages.FirstOrDefault();
                    Package = Packages.FirstOrDefault();
                });
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
                TargetModel.Date = Utility.GetDate();
                List<PackageRelationship> models = SetModel();

                if (IncompleteUserInput(models))
                {
                    return;
                }

                bool done = false;
                if (ModelExist)
                {
                    if (StockPackageRelationship == null || StockPackageRelationship.Id <= 0)
                    {
                        Utility.DisplayMessage("Stock Package Relationship cannot be null! Please try again, but contact your system administrator after three unsuccessful trials.");
                        return;
                    }
                    
                    StockPackageRelationship.Stock = Stock;
                    StockPackageRelationship.DateSet = Utility.GetDate();
                    StockPackageRelationship.SetBy = Utility.LoggedInUser;
                    StockPackageRelationship.Relationships = models;
                    done = _businessFacade.ModifyStockPackageRelationship(StockPackageRelationship);
                }
                else
                {
                    StockPackageRelationship stockPackageRelationship = new StockPackageRelationship();
                    stockPackageRelationship.Stock = Stock;
                    stockPackageRelationship.DateSet = Utility.GetDate();
                    stockPackageRelationship.SetBy = Utility.LoggedInUser;
                    stockPackageRelationship.Relationships = models;

                    done = _businessFacade.AddStockPackageRelationship(stockPackageRelationship);
                }

                SaveCompleted(done);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override sealed void UpdateViewState(Edit.Mode uiState)
        {
            try
            {
                int index = 0;
                int itemCount = 0;
                base.UpdateViewState(uiState);
                //CanDeleteStockPackages = Stock == null || Stock.Id <= 0 ? false : true;

                if (TargetCollection != null)
                {
                    index = TargetCollection.CurrentPosition;

                    //ObservableCollection<PackageRelationship> packageRelationships = (ObservableCollection<PackageRelationship>)TargetCollection.SourceCollection;
                    //if (packageRelationships != null)
                }

                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            CanBeMovedUp = false;
                            CanBeMovedDown = false;

                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            CanBeMovedUp = false;
                            CanBeMovedDown = false;

                            if (itemCount == 0)
                            {
                                CanBeMovedUp = false;
                                CanBeMovedDown = false;
                            }

                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            itemCount = collectionManager.Collection.Count - 1;

                            if (itemCount == 0)
                            {
                                CanBeMovedUp = false;
                                CanBeMovedDown = false;
                            }
                            else if (index == itemCount && itemCount > 0)
                            {
                                CanBeMovedUp = true;
                                CanBeMovedDown = false;
                            }
                            else if (index < itemCount && index > 0)
                            {
                                CanBeMovedUp = true;
                                CanBeMovedDown = true;
                            }
                            else if (index == 0)
                            {
                                CanBeMovedUp = false;
                                CanBeMovedDown = true;
                            }
                            else
                            {
                                CanBeMovedUp = false;
                                CanBeMovedDown = false;
                            }

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }





       
    }
}
