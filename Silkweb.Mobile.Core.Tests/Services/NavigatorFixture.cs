using System;
using NUnit.Framework;
using Silkweb.Mobile.Core.Services;
using Moq;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Factories;
using Silkweb.Mobile.Core.Tests.Mocks;
using Silkweb.Mobile.Core.ViewModels;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.Core.Tests.Services
{
    [TestFixture]
    public class NavigatorFixture
    {
        private MockViewModel _viewModel;
        private Navigator _navigator;
        private Action<MockViewModel> _action;

        [SetUp]
        public void SetUp()
        {
            _action = x => x.Title = "Test";
            _viewModel = new MockViewModel();
            var navigation = new Mock<INavigation>();
            var page = new Mock<IPage>();

            page.Setup(x => x.Navigation).Returns(navigation.Object);

            navigation.Setup(x => x.PopAsync()).ReturnsAsync(new Page { BindingContext = new MockViewModel()});
            navigation.Setup(x => x.PopModalAsync()).ReturnsAsync(new Page { BindingContext = new MockViewModel()});
            navigation.Setup(x => x.PopToRootAsync());

            var viewFactory = new Mock<IViewFactory>();
            viewFactory.Setup(x => x.Resolve<MockViewModel>(out _viewModel, _action)).Returns(new MockView());

            _navigator = new Navigator(page.Object, viewFactory.Object);
        }

        [Test]
        public async void NavigateToView()
        {
            MockViewModel viewModel = await _navigator.PushAsync<MockViewModel>(_action);
            Assert.That(viewModel, Is.EqualTo(_viewModel));
        }

        [Test]
        public async void NavigateToModalView()
        {
            MockViewModel viewModel = await _navigator.PushModalAsync<MockViewModel>(_action);
            Assert.That(viewModel, Is.EqualTo(_viewModel));
        }

        [Test]
        public async void NavigateFromView()
        {
            var viewModel = await _navigator.PopAsync();
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel, Is.TypeOf<MockViewModel>());
        }

        [Test]
        public async void NavigateFromModalView()
        {
            var viewModel = await _navigator.PopModalAsync();
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel, Is.TypeOf<MockViewModel>());
        }

        [Test]
        public async void NavigateToRoot()
        {
            var viewModel = await _navigator.PopModalAsync();
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel, Is.TypeOf<MockViewModel>());
        }
    }
}

