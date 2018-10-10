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
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.Model;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class StockCategoryViewModel : SetupViewModelBase<StockCategory>
    {
        public StockCategoryViewModel(ISetupService<StockCategory> service, IEventAggregator eventAggregator)
            : base(service)
        {
            _modelName = "Stock Category";

            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;
            
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupStockCategory;
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
            OnInitialise(UI.StockSetup.Category);
        }
        private bool IsView(UI.StockSetup ui)
        {
            return ui == UI.StockSetup.Category;
        }
        private void OnInitialise(UI.StockSetup ui)
        {
            try
            {
                base.LoadAll();

                //Utility.DisplayMessage(Utility.DbPath);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
        public string TabCaption
        {
            get { return _modelName; }
        }
        //public string Db
        //{
        //    get { return Utility.GetDbPath(); }
        //}

        protected override void OnSaveCommand()
        {
            try
            {
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

       
    }


}
