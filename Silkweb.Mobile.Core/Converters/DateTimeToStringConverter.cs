using System;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Extensions;

namespace Silkweb.Mobile.Core.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is DateTime) || !(parameter is string))
                return null;

            var dateTime = (DateTime)value;
            var format = (string)parameter;

            if (format.Contains("d{0}"))
                return string.Format(dateTime.ToString(format), dateTime.DaySuffix());

            return dateTime.ToString(format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

