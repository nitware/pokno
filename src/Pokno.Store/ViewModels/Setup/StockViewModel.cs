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

using Microsoft.Practices.Unity;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.ViewModel;
using System.ComponentModel;
using Pokno.Store.Services;
using Pokno.Infrastructure.Models;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using Pokno.Infrastructure.Events;
using Pokno.Model;
using Pokno.Infratructure.Services;
using Prism.Events;
using System.Collections.ObjectModel;

namespace Pokno.Store.ViewModels
{
    public class StockViewModel : SetupViewModelBase<Stock>
    {
        private StockType _stockType;
        private ObservableCollection<StockType> _stockTypes;
        private ISetupService<StockType> _stockTypeService;

        private BackgroundWorker _worker;

        public StockViewModel(ISetupService<Stock> _service, ISetupService<StockType> stockTypeService, IEventAggregator eventAggregator)
            : base(_service)
        {
            _modelName = "Stock";
            _stockTypeService = stockTypeService;
            
            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.CurrentCultureIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.CurrentCultureIgnoreCase) && l.Id != Model.Id;
            
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public string TabCaption
        {
            get { return _modelName; }
        }

        private bool IsView(UI.StockSetup payload)
        {
            return payload == UI.StockSetup.Product;
        }
       
        public ObservableCollection<StockType> StockTypes
        {
            get { return _stockTypes; }
            set
            {
                _stockTypes = value;
                base.OnPropertyChanged("StockTypes");
            }
        }
        public StockType StockType
        {
            get { return _stockType; }
            set
            {
                _stockType = value;
                base.OnPropertyChanged("StockType");
            }
        }

        protected override void OnSaveCommand()
        {
            try
            {
                if (StockType == null || StockType.Id <= 0)
                {
                    Utility.DisplayMessage("Please select Stock Type!");
                    return;
                }

                Model.Type = StockType;
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

        protected override void Clear()
        {
            try
            {
                base.Clear();
                if (StockTypes != null)
                {
                    StockType = StockTypes.FirstOrDefault();
                }
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
                UpdateViewState(Edit.Mode.Adding);
                Model = new Stock();

                if (Models != null)
                {
                    Models.MoveCurrentTo(null);
                }

                LoadAllStockTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                        List<Stock> stocks = _service.LoadAll();
                        List<StockType> stockTypes = _stockTypeService.LoadAll();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["stockTypes"] = stockTypes;
                        dictionary["stocks"] = stocks;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }


                //base.LoadAll();
                //LoadAllStockTypes();
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
                    List<StockType> stockTypes = (List<StockType>)dictionary["stockTypes"];
                    List<Stock> stocks = (List<Stock>)dictionary["stocks"];
                                        
                    base.OnLoadAllCompletetedHelper(stocks);
                    PopulateStockType(stockTypes);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStockType(List<StockType> stockTypes)
        {
            try
            {
                if (stockTypes == null)
                {
                    stockTypes = new List<StockType>();
                }
                if (stockTypes.Count > 0)
                {
                    stockTypes.Insert(0, new StockType() { Id = 0, Name = "<< Select Type >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    StockTypes = new ObservableCollection<StockType>(stockTypes);
                    StockType = StockTypes.FirstOrDefault();
                });
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllStockTypes()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllStockTypesCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _stockTypeService.LoadAll();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadAllStockTypesCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    List<StockType> stockTypes = e.Result as List<StockType>;
                    PopulateStockType(stockTypes);
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
                            Model = Models.CurrentItem as Stock;
                            if (StockTypes != null && Model.Type != null)
                            {
                                StockType = StockTypes.Where(t => t.Id == Model.Type.Id).SingleOrDefault();
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
