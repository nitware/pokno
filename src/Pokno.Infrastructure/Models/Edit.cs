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

namespace Pokno.Infrastructure.Models
{
    public class Edit
    {
        public enum Mode
        {
            Loaded = 1,
            Adding = 2,
            Editing = 3,
            Selected = 4,
            ChangeBound = 5
        }
    }


}
