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

using System.Collections.ObjectModel;
using Pokno.Infrastructure.Interfaces;
using Pokno.Service;
using Pokno.Model;
using System.Collections.Generic;

namespace Pokno.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private IBusinessFacade _service;

        public PaymentService(IBusinessFacade service)
        {
            _service = service;
        }

        public List<Payment> LoadTransactionByPerson(Person person)
        {
            try
            {
                return _service.GetPaymentTransactions(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PaymentDetail> LoadPaymentDetailByPayment(Payment payment)
        {
            try
            {
                return _service.GetPaymentDetails(payment);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //public bool UpdatePaymentDetail(List<PaymentDetail> paymentDetails)
        //{
        //    try
        //    {
        //        return _service.UpdatePaymentDetail(paymentDetails);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public bool ModifyPaymentDetail(List<PaymentDetail> paymentDetails)
        {
            try
            {
                return _service.ModifyPaymentDetail(paymentDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }
       


    }
}
