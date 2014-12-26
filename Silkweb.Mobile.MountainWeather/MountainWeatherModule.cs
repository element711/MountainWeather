using Autofac;
using Silkweb.Mobile.MountainWeather.Services;
using Silkweb.Mobile.MountainWeather.ViewModels;
using Silkweb.Mobile.MountainWeather.Views;
using Xamarin.Forms;
using System;
using Silkweb.Mobile.Core;

namespace Silkweb.Mobile.MountainWeather
{
    public class MountainWeatherModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // service registration
            builder.RegisterType<MountainWeatherService>()
                .As<IMountainWeatherService>()
                .SingleInstance();

//            builder.RegisterType<MockMountainWeatherService>()
//                .As<IMountainWeatherService>()
//                .SingleInstance();

            // view model registration
            builder.RegisterType<MountainAreaViewModel>();

            builder.RegisterType<MountainAreasViewModel>()
                .SingleInstance();

            builder.RegisterType<ForecastReportViewModel>();

            // view registration
            builder.RegisterType<MountainAreasView>()
                .SingleInstance();

            builder.RegisterType<ForecastReportView>();

            // current page resolver
            builder.RegisterInstance<Func<Page>>(() => 
                ((NavigationPage)Application.Current.MainPage).CurrentPage);
        }
    }
}

