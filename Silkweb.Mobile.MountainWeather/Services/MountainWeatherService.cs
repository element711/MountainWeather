using System;
using System.Collections.Generic;
using Silkweb.Mobile.MountainWeather.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using System.Globalization;

namespace Silkweb.Mobile.MountainWeather.Services
{
    public class MountainWeatherService : IMountainWeatherService
    {
        private const string BaseUrL = "http://datapoint.metoffice.gov.uk/public/data/";
        private const string Key = "c7bbe567-e118-4794-ad46-5e235ff1e781";

        public async Task<ForecastCapability[]> GetCapabilities()
        {
            string result = null;

            try
            {
                Debug.WriteLine("Getting capabilities from DataPoint Service...");
                result = await Get("txt/wxfcs/mountainarea/json/capabilities");   
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get capabilities from service provider. The service maybe down. Retry or try again later.", ex);
            }

            ForecastCapability[] forecastCapability;

            try
            {
                var forecastsToken = JObject.Parse(result)["MountainForecastList"]["MountainForecast"];

                forecastCapability = forecastsToken.Select(forecast => {

                    var capability = new ForecastCapability
                    {
                        IssuedDate = DateTime.Parse((string)forecast["DataDate"], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                        ValidFrom = DateTime.Parse((string)forecast["ValidFrom"], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                        ValidTo = DateTime.Parse((string)forecast["ValidTo"], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                        CreatedDate = DateTime.Parse((string)forecast["CreatedDate"], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                        Uri = new Uri((string)forecast["URI"]),
                        Area = (string)forecast["Area"]
                    };

                    Risk risk;
                    Enum.TryParse<Risk>((string)forecast["Risk"], out risk);
                    capability.Risk = risk;
                    return capability;

                }).ToArray();
            }
            catch (Exception ex)
            {
                throw new FormatException("Failed to format forecast capabilities.", ex);
            }

            return forecastCapability;
        }

        public async Task<IEnumerable<Location>> GetAreas()
        {
//            string result;

//            try
//            {
//                Debug.WriteLine("Getting Locations from DataPoint Service...");
//                result = await Get("txt/wxfcs/mountainarea/json/sitelist");   
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Failed to get locations from service provider. The service maybe down. Retry or try again later.", ex);
//            }

//            Location[] locations

//            try
//            {                
//                var locationToken = JObject.Parse(result)["Locations"]["Location"];
//
//                locations = locationToken.Select(location => new Location()
//                    { 
//                        Id = (int)location["@id"], 
//                        Name = (string)location["@name"] 
//                    }).ToArray();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Failed to format the mountain areas site list.", ex);
//            }

            Location[] locations = new Location[7]
                {
                    new Location { Id = 100, Name = "Brecon Beacons" },
                    new Location { Id = 101, Name = "East Highland" },
                    new Location { Id = 102, Name = "Lake District" },
                    new Location { Id = 103, Name = "Peak District" },
                    new Location { Id = 104, Name = "Snowdonia" },
                    new Location { Id = 105, Name = "West Highland" },
                    new Location { Id = 106, Name = "Yorkshire Dales" }
                };

            return locations;
        }

        public async Task<ForecastReport> GetAreaForecast(int id)
        {
            string result = null;

            try
            {
                Debug.WriteLine("Getting Area Forecast from DataPoint Service...");
                result = await Get(string.Format("txt/wxfcs/mountainarea/json/{0}", id));   
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Area Forecast from service provider. The service maybe down. Retry or try again", ex);
            }

            ForecastReport forecastReport;

            try
            {                
                var report = JObject.Parse(result)["report"];

                var issueDate = DateTime.Parse((string)report["creation-time"], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

                var forecastReport2 = new ForecastReport();
                forecastReport2.IssuedBy = (string)report["creating-authority"];
                forecastReport2.IssueDateTime = issueDate;
                forecastReport2.Title = (string)report["title"];
                forecastReport2.Location = (string)report["title"];
                forecastReport2.ValidFrom = DateTime.Parse((string)report["ValidFrom"], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                forecastReport2.ValidTo = DateTime.Parse((string)report["ValidTo"], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                forecastReport2.Validity = (string)report["Validity"];
                forecastReport2.IssuedDate = (string)report["IssuedDate"];
                forecastReport2.Hazards = report["Hazards"]["Hazard"].Select(hazard => new Hazard {
                    No = (short)hazard["no"],
                    Element = (string)hazard["Element"],
                    Risk = (string)hazard["Risk"],
                    Comments = (string)hazard["Comments"]
                });
                forecastReport2.Overview = (string)report["Overview"];
                forecastReport2.ForecastDay0 = ParseForecast(report["Forecast_Day0"], issueDate);
                forecastReport2.ForecastDay1 = ParseForecast(report["Forecast_Day1"], issueDate.AddDays(1));
                forecastReport2.OutlookDay2 = (string)report["Outlook_Day2"];
                forecastReport2.OutlookDay3 = (string)report["Outlook_Day3"];
                forecastReport2.OutlookDay4 = (string)report["Outlook_Day4"];
                forecastReport = forecastReport2;
            }
            catch (Exception ex)
            {
                throw new FormatException("Failed to format the forecast report.", ex);
            }

            return forecastReport;
        }

        private Forecast ParseForecast(JToken token, DateTime datetime)
        {
            var forecast = new Forecast
            {
                Date = datetime,
                Weather = (string)token["Weather"],
                Visibility = (string)token["Visibility"],
                HillFog = (string)token["HillFog"],
                MaxWindLevel = (string)token["MaxWindLevel"],
                MaxWind = (string)token["MaxWind"],
                TempLowLevel = (string)token["TempLowLevel"],
                TempHighLevel = (string)token["TempHighLevel"],
                FreezingLevel = (string)token["FreezingLevel"]                             
            };

            if (token["WeatherPPN"] != null)
            {
                var wxPeriod = token["WeatherPPN"]["WxPeriod"];

                forecast.WeatherPPN = new WeatherPPN
                { 
                    WxPeriods = wxPeriod.Select(period =>
                            new WxPeriod
                        {
                            No = (short)period["period"],
                            Period = (string)period["Period"],
                            Weather = (int)period["Weather"],
                            Probability = (string)period["Probability"],
                            PpnType = (string)period["Ppn_type"]
                            }).ToArray()
                }; 
            }

            return forecast;
        }

        private async Task<string> Get(string uri)
        {
            var client = new System.Net.Http.HttpClient ();

            client.BaseAddress = new Uri(BaseUrL);

            var response = await client.GetAsync(string.Format("{0}?key={1}", uri, Key));

            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

    }
}