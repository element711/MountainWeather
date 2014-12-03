using System;
using NUnit.Framework;
using Autofac;
using System.Linq;

namespace Silkweb.Mobile.MountainWeather.Tests
{
    [TestFixture]
    public class MountainWeatherModuleFixture
    {
        [Test]
        public void RegistersModuleWithBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MountainWeatherModule>();
            var container = builder.Build();

            Assert.That(container.ComponentRegistry.Registrations.Count(), Is.GreaterThan(1));
        }

    }
}

