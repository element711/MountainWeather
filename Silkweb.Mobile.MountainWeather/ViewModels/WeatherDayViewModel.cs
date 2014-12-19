using System;
using Silkweb.Mobile.Core.ViewModels;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class WeatherDayViewModel : SelectableViewModel
    {
        private DateTime _issuedDate;
        private DateTime _date;
        private string _weather;

        public DateTime Date 
        {  
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public DateTime IssuedDate
        {
            get { return _issuedDate; }
            set { SetProperty(ref _issuedDate, value);  }
        }

        public string IssuedBy { get; set; }

        public string Weather 
        { 
            get { return _weather; }
            set { SetProperty(ref _weather, value); }
        }
    }
    
}
