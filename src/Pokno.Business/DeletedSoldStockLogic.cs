using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Model.Translator;
using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class DeletedSoldStockLogic : BusinessLogicBase<DeletedSoldStock, DELETED_SOLD_STOCK>
    {
        public DeletedSoldStockLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new DeletedSoldStockTranslator();
        }

    }



}
