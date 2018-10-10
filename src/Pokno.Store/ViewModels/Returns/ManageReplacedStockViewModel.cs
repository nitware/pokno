using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Model.Model;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class ManageReplacedStockViewModel : BaseApplicationViewModel
    {
        private BackgroundWorker _worker;
        private IBusinessFacade _businessFacade;

        private bool _isBusy;
        private int _recordCount;
        private int _selectedItemCount;
        private ReturnedStockReplacement _untreatedReplacedStock;
        private ObservableCollection<ReturnedStockReplacement> _untreatedReplacedStocks;
        private ObservableCollection<ReplacedStockAction> _actions;
        private ReplacedStockAction _action;
        //private bool _itemIsReturnable;

        public ManageReplacedStockViewModel(IEventAggregator eventAggregator, IBusinessFacade businessFacade)
        {
            _businessFacade = businessFacade;

            ReturnCommand = new DelegateCommand(OnReturnCommand, CanReturnItem);
            eventAggregator.GetEvent<ReturnEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public DelegateCommand ReturnCommand { get; private set; }

        private bool IsView(UI.Returns ui)
        {
            return ui == UI.Returns.ManageReplacedItems;
        }

        public string TabCaption
        {
            get { return "Manage Replaced Stock"; }
        }
        //public bool ItemIsReturnable
        //{
        //    get { return _itemIsReturnable; }
        //    set
        //    {
        //        _itemIsReturnable = value;
        //        if (ReturnCommand != null)
        //        {
        //            ReturnCommand.RaiseCanExecuteChanged();
        //        }
        //    }
        //}
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                //if (_isBusy)
                //{
                //    ItemIsReturnable = false;
                //}

                base.OnPropertyChanged("IsBusy");
                ReturnCommand.RaiseCanExecuteChanged();
            }
        }
        public int RecordCount
        {
            get { return _recordCount; }
            set
            {
                _recordCount = value;
                base.OnPropertyChanged("RecordCount");
            }
        }
        public int SelectedItemCount
        {
            get { return _selectedItemCount; }
            set
            {
                _selectedItemCount = value;
                base.OnPropertyChanged("SelectedItemCount");
            }
        }
        
        public ObservableCollection<ReturnedStockReplacement> UntreatedReplacedStocks
        {
            get { return _untreatedReplacedStocks; }
            set
            {
                _untreatedReplacedStocks = value;
                base.OnPropertyChanged("UntreatedReplacedStocks");
            }
        }

        public ReturnedStockReplacement UntreatedReplacedStock
        {
            get { return _untreatedReplacedStock; }
            set
            {
                _untreatedReplacedStock = value;
                base.OnPropertyChanged("UntreatedReplacedStock");
            }
        }

        public ObservableCollection<ReplacedStockAction> Actions
        {
            get { return _actions; }
            set
            {
                _actions = value;
                base.OnPropertyChanged("Actions");
            }
        }

        public ReplacedStockAction Action
        {
            get { return _action; }
            set
            {
                _action = value;
                base.OnPropertyChanged("Action");
            }
        }

        private bool CanReturnItem()
        {
            if (IsBusy)
            {
                return false;
            }

            return CanReturnItemHelper();
        }

        private bool CanReturnItemHelper()
        {
            bool itemsSelected = false;

            try
            {
                if (UntreatedReplacedStocks != null && UntreatedReplacedStocks.Count > 0)
                {
                    List<ReturnedStockReplacement> selectedItems = UntreatedReplacedStocks.Where(s => s.IsSelected == true).ToList();
                    if (selectedItems != null && selectedItems.Count > 0)
                    {
                        foreach (ReturnedStockReplacement replacedStocks in selectedItems)
                        {
                            if (string.IsNullOrWhiteSpace(replacedStocks.ActionReason))
                            {
                                return false;
                            }
                        }

                        itemsSelected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }

            return itemsSelected;
        }
        private void OnInitialise(UI.Returns ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        List<ReplacedStockAction> actions = _businessFacade.GetAllReplacedStockAction();
                        List<ReturnedStockReplacement> untreatedReplacedStocks = _businessFacade.GetAllUntreatedStockReplacement();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["untreatedReplacedStocks"] = untreatedReplacedStocks;
                        dictionary["actions"] = actions;

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

        private void OnInitialiseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                List<ReplacedStockAction> actions = null;
                List<ReturnedStockReplacement> untreatedReplacedStocks = null;
                
                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    untreatedReplacedStocks = (List<ReturnedStockReplacement>)dictionary["untreatedReplacedStocks"];
                    actions = (List<ReplacedStockAction>)dictionary["actions"];
                }

                PopulateStockReturnReplacementActions(actions);
                LoadAllUntreatedStockReplacements(untreatedReplacedStocks);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateStockReturnReplacementActions(List<ReplacedStockAction> actions)
        {
            try
            {
                if (actions == null)
                {
                    actions = new List<ReplacedStockAction>();
                }

                
                Actions = new ObservableCollection<ReplacedStockAction>(actions);
                Action = Actions.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void LoadAllUntreatedStockReplacements(List<ReturnedStockReplacement> untreatedReplacedStocks)
        {
            try
            {
                if (untreatedReplacedStocks == null)
                {
                    untreatedReplacedStocks = new List<ReturnedStockReplacement>();
                }

                SelectedItemCount = 0;
                RecordCount = untreatedReplacedStocks.Count;
                foreach (ReturnedStockReplacement replacedStock in untreatedReplacedStocks)
                {
                    replacedStock.Actions = Actions;
                    replacedStock.Action = Actions.FirstOrDefault();

                    replacedStock.PropertyChanged += replacedStock_PropertyChanged;
                }

                UntreatedReplacedStocks = new ObservableCollection<ReturnedStockReplacement>(untreatedReplacedStocks);
                UntreatedReplacedStock = null;
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void replacedStock_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected" || e.PropertyName == "ActionReason")
            {
                ReturnCommand.RaiseCanExecuteChanged();
            }

            if (e.PropertyName == "IsSelected")
            {
                SelectedItemCount = UntreatedReplacedStocks.Where(x => x.IsSelected == true).Count();
            }
        }
        
        private void OnReturnCommand()
        {
            try
            {
                if (IncompleteUserInput())
                {
                    return;
                }

                List<ReturnedStockReplacement> selectedReplacedItems = UntreatedReplacedStocks.Where(x => x.IsSelected == true).ToList();
                if (selectedReplacedItems == null || selectedReplacedItems.Count <= 0)
                {
                    Utility.DisplayMessage("No replaced stock selected!");
                    return;
                }
                
                foreach(ReturnedStockReplacement selectedReplacedItem in selectedReplacedItems)
                {
                    selectedReplacedItem.ActionDate = Utility.GetDate();
                    selectedReplacedItem.ActionExecutor = Utility.LoggedInUser;
                }

                OnReturnCommandHelper(selectedReplacedItems);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnReturnCommandHelper(List<ReturnedStockReplacement> selectedReplacedItems)
        {
            try
            {
                IsBusy = true;
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnReturnCommandCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        bool treated = _businessFacade.TreatReplacedStock(selectedReplacedItems);
                        List<ReturnedStockReplacement> untreatedReplacedStocks = _businessFacade.GetAllUntreatedStockReplacement();

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["untreatedReplacedStocks"] = untreatedReplacedStocks;
                        dictionary["treated"] = treated;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                IsBusy = false;
                //ItemIsReturnable = true;
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnReturnCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                IsBusy = false;
                if (e.Error != null)
                {
                    //ItemIsReturnable = true;
                    Utility.DisplayMessage(e.Error.Message);
                    return;
                }

                if (e.Result != null)
                {
                    Dictionary<string, object> dictionary = e.Result as Dictionary<string, object>;
                    List<ReturnedStockReplacement> untreatedReplacedStocks = (List<ReturnedStockReplacement>)dictionary["untreatedReplacedStocks"];
                    bool treated = (bool)dictionary["treated"];

                    if (treated)
                    {
                        LoadAllUntreatedStockReplacements(untreatedReplacedStocks);
                        Utility.DisplayMessage("Selected replaced item has been successfully treated.");
                    }
                    else
                    {
                        Utility.DisplayMessage("Selected replaced item treatment failed! Please try again.");
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool IncompleteUserInput()
        {
            try
            {
                if (UntreatedReplacedStocks == null || UntreatedReplacedStocks.Count <= 0)
                {
                    Utility.DisplayMessage("No replaced stock found!");
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }




    }



}
