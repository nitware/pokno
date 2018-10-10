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

using Pokno.Infrastructure.Interfaces;
using System.Windows.Data;
using System.ComponentModel;
using Pokno.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using Pokno.Infrastructure.Events;
using System.Collections.ObjectModel;
using Pokno.Model;
using Prism.Events;
using Pokno.Service;
using Prism.Commands;

namespace Pokno.Infrastructure.ViewModels
{
    public class StockPricePopUpViewModel : CollectibleViewModelBase<StockPrice>
    {
        private Window PopUp;
        private BackgroundWorker _worker;

        private bool _isBusy;
        private bool _isAdding;
        private bool _isEditing;
        //private bool _modelCanBeEdited;
        private StockPrice _oldStockPrice;
        private bool _canDeleteStockPrices;
        private StockPackage _stockPackage;
        private ICollectionView _stockPackages;
        private ObservableCollection<StockPackage> _packages;
        private StockPackage _package;

        public StockPricePopUpViewModel(IBusinessFacade businessFacade, ICollectibleService<StockPrice> service, IEventAggregator eventAggregator)
            : base(service, businessFacade)
        {
            ModelName = "Stock Price";
            UpdateViewState(Edit.Mode.Loaded);

            OkCommand = new DelegateCommand(OnOkCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);
            SetPopUpCommand = new DelegateCommand<object>(OnSetPopUpCommand);
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanDelete);
            EditCommand = new DelegateCommand(OnEditCommand);

            OnInitialise(UI.StockSetup.Price);
        }
                   
        public DelegateCommand EditCommand { get; private set; }
        public DelegateCommand OkCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public ICommand SetPopUpCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

