using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pokno.Infrastructure.Converters
{
    public class IsExistConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = "";
            bool exists = (bool)value;
            
            if (exists)
            {
                color = "Black";
            }
            else
            {
                color = "Red";
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool exists = false;
            string color = (string)value;
            
            if (color == "Red")
            {
                exists = false;
            }
            else
            {
                exists = true;
            }

            return exists;
        }



    }


}
