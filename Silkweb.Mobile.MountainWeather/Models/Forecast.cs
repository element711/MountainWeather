using System;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.Models
{
	public class Forecast
	{
        public DateTime Date { get; set; }

        public string Weather { get; set; }

        public string Visibility { get; set; }

        public string HillFog { get; set; }

        public string MaxWindLevel { get; set; }

        public string MaxWind { get; set; }

        public string TempLowLevel { get; set; }

        public string TempHighLevel { get; set; }

        public string FreezingLevel { get; set; }

        public WeatherPPN WeatherPPN { get; set; }

	}


}

