using System;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.MountainWeather.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Services;
using Silkweb.Mobile.Core.ViewModels;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class MountainAreaViewModel : ViewModelBase
    {
        private readonly IMountainWeatherService _mountainWeatherService;
        private readonly INavigator _navigator;
        private readonly Location _location;
        private readonly IDialogProvider _dialogProvider;

        public MountainAreaViewModel(Location location, 
            IMountainWeatherService mountainWeatherService,
            INavigator navigator,
            IDialogProvider dialogProvider)
        {
            this._dialogProvider = dialogProvider;
            _location = location;
            _navigator = navigator;
            _mountainWeatherService = mountainWeatherService;
            ShowForecastCommand = new Command(ShowForecast);
        }


        public string Name { get { return _location.Name; } }

        public DateTime IssuedDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public ICommand ShowForecastCommand { get; set; }

        private async void ShowForecast()
        {
            try
            {
                ForecastReport forecastReport = await _mountainWeatherService.GetAreaForecast(_location.Id);

                if (forecastReport == null)
                    return;

                await _navigator.PushAsync<ForecastReportViewModel>(vm => 
                    {
                        vm.Title = _location.Name;
                        vm.ForecastReport = forecastReport;
                    }
                );
            }
            catch (Exception ex)
            {
                var result = await _dialogProvider.DisplayActionSheet(ex.Message, "Cancel", null, "Retry");

                if (result == "Retry")
                    ShowForecast();
            }
        }
    }
}

