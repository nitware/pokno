using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class ChequeTranslator : TranslatorBase<Cheque, CHEQUE>
    {
        private BankTranslator bankTranslator;
        
        public ChequeTranslator()
        {
            bankTranslator = new BankTranslator();
        }

        public override Cheque TranslateToModel(CHEQUE entity)
        {
            try
            {
                Cheque check = null;
                if (entity != null)
                {
                    check = new Cheque();
                    check.Id = entity.Payment_Detail_Id;
                    check.Bank = bankTranslator.Translate(entity.BANK);
                    check.ChequeNumber = entity.Cheque_Number;
                    check.AccountNumber = entity.Account_Number;
                }

                return check;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override CHEQUE TranslateToEntity(Cheque check)
        {
            try
            {
                CHEQUE entity = null;
                if (check != null)
                {
                    entity = new CHEQUE();
                    entity.Payment_Detail_Id = check.Id;
                    entity.Bank_Id = check.Bank.Id;
                    entity.Cheque_Number = check.ChequeNumber;
                    entity.Account_Number = check.AccountNumber;
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
