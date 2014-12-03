using System;
using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.MountainWeather.Models;
using Silkweb.Mobile.MountainWeather.Services;
using Moq;
using Silkweb.Mobile.Core.Services;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.MountainWeather.Tests.ViewModels
{
    [TestFixture]
    public class MountainAreaViewModelFixture
    {
        [Test]
        public void ShowsForecastWhenShowForecastCommandExecutes()
        {
            var location = new Location { Id = 100, Name = "Area 1" };
            var service = new Mock<IMountainWeatherService>();
            var forecast = new ForecastReport { ForecastDay0  = new Forecast { Weather =  "Test forecast" } };
            service.Setup(x => x.GetAreaForecast(100)).ReturnsAsync(forecast);
            var navigator = new Mock<INavigator>();
            var dialogProvder = new Mock<IDialogProvider>();

            var viewModel = new MountainAreaViewModel(location, service.Object, navigator.Object, dialogProvder.Object);

            Assert.That(viewModel.Name, Is.EqualTo(location.Name));

            viewModel.ShowForecastCommand.Execute(null);

            service.Verify(x => x.GetAreaForecast(100));
        }
    }
}

