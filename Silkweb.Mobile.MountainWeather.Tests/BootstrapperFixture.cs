using System;
using NUnit.Framework;
using Silkweb.Mobile.Core;
using Xamarin.Forms;

namespace Silkweb.Mobile.MountainWeather.Tests
{
    public class App : Application {}

    [TestFixture]
    public class BootstrapperFixture
    {
        [Test]
        public void BootstrapsApplicationWhenRun()
        {
            var app = new App();
            var bootsrapper = new Bootstrapper(app);
            bootsrapper.Run();

            Assert.That(app.MainPage, Is.Not.Null);
            Assert.That(app.MainPage, Is.TypeOf<NavigationPage>());
        }

    }
}

