using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Security.Cryptography;
using Pokno.Model.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using Pokno.Model;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class LoginDetailLogic : BusinessLogicBase<LoginDetail, PERSON_LOGIN>
    {
        private const string DefaultPassword = "welcome";

        public LoginDetailLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new LoginDetailTranslator();
        }

        public override List<LoginDetail> GetAll()
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> selector = pl => pl.PERSON.Person_Type_Id == 1 || pl.PERSON.Person_Type_Id == 3;
                return base.GetModelsBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public override List<LoginDetail> GetAll()
        //{
        //    try
        //    {
        //         var poknoEntities = new PoknoV41Entities();
        //        List<LoginDetail> loginDetails = (from ld in poknoEntities.PERSON_LOGIN
        //                                                      select new LoginDetail
        //                                                      {
        //                                                          Person = ld.

        //                                                          StockId = srd.Stock_Id.Value,
        //                                                          StockName = srd.Stock_Name,
        //                                                          QuantityPackagePurchased = srd.Quantity_Purchased,
        //                                                          QuantityPackageSold = srd.Quantity_Sold,
        //                                                          Cost = srd.Cost,
        //                                                          TransactionMonth = srd.Month_Purchased.HasValue ? srd.Month_Purchased : srd.Month_Sold,
        //                                                          TransactionYear = srd.Year_Purchased.HasValue ? srd.Year_Purchased : srd.Year_Sold,
        //                                                          CostPrice = srd.Cost_Price,
        //                                                          SellingPrice = srd.Selling_Price,
        //                                                          ActualSellingPrice = srd.Actual_Selling_Price,
        //                                                          Discount = srd.Discount,
        //                                                          Profit = srd.Profit,
        //                                                          MonthSold = srd.Month_Sold,
        //                                                          YearSold = srd.Year_Sold,
        //                                                          MonthYearSold = srd.Month_Year_Sold
        //                                                      }).OrderBy(s => s.TransactionMonth).ToList();
        //        return stockReviewDetails;

        //        List<LoginDetail> loginDetails = (from )
        //        return base.GetAll();
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}

        public LoginDetail Get(string userName, string password)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> selector = pl => pl.Username.Equals(userName, StringComparison.OrdinalIgnoreCase);
                LoginDetail loginDetail = GetModelBy(selector);

                if (loginDetail != null)
                {
                    byte[] enteredPasswordHash = CreatePasswordHash(password);
                    if (ComparePassword(enteredPasswordHash, loginDetail.Password))
                    {
                        return loginDetail;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool ComparePassword(byte[] hash, byte[] oldHash)
        {
            try
            {
                if (hash == null || oldHash == null || hash.Length != oldHash.Length)
                {
                    return false;
                }
                               
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != oldHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LoginDetail Get(string userName)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> selector = pl => pl.Username.Equals(userName, StringComparison.OrdinalIgnoreCase);
                return GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LoginDetail Get(Person person)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> selector = pl => pl.Person_Id == person.Id;
                return GetModelBy(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LoginDetail Add(Person person)
        {
            try
            {
                LoginDetail login = new LoginDetail();
                login.Person = person;
                login.Username = CreateUserName(person);
                login.Password = CreatePasswordHash(DefaultPassword);
                login.IsLocked = false;
                login.IsActivated = false;
                login.IsFirstLogon = true;

                return base.Add(login);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string CreateUserName(Person user)
        {
            try
            {
                string smallFirstName = user.FirstName.Substring(1, user.FirstName.Length - 1).ToLower();
                string smallLastName = user.LastName.Substring(1, user.LastName.Length - 1).ToLower();
                string firstNameFirstChar = user.FirstName.Substring(0, 1).ToUpper();
                string lastNameFirstChar = user.LastName.Substring(0, 1).ToUpper();

                return firstNameFirstChar + smallFirstName + "." + lastNameFirstChar + smallLastName;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public bool ResetPassword(LoginDetail loginDetail)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> selector = l => l.Person_Id == loginDetail.Person.Id;
                PERSON_LOGIN loginEntity = GetEntityBy(selector);

                if (loginEntity != null)
                {
                    byte[] hash = CreatePasswordHash(DefaultPassword);

                    loginEntity.Password = hash;
                    loginEntity.Is_Locked = false;
                    loginEntity.Is_Activated = true;
                    loginEntity.Is_First_Logon = true;

                    int rowsAffected = repository.Save();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(NoItemModified);
                    }
                }
                else
                {
                    return Add(loginDetail.Person) != null ? true : false;
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
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

        private static byte[] CreatePasswordHash(string password)
        {
            try
            {
                //string defaultPassword = "welcome";

                HashAlgorithm hashAlg = new SHA512Managed();
                byte[] pwordData = Encoding.Default.GetBytes(password);
                byte[] hash = hashAlg.ComputeHash(pwordData);
                return hash;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Modify(Person person)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> predicate = c => c.Person_Id == person.Id;
                PERSON_LOGIN loginDetailEntity = GetEntityBy(predicate);

                loginDetailEntity.Username = CreateUserName(person);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
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

        public bool Modify(LoginDetail loginDetail)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> predicate = c => c.Person_Id == loginDetail.Person.Id;
                PERSON_LOGIN loginDetailEntity = GetEntityBy(predicate);

                loginDetailEntity.Username = loginDetail.Username;
                loginDetailEntity.Is_Activated = loginDetail.IsActivated;
                loginDetailEntity.Is_Locked = loginDetail.IsLocked;
               
                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
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

        public bool Update(Person person)
        {
            try
            {
                bool modified = false;
                LoginDetail existingLoginDetail = Get(person);

                if (person.Type.Id == 1 || person.Type.Id == 3)
                {
                    if (existingLoginDetail == null || existingLoginDetail.Person == null || existingLoginDetail.Person.Id <= 0)
                    {
                        LoginDetail newLoginDetail = Add(person);
                        modified = newLoginDetail != null ? true : false;
                    }
                    else
                    {
                        Modify(person);
                        modified = true;
                    }
                }
                else
                {
                    if (existingLoginDetail != null && existingLoginDetail.Person != null && existingLoginDetail.Person.Id > 0)
                    {
                        Remove(person);
                    }

                    modified = true;
                }

                return modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LoginDetail ChangePassword(Person person, string password)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> predicate = c => c.Person_Id == person.Id;
                PERSON_LOGIN loginDetailEntity = GetEntityBy(predicate);

                byte[] hash = CreatePasswordHash(password);
               
                loginDetailEntity.Password = hash;
                loginDetailEntity.Is_First_Logon = false;

                //loginDetailEntity.Is_Activated = true;
                //loginDetailEntity.Is_Locked = false;
                
                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return Get(person);
                }

                return null;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
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

        public bool Remove(Person person)
        {
            try
            {
                Expression<Func<PERSON_LOGIN, bool>> selector = P => P.Person_Id == person.Id;
                return base.Remove(selector);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
