using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Model.Translator;
using Pokno.Entity;

namespace Pokno.Model
{
   public class PersonTranslator : TranslatorBase<Person, PERSON>
    {
       private RoleTranslator roleTranslator;
       private LocationTranslator locationTranslator;
       private PersonTypeTranslator personTypeTranslator;

       public PersonTranslator()
       {
           locationTranslator = new LocationTranslator();
           personTypeTranslator = new PersonTypeTranslator();
           roleTranslator = new RoleTranslator();
       }
       public override Person TranslateToModel(PERSON personEntity)
       {
           try
           {
               
               Person person = null;
               if (personEntity != null)
               {
                   person = new Person();
                   person.Id = (int)personEntity.Person_Id;
                   person.LastName = personEntity.Last_Name;
                   person.FirstName = personEntity.First_Name;
                   person.OtherName = personEntity.Other_Name;
                   person.Name = person.FirstName + " " + person.LastName;
                   person.FullName = person.FirstName + " " + person.LastName + " " + person.OtherName;
                   person.MobilePhone = personEntity.Mobile_Phone;
                   person.Email = personEntity.Email;
                   person.ContactAddress = personEntity.Contact_Address;
                   person.Type = personTypeTranslator.Translate(personEntity.PERSON_TYPE);
                   person.Role = roleTranslator.Translate(personEntity.ROLE);
                   person.Location = locationTranslator.Translate(personEntity.LOCATION);
               }

               return person;
           }
           catch (Exception)
           {
               throw;
           }
       }

       public override PERSON TranslateToEntity(Person person)
       {
           try
           {
               PERSON personEntity = null;
               if (person != null)
               {
                   personEntity = new PERSON();
                   personEntity.Person_Type_Id = person.Type.Id;
                   personEntity.Last_Name = person.LastName;
                   personEntity.First_Name = person.FirstName;
                   personEntity.Other_Name = person.OtherName;
                   personEntity.Email = person.Email;
                   personEntity.Mobile_Phone = person.MobilePhone;
                   personEntity.Contact_Address = person.ContactAddress;
                   personEntity.Role_Id = person.Role.Id;
                   personEntity.Location_Id = person.Location.Id;
               }

               return personEntity;
           }
           catch (Exception)
           {
               throw;
           }
       }




    }


}
