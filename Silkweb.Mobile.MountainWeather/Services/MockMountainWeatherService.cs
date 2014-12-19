using System;
using System.Collections.Generic;
using Silkweb.Mobile.MountainWeather.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace Silkweb.Mobile.MountainWeather.Services
{
    public class MockMountainWeatherService : IMountainWeatherService
    {
        public async Task<ForecastCapability[]> GetCapabilities()
        {
            string result = null;

            try
            {
                Debug.WriteLine("Getting capabilities from DataPoint Service...");
                result = await Task.Factory.StartNew<string>(()
                    => "{\"MountainForecastList\":{\"MountainForecast\":[{\"DataDate\":\"2014-12-07T18:29:10Z\",\"ValidFrom\":\"2014-12-07T18:00:00Z\",\"ValidTo\":\"2014-12-11T18:00:00Z\",\"CreatedDate\":\"2014-12-07T18:30:25Z\",\"URI\":\"http:\\/\\/datapoint.metoffice.gov.uk\\/public\\/data\\/txt\\/wxfcs\\/mountainarea\\/{format}\\/100?key={key}\",\"Area\":\"Brecon Beacons\",\"Risk\":\"High\"},{\"DataDate\":\"2014-12-07T17:36:25Z\",\"ValidFrom\":\"2014-12-07T17:00:00Z\",\"ValidTo\":\"2014-12-11T17:00:00Z\",\"CreatedDate\":\"2014-12-07T17:46:17Z\",\"URI\":\"http:\\/\\/datapoint.metoffice.gov.uk\\/public\\/data\\/txt\\/wxfcs\\/mountainarea\\/{format}\\/101?key={key}\",\"Area\":\"East Highland\",\"Risk\":\"High\"},{\"DataDate\":\"2014-12-07T16:25:08Z\",\"ValidFrom\":\"2014-12-07T16:00:00Z\",\"ValidTo\":\"2014-12-11T16:00:00Z\",\"CreatedDate\":\"2014-12-07T17:46:25Z\",\"URI\":\"http:\\/\\/datapoint.metoffice.gov.uk\\/public\\/data\\/txt\\/wxfcs\\/mountainarea\\/{format}\\/102?key={key}\",\"Area\":\"Lake District\",\"Risk\":\"High\"},{\"DataDate\":\"2014-12-07T17:01:32Z\",\"ValidFrom\":\"2014-12-07T17:00:00Z\",\"ValidTo\":\"2014-12-11T17:00:00Z\",\"CreatedDate\":\"2014-12-07T17:46:16Z\",\"URI\":\"http:\\/\\/datapoint.metoffice.gov.uk\\/public\\/data\\/txt\\/wxfcs\\/mountainarea\\/{format}\\/103?key={key}\",\"Area\":\"Peak District\",\"Risk\":\"Medium\"},{\"DataDate\":\"2014-12-07T18:38:24Z\",\"ValidFrom\":\"2014-12-07T18:00:00Z\",\"ValidTo\":\"2014-12-11T18:00:00Z\",\"CreatedDate\":\"2014-12-07T18:39:45Z\",\"URI\":\"http:\\/\\/datapoint.metoffice.gov.uk\\/public\\/data\\/txt\\/wxfcs\\/mountainarea\\/{format}\\/104?key={key}\",\"Area\":\"Snowdonia\",\"Risk\":\"High\"},{\"DataDate\":\"2014-12-07T17:49:15Z\",\"ValidFrom\":\"2014-12-07T17:00:00Z\",\"ValidTo\":\"2014-12-11T17:00:00Z\",\"CreatedDate\":\"2014-12-07T17:52:59Z\",\"URI\":\"http:\\/\\/datapoint.metoffice.gov.uk\\/public\\/data\\/txt\\/wxfcs\\/mountainarea\\/{format}\\/105?key={key}\",\"Area\":\"West Highland\",\"Risk\":\"High\"},{\"DataDate\":\"2014-12-07T17:00:31Z\",\"ValidFrom\":\"2014-12-07T17:00:00Z\",\"ValidTo\":\"2014-12-11T17:00:00Z\",\"CreatedDate\":\"2014-12-07T17:46:15Z\",\"URI\":\"http:\\/\\/datapoint.metoffice.gov.uk\\/public\\/data\\/txt\\/wxfcs\\/mountainarea\\/{format}\\/106?key={key}\",\"Area\":\"Yorkshire Dales\",\"Risk\":\"Medium\"}]}}");
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
                        IssuedDate = DateTime.Parse((string)forecast["DataDate"]),
                        ValidFrom = DateTime.Parse((string)forecast["ValidFrom"]),
                        ValidTo = DateTime.Parse((string)forecast["ValidTo"]),
                        CreatedDate = DateTime.Parse((string)forecast["CreatedDate"]),
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
            string result;

            try
            {
                Debug.WriteLine("Getting Locations from DataPoint Service...");
                result = await Task.Factory.StartNew<string>(()
                    => "{\"Locations\":{\"Location\":[{\"@id\":\"100\",\"@name\":\"Brecon Beacons\"},{\"@id\":\"101\",\"@name\":\"East Highland\"},{\"@id\":\"102\",\"@name\":\"Lake District\"},{\"@id\":\"103\",\"@name\":\"Peak District\"},{\"@id\":\"104\",\"@name\":\"Snowdonia\"},{\"@id\":\"105\",\"@name\":\"West Highland\"},{\"@id\":\"106\",\"@name\":\"Yorkshire Dales\"}]}}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get locations from service provider. The service maybe down. Retry or try again later.", ex);
            }

            Location[] locations;

            try
            {                
                var locationToken = JObject.Parse(result)["Locations"]["Location"];

                locations = locationToken.Select(location => new Location()
                    { 
                        Id = (int)location["@id"], 
                        Name = (string)location["@name"] 
                    }).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to format the mountain areas site list.", ex);
            }

            return locations;
        }

        public async Task<ForecastReport> GetAreaForecast(int id)
        {
            string result = null;

            try
            {
                Debug.WriteLine("Getting Area Forecast from DataPoint Service...");
                result = await Task.Factory.StartNew<string>(()
                    => "{\"report\":{\"creating-authority\":\"Met Office\",\"creation-time\":\"2014-12-07T17:36:25\",\"title\":\"Mountain Forecasts\",\"location\":\"East Highland\",\"issue\":{\"date\":\"2014-12-07\",\"time\":\"1736\"},\"ValidFrom\":\"2014-12-07T17:00:00Z\",\"ValidTo\":\"2014-12-11T17:00:00Z\",\"Validity\":\"Monday\",\"IssuedDate\":\"Sunday, 07 December 2014\",\"Hazards\":{\"Hazard\":[{\"no\":\"1\",\"Element\":\"Blizzards\",\"Risk\":\"Medium\",\"Comments\":\"Frequent heavy snow showers at first\"},{\"no\":\"2\",\"Element\":\"Heavy snow\",\"Risk\":\"Low\",\"Comments\":\"Frequent heavy snow showers at first\"},{\"no\":\"3\",\"Element\":\"Storm force winds\",\"Risk\":\"High\",\"Comments\":\"Gust to 70 to 80mph overnight and at first on Monday with the risk of being blown over\"},{\"no\":\"4\",\"Element\":\"Gales\",\"Risk\":\"High\",\"Comments\":\"Winds falling below gale force later in the afternoon.\"},{\"no\":\"5\",\"Element\":\"Severe chill effect\",\"Risk\":\"High\",\"Comments\":\"Risk of hypothermia and frost bite, particularly overnight and Monday morning.\"},{\"no\":\"6\",\"Element\":\"Persistent extensive hill fog\",\"Risk\":\"Low\",\"Comments\":\"Temporary in snow showers\"},{\"no\":\"7\",\"Element\":\"Thunderstorms\",\"Risk\":\"Low\",\"Comments\":\"Not expected\"},{\"no\":\"8\",\"Element\":\"Heavy persistent rain\",\"Risk\":\"No Risk\",\"Comments\":\"\"},{\"no\":\"9\",\"Element\":\"Strong sunlight\",\"Risk\":\"Low\",\"Comments\":\"Low winter sun and glare off the snow.\"}]},\"Overview\":\"Snow showers will die out and winds will gradually ease on Monday as a ridge of high pressure builds in from the Atlantic\",\"Forecast_Day0\":{\"Weather\":\"Clear then sunny spells and snow showers. The snow showers heavy and frequent overnight and at first on Monday with temporary white out and blizzard conditions. The showers becoming confined to the Cairngorms and Eastern Grampians during the morning as the southern Highlands becoming dry and sunny. All ranges mainly dry with clear spells by dusk.\",\"Visibility\":\"Very good or excellent falling very poor in snow showers.\",\"HillFog\":\"Generally nil significant, but patches 700-900m, but much lower in showers\",\"MaxWindLevel\":\"600m\",\"MaxWind\":\"West or Northwest 40 to 50 gusts 70 to 80mph   over ridges and summits, decreasing 20 to 30 during the afternoon and evening.\",\"TempLowLevel\":\"Zero to plus 3 Celsius\",\"TempHighLevel\":\"Minus 3 Celsius\",\"FreezingLevel\":\"200 to 300m\",\"WeatherPPN\":{\"WxPeriod\":[{\"period\":\"1\",\"Period\":\"0000 to 0300\",\"Weather\":25,\"Probability\":\"60%\",\"Ppn_type\":\"\"},{\"period\":\"2\",\"Period\":\"0300 to 0600\",\"Weather\":25,\"Probability\":\"60%\",\"Ppn_type\":\"\"},{\"period\":\"3\",\"Period\":\"0600 to 0900\",\"Weather\":25,\"Probability\":\"60%\",\"Ppn_type\":\"\"},{\"period\":\"4\",\"Period\":\"0900 to 1200\",\"Weather\":26,\"Probability\":\"50%\",\"Ppn_type\":\"\"},{\"period\":\"5\",\"Period\":\"1200 to 1500\",\"Weather\":3,\"Probability\":\"30%\",\"Ppn_type\":\"\"},{\"period\":\"6\",\"Period\":\"1500 to 1800\",\"Weather\":0,\"Probability\":\"20%\",\"Ppn_type\":\"\"},{\"period\":\"7\",\"Period\":\"1800 to 2100\",\"Weather\":0,\"Probability\":\"10%\",\"Ppn_type\":\"\"},{\"period\":\"8\",\"Period\":\"2100 to 2400\",\"Weather\":0,\"Probability\":\"0%\",\"Ppn_type\":\"\"}]}},\"Forecast_Day1\":{\"Weather\":\"Dry during the early hours, but cloud thickening and low outbreaks of rain, sleet and snow by dawn. Snow soon confined to the highest tops and turning to rain at all levels during the morning. Rain then clearing back to snow showers in the evening.\",\"Visibility\":\"Very good falling moderate or poor at times and very poor in snow. Temporary blizzard and white out conditions.\",\"HillFog\":\"Nil significant at first. Becoming broken or overcast 300 to 600m at times during daylight hours. Lifting and breaking in the evening.\",\"MaxWindLevel\":\"600m\",\"MaxWind\":\"Increasing Southwest 50 to 60 during the morning, gusts 80mph or more over summits and ridges, veering westerly later\",\"TempLowLevel\":\"Zero to Minus 2 Celsius early and later. Rising to plus 6 during daylight hours.\",\"TempHighLevel\":\"Minus 3 Celsius early and later, rising Plus 3 around the middle of the day.\",\"FreezingLevel\":\"200-400m, rising above the summits for a time around the middle of the day.\"},\"Outlook_Day2\":\"Frequent snow showers with severe gale or storm force west or northwest winds over summits. Blizzard conditions.\",\"Outlook_Day3\":\"Frequent snow showers with severe gale or storm force west or northwest winds over summits. Blizzard conditions. Winds and snow showers gradually easing.\",\"Outlook_Day4\":\"Snow or snow showers. Strong to gale force west becoming north winds. Blizzard conditions at times.\"}}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Area Forecast from service provider. The service maybe down. Retry or try again", ex);
            }

            ForecastReport forecastReport;

            try
            {                
                var report = JObject.Parse(result)["report"];

                var issueDate = DateTime.Parse((string)report["creation-time"]);

                var forecastReport2 = new ForecastReport();
                forecastReport2.IssuedBy = (string)report["creating-authority"];
                forecastReport2.IssueDateTime = issueDate;
                forecastReport2.Title = (string)report["title"];
                forecastReport2.Location = (string)report["title"];
                forecastReport2.ValidFrom = DateTime.Parse((string)report["ValidFrom"]);
                forecastReport2.ValidTo = DateTime.Parse((string)report["ValidTo"]);
                forecastReport2.Validity = (string)report["Validity"];
                forecastReport2.IssuedDate = (string)report["IssuedDate"];
                forecastReport2.Hazards = report["Hazards"]["Hazard"].Select(hazard => new Hazard {
                    No = (short)hazard["no"],
                    Element = (string)hazard["Element"],
                    Risk = (string)hazard["Risk"],
                    Comments = (string)hazard["Comments"]
                });
                forecastReport2.Overview = (string)report["Overview"];
                forecastReport2.ForecastDay0 = ParseForecast(report["Forecast_Day0"], issueDate.Date.AddDays(1));
                forecastReport2.ForecastDay1 = ParseForecast(report["Forecast_Day1"], issueDate.Date.AddDays(2));
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

    }
}