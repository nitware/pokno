﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class PersonTypeTranslator : TranslatorBase<PersonType, PERSON_TYPE>
    {
        public override PersonType TranslateToModel(PERSON_TYPE personTypeEntity)
        {
            try
            {
                PersonType personType = null;
                if (personTypeEntity != null)
                {
                    personType = new PersonType();
                    personType.Id = (int)personTypeEntity.Person_Type_Id;
                    personType.Name = personTypeEntity.Person_Type_Name;
                    personType.Description = personTypeEntity.Person_Type_Description;
                }

                return personType;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override PERSON_TYPE TranslateToEntity(PersonType personType)
        {
            PERSON_TYPE personTypeEntity = null;
            if (personType != null)
            {
                personTypeEntity = new PERSON_TYPE();
                personTypeEntity.Person_Type_Id = personType.Id;
                personTypeEntity.Person_Type_Name = personType.Name;
                personTypeEntity.Person_Type_Description = personType.Description;
            }

            return personTypeEntity;
        }

    }
}
