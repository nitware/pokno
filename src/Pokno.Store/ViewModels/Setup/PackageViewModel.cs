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

using Pokno.Model;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Interfaces;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Linq;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.Store.ViewModels
{
    public class PackageViewModel : SetupViewModelBase<Package>
    {
        public PackageViewModel(ISetupService<Package> service, IEventAggregator eventAggregator)
            : base(service)
        {
            _modelName = "Package Type";

            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;

            eventAggregator.GetEvent<StockSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        private bool IsView(UI.StockSetup ui)
        {
            return ui == UI.StockSetup.Package;
        }
        private void OnInitialise(UI.StockSetup ui)
        {
            base.LoadAll();
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

        protected override ICollection<Package> GetReturnedModels()
        {
            try
            {
                ICollection<Package> packages = null;
                if (ReturnedModels != null && ReturnedModels.Count > 0)
                {
                    packages = ReturnedModels.Where(c => c.Id != 0).ToList();
                }

                return packages;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

    }

}



