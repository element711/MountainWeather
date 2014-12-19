using System;
using System.Collections.Generic;

namespace Silkweb.Mobile.MountainWeather.Models
{
    public class WeatherCode
    {
        public WeatherCode (int code, string description, string icon, string nightIcon = null)
        {
            Code = code;
            Description = description;
            Icon = icon;
            NightIcon = nightIcon;
        }
        public int Code { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string NightIcon { get; set; }
    }

    public class WeatherCodes : List<WeatherCode>
    {
        public static WeatherCodes Instance
        {
            get { return _weatherCodes;}
        }

        public WeatherCode TryFind(int code)
        {
            if (code < Count)
                return this[code];
            
            return null;
        }

        static readonly WeatherCodes _weatherCodes = new WeatherCodes
        {
            new WeatherCode(0, "Clear night", "wsymbol_0008_clear_sky_night", ""),
            new WeatherCode(1, "Sunny day", "wsymbol_0001_sunny", ""),
            new WeatherCode(2, "Partly cloudy (night)", "wsymbol_0041_partly_cloudy_night", ""),
            new WeatherCode(3, "Partly cloudy (day)", "wsymbol_0002_sunny_intervals", ""),
            new WeatherCode(4, "Not used", "N/A", ""),
            new WeatherCode(5, "Mist", "wsymbol_0006_mist", "wsymbol_0063_mist_night"),
            new WeatherCode(6, "Fog", "wsymbol_0007_fog", "wsymbol_0064_fog_night"),
            new WeatherCode(7, "Cloudy", "wsymbol_0003_white_cloud", "wsymbol_0044_mostly_cloudy_night"),
            new WeatherCode(8, "Overcast", "wsymbol_0004_black_low_cloud", "wsymbol_0042_cloudy_night"),
            new WeatherCode(9, "Light rain shower (night)", "wsymbol_0025_light_rain_showers_night", ""),
            new WeatherCode(10, "Light rain shower (day)", "wsymbol_0009_light_rain_showers", ""),
            new WeatherCode(11, "Drizzle", "wsymbol_0048_drizzle", "wsymbol_0066_drizzle_night"),
            new WeatherCode(12, "Light rain", "wsymbol_0017_cloudy_with_light_rain", "wsymbol_0033_cloudy_with_light_rain_night"),
            new WeatherCode(13, "Heavy rain shower (night)", "wsymbol_0026_heavy_rain_showers_night", ""),
            new WeatherCode(14, "Heavy rain shower (day)", "wsymbol_0010_heavy_rain_showers", ""),
            new WeatherCode(15, "Heavy rain", "wsymbol_0018_cloudy_with_heavy_rain", "wsymbol_0034_cloudy_with_heavy_rain_night"),
            new WeatherCode(16, "Sleet shower (night)", "wsymbol_0029_sleet_showers_night", ""),
            new WeatherCode(17, "Sleet shower (day)", "wsymbol_0013_sleet_showers", ""),
            new WeatherCode(18, "Sleet", "wsymbol_0021_cloudy_with_sleet", "wsymbol_0037_cloudy_with_sleet_night"),
            new WeatherCode(19, "Hail shower (night)", "wsymbol_0030_light_hail_showers_night", ""),
            new WeatherCode(20, "Hail shower (day)", "wsymbol_0014_light_hail_showers", ""),
            new WeatherCode(21, "Hail", "wsymbol_0022_cloudy_with_light_hail", "wsymbol_0038_cloudy_with_light_hail_night"),
            new WeatherCode(22, "Light snow shower (night)", "wsymbol_0027_light_snow_showers_night", ""),
            new WeatherCode(23, "Light snow shower (day)", "wsymbol_0011_light_snow_showers", ""),
            new WeatherCode(24, "Light snow", "wsymbol_0019_cloudy_with_light_snow", "wsymbol_0035_cloudy_with_light_snow_night"),
            new WeatherCode(25, "Heavy snow shower (night)", "wsymbol_0028_heavy_snow_showers_night", ""),
            new WeatherCode(26, "Heavy snow shower (day)", "wsymbol_0012_heavy_snow_showers", ""),
            new WeatherCode(27, "Heavy snow", "wsymbol_0020_cloudy_with_heavy_snow", "wsymbol_0036_cloudy_with_heavy_snow_night"),
            new WeatherCode(28, "Thunder shower (night)", "wsymbol_0032_thundery_showers_night", ""),
            new WeatherCode(29, "Thunder shower (day)", "wsymbol_0016_thundery_showers", ""),
            new WeatherCode(30, "Thunder", "wsymbol_0024_thunderstorms", "wsymbol_0040_thunderstorms_night")
        };
    }
}

