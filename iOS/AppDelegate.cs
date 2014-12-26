using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace Silkweb.Mobile.MountainWeather.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init ();

            LoadApplication(new MountainWeatherApp());

            return base.FinishedLaunching (app, options);
        }
    }
}

