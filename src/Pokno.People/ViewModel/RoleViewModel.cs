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
using Pokno.Model;
using Prism.Events;
using Pokno.Infrastructure.Events;
using System.Windows.Threading;
using System.ComponentModel;

namespace Pokno.People.ViewModels
{
    public class RoleViewModel : SetupViewModelBase<Role>
    {
        //private Dispatcher _dispatcher;

        public RoleViewModel(ISetupService<Role> _service, IEventAggregator eventAggregator)
            : base(_service)
        {
            _modelName = "Role";
            _dispatcher = Application.Current.Dispatcher;

            base._addSelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase);
            base._modifySelector = l => l.Name.Equals(Model.Name.Replace(" ", "").Trim(), StringComparison.OrdinalIgnoreCase) && l.Id != Model.Id;

            eventAggregator.GetEvent<PersonAccessControlEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        private bool IsView(UI.PeopleAccessControl ui)
        {
            return ui == UI.PeopleAccessControl.Role;
        }
        public void OnInitialise(UI.PeopleAccessControl ui)
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
