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

using Prism.Commands;
using System.Windows.Threading;
using System.ComponentModel;
using Pokno.Infrastructure;
using System.Windows.Data;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using Pokno.Service;

namespace Pokno.Infrastructure.ViewModel
{
    public abstract class SetupViewModelBase<T> : BaseApplicationViewModel where T : class, new()
    {
        protected Dispatcher _dispatcher;
        private BackgroundWorker _worker;

        private string _saveSuccessfulMessage;
        private string _saveFailedMessage;
        private string _modifySuccessfulMessage;
        private string _modifyFailedMessage;
        private string _removeSuccessfulMessage;
        private string _removeFailedMessage;

        private string _ActionSuccessfulMessage;
        private string _ActionFailedMessage;

        protected string _modelName;
        private string _recordCount;
        
        protected ISetupService<T> _service;
        protected ListCollectionView _models;
        protected List<T> _returnedModels;
        protected T _model;

        private bool _isBusy;
        private bool _canSaveItem;
        private bool _canRemoveItem;
        private bool _canClearScreen;

        protected Func<T, bool> _addSelector;
        protected Func<T, bool> _modifySelector;

        protected string NAME = "Name";

        public SetupViewModelBase(ISetupService<T> service) 
        {
            _service = service;
            RecordCount = RecordCountLabel + "0";

            ViewState = Edit.Mode.Loaded;
            _dispatcher = Application.Current.Dispatcher;
            
            Model = new T();
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSave);
            ClearCommand = new DelegateCommand(OnClearCommand, CanClear);
            RemoveCommand = new DelegateCommand(OnRemoveCommand, CanRemove);

            UpdateViewState(ViewState);
        }

        private void SetMessages()
        {
            _saveSuccessfulMessage = _modelName + " has been added successfully";
            _saveFailedMessage = _modelName + " creation failed! Please try again";
            _modifySuccessfulMessage = _modelName + " has been modified successfully";
            _modifyFailedMessage = _modelName + " modification failed! Please try again";
            _removeSuccessfulMessage = _modelName + " has been removed successfully";
            _removeFailedMessage = _modelName + " removal failed! Please try again";
        }

        public Edit.Mode ViewState { get; set; }
        public DelegateCommand SaveCommand { get; protected set; }
        public DelegateCommand RemoveCommand { get; protected set; }
        public DelegateCommand ClearCommand { get; protected set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy)
                {
                    CanSaveItem = false;
                    CanRemoveItem = false;
                }

