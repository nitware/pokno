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
using Pokno.Infrastructure.Models;
using Pokno.Model;
using Pokno.Infrastructure.ViewModel;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class StockReturnTypeViewModel : SetupViewModelBase<StockReturnType>
    {
        public StockReturnTypeViewModel(ISetupService<StockReturnType> service, IEventAggregator eventAggregator)
            : base(service)
        {
            _modelName = "Stock Return Type";
            
            //base.LoadAll();
            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;
            
            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        private bool IsView(UI.StockSetup ui)
        {
            return ui == UI.StockSetup.State;
        }
        private void OnInitialise(UI.StockSetup ui)
        {
            try
            {
                base.LoadAll();
                //Model = new StockReturnType();
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
