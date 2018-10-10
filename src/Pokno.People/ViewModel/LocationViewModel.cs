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
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.Models;
using Prism.Regions;
using Pokno.Model;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.People.ViewModel
{
    public class LocationViewModel : SetupViewModelBase<Location>
    {
        public LocationViewModel(ISetupService<Location> _service, IEventAggregator eventAggregator)
            : base(_service)
        {
            _modelName = "Location";
            
            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupLocation;
            eventAggregator.GetEvent<PersonBasicSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);

            base.LoadAll();
        }

        private bool IsView(UI.PeopleSetup ui)
        {
            return ui == UI.PeopleSetup.Location;
        }
        private void OnInitialise(UI.PeopleSetup ui)
        {
            base.LoadAll();

            //Model = new Location();
            //UpdateViewState(Edit.Mode.Loaded);
        }

        protected override void OnSaveCommand()
        {
            if (base.InvalidEntry(Model.Name))
            {
                return;
            }

            if (string.IsNullOrEmpty(Model.Address))
            {
                MessageBox.Show("Please enter address!");
                return;
            }

            base.OnSaveCommand();
        }

        public string TabCaption
        {
            get { return _modelName; }
        }

    }


}
