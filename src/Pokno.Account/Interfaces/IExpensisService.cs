using System;
using System.Net;
using System.Windows;
using System.Windows.Input;

using Pokno.Model.Model;

namespace Pokno.Account.Interfaces
{
    public interface IExpensisService
    {
        Expenses LoadExpensisByDate(DateTime expensisDate);
        bool Save(Expenses expensis);
    }




}
