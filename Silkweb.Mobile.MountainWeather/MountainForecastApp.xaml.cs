using Silkweb.Mobile.Core;
using Xamarin.Forms;

namespace Silkweb.Mobile.MountainWeather
{	
	public partial class MountainWeatherApp : Application
	{	
		public MountainWeatherApp()
		{
			InitializeComponent();

            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Run();
		}
	}
}

