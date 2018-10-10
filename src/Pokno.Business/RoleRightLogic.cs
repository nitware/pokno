using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class RoleRightLogic : BusinessLogicBase<RoleRight, ROLE_RIGHT>
    {
        public RoleRightLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new RoleRightTranslator();
        }

        public List<RoleRight> Create(Role role, List<Right> rights)
        {
            try
            {
                List<RoleRight> roleRights = null;
                if (role != null && rights != null)
                {
                    roleRights = new List<RoleRight>();
                    foreach (Right right in rights)
                    {
                        if (right.IsInRole)
                        {
                            RoleRight roleRight = new RoleRight();
                            roleRight.Role = role;
                            roleRight.Right = right;

                            roleRights.Add(roleRight);
                        }
                    }
                }

                return roleRights;
            }
            catch (Exception)
            {
                throw;
            }
        }


        
    }



}
