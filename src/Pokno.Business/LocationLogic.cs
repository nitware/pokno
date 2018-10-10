using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data;

using Pokno.Model;
using Pokno.Entity;
using System.Linq.Expressions;
using Pokno.Business.Interfaces;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class LocationLogic : BusinessLogicBase<Location, LOCATION>
    {
        public LocationLogic(IRepository repository)
            : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            base.translator = new LocationTranslator();
        }

        public bool Modify(Location location)
        {
            try
            {
                Expression<Func<LOCATION, bool>> selctor = lc => lc.Location_Id == location.Id;
                LOCATION locationEntity = GetEntityBy(selctor);
                locationEntity.Location_Name = location.Name;
                locationEntity.Location_Address = location.Address;
                int rowAffected = repository.Save();

                if (rowAffected > 0)
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
            catch (ConstraintException)
            {
                throw new ConstraintException("");
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
        }

        public bool Remove(Location location)
        {
            try
            {
                Expression<Func<LOCATION, bool>> selector = mylocate => mylocate.Location_Id == location.Id;
                bool suceeded = base.Remove(selector);

                //repository.Save();
                return suceeded;

            }            
            catch (Exception)
            {
                throw;
            }
        }




    }
}
