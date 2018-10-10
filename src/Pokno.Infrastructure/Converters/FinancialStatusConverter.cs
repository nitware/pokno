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

using System.Windows.Data;
using System.Globalization;

namespace Pokno.Infrastructure.Converters
{
    public class FinancialStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal statusValue = (decimal)value;
            if (statusValue == 0)
            {
                //return "Green";
                return "White";
            }
            else if (statusValue > 0)
            {
                return "Red";
            }
            else
            {
                return "Blue";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
