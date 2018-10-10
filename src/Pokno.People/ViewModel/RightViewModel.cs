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

using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Interfaces;
using Pokno.Infrastructure.Models;
using Pokno.Model;

namespace Pokno.People.ViewModels
{
    public class RightViewModel : SetupViewModelBase<Right>
    {
        public RightViewModel(ISetupService<Right> _service)
            : base(_service)
        {
            _modelName = "Right";
        }

        public string TabCaption
        {
            get { return _modelName; }
        }

       



    }
}
