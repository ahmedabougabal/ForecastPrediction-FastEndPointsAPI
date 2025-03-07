using FastEndpoints;
using fastEndPointsAPIs.Models;

namespace fastEndPointsAPIs.Services;

public class WeatherService : IWeatherService
{
    private static readonly string[] Summaries =
    {
        "freezing", "bracing", "chilly", "cool", "mild", "windy","warm"
    };

    public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync(int days)
    {
        await Task.Delay(100);
        return Enumerable.Range(1, days)
            .Select(Index => new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(Index),
                TemperatureC = Random.Shared.Next(-20, 55), // random temperatures
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]

            }).ToArray();
    }

}