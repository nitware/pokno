using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Infrastructure.Interfaces;
using System.Collections.ObjectModel;
using Pokno.Model;
using Pokno.Service;
using System.Collections.Generic;

namespace Pokno.Infratructure.Services
{
    public class LocationService : ISetupService<Location>
    {
        private IBusinessFacade _service;

        public LocationService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Location> LoadAll()
        {
            try
            {
                return _service.GetAllLocations();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(Location location)
        {
            try
            {
                return _service.AddLocation(location);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(Location location)
        {
            try
            {
                return _service.ModifyLocation(location);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(Location location)
        {
            try
            {
                return _service.RemoveLocation(location);
            }
            catch (Exception)
            {
                throw;
            }
        }

       


    }


}
