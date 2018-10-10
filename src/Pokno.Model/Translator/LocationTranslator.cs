using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
   public class LocationTranslator : TranslatorBase<Location,LOCATION>
    {
       public override Location TranslateToModel(LOCATION locationEntity)
       {
           try
           {
               Location location = null;
               if (locationEntity != null)
               {
                   location = new Location();
                   location.Id = (int)locationEntity.Location_Id;
                   location.Name = locationEntity.Location_Name;
                   location.Address = locationEntity.Location_Address;
               }

               return location;
           }
           catch (Exception)
           {
               throw;
           }
       }

       public override LOCATION TranslateToEntity(Location location)
        {
            try
            {
                LOCATION locationEntity = null;
                if (location != null)
                {
                    locationEntity = new LOCATION();
                    locationEntity.Location_Id = location.Id;
                    locationEntity.Location_Name = location.Name;
                    locationEntity.Location_Address = location.Address;
                }

                return locationEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
