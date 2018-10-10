using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;
using System.Data;
using System.Linq.Expressions;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class EsnecilLogic : BusinessLogicBase<Esnecil, ESNECIL>
    {
        private CurrentEsnecilLogic _currentEsnecilLogic;

        public EsnecilLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new EsnecilTranslator();
            _currentEsnecilLogic = new CurrentEsnecilLogic(repository);
        }

        public override Esnecil Add(Esnecil esnecil)
        {
            try
            {
                if (esnecil == null)
                {
                    throw new ArgumentNullException("esnecil");
                }

                Esnecil newEsnecil = null;
                base.OpenDatabaseConnectionIfClosed();
                using (IDbTransaction transaction = repository.DbContext.Database.Connection.BeginTransaction())
                {
                    _currentEsnecilLogic.repository = repository;
                    bool removed = _currentEsnecilLogic.Remove();
                    if (removed == false)
                    {
                        throw new Exception("Current Esnecil Delete Operation failed!");
                    }

                    newEsnecil = base.Add(esnecil);
                    if (newEsnecil == null || newEsnecil.Id <= 0)
                    {
                        throw new Exception("Save Operation failed!");
                    }

                    CurrentEsnecil currentEsnecil = new CurrentEsnecil();
                    currentEsnecil.Esnecil = newEsnecil;
                    CurrentEsnecil newCurrentEsnecil = _currentEsnecilLogic.Add(currentEsnecil);
                    if (newCurrentEsnecil == null || newCurrentEsnecil.Esnecil == null || newCurrentEsnecil.Esnecil.Id <= 0)
                    {
                        throw new Exception("Current Esnecil Save Operation failed!");
                    }

                    base.CommitTransaction(transaction);

                    //transaction.Commit();
                    //repository.DbContext.Database.Connection.Close();
                }

                return newEsnecil;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Esnecil esnecil)
        {
            try
            {
                Expression<Func<ESNECIL, bool>> predicate = x => x.Esnecil_Id == esnecil.Id;
                ESNECIL entity = GetEntityBy(predicate);

                entity.Validation_Key = esnecil.ValidationKey;
                entity.Machine_Code = esnecil.MachineCode;
                entity.Esnecil_Code = esnecil.EsnecilCode;
                entity.Serial_Code = esnecil.SerialCode;
                entity.Activation_Date = esnecil.ActivationDate;
                entity.Is_Evaluation = esnecil.IsEvaluation;

                repository.Save();
                return true;
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
