using System;
using Xamarin.Forms;

namespace Silkweb.Mobile.MountainWeather.Converters
{
    public class SelectedColorConverter : IValueConverter
    {
        public Color SelectedColor { get; set; }

        public Color UnSelectedColor { get; set; }

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
                return UnSelectedColor;

            var isSelected = (bool)value;

            return isSelected ? SelectedColor : UnSelectedColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}

