using System;
using System.Collections.Generic;
using Silkweb.Mobile.MountainWeather.Models;
using System.Threading.Tasks;

namespace Silkweb.Mobile.MountainWeather.Services
{
    public interface IMountainWeatherService
    {
        Task<ForecastCapability[]> GetCapabilities();

        Task<IEnumerable<Location>> GetAreas();

        Task<ForecastReport> GetAreaForecast(int id);
    }
}

