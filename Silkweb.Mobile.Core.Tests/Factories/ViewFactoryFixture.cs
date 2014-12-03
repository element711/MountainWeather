using NUnit.Framework;
using Silkweb.Mobile.Core.Factories;
using Silkweb.Mobile.Core.Tests.Mocks;
using Autofac;

namespace Silkweb.Mobile.Core.Tests.Factories
{
    [TestFixture]
    public class ViewFactoryFixture
    {
        [Test]
        public void ResolvesViewFromViewModelWhenViewModelIsRegisteredWithViewType()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MockViewModel>().SingleInstance();
            builder.RegisterType<MockView>().SingleInstance();
            var container = builder.Build();

            var viewFactory = new ViewFactory(container);

            viewFactory.Register<MockViewModel, MockView>();

            MockViewModel viewModel;

            var view = viewFactory.Resolve<MockViewModel>(out viewModel, x => x.Title = "Test Title");

            Assert.That(view, Is.Not.Null);
            Assert.That(view, Is.TypeOf<MockView>());
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel.Title, Is.EqualTo("Test Title"));

            view = viewFactory.Resolve<MockViewModel>(x => x.Title = "Test Title 2");

            Assert.That(view, Is.Not.Null);
            Assert.That(viewModel.Title, Is.EqualTo("Test Title 2"));

            view = viewFactory.Resolve<MockViewModel>(viewModel);

            Assert.That(view, Is.Not.Null);
            Assert.That(view, Is.TypeOf<MockView>());
        }
    }
}

