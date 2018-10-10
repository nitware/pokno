using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Model.Model;

namespace Pokno.People.Interfaces
{
    public interface ILoginService
    {
        LoginDetail ValidateUser(string userName, string password);
    }


}
