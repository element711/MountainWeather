using System;
using Silkweb.Mobile.MountainWeather.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Services;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class MountainAreaViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly Location _location;
        private readonly ForecastReportViewModel _forecastReportViewModel;

        public MountainAreaViewModel(
            Location location, 
            INavigator navigator,
            Func<Location, ForecastReportViewModel> forecastReportViewModelFactory)
        {
            _location = location;
            _navigator = navigator;
            _forecastReportViewModel = forecastReportViewModelFactory(_location);

            ShowForecastCommand = new Command(ShowForecast);
        }

        public string Name { get { return _location.Name; } }

        public DateTime IssuedDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public ICommand ShowForecastCommand { get; set; }

        private async void ShowForecast()
        {
            await _navigator.PushAsync<ForecastReportViewModel>(_forecastReportViewModel);
        }
    }
}

