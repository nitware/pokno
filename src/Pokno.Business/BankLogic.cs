using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using Pokno.Business.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class BankLogic : BusinessLogicBase<Bank, BANK>
    {
        public BankLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new BankTranslator();
        }
        
        public  bool Modify(Bank bank)
        {
            try
            {
                 Expression<Func<BANK, bool>> predicate = b => b.Bank_Id == bank.Id;
                 BANK bankEntity  = GetEntityBy(predicate);
                 bankEntity.Bank_Name = bank.Name;
                 bankEntity.Bank_Description = bank.Description;

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

        public bool Remove(Bank bank) 
        {
            try
            {
                Expression<Func<BANK, bool>> selector = b => b.Bank_Id == bank.Id;
                bool suceeded = base.Remove(selector);
                return suceeded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        



    }
}
