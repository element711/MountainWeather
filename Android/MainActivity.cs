using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace Silkweb.Mobile.MountainWeather.Android
{
    [Activity(Label = "Silkweb.Mobile.MountainWeather.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(MountainWeatherApp.Current.MainPage);
        }
    }
}

