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
using System.Collections.ObjectModel;
using Pokno.Service;
using System.Collections.Generic;
using Pokno.Model;

namespace Pokno.Infratructure.Services
{
    public class PersonService : ISetupService<Person>
    {
        private IBusinessFacade _service;

        public PersonService(IBusinessFacade service)
        {
            _service = service;
            //_service = new BusinessFacade(new Repository(dbPath));
        }

        public List<Person> LoadAll()
        {
            try
            {
                return _service.GetAllPeople();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> LoadAll(Person person)
        {
            try
            {
                return _service.GetUsers(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> LoadAllUsersBy(Person person)
        {
            try
            {
                return _service.GetUsersBy(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person GetById(long id)
        {
            try
            {
                return _service.GetPersonById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public bool Save(Person person)
        {
            try
            {
                return _service.AddPerson(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(Person person)
        {
            try
            {
                return _service.ModifyPerson(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(Person person)
        {
            try
            {
                return _service.RemovePerson(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        




    }
}
