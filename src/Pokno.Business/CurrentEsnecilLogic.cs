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

namespace Pokno.Business
{
    public class CurrentEsnecilLogic : BusinessLogicBase<CurrentEsnecil, CURRENT_ESNECIL>
    {
        public CurrentEsnecilLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new CurrentEsnecilTranslator();
        }

        public Esnecil Get()
        {
            try
            {
                List<CurrentEsnecil> currentEsnecils = base.GetAll();
                if (currentEsnecils == null || currentEsnecils.Count <= 0)
                {
                    return null;
                }

                CurrentEsnecil currentEsnecil = currentEsnecils.SingleOrDefault();

                return currentEsnecil.Esnecil;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove()
        {
            try
            {
                List<CurrentEsnecil> currentEsnecils = base.GetAll();
                if (currentEsnecils == null || currentEsnecils.Count <= 0)
                {
                    return true;
                }

                foreach (CurrentEsnecil currentEsnecil in currentEsnecils)
                {
                    Expression<Func<CURRENT_ESNECIL, bool>> selector = sp => sp.Esnecil_Id == currentEsnecil.Esnecil.Id;
                    base.Remove(selector);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }


}
