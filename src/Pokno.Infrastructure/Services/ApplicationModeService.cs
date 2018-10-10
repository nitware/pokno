using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Service;
using Pokno.Model.Model;
using Pokno.Infrastructure.Interfaces;

namespace Pokno.Infratructure.Services
{
    public class ApplicationModeService : ISetupService<ApplicationMode>
    {
        private IBusinessFacade _service;

        public ApplicationModeService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<ApplicationMode> LoadAll()
        {
            try
            {
                return _service.GetAllApplicationModes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(ApplicationMode applicationMode)
        {
            try
            {
                return _service.AddApplicationMode(applicationMode);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(ApplicationMode applicationMode)
        {
            try
            {
                return _service.ModifyApplicationMode(applicationMode);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(ApplicationMode applicationMode)
        {
            try
            {
                return _service.RemoveApplicationMode(applicationMode);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
