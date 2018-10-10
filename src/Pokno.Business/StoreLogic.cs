using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity.Core;
using System.Data;

namespace Pokno.Business
{
    public class StoreLogic : BusinessLogicBase<Store, STORE>
    {
        public StoreLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new StoreTranslator();
        }

        public Store Get()
        {
            try
            {
                Store store = null;
                List<Store> stores = base.GetAll();
                if (stores != null && stores.Count > 1)
                {
                    throw new Exception("Multiple instances of store found! Please contact your system administrator.");
                }
                else if (stores != null && stores.Count == 1)
                {
                    store = stores.SingleOrDefault();
                }

                return store;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Store Add(Store store)
        {
            try
            {
                if (store == null)
                {
                    throw new ArgumentNullException("store");
                }

                Store newStore = null;
                if (store.Id <= 0)
                {
                    store.Id = 1;
                    newStore = base.Add(store);
                }
                else
                {
                    if (Modify(store))
                    {
                        newStore = store;
                    }
                }

                return newStore;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Add(Store store, string destinationFolder, string sourceFilePath, IFileManager fileManager)
        {
            try
            {
                if (store == null || store.Id <= 0)
                {
                    throw new ArgumentNullException("store");
                }
                if (fileManager == null)
                {
                    throw new ArgumentNullException("fileManager");
                }

                bool modified = false;
                store.LogoFileName = fileManager.GetFileName(sourceFilePath);

                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction ctxTrans = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    modified = Modify(store);
                    if (modified)
                    {
                        //save logo file name if exist
                        if (!string.IsNullOrWhiteSpace(store.LogoFileName))
                        {
                            fileManager.Save(destinationFolder, sourceFilePath, store.LogoFileName);
                        }
                    }

                    ctxTrans.Commit();
                    repository.DbContext.Database.Connection.Close();
                }

                return modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteLogo(Store store, string destinationFolder, IFileManager fileManager)
        {
            try
            {
                if (store == null || store.Id <= 0)
                {
                    throw new ArgumentNullException("store");
                }
                if (fileManager == null)
                {
                    throw new ArgumentNullException("fileManager");
                }

                bool modified = false;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction ctxTrans = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    store.LogoFileName = null;
                    modified = Modify(store);
                    if (modified)
                    {
                        fileManager.DeleteAllFilesInFolder(destinationFolder);
                    }

                    base.CommitTransaction(ctxTrans);
                }

                return modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Store store)
        {
            try
            {
                Expression<Func<STORE, bool>> predicate = s => s.Store_Id == store.Id;
                STORE entity = GetEntityBy(predicate);

                entity.Store_Name = store.Name;
                entity.Address = store.Address;
                entity.Website = store.Website;
                entity.Email = store.Email;
                entity.Phone = store.Phone;
                entity.Disclaimer = store.Disclaimer;
                entity.Description = store.Description;
                entity.Logo_File_Name = store.LogoFileName;

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



    }

}
