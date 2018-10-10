using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class RoleRightTranslator : TranslatorBase<RoleRight, ROLE_RIGHT>
    {
        private RoleTranslator roleTranslator;
        private RightTranslator rightTranslator;

        public RoleRightTranslator()
        {
            roleTranslator = new RoleTranslator();
            rightTranslator = new RightTranslator();
        }

        public override RoleRight TranslateToModel(ROLE_RIGHT roleRightEntity)
        {
            try
            {
                RoleRight roleRight = null;
                if (roleRightEntity != null)
                {
                    roleRight = new RoleRight();
                    roleRight.Role = roleTranslator.Translate(roleRightEntity.ROLE);
                    roleRight.Right = rightTranslator.Translate(roleRightEntity.RIGHT);
                    roleRight.Description = roleRightEntity.Description;
                }

                return roleRight;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ROLE_RIGHT TranslateToEntity(RoleRight roleRight)
        {
            try
            {
                ROLE_RIGHT roleRightEntity = null;
                if (roleRight != null)
                {
                    roleRightEntity = new ROLE_RIGHT();
                    roleRightEntity.Role_Id = roleRight.Role.Id;
                    roleRightEntity.Right_Id = roleRight.Right.Id;
                    roleRightEntity.Description = roleRight.Description;
                }

                return roleRightEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}