                base.OnPropertyChanged("IsBusy");
            }
        }
        public bool CanSaveItem
        {
            get { return _canSaveItem; }
            set
            {
                _canSaveItem = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public bool CanRemoveItem
        {
            get { return _canRemoveItem; }
            set
            {
                _canRemoveItem = value;
                RemoveCommand.RaiseCanExecuteChanged();
            }
        }
        public bool CanClearScreen
        {
            get { return _canClearScreen; }
            set
            {
                _canClearScreen = value;
                ClearCommand.RaiseCanExecuteChanged();
            }
        }
       
        protected bool CanSave()
        {
            return CanSaveItem;
        }
        protected bool CanRemove()
        {
            return CanRemoveItem;
        }
        protected bool CanClear()
        {
            return CanClearScreen;
        }

        public string RecordCountLabel
        {
            get { return "Record Count: "; }
        }
        public string RecordCount
        {
            get { return _recordCount; }
            set
            {
                _recordCount = value;
                base.OnPropertyChanged("RecordCount");
            }
        }
        public T Model
        {
            get { return _model; }
            set
            {
                _model = value;
                base.OnPropertyChanged("Model");


            }
        }
        public List<T> ReturnedModels
        {
            get { return _returnedModels; }
            set
            {
                _returnedModels = value;
                base.OnPropertyChanged("ReturnedModels");
            }
        }

        public ListCollectionView Models
        {
            get { return _models; }
            set
            {
                _models = value;
                base.OnPropertyChanged("Models");
            }
        }

        protected virtual void OnClearCommand()
        {
            try
            {
                ClearHelper();
                UpdateViewState(Edit.Mode.Loaded);
            
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        protected virtual void Clear()
        {
            try
            {
                LoadAll();
                ClearHelper();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void ClearHelper()
        {
            try
            {
                Model = new T();
                if (Models != null)
                {
                    Models.MoveCurrentTo(null);
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual void LoadAll()
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllCompleteted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _service.LoadAll();
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnLoadAllCompleteted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<T> models = e.Result as List<T>;
                OnLoadAllCompletetedHelper(models);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void OnLoadAllCompletetedHelper(List<T> models)
        {
            try
            {
                _dispatcher.Invoke
                          (() =>
                          {
                              if (models != null)
                              {
                                  ReturnedModels = models;

                                  Models = new ListCollectionView(new ObservableCollection<T>(models));
                                  RecordCount = RecordCountLabel + models.Count;
                                  Models.MoveCurrentTo(null);

                                  LoadAllHelper();
                              }
                              else
                              {
                                  RecordCount = RecordCountLabel + 0;
                              }
                          });
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
                 
        protected virtual void LoadAllHelper()
        {
            try
            {
                if (Models != null)
                {
                    Models.CurrentChanged += (s, e) =>
                    {
                        if (Models.CurrentItem != null)
                        {
                            Model = Models.CurrentItem as T;
                            UpdateViewState(Edit.Mode.Editing);
                        }
                        else
                        {
                            Model = new T();
                        }
                    };
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected void OnRemoveCommand()
        {
            try
            {
                SetMessages();
                if (ViewState == Edit.Mode.Editing)
                {
                    IsBusy = true;
                    SetActionMessage(_removeSuccessfulMessage, _removeFailedMessage);
                    
                    using (_worker = new BackgroundWorker())
                    {
                        _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnActionCommandCompleted);
                        _worker.DoWork += (s, e) =>
                            {
                                e.Result = _service.Remove(Model);
                            };
                        _worker.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                CanRemoveItem = true;
                Utility.DisplayMessage(ex.Message);
            }
        }
  
        protected virtual void OnSaveCommand()
        {
            try
            {
                SetMessages();

                IsBusy = true;
                bool done = false;

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnActionCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            if (ViewState == Edit.Mode.Editing)
                            {
                                SetActionMessage(_modifySuccessfulMessage, _modifyFailedMessage);
                                done = _service.Modify(Model);
                            }
                            else
                            {
                                SetActionMessage(_saveSuccessfulMessage, _saveFailedMessage);
                                done = _service.Save(Model);
                            }

                            e.Result = done;
                        };
                    _worker.RunWorkerAsync();
                   
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                CanSaveItem = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnActionCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;

                if (e.Error != null)
                {
                    if (ViewState == Edit.Mode.Editing)
                    {
                        CanSaveItem = true;
                        CanRemoveItem = true;
                    }
                    else
                    {
                        CanSaveItem = true;
                    }

                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                bool done = false;
                if (e.Result != null)
                {
                    done = (bool)e.Result;
                }

                ActionCompleted(done);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        private void ActionCompleted(bool done)
        {
            try
            {
                if (done)
                {
                    Clear();
                    UpdateViewState(Edit.Mode.Adding);
                    Utility.DisplayMessage(_ActionSuccessfulMessage);
                }
                else
                {
                    Utility.DisplayMessage(_ActionFailedMessage);
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        protected virtual bool InvalidEntry(string nameProperty)
        {
            try
            {
                string message = "'" + nameProperty + "' already exist in the system! Operation has been aborted.";
                
                if (Model != null)
                {
                    if (string.IsNullOrEmpty(nameProperty))
                    {
                        Utility.DisplayMessage("Please enter " + _modelName + " name!");
                        return true;
                    }
                }
                else
                {
                    Utility.DisplayMessage("Base object is empty! Please contact your system administrator");
                    return true;
                }

                if (ViewState == Edit.Mode.Editing)
                {
                    if (_modifySelector != null)
                    {
                        if (ModelAlreadyExist(_modifySelector))
                        {
                            Utility.DisplayMessage(message);
                            return true;
                        }
                    }
                    else
                    {
                        Utility.DisplayMessage("Modify Selector cannot be null! Please contact your system administrator");
                        return true;
                    }
                }
                else 
                {
                    if (_addSelector != null)
                    {
                        if (ModelAlreadyExist(_addSelector))
                        {
                            Utility.DisplayMessage(message);
                            return true;
                        }
                    }
                    else
                    {
                        Utility.DisplayMessage("Add Selector cannot be null! Please contact your system administrator");
                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual ICollection<T> GetReturnedModels()
        {
            try
            {
                ICollection<T> collection = ReturnedModels;
                return collection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void UpdateViewState(Edit.Mode viewState)
        {
            ViewState = viewState;

            try
            {
                switch (viewState)
                {
                    case Edit.Mode.Adding:
                    case Edit.Mode.Loaded:
                        {
                            CanSaveItem = true;
                            CanRemoveItem = false;
                            CanClearScreen = false;

                            break;
                        }
                    case Edit.Mode.Editing:
                        {
                            CanSaveItem = true;
                            CanRemoveItem = true;
                            CanClearScreen = true;

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void SetActionMessage(string success, string failed)
        {
            _ActionSuccessfulMessage = success;
            _ActionFailedMessage = failed;
        }

        protected virtual bool ModelAlreadyExist(Func<T, bool> selector)
        {
            try
            {
                List<T> models = ReturnedModels;
                if (models != null && models.Count > 0)
                {
                    models = RemoveSpacesFromModelNamePropertyValue(models);

                    T model = models.Where(selector).SingleOrDefault();
                    if (model != null)
                    {
                        if (ViewState == Edit.Mode.Editing)
                        {
                            LoadAll();
                        }

                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual List<T> RemoveSpacesFromModelNamePropertyValue(List<T> models)
        {
            try
            {
                const string ID = "Id";
                

                List<T> newModels = new List<T>();
                foreach (T t in models)
                {
                    System.Reflection.PropertyInfo idPropertyInfo = t.GetType().GetProperty(ID);
                    System.Reflection.PropertyInfo namePropertyInfo = t.GetType().GetProperty(NAME);
                    if (idPropertyInfo == null || namePropertyInfo == null)
                    {
                        throw new NullReferenceException("Property Name specified does not exist in the supplied Model! Please contact your system administrator.");
                    }

                    object id = t.GetType().GetProperty(ID).GetValue(t, null);
                    string name = t.GetType().GetProperty(NAME).GetValue(t, null).ToString();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        name = name.Replace(" ", "").Trim();

                        T newModel = new T();
                        newModel.GetType().GetProperty(ID).SetValue(newModel, id);
                        newModel.GetType().GetProperty(NAME).SetValue(newModel, name);
                        newModels.Add(newModel);
                    }
                }

                return newModels;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
