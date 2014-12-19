using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.MountainWeather.Models;
using Moq;
using Silkweb.Mobile.MountainWeather.Services;
using Silkweb.Mobile.Core.Interfaces;
using System.Linq;

namespace Silkweb.Mobile.MountainWeather.Tests.ViewModels
{
    [TestFixture]
    public class ForecastReportViewModelFixture
    {
        [Test]
        public void CreatesWithForecast()
        {
            var location = new Location { Id = 100, Name = "Area 1" };
            var service = new MockMountainWeatherService();
            var dialogProvder = new Mock<IDialogProvider>();

            var viewModel = new ForecastReportViewModel(location, dialogProvder.Object, service);
            viewModel.LoadForecast();


            Assert.That(viewModel.Items, Is.Not.Null);
            Assert.That(viewModel.Items.Count(), Is.EqualTo(5));
        }

    }

}

