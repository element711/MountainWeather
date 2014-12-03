using System;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.Models
{
	public class RainGauge
	{
        public DateTime MeasurementDate { get; set; }

        public string Type { get; set; }

        public string Site { get; set; }

        public int Altitude { get; set; }

        public string Location { get; set; }

        public string WMO { get; set; }

        public IEnumerable<GaugeText> Texts { get; set; }
	}


}

