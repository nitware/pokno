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

using System.ComponentModel;
using System.Collections.ObjectModel;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Interfaces;
using System.Windows.Data;
using System.Windows.Threading;
using Pokno.Model;
using Pokno.Infratructure.Services;
using System.Collections.Generic;
using Prism.Commands;
using Pokno.Service;
using System.Linq;

namespace Pokno.Infrastructure.Models
{
    public abstract class CollectibleViewModelBase<T> : ObservableCollectionManagerBase<T> where T : class, new()
    {
        protected Dispatcher _dispatcher;
        private BackgroundWorker _worker;

        protected ICollectibleService<T> _service;
        protected readonly IBusinessFacade _businessFacade;
        private  ObservableCollection<Stock> _stocks;
        protected Stock _stock;
        private int _itemCount;
        private string _modelName;
        
        public CollectibleViewModelBase(ICollectibleService<T> service, IBusinessFacade businessFacade)
        {
            _service = service;
            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;

            TargetModel = new T();
            Initialize();
        }

        public virtual Stock Stock { get; set; }

        protected abstract bool IsRequiredDetailsEntered();
        protected abstract bool ModelAlreadyExist();
        protected abstract void ClearView();

        public int ItemCount
        {
            get { return _itemCount; }
            set
            {
                _itemCount = value;
                base.OnPropertyChanged("ItemCount");
            }
        }
        public string ModelName
        {
            get { return _modelName; }
            set
            {
                _modelName = value;
                base.OnPropertyChanged("ModelName");
            }
        }
        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                base.OnPropertyChanged("Stocks");
            }
        }
              
        private void Initialize()
        {
            try
            {
                ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
                RemoveCommand = new DelegateCommand(OnRemoveCommand, CanRemove);
                SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
                AddCommand = new DelegateCommand(OnAddCommand, CanAdd);

                SetTotalItemCount();

                //_stockService = new StockService();

                //UpdateViewState(Edit.Mode.Loaded);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual void LoadAll()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            e.Result = GetAllStockHelper();
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual List<Stock> GetAllStockHelper()
        {
            try
            {
                return _businessFacade.GetAllStockWithDependant();
                //return _businessFacade.GetAllStocks();
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void OnLoadAllCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    DisplayMessage(e.Error.Message);
                    return;
                }

                List<Stock> stocks = null;
                if (e.Result != null)
                {
                    stocks = e.Result as List<Stock>;
                }

                LoadAllStockHelper(stocks);
            }
            catch(Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected void LoadAllStockHelper(List<Stock> stocks)
        {
            try
            {
                if (stocks == null)
                {
                    stocks = new List<Stock>();
                }

                if (stocks.Count > 0)
                {
                    stocks.Insert(0, new Stock() { Name = "<< Select Stock >>", HasPackage = true, HasPackageRelationship = true, HasPrice = true });
                }

                _dispatcher.Invoke(() =>
                {
                    Stocks = new ObservableCollection<Stock>(stocks);
                    Stock = Stocks.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual void OnClearCommand()
        {
            try
            {
                ClearView();
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual void OnSaveCommand()
        {
            try
            {
                List<T> models = SetModel();
                if (IncompleteUserInput(models))
                {
                    return;
                }

                bool done = false;
                if (ModelExist)
                {
                    done = _service.Modify(models);
                }
                else
                {
                    done = _service.Save(models);
                }

                SaveCompleted(done);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual List<T> SetModel()
        {
            try
            {
                ObservableCollection<T> sourceCollection = (ObservableCollection<T>)TargetCollection.SourceCollection;
                List<T> models = new List<T>(sourceCollection);
                return models;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual bool IncompleteUserInput(List<T> models)
        {
            try
            {
                if (models == null || models.Count <= 0)
                {
                    DisplayMessage("No item to save!");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void OnRemoveCommand()
        {
            try
            {
                int index = TargetCollection.CurrentPosition;
                if (index > -1)
                {
                    collectionManager.Collection.RemoveAt(index);
                    RefreshModelCollection();
                }
                else
                {
                    DisplayMessage("No selection made! Please select a row for removal");
                }

                SetTotalItemCount();
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual void OnAddCommand()
        {
            try
            {
                if (!IsRequiredDetailsEntered())
                {
                    return;
                }
                //else if (ModelAlreadyExist())
                //{
                //    return;
                //}

                UpdateModels();

                SetTotalItemCount();
            }
            catch (Exception ex)
            {
                DisplayMessage("Error Occurred! " + ex.Message);
            }
        }

        protected void SaveCompleted(bool done)
        {
            try
            {
                SetTotalItemCount();

                if (done)
                {
                    ClearView();
                    DisplayMessage(ModelName + " have been successfully saved");
                }
                else
                {
                    DisplayMessage(ModelName + " have not been saved! Please try again");
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected void LoadModelsByStockHelper(List<T> models)
        {
            try
            {
                if (models == null || models.Count <= 0)
                {
                    models = new List<T>();
                }

                _dispatcher.Invoke(() =>
                {
                    ObservableCollection<T> oModels = new ObservableCollection<T>(models);

                    SetCurrentTargetCollection(oModels);
                    collectionManager.Collection = oModels;

                    SetTotalItemCount();
                    if (models != null)
                    {
                        if (models.Count > 0)
                        {
                            UpdateViewState(Edit.Mode.Editing);
                        }
                        else
                        {
                            UpdateViewState(Edit.Mode.Loaded);
                        }

                        IsModelExist(oModels);
                    }
                });
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected void SetTotalItemCount()
        {
            try
            {
                ObservableCollection<T> models = null;
                if (TargetCollection != null)
                {
                    models = (ObservableCollection<T>)TargetCollection.SourceCollection;
                }

                ItemCount = models == null ? 0 : models.Count;
            }
            catch(Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        



      

    }

}
