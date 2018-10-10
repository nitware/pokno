using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity.Core;
using System.Transactions;

namespace Pokno.Business
{
    public  class PersonLogic : BusinessLogicBase<Person, PERSON>
    {
        private const string INCLUDE = "PERSON_TYPE,ROLE,LOCATION";
        private LoginDetailLogic loginDetailLogic;

        public PersonLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new PersonTranslator();
            loginDetailLogic = new LoginDetailLogic(repository);  
        }

        public override List<Person> GetAll()
        {
            try
            {
                Expression<Func<PERSON, bool>> selector = p => p.Person_Id > 0;
                Func<IQueryable<PERSON>, IOrderedQueryable<PERSON>> orderBy = p => p.OrderBy(x => x.First_Name).ThenBy(x => x.Last_Name).ThenBy(x => x.Other_Name).ThenBy(x => x.Person_Type_Id);

                List<Person> people = base.GetModelsBy(selector, orderBy, INCLUDE);

                return people;
            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    if (repository.DbContext.Database.Connection.State == ConnectionState.Open)
            //    {
            //        repository.DbContext.Database.Connection.Close();
            //    }
            //}
        }

        public List<Person> GetAllCustomerAndSupplier()
        {
            try
            {
                Func<IQueryable<PERSON>, IOrderedQueryable<PERSON>> orderBy = p => p.OrderBy(x => x.First_Name).ThenBy(x => x.Last_Name).ThenBy(x => x.Other_Name).ThenBy(x => x.Person_Type_Id);
                Expression<Func<PERSON, bool>> selector = p => p.Person_Type_Id == 2 || p.Person_Type_Id == 3;

                List<Person> people = base.GetModelsBy(selector, orderBy, INCLUDE);

                return people;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> GetAll(Person person)
        {
            try
            {
                List<Person> users = new List<Person>();
                if (person != null)
                {
                    if (person.Role.Id != 2)
                    {
                        Expression<Func<PERSON, bool>> selector = p => p.Role_Id != 2 && p.Role_Id != person.Role.Id;
                        users = base.GetModelsBy(selector);
                    }
                    else
                    {
                        users = base.GetAll();
                    }
                }

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> GetUsersBy(Person person)
        {
            try
            {
                List<Person> users = new List<Person>();
                if (person != null)
                {
                    if (person.Role.Id != 2)
                    {
                        Expression<Func<PERSON, bool>> selector = p => p.Role_Id != 2 && p.Role_Id != person.Role.Id && p.Person_Type_Id == 1;
                        users = base.GetModelsBy(selector);
                    }
                    else
                    {
                        Expression<Func<PERSON, bool>> selector = p => p.Person_Type_Id == 1;
                        users = base.GetModelsBy(selector);
                    }
                }

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Person GetBy(long id)
        {
            try
            {
                Expression<Func<PERSON, bool>> selector = p => p.Person_Id == id;
                return base.GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Person GetBy(string userName)
        {
            try
            {
                Person person = null;
                LoginDetail loginDetail = loginDetailLogic.Get(userName);
                person = GetBy(person, loginDetail);

                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person GetBy(string userName, string password)
        {
            try
            {
                Person person = null;
                LoginDetail loginDetail = loginDetailLogic.Get(userName, password);

                person = GetBy(person, loginDetail);

                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Person GetBy(Person person, LoginDetail loginDetail)
        {
            try
            {
                if (loginDetail != null)
                {
                    person = GetBy(loginDetail.Person.Id);
                    person.LoginDetail = loginDetail;
                }

                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Person Add(Person person)
        {
            try
            {
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    person.FirstName = ConvertToPascalCasing(person.FirstName);
                    person.LastName = ConvertToPascalCasing(person.LastName);
                    if (!string.IsNullOrEmpty(person.OtherName))
                    {
                        person.OtherName = ConvertToPascalCasing(person.OtherName);
                    }

                    bool done = false;
                    Person newPerson = base.Add(person);
                    if (newPerson != null)
                    {
                        //if (person.Type.Id == 1 || person.Type.Id == 3)

                        if (person.Type.Id == 1)
                        {
                            loginDetailLogic.repository = repository;
                            LoginDetail newLogin = loginDetailLogic.Add(newPerson);
                            if (newLogin != null)
                            {
                                done = true;
                            }
                        }
                        else
                        {
                            done = true;
                        }

                        if (done)
                        {
                            //transaction.Commit();
                            //repository.DbContext.Database.Connection.Close();

                            base.CommitTransaction(transaction);
                            return newPerson;
                        }
                    }
                }

                return null;
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
                bool suceeded = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    loginDetailLogic.repository = repository;
                    loginDetailLogic.Remove(person);

                    Expression<Func<PERSON, bool>> selector = P => P.Person_Id == person.Id;
                    suceeded = base.Remove(selector);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();

                    base.CommitTransaction(transaction);
                }

                return suceeded;
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
                Expression<Func<PERSON, bool>> predicate = ps => ps.Person_Id == person.Id;
                PERSON personEntity = GetEntityBy(predicate);

                person.FirstName = ConvertToPascalCasing(person.FirstName);
                person.LastName = ConvertToPascalCasing(person.LastName);
                if (!string.IsNullOrEmpty(person.OtherName))
                {
                    person.OtherName = ConvertToPascalCasing(person.OtherName);
                }

                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    personEntity.Last_Name = person.LastName;
                    personEntity.First_Name = person.FirstName;
                    personEntity.Other_Name = person.OtherName;
                    personEntity.Mobile_Phone = person.MobilePhone;
                    personEntity.Contact_Address = person.ContactAddress;
                    personEntity.Person_Type_Id = person.Type.Id;
                    personEntity.Location_Id = person.Location.Id;
                    personEntity.Role_Id = person.Role.Id;
                    personEntity.Email = person.Email;

                    // modify login detail
                    loginDetailLogic.repository = repository;
                    bool updated = loginDetailLogic.Update(person);
                    if (updated == false)
                    {
                        throw new Exception("Login detail modify operation failed!");
                    }

                    repository.Save();
                    CommitTransaction(transaction);
                }

                return true;



                //if (rowAffected > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    throw new Exception(NoItemModified);
                //}
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (ConstraintException)
            {
                throw new ConstraintException("");
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public List<Person> GetPersonsByType(PersonType personType)
        {
            try
            {
                Expression<Func<PERSON, bool>> selector = P => P.Person_Type_Id == personType.Id;
                return GetModelsBy(selector);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private string ConvertToPascalCasing(string word)
        {
            try
            {
                string name = word.Substring(1, word.Length - 1).ToLower();
                string nameFirstChar = word.Substring(0, 1).ToUpper();

                return nameFirstChar + name;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        
    }


}
