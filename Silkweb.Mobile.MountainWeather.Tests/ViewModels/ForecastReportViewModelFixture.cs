using System;
using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.MountainWeather.Models;

namespace Silkweb.Mobile.MountainWeather.Tests.ViewModels
{
    [TestFixture]
    public class ForecastReportViewModelFixture
    {
        [Test]
        public void CreatesWithForecast()
        {
            bool forecastChanged = false;
            var forecastReport = new ForecastReport { ForecastDay0 = new Forecast { Weather =  "Test Forecast" }};
            var viewModel = new ForecastReportViewModel();

            viewModel.PropertyChanged += (sender, e) => 
                {
                    if (e.PropertyName == "Forecast" && viewModel.ForecastReport == forecastReport)
                    {
                        forecastChanged = true;
                    }
                };

            viewModel.ForecastReport = forecastReport;

            Assert.That(forecastChanged, Is.True);
        }

    }

}

