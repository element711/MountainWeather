using System;
using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather.Models;
using System.Linq;

namespace Silkweb.Mobile.MountainWeather.Converters
{
    public class WeatherCodeConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is int))
                return null;

            var code = (int)value;

            var weatherCode = WeatherCodes.Instance.FirstOrDefault(x => x.Code == code);

            return weatherCode.Icon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}

