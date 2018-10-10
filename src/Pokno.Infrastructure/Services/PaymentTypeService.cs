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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Pokno.Infrastructure.Interfaces;
using Pokno.Service;
using Pokno.Model;

namespace Pokno.Infratructure.Services
{
    public class PaymentTypeService : ISetupService<PaymentType>
    {
        private IBusinessFacade _service;

        public PaymentTypeService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<PaymentType> LoadAll()
        {
            try
            {
                return _service.GetAllPaymentTypes();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Save(PaymentType paymentType)
        {
            try
            {
                return _service.AddPaymentType(paymentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Modify(PaymentType paymentType)
        {
            try
            {
                return _service.ModifyPaymentType(paymentType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Remove(PaymentType paymentType)
        {
            try
            {
                return _service.RemovePaymentType(paymentType);
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
