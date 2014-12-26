using Silkweb.Mobile.MountainWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Extensions;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class ForecastViewModel : WeatherDayViewModel
    { 
        public ForecastViewModel(Forecast forecast)
        {   
            Forecast = forecast;
            Date = forecast.Date;
            Weather = forecast.Weather;
            Title = string.Format(forecast.Date.ToString("dddd d{0} MMMM"), Date.DaySuffix());
            IssuedBy = string.Format("Issued by The Met Office on {0} at {1}",
                string.Format(forecast.Date.ToString("d{0} MMM"), Date.DaySuffix()),
                string.Format(forecast.Date.ToString("hh:ss")));

            if (forecast.WeatherPPN != null && forecast.WeatherPPN.WxPeriods != null)
            {
                int code = forecast.WeatherPPN.WxPeriods
                    .Where(x => x.No > 2 && x.No < 7)
                    .Select(x => x.Weather)
                    .Mode();

                var weatherCode = WeatherCodes.Instance.FirstOrDefault(x => x.Code == code);

                if (weatherCode != null && !string.IsNullOrEmpty(weatherCode.Icon))
                    Icon = weatherCode.Icon;

                WeatherPeriods = forecast.WeatherPPN.WxPeriods
                    .Select(period => new WeatherPeriodViewModel(period))
                    .ToList();
            }
        } 

        public Forecast Forecast { get; set; }

        public IEnumerable<WeatherPeriodViewModel> WeatherPeriods { get; set; }

        public ImageSource Icon { get; set; }
    }
}
