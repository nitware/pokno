using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Pokno.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using System.Transactions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class RoleLogic : BusinessLogicBase<Role, ROLE>
    {
        private RightLogic rightLogic;
        private RoleRightLogic roleRightLogic;

        public RoleLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();

            rightLogic = new RightLogic(repository);
            roleRightLogic = new RoleRightLogic(repository);
            base.translator = new RoleTranslator();
        }

        public override List<Role> GetAll()
        {
            try
            {
                List<Role> roles = base.GetAll();
                return SetPersonRightView(roles);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Role> GetAll(Person person)
        {
            try
            {
                List<Role> roles = new List<Role>();
                if (person != null)
                {
                    if (person.Role.Id != 2)
                    {
                        Expression<Func<ROLE, bool>> selector = r => r.Role_Id != 2 && r.Role_Id != person.Role.Id;
                        roles = base.GetModelsBy(selector);
                    }
                    else
                    {
                        roles = base.GetAll();
                    }
                }

                return SetPersonRightView(roles);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Role role)
        {
            try
            {
                Expression<Func<ROLE, bool>> selector = r => r.Role_Id == role.Id;
                ROLE roleEntity = GetEntityBy(selector);
                roleEntity.Role_Name = role.Name;
                roleEntity.Role_Description = role.Description;

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

        public bool Remove(Role role)
        {
            try
            {
                Expression<Func<ROLE, bool>> selector = r => r.Role_Id == role.Id;
                bool suceeded = base.Remove(selector);
                
                //repository.Save();
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Role SetPersonRightView(Role role)
        {
            try
            {
                List<Right> rightsInRole = role.Rights;
                List<Right> rights = rightLogic.GetAll(); //get all rights

                foreach (Right right in rights)
                {
                    foreach (Right rightInRole in rightsInRole)
                    {
                        if (rightInRole.Id == right.Id)
                        {
                            right.IsInRole = true;
                        }
                    }
                }

                role.PersonRight = new PersonRight();
                role.PersonRight.View = rights;

                return role;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Role> SetPersonRightView(List<Role> roles)
        {
            try
            {
                List<Role> newRoles = new List<Role>();
                if (roles != null)
                {
                    foreach (Role role in roles)
                    {
                        Role newRole = SetPersonRightView(role);
                        newRoles.Add(newRole);
                    }
                }

                return newRoles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AssignRightToRole(Role role)
        {
            try
            {
                if (role == null || role.Id <= 0)
                {
                    throw new Exception("Role cannot be null! Please Assign Right to Role and try again.");
                }

                bool isSuccessful = true;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    roleRightLogic.repository = repository;
                    roleRightLogic.Remove(rr => rr.Role_Id == role.Id);

                    List<RoleRight> roleRights = new List<RoleRight>();
                    roleRights = roleRightLogic.Create(role, role.PersonRight.View);
                    if (roleRights != null && roleRights.Count > 0)
                    {
                        isSuccessful = roleRightLogic.Add(roleRights) > 0 ? true : false;

                        base.CommitTransaction(transaction);

                        //transaction.Commit();
                        //repository.DbContext.Database.Connection.Close();
                    }
                }
                
                return isSuccessful;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }

}
