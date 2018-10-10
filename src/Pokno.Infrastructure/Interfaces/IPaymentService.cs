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

using Pokno.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Pokno.Infrastructure.Interfaces
{
    public interface IPaymentService
    {
        List<Pokno.Model.Payment> LoadTransactionByPerson(Person person);
        List<PaymentDetail> LoadPaymentDetailByPayment(Pokno.Model.Payment payment);
        bool ModifyPaymentDetail(List<PaymentDetail> paymentDetails);


        //bool UpdatePaymentDetail(List<PaymentDetail> paymentDetails);
        //void LoadTransactionByPerson(Pokno.Model.Person person);
        //void LoadPaymentDetailByPayment(Pokno.Model.Payment payment);
        //void ModifyPaymentDetail(ObservableCollection<PaymentDetail> paymentDetails);
    }



}
