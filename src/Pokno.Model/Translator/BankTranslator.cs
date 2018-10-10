using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class BankTranslator : TranslatorBase<Bank, BANK>
    {
        public override Bank TranslateToModel(BANK bankEntity)
        {
            try
            {
                Bank bank = null;
                if (bankEntity != null)
                {
                    bank = new Bank();
                    bank.Id = (int)bankEntity.Bank_Id;
                    bank.Name = bankEntity.Bank_Name;
                    bank.Description = bankEntity.Bank_Description;
                }

                return bank;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override BANK TranslateToEntity(Bank bank)
        {
            try
            {
                BANK bankEntity = null;
                if (bank != null)
                {
                    bankEntity = new BANK();
                    bankEntity.Bank_Id = bank.Id;
                    bankEntity.Bank_Name = bank.Name;
                    bankEntity.Bank_Description = bank.Description;
                }

                return bankEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
