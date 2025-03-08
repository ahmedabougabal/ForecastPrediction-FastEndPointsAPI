using FastEndpoints;
using fastEndPointsAPIs.Contracts.Requests;
using fastEndPointsAPIs.Contracts.Responses;
using fastEndPointsAPIs.Models;
using fastEndPointsAPIs.Services;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging;


namespace fastEndPointsAPIs.Endpoints;

// this method is like saying i am creating an endpoint that takes a request and return a response 
public class WeatherForecastEndpoint : Endpoint<WeatherForecastRequest, WeatherForecastsResponse, WeatherForecastMapper>
{
    public ILogger<WeatherForecastEndpoint> _logger { get; init; }
    public IWeatherService _weatherService { get; set; }

    public WeatherForecastEndpoint(ILogger<WeatherForecastEndpoint> logger, IWeatherService weatherService)
    {
        _weatherService = weatherService;
        _logger = logger;
    }
    
    
  
    public override void Configure() // sets up how the endpoint works 
    {
        Verbs(Http.GET);
        Routes("weather/{days}");
        AllowAnonymous(); // to allow this endpoint to function as auth is applied
        Summary(s =>
        {
            s.Summary= "Weather forecast prediction";
            s.Description = "this is an endpoint for predicting weather forecasts for upcoming {input days} days.";
            s.Params["days"] = "this is the number of days";
            s.Response(200, "a list of weather forecasts");
            s.Response(400, "If the 'days' parameter is invalid (e.g., non-numeric or negative)");
        });
    }
    

    // method that runs when sb calls my endpoint
    public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
    {
        _logger.LogDebug("fetching weather forecast for " +
                               "days{Days}.", req.Days);
        var forecasts = await _weatherService.GetForecastsAsync(req.Days);
        // turns forecasts to list of responses instead of handing over an unlisted single forecasts
        var forecastResponses = forecasts.Select(Map.FromEntity).ToList();
        
        var response = new WeatherForecastsResponse
        {
            Forecasts = forecastResponses // puts the list into the IEnumerable defined in the file WeatherForcastsResponse
        };
        await SendAsync(response, cancellation:ct); // sends the collection
    }
}
/*
 *Creating a Range: Enumerable.Range(1, req.Days) creates a sequence of numbers (1, 2, 3, etc.) up to the requested days.
   
   For Each Day: .Select(...) means "for each number in that sequence, do something." In this case, create a weather forecast.
   
   Creating Weather Objects: For each day, we create a WeatherForecast object with:
   
   A date (current date + X days)
   
   A random temperature
   
   A random weather description (like "mild" or "freezing")
   
   Converting to Response Format: We then convert these weather objects to a format that's suitable for sending back to the client.
   
   Sending the Response: Finally, we send this formatted data back to whoever made the request.
 *
 * 
 */