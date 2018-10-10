using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;

namespace Pokno.Infrastructure.Converters
{
    public class MakeComboBoxItemBoldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string fontWeight = "";
            bool exists = (bool)value;

            if (exists)
            {
                fontWeight = "Normal";
            }
            else
            {
                fontWeight = "Bold";
            }

            return fontWeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool exists = false;
            string fontWeight = (string)value;

            if (fontWeight == "Bold")
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
