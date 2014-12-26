using Silkweb.Mobile.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Factories;

namespace Silkweb.Mobile.MountainWeather.Converters
{
    public class ViewModelToViewConverter : BindableObject, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (ViewFactory.Instance == null)
                return null;

            var viewModel = value as IViewModel;
            if (viewModel == null) return null;

            var view = ViewFactory.Instance.Resolve(viewModel);

            return view;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
