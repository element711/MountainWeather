using System;
using NUnit.Framework;
using Silkweb.Mobile.MountainWeather.Models;
using Moq;
using Silkweb.Mobile.MountainWeather.Services;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.Core.Services;
using System.Linq;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.MountainWeather.Tests.ViewModels
{
    [TestFixture]
    public class MountainAreasViewModelFixture
    {
        [Test]
        public void CreatesWithMountainAreas()
        {
            var service = new Mock<IMountainWeatherService>();
            var navigator = new Mock<INavigator>();
            var dialogProvder = new Mock<IDialogProvider>();
            var forecastReportViewModel = new Mock<ForecastReportViewModel>();

            Func<Location, MountainAreaViewModel> locationFactory = location => 
                new MountainAreaViewModel(location, navigator.Object, x => forecastReportViewModel.Object);

            var areas = new Location[]
                {
                    new Location { Id = 100, Name = "Area 1" },
                    new Location { Id = 101, Name = "Area 2" },
                    new Location { Id = 102, Name = "Area 3" }
                };

            service.Setup(x => x.GetAreas()).ReturnsAsync(areas);

            var viewModel = new MountainAreasViewModel(service.Object, locationFactory, dialogProvder.Object);

            service.Verify(x => x.GetAreas());

            Assert.That(viewModel.Areas, Is.Not.Null);
            Assert.That(viewModel.Areas.Count(), Is.EqualTo(areas.Length));
        }
    }
}

