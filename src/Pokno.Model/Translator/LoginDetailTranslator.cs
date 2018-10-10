using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Model;
using Pokno.Entity;

namespace Pokno.Model.Translator
{
    public class LoginDetailTranslator : TranslatorBase<LoginDetail, PERSON_LOGIN>
    {
        private PersonTranslator personTranslator;

        public LoginDetailTranslator()
        {
            personTranslator = new PersonTranslator();
        }

        public override LoginDetail TranslateToModel(PERSON_LOGIN personLoginEntity)
        {
            try
            {
                LoginDetail personLogin = null;
                if (personLoginEntity != null)
                {
                    personLogin = new LoginDetail();
                    personLogin.Person = personTranslator.Translate(personLoginEntity.PERSON);
                    personLogin.Username = personLoginEntity.Username;
                    personLogin.Password = personLoginEntity.Password;
                    personLogin.IsLocked = personLoginEntity.Is_Locked;
                    personLogin.IsActivated = personLoginEntity.Is_Activated;
                    personLogin.IsFirstLogon = personLoginEntity.Is_First_Logon;
                }

                return personLogin;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PERSON_LOGIN TranslateToEntity(LoginDetail personLogin)
        {
            try
            {
                PERSON_LOGIN personLoginEntity = null;
                if (personLogin != null)
                {
                    personLoginEntity = new PERSON_LOGIN();
                    personLoginEntity.Person_Id = personLogin.Person.Id;
                    personLoginEntity.Username = personLogin.Username;
                    personLoginEntity.Password = personLogin.Password;
                    personLoginEntity.Is_Locked = personLogin.IsLocked;
                    personLoginEntity.Is_Activated = personLogin.IsActivated;
                    personLoginEntity.Is_First_Logon = personLogin.IsFirstLogon;
                }

                return personLoginEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}
