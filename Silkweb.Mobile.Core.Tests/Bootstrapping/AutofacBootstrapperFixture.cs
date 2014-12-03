using System;
using NUnit.Framework;
using Silkweb.Mobile.Core.Bootstrapping;
using Silkweb.Mobile.Core.Factories;
using Silkweb.Mobile.Core.ViewModels;
using Xamarin.Forms;
using Autofac;
using System.Linq;
using Silkweb.Mobile.Core.Tests.Mocks;

namespace Silkweb.Mobile.Core.Tests.Bootstrapping
{
    [TestFixture]
    public class AutofacBootstrapperFixture
    {
        [Test]
        public void ConfiguresWhenRun()
        {
            var bootstrapper = new MockBootstrapper();
            bootstrapper.Run();

            Assert.That(bootstrapper.ViewFactory, Is.Not.Null);

            var view = bootstrapper.ViewFactory.Resolve<MockViewModel>();

            Assert.That(view, Is.Not.Null);

            Assert.That(bootstrapper.Container, Is.Not.Null);

        }
    }
}

