using FluentValidation;

namespace server.Application.WeatherForecasts.Queries;

public class GetWeatherForecastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
{
    public GetWeatherForecastQueryValidator()
    {
        // Date validation: if provided, ensure it's not the default value
        // Note: ASP.NET Core model binding will already reject invalid date formats and add a model state error.
        RuleFor(r => r.Params.Date)
            .Must(m => !m.HasValue || m.Value != default)
            .WithMessage("date must be a valid ISO date (yyyy-MM-dd)");
    }
}
