using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Pokno.Model;
//using Pokno.Data;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public abstract class BusinessLogicBase<T, E> where E : class
    {
        public IRepository repository;
        public TranslatorBase<T, E> translator;
        
        public BusinessLogicBase(IRepository _repository)
        {
            repository = _repository;
        }
        
        protected const string ArgumentNullException = "Null object argument. Please contact your system administartor";
        protected const string UpdateException = "Operation failed due to update exception!";
        protected const string NoItemModified = "No item modified!";
        protected const string NoItemFound = "No item found to modified!";
        protected const string NoItemRemoved = "No item removed!";
        protected const string ErrowDuringProccesing = "Errow Occured During Processing.";
        protected const string TryAgain = "Please try again, but contact your system administrator after three unsuccessful trials.";

        protected const string ForeignKeyConstrainFailed = "constraint failedFOREIGN KEY constraint failed: constraint failed\r\nFOREIGN KEY constraint failed";
        protected const string ForeignKeyViolation = "The relationship could not be changed because one or more of the foreign-key properties is non-nullable";

        protected const string ITEM_WITH_THE_SAME_KEY = "An item with the same key has already been added";
        protected const string CONNECTION_WAS_CLOSED = "Connection was closed, statement was terminated";
        protected const string CONTEXT_CANNOT_BE_USED = "The context cannot be used while the model is being created. This exception may be thrown if the context";
        protected const string EDMTYPE_CANNOT_BE_MAPPED = "An EdmType cannot be mapped to CLR classes multiple times. The EdmType";
        protected const string LIBRARY_ROUTINE_CALLED_OUT_OF_SEQUENCE = "library routine called out of sequence";

        protected void OpenDatabaseConnectionIfClosed()
        {
            try
            {
                if (repository.DbContext.Database.Connection.State != ConnectionState.Open)
                {
                    repository.DbContext.Database.Connection.Open();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (message.Contains(LIBRARY_ROUTINE_CALLED_OUT_OF_SEQUENCE))
                {
                    try
                    {
                        if (repository.DbContext.Database.Connection.State != ConnectionState.Open)
                        {
                            repository.DbContext.Database.Connection.Open();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        protected void CommitTransaction(IDbTransaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    transaction.Commit();
                    repository.DbContext.Database.Connection.Close();
                }
            }
            catch(Exception)
            {

            }
        }
        //protected void RoolBackTransaction(IDbTransaction transaction)
        //{
        //    try
        //    {
        //        if (transaction != null)
        //        {
        //            transaction.Rollback();
        //            repository.DbContext.Database.Connection.Close();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        public virtual List<T> GetTopBy(int top, Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "")
        {
            List<T> models = null;

            try
            {
                List<E> entities = repository.GetTopBy(top, filter, orderBy, includeProperties);
                if (entities != null && entities.Count > 0)
                {
                    models = translator.Translate(entities);
                }
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return models;
        }

        protected void SuppressError(Exception ex)
        {
            try
            {
                string message = ex.Message;
                if (!message.Contains(ITEM_WITH_THE_SAME_KEY) && !message.Contains(CONNECTION_WAS_CLOSED) && !message.Contains(CONTEXT_CANNOT_BE_USED) && !message.Contains(EDMTYPE_CANNOT_BE_MAPPED))
                {
                    throw ex;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        public List<T> GetModelsBy(string rawQuery)
        {
            List<T> models = null;

            try
            {
                if (string.IsNullOrWhiteSpace(rawQuery))
                {
                    return null;
                }

                List<E> entities = repository.DbContext.Database.SqlQuery<E>(rawQuery).ToList();
                if (entities != null && entities.Count > 0)
                {
                    models = translator.Translate(entities);
                }
            }
            catch(Exception ex)
            {
                SuppressError(ex);
            }

            return models;
        }

        public virtual long GetMaxValueBy(Func<E, long> selector)
        {
            long value = 0;

            try
            {
                value = repository.GetMaxValueBy(selector); 
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return value;
        }

        public virtual T GetModelBy(Expression<Func<E, bool>> selector = null)
        {
            T t = default(T);

            try
            {
                E entity = repository.GetSingleBy(selector);
                t = translator.Translate(entity);
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return t;
        }

        public virtual List<T> GetModelsBy(Expression<Func<E, bool>> selector = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "")
        {
            List<T> models = null;

            try
            {
                List<E> entities = repository.GetBy(selector, orderBy, includeProperties).ToList();
                if (entities != null && entities.Count > 0)
                {
                    models = translator.Translate(entities);
                }
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return models;
        }

        public virtual List<T> FindBy(Expression<Func<E, bool>> selector = null)
        {
            List<T> models = null;

            try
            {
                List<E> entities = repository.FindAll(selector).ToList();
                if (entities != null && entities.Count > 0)
                {
                    models = translator.Translate(entities);
                }
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return models;
        }

        public virtual E GetEntityBy(Expression<Func<E, bool>> selector)
        {
            E e = default(E);

            try
            {
                e = repository.GetSingleBy(selector);
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return e;
        }

        public virtual List<E> GetEntitiesBy(Expression<Func<E, bool>> selector = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "")
        {
            List<E> entities = null;

            try
            {
                entities = repository.GetBy(selector, orderBy, includeProperties).ToList();
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return entities;
        }

        public virtual List<T> GetAll()
        {
            List<T> models = null;

            try
            {
                List<E> entities = repository.GetAll<E>().ToList();
                if (entities != null && entities.Count > 0)
                {
                    models = translator.Translate(entities);
                }
            }
            catch (Exception ex)
            {
                SuppressError(ex);
            }

            return models;
        }

        public virtual T Add(T model)
        {
            try
            {
                E entity = translator.Translate(model);
                E addedEntity = repository.Add(entity);

                repository.Save();

                return translator.Translate(addedEntity);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual int Add(List<T> models)
        {
            try
            {
                List<E> entities = translator.Translate(models);
                repository.Add<E>(entities);

                return repository.Save();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> AddCollection(List<T> models)
        {
            try
            {
                List<E> entities = translator.Translate(models);
                entities = repository.AddCollection<E>(entities).ToList();
                repository.Save();

                List<T> newModels = null;
                if (entities != null && entities.Count > 0)
                {
                    newModels = translator.Translate(entities);
                }

                return newModels;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(ArgumentNullException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Expression<Func<E, bool>> selector)
        {
            try
            {
                repository.Delete(selector);
                return Save() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                string innerException = "";
                string message = ex.Message;
                
                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                {
                    innerException = ex.InnerException.InnerException.Message;
                }

                //bool e = ForeignKeyViolation.Contains(message);
                //bool e2 = ForeignKeyConstrainFailed.Contains(innerException);
                if (ForeignKeyViolation.Contains(message) || ForeignKeyConstrainFailed.Contains(innerException))
                {
                    throw new Exception("This record cannot be removed at this time, because it has other record(s) attached to it. But if you insist on its removal, then you will first of all remove all records attached to it, after which you can now remove it.\n\nIf you are still not succesful after taking the above recommended steps, kindly contact you system administartor for assistance.");
                }

                throw;
            }
        }

        public int Save()
        {
            return repository.Save();
        }

       



       


    }


}
