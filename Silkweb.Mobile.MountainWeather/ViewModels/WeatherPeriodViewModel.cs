using System;
using Silkweb.Mobile.Core.ViewModels;
using Silkweb.Mobile.MountainWeather.Models;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class WeatherPeriodViewModel : ViewModelBase
    {
        public WeatherPeriodViewModel(WxPeriod period)
        {
            var weatherCode = WeatherCodes.Instance.TryFind(period.Weather);
            Icon = weatherCode.Icon;

            Weather = weatherCode.Description
                .Replace("(day)", string.Empty)
                .Replace("(night)", string.Empty);

            Probability = period.Probability;
            SetPeriod(period);
        }

        public string Period { get; set; }

        public string Icon { get; set; }

        public string Weather { get; set; }

        public string Probability { get; set; }

        private void SetPeriod(WxPeriod period)
        {
            var periods = period.Period.Replace(" to ", "|").Split('|');
            var fromTime = ToTimeString(periods[0].Trim());
            var toTime = ToTimeString(periods[1].Trim());
            Period = string.Format("{0}-{1}", fromTime, toTime);
        }

        private string ToTimeString(string time)
        {
            var hour = int.Parse(time.Substring(0, 2));
            var mins = int.Parse(time.Substring(2, 2));

            return new DateTime()
                .AddHours(hour)
                .AddMinutes(mins)
                .ToString("htt")
                .ToLower();
        }

    }
}

