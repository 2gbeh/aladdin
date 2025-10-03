using FluentValidation;

namespace server.Application.WeatherForecasts.Queries;

public class GetWeatherForecastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
{
    public GetWeatherForecastQueryValidator()
    {
        // No rules needed for now as the query has no inputs.
        // This exists to demonstrate/verify the validation pipeline is wired up.
    }
}
