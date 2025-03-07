using fastEndPointsAPIs.Models;

namespace  fastEndPointsAPIs.Contracts.Responses;

public class WeatherForecastsResponse
{
    public IEnumerable<WeatherForecastResponse> Forecasts { get; set; }
}

