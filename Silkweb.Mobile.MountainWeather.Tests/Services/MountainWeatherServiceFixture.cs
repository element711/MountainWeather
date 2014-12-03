using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.Services;
using System.Linq;

namespace Silkweb.Mobile.MountainWeather.Tests.Services
{
    [TestFixture]
    public class MountainWeatherServiceFixture
    {
        [Test, Ignore] // Current issue with 'Type Load Exception'
        public async void ReturnsMountainAreas()
        {
            var service = new MountainWeatherService();

            var areas = await service.GetAreas();

            Assert.That(areas, Is.Not.Null);
            Assert.That(areas.Count(), Is.GreaterThan(1));
        }

        [Test, Ignore] // Current issue with 'Type Load Exception'
        public async void ReturnAreaForecastReport()
        {
            var service = new MountainWeatherService();

            var forecastReport = await service.GetAreaForecast(101);

            Assert.That(forecastReport, Is.Not.Null);
            Assert.That(forecastReport.ForecastDay0, Is.Not.Null);
        }
    }
}

