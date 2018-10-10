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

namespace Pokno.Store.ViewModels
{
    public class StockPriceViewModel : CollectibleViewModelBase<StockPrice>
    {
        private BackgroundWorker _worker;

        private bool _canDeleteStockPrices;
        private StockPackage _stockPackage;
        private ICollectionView _stockPackages;
        private ObservableCollection<StockPackage> _packages;
        private StockPackage _package;

        public StockPriceViewModel(IBusinessFacade businessFacade, ICollectibleService<StockPrice> service, IEventAggregator eventAggregator)
            : base(service, businessFacade)
        {
            ModelName = "Stock Price";
            UpdateViewState(Edit.Mode.Loaded);

            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanDelete);
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public DelegateCommand DeleteCommand { get; private set; }
                
        private bool IsView(UI.StockSetup payload)
        {
            return payload == UI.StockSetup.Price;
        }
        public string TabCaption
        {
            get { return "Stock Price"; }
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

        public ICollectionView StockPackages
        {
            get { return _stockPackages; }
            set
            {
                _stockPackages = value;
                base.OnPropertyChanged("StockPackages");
            }
        }
        public StockPackage StockPackage
        {
            get { return _stockPackage; }
            set
            {
                _stockPackage = value;
                base.OnPropertyChanged("StockPackage");
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
                base.LoadAll();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override StockPrice GetNewModel()
        {
            try
            {
                StockPrice stockPrice = new StockPrice();
                StockPackage stockPackage = new StockPackage();
                Package package = new Package();

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
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void ClearViewHelper()
        {
            try
            {
                TargetModel = new StockPrice();
                base.ClearTargetCollection();
                SetTotalItemCount();

                if (Packages != null)
                {
                    Package = Packages.FirstOrDefault();
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
                IEnumerable<StockPrice> prices = (IEnumerable<StockPrice>)TargetCollection.SourceCollection;
                if (Stock == null || Stock.Id == 0)
                {
                    Utility.DisplayMessage("Please select stock!");
                    return false;
                }
                else if (Package == null || Package.Id == 0)
                {
                    Utility.DisplayMessage("Please select package!");
                    return false;
                }
                else if (TargetModel.CostPrice <= 0)
                {
                    Utility.DisplayMessage("Please enter cost price!");
                    return false;
                }
                else if (TargetModel.SellingPrice <= 0)
                {
                    Utility.DisplayMessage("Please enter selling price!");
                    return false;
                }
                else if (TargetModel.SellingPrice <= TargetModel.CostPrice)
                {
                    Utility.DisplayMessage("Selling price [ " + TargetModel.SellingPrice + " ] cannot be less than or equal to cost price [ " + TargetModel.CostPrice + " ]! Please modify");
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
        protected override bool IncompleteUserInput(List<StockPrice> models)
        {
            try
            {
                if (models == null)
                {
                    Utility.DisplayMessage("No item to save!");
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
                    Utility.DisplayMessage("Price for one or more package(s) has not been set! Please set price for all available " + Stock.Name + " packages.");
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
                    foreach (StockPrice stockPrice in TargetCollection)
                    {
                        if ((Package.Package.Name == stockPrice.StockPackage.Package.Name) && (Stock.Name == stockPrice.StockPackage.Stock.Name))
                        {
                            Utility.DisplayMessage(Package.Package.Name + " already exist for " + Stock.Name + "! Cannot add duplicate. Please change");
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
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadDataByCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
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
                Utility.DisplayMessage(ex.Message);
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
        protected override void OnSaveCommand()
        {
            try
            {
                TargetModel.DateEntered = Utility.GetDate();
                base.OnSaveCommand();
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
                base.UpdateViewState(uiState);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }



        


        




    }

}
