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

using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Linq;

using System.Collections.Generic;
using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Pokno.People.Services;
using Pokno.Infrastructure.Events;
using Prism.Events;
using Pokno.Model;
using Pokno.Infrastructure.Interfaces;
using Prism.Commands;
using Pokno.Infratructure.Services;
using Pokno.Service;


namespace Pokno.People.ViewModels
{
    public class AssignRoleToPersonViewModel : BaseApplicationViewModel
    {
        private Dispatcher _dispatcher;

        private ObservableCollection<Person> _users;
        private ListCollectionView _roles;
        private Person _user;
        private Role _role;
        private Role _selectedUserRole;

        private readonly IBusinessFacade _service;
        private PersonService _userService;
        private RoleService _roleService;
        private BackgroundWorker _worker;

        public AssignRoleToPersonViewModel(IBusinessFacade service, IEventAggregator eventAggregator)
        {
            _service = service;
            _roleService = new RoleService(service);
            _userService = new PersonService(service);
            _dispatcher = Application.Current.Dispatcher;

            SaveCommand = new DelegateCommand(OnSaveCommand);
            eventAggregator.GetEvent<PersonAccessControlEvent>().Subscribe(OnInitialise, ThreadOption.UIThread, false, IsView);
        }

        public DelegateCommand SaveCommand { get; private set; }

        public string TabCaption
        {
            get { return "Assign Role To Person"; }
        }
        public ObservableCollection<Person> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }
        public Person User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");

                SetUserRole(_user);
            }
        }
        public ListCollectionView Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                OnPropertyChanged("Roles");
            }
        }
        public Role SelectedUserRole
        {
            get { return _selectedUserRole; }
            set
            {
                _selectedUserRole = value;
                OnPropertyChanged("SelectedUserRole");
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
            return ui == UI.PeopleAccessControl.AssignRoleToPerson;
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
                        List<Role> roles = _roleService.LoadAll(Utility.LoggedInUser);
                        List<Person> people = _userService.LoadAllUsersBy(Utility.LoggedInUser);

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        dictionary["roles"] = roles;
                        dictionary["people"] = people;

                        e.Result = dictionary;
                    };
                    _worker.RunWorkerAsync();
                }
            }
            catch(Exception ex)
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

                List<Role> roles = null;
                List<Person> people = null;
                if (e.Result != null)
                {
                    Dictionary<string, object> result = e.Result as Dictionary<string, object>;
                    people = (List<Person>)result["people"];
                    roles = (List<Role>)result["roles"];
                }

                PopulateRole(roles);
                PopulatePeople(people);

                User = new Person();
                User.Role = new Role();
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulatePeople(List<Person> people)
        {
            try
            {
                if (people == null)
                {
                    people = new List<Person>();
                }

                if (people.Count > 0)
                {
                    people.Insert(0, new Person() { Id = -1, FullName = "<< Select User >>" });
                }

                _dispatcher.Invoke(() =>
                {
                    Users = new ObservableCollection<Person>(people);
                    User = Users.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private void PopulateRole(List<Role> roles)
        {
            try
            {
                if (roles == null)
                {
                    roles = new List<Role>();
                }

                _dispatcher.Invoke(() =>
                {
                    Roles = new ListCollectionView(roles);
                    if (roles != null)
                    {
                        Roles.MoveCurrentTo(null);
                        Roles.CurrentChanged += (sc, ea) =>
                        {
                            Role = Roles.CurrentItem as Role;
                        };
                    }
                });
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        //private void LoadAllRole()
        //{
        //    try
        //    {
        //        using(_worker = new BackgroundWorker())
        //        {
        //            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllRoleCompleted);
        //            _worker.DoWork += (s,e) =>
        //                {
        //                    e.Result = _roleService.LoadAll(Utility.LoggedInUser);
        //                };
        //            _worker.RunWorkerAsync();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        //private void OnLoadAllRoleCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Error != null)
        //        {
        //            Utility.DisplayMessage(e.Error.Message);
        //            return;
        //        }

        //        if (e.Result != null)
        //        {
        //            List<Role> roles = e.Result as List<Role>;

        //            _dispatcher.Invoke(() =>
        //                {
        //                    Roles = new ListCollectionView(roles);
        //                    if (roles != null)
        //                    {
        //                        Roles.MoveCurrentTo(null);
        //                        Roles.CurrentChanged += (sc, ea) =>
        //                        {
        //                            Role = Roles.CurrentItem as Role;
        //                        };
        //                    }
        //                });
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        //private void LoadAllUsers()
        //{
        //    try
        //    {
        //        using(_worker = new BackgroundWorker())
        //        {
        //            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnLoadAllUsersCompleted);
        //            _worker.DoWork += (s,e) =>
        //                {
        //                    e.Result = _userService.LoadAllUsersBy(Utility.LoggedInUser);
        //                };
        //            _worker.RunWorkerAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

        //private void OnLoadAllUsersCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Error != null)
        //        {
        //            Utility.DisplayMessage(e.Error.Message);
        //            return;
        //        }

        //        if (e.Result != null)
        //        {
        //            List<Person> people = e.Result as List<Person>;
        //            if (people.Count > 0)
        //            {
        //                people.Insert(0, new Person() { Id = -1, FullName = "<< Select User >>" });
        //            }

        //            _dispatcher.Invoke(() =>
        //                {
        //                    Users = new ObservableCollection<Person>(people);
        //                    User = Users.FirstOrDefault();
        //                });
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Utility.DisplayMessage(ex.Message);
        //    }
        //}

       
        private void SetUserRole(Person user)
        {
            try
            {
                SelectedUserRole = user.Role;
                if (user != null && user.Id > 0)
                {
                    if (Roles != null)
                    {
                        foreach (Role role in Roles)
                        {
                            role.HasUser = role.Id == User.Role.Id ? true : false;
                        }
                    }
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
                if (InvalidEntry())
                {
                    return;
                }

                Role selectedRole = Role;
                User.Role = selectedRole;
                bool done = _userService.Modify(User);
                if (done)
                {
                    Roles.MoveCurrentTo(null);
                    SelectedUserRole = selectedRole;
                    Utility.DisplayMessage("Role '" + User.Role.Name + "' has been successfully assigned to '" + User.FullName + "'");
                }
                else
                {
                    Utility.DisplayMessage("Assignment of Role to Person failed!");
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }

        private bool InvalidEntry()
        {
            try
            {
                if (Role == null || Role.Id <= 0)
                {
                    Utility.DisplayMessage("No role selected! Please select a role");
                    return true;
                }

                if (Roles == null)
                {
                    Utility.DisplayMessage("Role not found!");
                    return true;
                }

                IEnumerable<Role> roles = (IEnumerable<Role>)Roles.SourceCollection;
                if (roles == null || roles.Count() <= 0)
                {
                    Utility.DisplayMessage("No role(s) found! Contact your system administrator.");
                    return true;
                }

                Role role = roles.Where(r => r.HasUser == true).SingleOrDefault();
                if (role == null || role.Id <= 0)
                {
                    Utility.DisplayMessage("Role has no user assigned!");
                    return true;
                }
                
                if (Role == null || role.Name == Role.Name)
                {
                    Utility.DisplayMessage("No role changes found for '" + User.FullName + "'");
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
