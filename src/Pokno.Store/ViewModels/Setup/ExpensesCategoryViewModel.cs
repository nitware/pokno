using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Model.Model;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.Models;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.ComponentModel;

namespace Pokno.Store.ViewModels
{
    public class ExpensesCategoryViewModel : SetupViewModelBase<ExpensesCategory>
    {
        public ExpensesCategoryViewModel(ISetupService<ExpensesCategory> service, IEventAggregator eventAggregator)
            : base(service)
        {
            _modelName = "Expenses Category";

            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;
            
            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupExpensesCategory;
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);

        }
        private bool IsView(UI.StockSetup ui)
        {
            return ui == UI.StockSetup.ExpensesCategory;
        }
        public void OnInitialise(UI.StockSetup ui)
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
        public string TabCaption
        {
            get { return _modelName; }
        }

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
