﻿using System;
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
using System.Collections.Generic;

namespace Pokno.Infrastructure.Interfaces
{
    public interface ISetupService<T>
    {
        List<T> LoadAll();
        bool Save(T model);
        bool Modify(T model);
        bool Remove(T model);
    }
    

}