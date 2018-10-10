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
using Pokno.Infrastructure.Models;
using Pokno.Model;
using Prism.Events;
using Pokno.Infrastructure.Events;

namespace Pokno.People.ViewModel
{
    public class PersonTypeViewModel : SetupViewModelBase<PersonType>
    {
        public PersonTypeViewModel(ISetupService<PersonType> service, IEventAggregator eventAggregator)
            : base(service)
        {
            base._modelName = "Person Type";
            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;

            IsLoggedInUserHasRight = Utility.LoggedInUser.Role.PersonRight.CanSetupPersonType;
            eventAggregator.GetEvent<PersonBasicSetupEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public string TabCaption
        {
            get { return _modelName; }
        }

        private bool IsView(UI.PeopleSetup ui)
        {
            return ui == UI.PeopleSetup.PersonType;
        }
        private void OnInitialise(UI.PeopleSetup ui)
        {
            base.LoadAll();

            //Model = new PersonType();
            //base.UpdateViewState(Edit.Mode.Loaded);
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
