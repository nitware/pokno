using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Model.Model;
using Pokno.Model;
using System.Collections.Generic;

namespace Pokno.People.Interfaces
{
    public interface ILoginDetailService
    {
        List<LoginDetail> LoadAll();
        bool Reset(LoginDetail loginDetail);
        bool Modify(LoginDetail loginDetail);
        LoginDetail ChangePassword(Person person, string password);


    }




}
