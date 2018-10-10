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

using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Windows.Threading;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.Service;

namespace Pokno.Infrastructure.Models
{
    public abstract class ObservableCollectionManagerBase<T> : BaseApplicationViewModel
    {
        private bool _modelCanBeAdded;
        private bool _modelCanBeSaved;
        private bool _modelCanBeRemoved;
        private bool _modelCanBeCleared;
        
        private T _targetModel;
        private ListCollectionView _targetCollection;
        public ObservableCollectionManager<T> collectionManager;

        public ObservableCollectionManagerBase()
        {
            collectionManager = new ObservableCollectionManager<T>();
        }

        protected bool ModelExist { get; set; }
        public ICollectionView Models { get; set; }
        public DelegateCommand ClearCommand { get; protected set; }
        public DelegateCommand RemoveCommand { get; protected set; }
        public DelegateCommand SaveCommand { get; protected set; }
        public DelegateCommand AddCommand { get; protected set; }
        //public virtual DelegateCommand AddCommand { get; protected set; }

        public bool ModelCanBeAdded
        {
            get { return _modelCanBeAdded; }
            set
            {
                _modelCanBeAdded = value;
                if (AddCommand != null)
                {
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public bool ModelCanBeRemoved
        {
            get { return _modelCanBeRemoved; }
            set
            {
                _modelCanBeRemoved = value;
                if (RemoveCommand != null)
                {
                    RemoveCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public bool ModelCanBeSaved
        {
            get { return _modelCanBeSaved; }
            set
            {
                _modelCanBeSaved = value;
                if (SaveCommand != null)
                {
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public bool ModelCanBeCleared
        {
            get { return _modelCanBeCleared; }
            set
            {
                _modelCanBeCleared = value;
                if (ClearCommand != null)
                {
                    ClearCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public ListCollectionView TargetCollection
        {
            get { return _targetCollection; }
            set
            {
                _targetCollection = value;
                base.OnPropertyChanged("TargetCollection");
            }
        }

        public T TargetModel
        {
            get { return _targetModel; }
            set
            {
                _targetModel = value;
                base.OnPropertyChanged("TargetModel");
            }
        }

        public bool CanClear()
        {
            return ModelCanBeCleared;
        }
        public bool CanSave()
        {
            return ModelCanBeSaved;
        }
        public bool CanAdd()
        {
            return ModelCanBeAdded;
        }
        public bool CanRemove()
        {
            return ModelCanBeRemoved;
        }
        
        protected abstract T GetNewModel();

        protected void UpdateModels()
        {
            try
            {
                collectionManager.Collection.Add(GetNewModel());
                RefreshModelCollection();
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        public virtual void RefreshModelCollection()
        {
            try
            {
                ObservableCollection<T> currentModels = collectionManager.Collection;
                ObservableCollection<T> refreshedModels = collectionManager.Refresh(currentModels);

                SetCurrentTargetCollection(refreshedModels);
                              
                if (refreshedModels.Count > 0)
                {
                    UpdateViewState(Edit.Mode.Adding);
                }
                else
                {
                    UpdateViewState(Edit.Mode.Loaded);
                }               
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual void SetCurrentTargetCollection(ObservableCollection<T> refreshedModels)
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
                            SetCurrentTargetCollectionHelper();
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual void SetCurrentTargetCollectionHelper()
        {
            try
            {
                UpdateViewState(Edit.Mode.Selected);
            }
            catch(Exception)
            {
                throw;
            }
        }

        protected virtual void UpdateViewState(Edit.Mode uiState)
        {
            try
            {
                switch (uiState)
                {
                    case Edit.Mode.Loaded:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeSaved = false;
                            ModelCanBeRemoved = false;
                            ModelCanBeCleared = false;

                            break;
                        }
                    case Edit.Mode.Adding:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeSaved = true;
                            ModelCanBeRemoved = false;
                            ModelCanBeCleared = true;

                            break;
                        }
                    case Edit.Mode.Selected:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeSaved = true;
                            ModelCanBeRemoved = true;
                            ModelCanBeCleared = false;

                            break;
                        }
                    case Edit.Mode.Editing:
                        {
                            ModelCanBeAdded = true;
                            ModelCanBeRemoved = false;
                            ModelCanBeSaved = false;

                            if (TargetCollection != null)
                            {
                                ObservableCollection<T> models = (ObservableCollection<T>)TargetCollection.SourceCollection;
                                if (models != null && models.Count > 0)
                                {
                                    ModelCanBeCleared = true;
                                }
                                else
                                {
                                    ModelCanBeCleared = false;
                                }
                            }

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }
       
        protected virtual void ClearTargetCollection()
        {
            try
            {
                if (TargetCollection != null)
                {
                    if (collectionManager != null && collectionManager.Collection != null)
                    {
                        collectionManager.Collection.Clear();
                    }

                    ObservableCollection<T> models = (ObservableCollection<T>)TargetCollection.SourceCollection;

                    models.Clear();
                    TargetCollection = new ListCollectionView(models);
                    UpdateViewState(Edit.Mode.Loaded);
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected void IsModelExist(ObservableCollection<T> models)
        {
            try
            {
                if (models != null)
                {
                    ModelExist = models.Count > 0 ? true : false;
                }
                else
                {
                    ModelExist = false;
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
            }
        }

        protected virtual void DisplayMessage(string message, Pokno.Infrastructure.Models.Utility.MessageIcon? icon = null)
        {
            Utility.DisplayMessage(message);
        }
        



    }

}
