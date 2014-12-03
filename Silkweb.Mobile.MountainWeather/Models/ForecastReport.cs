using System;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.Models
{
    public class ForecastReport
	{
        public string IssuedBy { get; set; }

        public DateTime IssueDateTime { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public string Validity { get; set; }

        public string IssuedDate { get; set; }

        public IEnumerable<Hazard> Hazards { get; set; }

        public string Overview { get; set; }

        public Forecast ForecastDay0 { get; set; }

        public Forecast ForecastDay1 { get; set; }

        public string OutlookDay2 { get; set; }
       
        public string OutlookDay3 { get; set; }

        public string OutlookDay4 { get; set; }

        public string GroundConditions { get; set; }

        public IEnumerable<RainGauge> RainGauges { get; set; }

	}

}

