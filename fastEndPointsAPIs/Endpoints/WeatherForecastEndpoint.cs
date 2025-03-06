using FastEndpoints;
using fastEndPointsAPIs.Contracts.Requests;
using fastEndPointsAPIs.Contracts.Responses;
using fastEndPointsAPIs.Models;
using Microsoft.Extensions.Primitives;

namespace fastEndPointsAPIs.Endpoints;

// this method is like saying i am creating an endpoint that takes a request and return a response 
public class WeatherForecastEndpoint : Endpoint<WeatherForecastRequest, WeatherForecastsResponse>
{
    private static readonly string[] Summaries =
    {
        "freezing", "bracing", "chilly", "cool", "mild", "windy","warm"
    };
    public override void Configure() // sets up how the endpoint works 
    {
        Verbs(Http.GET);
        Routes("weather/{days}");
        AllowAnonymous(); // to allow this endpoint to function as auth is applied 
    }

    // method that runs when sb calls my endpoint
    public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
    {
        var forecasts = Enumerable.Range(1, req.Days)
            .Select(Index => new WeatherForecast()
            {
                Date = DateTime.Now.AddDays(Index),
                TemperatureC = Random.Shared.Next(-20, 55), // random temperatures
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]

            }).ToArray();
        var response = new WeatherForecastsResponse
        {
            Forecasts = forecasts.Select(x => new WeatherForecastResponse
            {
                Date = x.Date,
                Summary = x.Summary,
                TemperatureC = x.TemperatureC,
            }).ToList()  
        };
        await SendAsync(response, cancellation:ct);
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