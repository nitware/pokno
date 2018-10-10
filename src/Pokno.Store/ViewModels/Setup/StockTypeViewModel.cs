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

using Pokno.Infrastructure.ViewModel;
using Microsoft.Practices.Unity;
using Pokno.Infrastructure.Interfaces;
using Pokno.Store.Services;
using System.ComponentModel;
using System.Windows.Data;
using Pokno.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using Pokno.Infrastructure.Events;
using Pokno.Model;
using Prism.Events;
using Pokno.Service;
using System.Collections.ObjectModel;

namespace Pokno.Store.ViewModels
{
    public class StockTypeViewModel : SetupViewModelBase<StockType>
    {
        private StockCategory _stockCategory;
        private ObservableCollection<StockCategory> _stockCategories;
        private readonly StockTypeService _stockTypeService;

        private BackgroundWorker _worker;

        public StockTypeViewModel(IBusinessFacade businessFacade, ISetupService<StockType> service, IEventAggregator eventAggregator)
            : base(service)
        {
            _modelName = "Stock Type";
            _stockTypeService = new StockTypeService(businessFacade);

            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;
            
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public string TabCaption
        {
            get { return _modelName; }
        }

        public ObservableCollection<StockCategory> StockCategories
        {
            get { return _stockCategories; }
            set
            {
                _stockCategories = value;
                base.OnPropertyChanged("StockCategories");
            }
        }
        public StockCategory StockCategory
        {
            get { return _stockCategory; }
            set
            {
                _stockCategory = value;
                base.OnPropertyChanged("StockCategory");
            }
        }

        private bool IsView(UI.StockSetup payload)
        {
            return payload == UI.StockSetup.Type;
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
                        List<StockType> stockTypes = _service.LoadAll();
                        List<StockCategory> stockCategories = _stockTypeService.LoadAllStockCategories();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stockCategories"] = stockCategories;
                        dictionary["stockTypes"] = stockTypes;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
                
                //base.LoadAll();
                //LoadAllStockCategories();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadAllStockCategories()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllStockCategoriesCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _stockTypeService.LoadAllStockCategories();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadAllStockCategoriesCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    List<StockCategory> stockCategories = e.Result as List<StockCategory>;
                    PopulateStockCategory(stockCategories);
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

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    List<StockCategory> stockCategories = (List<StockCategory>)dictionary["stockCategories"];
                    List<StockType> stockTypes = (List<StockType>)dictionary["stockTypes"];
                                        
                    base.OnLoadAllCompletetedHelper(stockTypes);
                    PopulateStockCategory(stockCategories);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStockCategory(List<StockCategory> stockCategories)
        {
            try
            {
                if (stockCategories == null)
                {
                    stockCategories = new List<StockCategory>();
                }

                if (stockCategories.Count > 0)
                {
                    stockCategories.Insert(0, new StockCategory() { Id = 0, Name = "<< Select Category >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    StockCategories = new ObservableCollection<StockCategory>(stockCategories);
                    StockCategory = StockCategories.FirstOrDefault();
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
                if (StockCategory == null || StockCategory.Id <= 0)
                {
                    Utility.DisplayMessage("Please select a Stock Category!");
                    return;
                }

                Model.Category = StockCategory;
                if (base.InvalidEntry(Model.Name))
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

        protected override void OnClearCommand()
        {
            try
            {
                Model = new StockType();
                UpdateViewState(Edit.Mode.Adding);
                
                if (Models != null)
                {
                    Models.MoveCurrentTo(null);
                }

                LoadAllStockCategories();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected override void Clear()
        {
            try
            {
                base.Clear();
                if (StockCategories != null)
                {
                    StockCategory = StockCategories.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected override void LoadAllHelper()
        {
            try
            {
                if (Models != null)
                {
                    Models.CurrentChanged += (sc, ea) =>
                    {
                        if (Models.CurrentItem != null)
                        {
                            Model = Models.CurrentItem as StockType;
                            if (StockCategories != null && Model.Category != null)
                            {
                                StockCategory = StockCategories.Where(t => t.Id == Model.Category.Id).SingleOrDefault();
                                UpdateViewState(Edit.Mode.Editing);
                            }
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }


       
        

    }

}
