using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class StoreTranslator : TranslatorBase<Store, STORE>
    {
        public override Store TranslateToModel(STORE entity)
        {
            try
            {
                Store store = null;
                if (entity != null)
                {
                    store = new Store();
                    store.Id = (int)entity.Store_Id;
                    store.Name = entity.Store_Name;
                    store.Address = entity.Address;
                    store.Description = entity.Description;
                    store.Website = entity.Website;
                    store.Email = entity.Email;
                    store.Phone = entity.Phone;
                    store.Disclaimer = entity.Disclaimer;
                    store.LogoFileName = entity.Logo_File_Name;
                }

                return store;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STORE TranslateToEntity(Store store)
        {
            try
            {
                STORE entity = null;
                if (store != null)
                {
                    entity = new STORE();
                    entity.Store_Id = store.Id;
                    entity.Store_Name = store.Name;
                    entity.Address = store.Address;
                    entity.Description = store.Description;
                    entity.Website = store.Website;
                    entity.Email = store.Email;
                    entity.Phone = store.Phone;
                    entity.Disclaimer = store.Disclaimer;
                    entity.Logo_File_Name = store.LogoFileName;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }




}
