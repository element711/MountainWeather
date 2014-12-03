using System;
using NUnit.Framework;
using Silkweb.Mobile.Core;
using Xamarin.Forms;

namespace Silkweb.Mobile.MountainWeather.Tests
{
    [TestFixture]
    public class MountainWeatherAppFixture
    {
        [Test]
        public void CreatesAndSetsCurrentApp()
        {
            var app = new MountainWeatherApp();

            Assert.That(App.Current, Is.EqualTo(app));

            Assert.That(app.MainPage, Is.Not.Null);
            Assert.That(app.MainPage, Is.TypeOf<NavigationPage>());
        }

    }
}

