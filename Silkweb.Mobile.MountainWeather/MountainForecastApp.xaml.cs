using Silkweb.Mobile.Core;

namespace Silkweb.Mobile.MountainWeather
{	
	public partial class MountainWeatherApp : App
	{	
		public MountainWeatherApp()
		{
			InitializeComponent();

            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Run();
		}

        public new static App Current
        {
            get { return App.Current ?? new MountainWeatherApp();  }
        }
	}
}