        public List<StockPrice> UpdatedPrices { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                base.OnPropertyChanged("IsBusy");

                if (_isBusy)
                {
                    ModelCanBeSaved = false;
                }
            }
        }
        public StockPrice OldStockPrice
        {
            get { return _oldStockPrice; }
            set
            {
                _oldStockPrice = value;
                base.OnPropertyChanged("OldStockPrice");
            }
        }
        public bool IsAdding
        {
            get { return _isAdding; }
            set
            {
                _isAdding = value;
                base.OnPropertyChanged("IsAdding");
            }
        }
        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                base.OnPropertyChanged("IsEditing");
            }
        }

        private void OnEditCommand()
        {
            try
            {
                bool modelCanBeEdited = false;
                if (TargetModel != null && OldStockPrice != null && OldStockPrice.StockPackage != null && Package != null && Package.Id > 0)
                {
                    modelCanBeEdited = TargetModel.SellingPrice == OldStockPrice.SellingPrice && TargetModel.CostPrice == OldStockPrice.CostPrice && Package.Id == OldStockPrice.StockPackage.Id;
                }
                if (modelCanBeEdited)
                {
                    DisplayMessage("No changes made to stock price!", Utility.MessageIcon.Exclamation);
                    return;
                }

                if (TargetModel == null)
                {
                    DisplayMessage("No selected item found to edit! Please make selection.", Utility.MessageIcon.Exclamation);
                    return;
                }
                else if (InvalidUserEntry())
                {
                    return;
                }

               


                ObservableCollection<StockPrice> stockPrices = (ObservableCollection<StockPrice>)TargetCollection.SourceCollection;

                long id = stockPrices != null ? stockPrices.Min(s => s.Id) : 0;
                foreach (StockPrice price in TargetCollection)
                {
                    if (price.Id == TargetModel.Id)
                    {
                        price.Id = id > 0 ? 0 : --id;

                        price.StockPackage = Package;
                        price.SellingPrice = TargetModel.SellingPrice;
                        price.CostPrice = TargetModel.CostPrice;
                        price.DateEntered = Utility.GetDate();

                        break;
                    }
                }

                if (Packages != null)
                {
                    Package = Packages.FirstOrDefault();
                }

                if (TargetModel != null)
                {
                    TargetModel.CostPrice = 0;
                    TargetModel.SellingPrice = 0;
                }
                if (TargetCollection != null)
                {
                    TargetCollection.MoveCurrentTo(null);
                }

                UpdateViewState(Edit.Mode.Adding);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        protected override List<StockPrice> SetModel()
        {
            try
            {
                ObservableCollection<StockPrice> sourceCollection = (ObservableCollection<StockPrice>)TargetCollection.SourceCollection;
                List<StockPrice> models = new List<StockPrice>(sourceCollection);
                if (models != null)
                {
                    foreach(StockPrice price in models)
                    {
                        price.DateEntered = Utility.GetDate();
                        if(price.Id > 0)
                        {
                            price.Id = 0;
                        }
                    }
                }

                return models;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OnSetPopUpCommand(object param)
        {
            PopUp = (Window)param;
        }
        private bool CanSetPopUp(object param)
        {
            return true;
        }
        private void OnOkCommand()
        {
            try
            {
                PopUp.DialogResult = true;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        private void OnCancelCommand()
        {
            try
            {
                PopUp.DialogResult = false;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
     
        private bool IsView(UI.StockSetup payload)
        {
            return payload == UI.StockSetup.Price;
        }
      
        public bool CanDeleteStockPrices
        {
            get { return _canDeleteStockPrices; }
            set
            {
                _canDeleteStockPrices = value;
                DeleteCommand.RaiseCanExecuteChanged();
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
        public StockPackage Package
        {
            get { return _package; }
            set
            {
                _package = value;
                base.OnPropertyChanged("Package");
            }
        }

        //public ICollectionView StockPackages
        //{
        //    get { return _stockPackages; }
        //    set
        //    {
        //        _stockPackages = value;
        //        base.OnPropertyChanged("StockPackages");
        //    }
        //}
        //public StockPackage StockPackage
        //{
        //    get { return _stockPackage; }
        //    set
        //    {
        //        _stockPackage = value;
        //        base.OnPropertyChanged("StockPackage");
        //    }
        //}
        public override Stock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                if (_stock != null && _stock.Id > 0)
                {
                    base.ClearTargetCollection();
                    LoadDataBy(_stock);
                }
                else
                {
                    ClearViewHelper();
                }
            }
        }

        public void OnInitialise(UI.StockSetup payload)
        {
            try
            {
                if (Stocks == null || Stocks.Count <= 0)
                {
                    base.LoadAll();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        protected override StockPrice GetNewModel()
        {
            try
            {
                Package package = new Package();
                StockPrice stockPrice = new StockPrice();
                StockPackage stockPackage = new StockPackage();
                
                stockPrice.StockPackage = new StockPackage();
                stockPrice.CurrentStockPrice = new CurrentStockPrice();
                stockPrice.StockPackage.Stock = new Stock();
                stockPrice.StockPackage.Package = new Package();

                stockPrice.StockPackage.Stock.Id = Stock.Id;
                stockPrice.StockPackage.Stock.Name = Stock.Name;
                stockPrice.StockPackage.Id = Package.Id;
                stockPrice.StockPackage.Package.Name = Package.Package.Name;
                stockPrice.CostPrice = TargetModel.CostPrice;
                stockPrice.SellingPrice = TargetModel.SellingPrice;
                stockPrice.DateEntered = Utility.GetDate();
                
                return stockPrice;
            }
            catch (Exception)
            {
                throw;
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
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        public void ClearViewHelper()
        {
            try
            {
                TargetModel = new StockPrice();
                base.ClearTargetCollection();
                SetTotalItemCount();

                Packages = new ObservableCollection<StockPackage>();
                Package = new StockPackage();


                //if (Packages != null)
                //{
                //    Package = Packages.FirstOrDefault();
                //}
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        public void ResetStockList()
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
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        protected override bool IsRequiredDetailsEntered()
        {
            try
            {
                if (InvalidUserEntry())
                {
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

        private bool InvalidUserEntry()
        {
            try
            {
                IEnumerable<StockPrice> prices = (IEnumerable<StockPrice>)TargetCollection.SourceCollection;
                if (Stock == null || Stock.Id == 0)
                {
                    DisplayMessage("Please select stock!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (Package == null || Package.Id <= 0)
                {
                    DisplayMessage("Please select package!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (TargetModel.CostPrice <= 0)
                {
                    DisplayMessage("Please enter cost price!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (TargetModel.SellingPrice <= 0)
                {
                    DisplayMessage("Please enter selling price!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (TargetModel.SellingPrice <= TargetModel.CostPrice)
                {
                    DisplayMessage("Selling price [ " + TargetModel.SellingPrice + " ] cannot be less than or equal to cost price [ " + TargetModel.CostPrice + " ]! Please modify", Utility.MessageIcon.Exclamation);
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }
    
        protected override bool IncompleteUserInput(List<StockPrice> models)
        {
            try
            {
                if (models == null)
                {
                    DisplayMessage("No item to save!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (PriceNotSetForAllPackages(models))
                {
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private bool PriceNotSetForAllPackages(List<StockPrice> prices)
        {
            try
            {
                if (Packages.Count - 1 != prices.Count)
                {
                    DisplayMessage("Price for one or more package(s) has not been set! Please set price for all available " + Stock.Name + " packages.", Utility.MessageIcon.Exclamation);
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
                //if (TargetModel != null && TargetModel.Id > 0)
                //{
                //    return false;
                //}

                if (TargetCollection != null)
                {
                    foreach (StockPrice stockPrice in TargetCollection)
                    {
                        if ((Package.Package.Name == stockPrice.StockPackage.Package.Name) && (Stock.Name == stockPrice.StockPackage.Stock.Name))
                        {
                            DisplayMessage(Package.Package.Name + " already exist for " + Stock.Name + "! Cannot add duplicate. Please change", Utility.MessageIcon.Exclamation);
                            return true;
                        }
                    }
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void LoadDataBy(Stock stock)
        {
            try
            {
                IsBusy = true;

                using(_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadDataByCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            List<StockPrice> prices = _service.LoadByStock(_stock);
                            List<StockPackage> stockPackages = _businessFacade.GetStockPackages(stock);
                            bool noStockPriceExistFor = !_businessFacade.NoStockPriceExistFor(Stock);

                            Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            dictionary["noStockPriceExistFor"] = noStockPriceExistFor;
                            dictionary["stockPackages"] = stockPackages;
                            dictionary["prices"] = prices;

                            e.Result = dictionary;
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                IsBusy = false;
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnLoadDataByCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    DisplayMessage(e.Error.Message, Utility.MessageIcon.Error);
                    return;
                }

                List<StockPrice> prices = null;
                List<StockPackage> stockPackages = null;
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    CanDeleteStockPrices = (bool)dictionary["noStockPriceExistFor"];
                    stockPackages = (List<StockPackage>)dictionary["stockPackages"];
                    prices = (List<StockPrice>)dictionary["prices"];
                }

                // clear user input section
                TargetModel.CostPrice = 0;
                TargetModel.SellingPrice = 0;
                if (Packages != null)
                {
                    Package = Packages.FirstOrDefault();
                }
                
                base.LoadModelsByStockHelper(prices);
                PopulateStockPackage(stockPackages);
            }
            catch(Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
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

                stockPackages = stockPackages.Where(sp => sp.Package.Id != 0).ToList();
                if (stockPackages.Count > 0)
                {
                    stockPackages.Insert(0, new StockPackage() { Package = new Package() { Name = "<< Select Package >>" } });
                }

                _dispatcher.Invoke(() =>
                {
                    Packages = new ObservableCollection<StockPackage>(stockPackages);
                    Package = Packages.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private bool CanDelete()
        {
            return CanDeleteStockPrices;
        }
        private bool NoSelectedStock()
        {
            try
            {
                if (Stock == null || Stock.Id <= 0)
                {
                    DisplayMessage("No stock selected! Please select stock", Utility.MessageIcon.Exclamation);
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

                MessageBoxResult response = Utility.DisplayMessage("This action will delete all stock prices saved for '" + Stock.Name + "'. Do you which to continue?", MessageBoxButton.YesNo);
                if (response == MessageBoxResult.No)
                {
                    return;
                }

                bool deleted = _businessFacade.DeleteStockPriceByStock(Stock);
                if (deleted)
                {
                    CanDeleteStockPrices = !_businessFacade.NoStockPriceExistFor(Stock);

                    ClearView();
                    DisplayMessage(ModelName + " have been successfully deleted", Utility.MessageIcon.Information);
                }
                else
                {
                    DisplayMessage(ModelName + " have not been deleted! Please try again", Utility.MessageIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        
        protected override sealed void UpdateViewState(Edit.Mode uiState)
        {
            try
            {
                base.UpdateViewState(uiState);

                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                    case Edit.Mode.Adding:
                    case Edit.Mode.Editing:
                        {
                            ModelCanBeAdded = Stock != null && Stock.Id > 0 ? true : false;
                            SetInputSectionButtonState(true);
                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            SetInputSectionButtonState(false);
                            break;
                        }
                }

                if (TargetCollection != null)
                {
                    ObservableCollection<StockPrice> models = (ObservableCollection<StockPrice>)TargetCollection.SourceCollection;
                    ModelCanBeCleared = models != null && models.Count > 0 ? true : false;

                    List<StockPrice> prices = models.Where(sp => sp.Id <= 0).ToList();
                    ModelCanBeSaved = prices != null && prices.Count > 0 ? true : false;

                }

            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void SetInputSectionButtonState(bool isAdding)
        {
            IsEditing = !isAdding;
            IsAdding = isAdding;
        }

        protected override void SetCurrentTargetCollection(ObservableCollection<StockPrice> refreshedModels)
        {
            try
            {
                TargetCollection = new ListCollectionView(refreshedModels);
                if (refreshedModels != null)
                {
                    TargetCollection.MoveCurrentTo(null);
                    TargetCollection.CurrentChanged += (s, e) =>
                    {
                        if (TargetCollection.CurrentItem != null)
                        {
                            StockPrice stockPrice = TargetCollection.CurrentItem as StockPrice;
                            TargetModel.SellingPrice = stockPrice.SellingPrice;
                            TargetModel.CostPrice = stockPrice.CostPrice;
                            TargetModel.Id = stockPrice.Id;

                            StoreExistingPrice(stockPrice);

                            if (Packages != null && Packages.Count > 0)
                            {
                                Package = Packages.Where(p => p.Id == stockPrice.StockPackage.Id).SingleOrDefault();
                            }

                            UpdateViewState(Edit.Mode.Selected);
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

       

        private void StoreExistingPrice(StockPrice stockPrice)
        {
            try
            {
                OldStockPrice = new StockPrice();
                OldStockPrice.StockPackage = new StockPackage();
                OldStockPrice.StockPackage = stockPrice.StockPackage;
                OldStockPrice.SellingPrice = stockPrice.SellingPrice;
                OldStockPrice.CostPrice = stockPrice.CostPrice;
                OldStockPrice.Id = stockPrice.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
            
        protected override sealed void DisplayMessage(string message, Pokno.Infrastructure.Models.Utility.MessageIcon? icon = null)
        {
            Utility.DisplayMessage(message, icon.GetValueOrDefault());
        }

        protected override void OnSaveCommand()
        {
            try
            {
                if (UpdatedPrices == null)
                {
                    DisplayMessage("Updated stock price container cannot be null! Please contact your system administrator.", Utility.MessageIcon.Exclamation);
                    return;
                }

                List<StockPrice> models = SetModel();
                if (IncompleteUserInput(models))
                {
                    return;
                }

                OnSaveCommandHelper(models);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnSaveCommandHelper(List<StockPrice> models)
        {
            try
            {
                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnSaveCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            bool done = false;
                            if (ModelExist)
                            {
                                done = _service.Modify(models);
                            }
                            else
                            {
                                done = _service.Save(models);
                            }

                            List<StockPrice> prices = null;
                            if (done)
                            {
                                UpdatedPrices.RemoveAll(p => p.StockPackage.Stock.Id == Stock.Id);
                                prices = _service.LoadByStock(Stock);
                            }

                            Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            dictionary["prices"] = prices;
                            dictionary["done"] = done;

                            e.Result = dictionary;
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                IsBusy = false;
                ModelCanBeSaved = true;
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnSaveCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    ModelCanBeSaved = true;
                    DisplayMessage(e.Error.Message, Utility.MessageIcon.Error);
                    return;
                }

                bool done = false;
                List<StockPrice> prices = null;
                Dictionary<string, object> dictionary = e.Result as  Dictionary<string, object>;
                if (dictionary != null)
                {
                    done = (bool)dictionary["done"];
                    prices = (List<StockPrice>)dictionary["prices"];
                }

                if (prices != null && prices.Count > 0)
                {
                    UpdatedPrices.AddRange(prices);
                }

                SaveCompleted(done);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }


        




    }

}
