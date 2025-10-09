using MediatR;
using server.Domain.Entities;
using server.Shared.Dtos;
using server.Shared.Utilities;

namespace server.Application.WeatherForecasts.Queries;

public sealed class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastDto>>
{
    public Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastQuery req, CancellationToken ct)
    {
        var forecasts = GenerateForecasts();

        if (req.Date.HasValue)
        {
            forecasts = forecasts.Where(w => w.Date == req.Date.Value);
        }

        var result = forecasts.Select(f => new WeatherForecastDto(
            f.Date,
            f.Celsius,
            f.Fahrenheit,
            f.Summary
        ));

        return Task.FromResult(result);
    }

    private static IEnumerable<WeatherForecast> GenerateForecasts()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool",
            "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var daysLeft = DateTimeUtil.GetDaysLeftInWeek();
        var random = new Random();

        return Enumerable.Range(0, daysLeft).Select(i =>
        {
            var date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));           
            var celsius = random.Next(-20, 55);           
            var s = random.Next(summaries.Length);
            var summary = summaries[s];

            return new WeatherForecast(date, celsius, summary);
        });
    }

}
