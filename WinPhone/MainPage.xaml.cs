using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather;

namespace Silkweb.Mobile.MountainWeather.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = MountainWeatherApp.Current.MainPage.ConvertPageToUIElement(this);
        }
    }
}
