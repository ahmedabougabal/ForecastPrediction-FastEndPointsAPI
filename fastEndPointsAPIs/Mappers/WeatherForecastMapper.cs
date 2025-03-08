using FastEndpoints;
using fastEndPointsAPIs.Contracts.Requests;
using fastEndPointsAPIs.Contracts.Responses;
using fastEndPointsAPIs.Models;

public class WeatherForecastMapper : 
  Mapper<WeatherForecastRequest, WeatherForecastResponse, WeatherForecast>
  {
    public override WeatherForecastResponse FromEntity(WeatherForecast e){
      return new WeatherForecastResponse
      {
        Date = e.Date,
        Summary = e.Summary,
        TemperatureC = e.TemperatureC,
        // TemperatureF = e.TemperatureF
        /*
         *The TemperatureF property in WeatherForecastResponse is designed to be
         * computed automatically from TemperatureC. Any attempt to assign a
         * value to it directly contradicts its read-only nature.
         * value to it directly contradicts its read-only nature.
         * 
         */
      };
    }
  }