using System;
using Silkweb.Mobile.Core.Extensions;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class OutlookViewModel : WeatherDayViewModel
    {
        public OutlookViewModel(string outlook, DateTime date)
        {
            Date = date;
            Weather = outlook;
            Title = string.Format(date.ToString("dddd d{0} MMMM"), Date.DaySuffix());
            IssuedBy = string.Format("Issued by The Met Office on {0} at {1}",
                string.Format(date.ToString("d{0} MMM"), Date.DaySuffix()),
                string.Format(date.ToString("hh:ss")));
        }
    }
}
