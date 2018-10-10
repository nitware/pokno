using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.People.Services;
using Pokno.People.Interfaces;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.Events;
using Prism.Events;
using Pokno.Infrastructure.Interfaces;
using Pokno.Model;
using Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Threading;
using Pokno.Infrastructure.ViewModel;
using Pokno.Service;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pokno.People.ViewModels
{
    public class AssignRightToRoleViewModel : BaseApplicationViewModel
    {
        private Dispatcher _dispatcher;

        private ObservableCollection<Role> _roles;
        private ISetupService<Person> _personService;
        private IAssignRightToRoleService _service;
        private RoleService _roleService;
        private Role _role;
                
        private BackgroundWorker _worker;
        private readonly IBusinessFacade _businessFacade;

        public AssignRightToRoleViewModel(IBusinessFacade businessFacade, IAssignRightToRoleService service, RoleService roleService, ISetupService<Person> personService, IEventAggregator eventAggregator)
        {
            _service = service;
            _roleService = roleService;
            _personService = personService;
            _businessFacade = businessFacade;
            _dispatcher = Application.Current.Dispatcher;

            SaveCommand = new DelegateCommand(OnSaveCommand);
            eventAggregator.GetEvent<PersonAccessControlEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public List<Role> RawRoles { get; set; }
        public DelegateCommand SaveCommand { get; private set; }

        public string TabCaption
        {
            get { return "Assign Right To Role"; }
        }

        public ObservableCollection<Role> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                OnPropertyChanged("Roles");
            }
        }
        public Role Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged("Role");
            }
        }
        
        private bool IsView(UI.PeopleAccessControl ui)
        {
            return ui == UI.PeopleAccessControl.AssignRightToRole;
        }

        public void OnInitialise(UI.PeopleAccessControl ui)
        {
            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnInitialiseCompleted);
                    _worker.DoWork += (s, e) =>
                    {
                        e.Result = _roleService.LoadAll(Utility.LoggedInUser);
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

                if (e.Result != null)
                {
                    RawRoles = e.Result as List<Role>;
                    if (RawRoles.Count > 0)
                    {
                        RawRoles.Insert(0, new Role() { Id = -1, Name = "<< Select Role >>" });
                    }

                    _dispatcher.Invoke(() =>
                    {
                        Roles = new ObservableCollection<Role>(RawRoles);
                        Role = Roles.FirstOrDefault();
                    });
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void OnSaveCommand()
        {
            try
            {
                if (EntryIsInvalid())
                {
                    return;
                }

                bool done = _service.AssignRightToRole(Role);

                _dispatcher.Invoke(() =>
                    {
                        if (done)
                        {
                            Role = Role;
                            if (Role.Id == Utility.LoggedInUser.Role.Id)
                            {
                                Utility.LoggedInUser = _businessFacade.GetPersonById(Utility.LoggedInUser.Id);
                            }

                            Utility.DisplayMessage("Right(s) has been successfully assigned to Role ( " + Role.Name + " )");
                        }
                        else
                        {
                            Utility.DisplayMessage("Assignment of Right(s) to Role failed!");
                        }
                    });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool EntryIsInvalid()
        {
            try
            {
                if (Role == null || Role.Id == -1)
                {
                    Utility.DisplayMessage("No role selected! Please select role");
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        



    }



}
