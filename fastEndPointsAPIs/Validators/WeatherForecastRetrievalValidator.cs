using FastEndpoints;
using FluentValidation;

namespace fastEndPointsAPIs.Validators;
using fastEndPointsAPIs.Contracts.Requests;


public class WeatherForecastRetrievalValidator :
    Validator<WeatherForecastRequest>
{
    public WeatherForecastRetrievalValidator()
    {
        RuleFor(x => x.Days)
            .GreaterThanOrEqualTo(1)
            .WithMessage("weather forecast days must be greater than or equal to 1.")
            .LessThanOrEqualTo(15)
            .WithMessage("weather forecast days must be less than or equal to 15.");
    }
}