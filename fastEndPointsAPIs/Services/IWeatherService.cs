using fastEndPointsAPIs.Models;

namespace fastEndPointsAPIs.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync(int days);

};