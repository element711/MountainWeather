using System;
using NUnit.Framework;
using Silkweb.Mobile.Core.Extensions;
using Xamarin.Forms;

namespace Silkweb.Mobile.Core.Tests.Extensions
{
    public class App : Application {}

    [TestFixture]
    public class ApplicationResourceExtensionFixture
    {
        [Test]
        public void ProvidesApplicationResource()
        {
            const string key = "testKey";
            const string expected = "TestResource";

            var app = new App();
            app.Resources = new ResourceDictionary();
            app.Resources.Add(key, expected);
        
            var label = new Label();

            var serviceProviderContext = new ServiceProviderDummy(
                new ProvideValueTargetDummy(label, Label.TextProperty));

            var resourceExtension = new ApplicationResourceExtension();
            resourceExtension.Key = key;
            var actual = resourceExtension.ProvideValue(serviceProviderContext);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}

