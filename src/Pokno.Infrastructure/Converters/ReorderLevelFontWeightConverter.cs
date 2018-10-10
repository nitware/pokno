using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pokno.Infrastructure.Converters
{
    public class ReorderLevelFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fontWeight = "";
            long reoderLevel = (long)value;

            if (reoderLevel <= 0)
            {
                fontWeight = "Bold";
            }
            else
            {
                fontWeight = "Normal";
            }

            return fontWeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
            //throw new NotImplementedException();
        }


    }
}
