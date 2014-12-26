using Autofac;
using Silkweb.Mobile.MountainWeather.Views;
using Xamarin.Forms;
using Silkweb.Mobile.Core.Factories;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.Core.Bootstrapping;

namespace Silkweb.Mobile.MountainWeather
{
    public class Bootstrapper : AutofacBootstrapper
    {
        private readonly Application _application;

        public Bootstrapper(Application application)
        {
            _application = application;           
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<MountainWeatherModule>();
        } 

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<MountainAreasViewModel, MountainAreasView>();
            viewFactory.Register<ForecastReportViewModel, ForecastReportView>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            // set main page
            var viewFactory = container.Resolve<IViewFactory>();
            var mainPage = viewFactory.Resolve<MountainAreasViewModel>();
            var navigationPage = new NavigationPage(mainPage);

            Color backgroundColor = (Color)_application.Resources["backgroundColor"]; 
            Color textColor = (Color)_application.Resources["textColor"];

            navigationPage.BarBackgroundColor = backgroundColor;
            navigationPage.BarTextColor = textColor;
            navigationPage.BackgroundColor = backgroundColor;

            _application.MainPage = navigationPage;
        }
    }
}

