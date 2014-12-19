using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.MountainWeather.Models;
using Moq;
using Silkweb.Mobile.Core.Services;

namespace Silkweb.Mobile.MountainWeather.Tests.ViewModels
{
    [TestFixture]
    public class MountainAreaViewModelFixture
    {
        [Test]
        public void ShowsForecastWhenShowForecastCommandExecutes()
        {
            var location = new Location { Id = 100, Name = "Area 1" };
            var navigator = new Mock<INavigator>();
            var forecastReportViewModel = new Mock<ForecastReportViewModel>();

            var viewModel = new MountainAreaViewModel(location, navigator.Object, x => forecastReportViewModel.Object);

            Assert.That(viewModel.Name, Is.EqualTo(location.Name));

            viewModel.ShowForecastCommand.Execute(null);

            // add verifications..

        }
    }
}

