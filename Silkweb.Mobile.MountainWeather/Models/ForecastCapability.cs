using System;

namespace Silkweb.Mobile.MountainWeather.Models
{
	public class ForecastCapability
	{
        public DateTime IssuedDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime CreatedDate { get; set; }

        public Uri Uri { get; set; }

        public string Area { get; set; }

        public Risk Risk { get; set; }
	}

}

