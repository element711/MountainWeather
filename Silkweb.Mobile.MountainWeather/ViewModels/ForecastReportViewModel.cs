using System;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.Core.ViewModels;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class ForecastDayViewModel : ViewModelBase
    {
        public string Day { get; set; }
    }

    public class ForecastReportViewModel : ViewModelBase
    {
        private ForecastReport _forecastReport;

        public ForecastReport ForecastReport
        {
            get { return _forecastReport; }
            set 
            { 
                SetProperty(ref _forecastReport, value);
                SetDays();
            }
        }

        List<ForecastDayViewModel> _days;
        public List<ForecastDayViewModel> Days
        {
            get
            {
                return _days;
            }
            set
            {
                SetProperty(ref _days, value);
            }
        }

        private void SetDays()
        {
            var date = ForecastReport.IssueDateTime;
            var days = new List<ForecastDayViewModel>();

            for (int i = 0; i < 5; i++)
            {
                var day = date.DayOfWeek;
                days.Add(new ForecastDayViewModel { Day = day.ToString() });
                date = date.AddDays(1);
            }

            Days = days;
        }
    }
}

