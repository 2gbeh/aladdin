using MediatR;
using server.Shared.Dtos;
using server.Domain.Entities;

namespace server.Application.WeatherForecasts.Queries;

public sealed record GetWeatherForecastQuery(WeatherForecastQueryParams Params) : IRequest<IEnumerable<WeatherForecastDto>>;

public sealed class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQueryDtos.Request, GetWeatherForecastQueryDtos.Response>
{
    public Task<GetWeatherForecastQueryDtos.Response> Handle(GetWeatherForecastQueryDtos.Request req, CancellationToken cancellationToken)
    {
        var forecasts = GenerateForecasts();

        if (req.Params.Date.HasValue)
        {
            forecasts = forecasts.Where(w => w.Date == req.Params.Date.Value);
        }

        var items = forecasts.Select(s => new WeatherForecastDto(
            s.Date,
            s.TemperatureC,
            s.TemperatureF,
            s.Summary
        ));

        var response = new GetWeatherForecastQueryDtos.Response(items);
        return Task.FromResult(response);
    }

    private static IEnumerable<WeatherForecast> GenerateForecasts()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool",
            "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var daysLeft = GetDaysLeftInWeek();
        var random = new Random();

        return Enumerable.Range(0, daysLeft).Select(i =>
        {
            var date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));           
            var temperatureC = random.Next(-20, 55);           
            var s = random.Next(summaries.Length);
            var summary = summaries[s];

            return new WeatherForecast(date, temperatureC, summary);
        });
    }

    private static int GetDaysLeftInWeek()
    {
        var today = DateTime.Now.DayOfWeek;
        var daysUntilEndOfWeek = DayOfWeek.Saturday - today;
        return daysUntilEndOfWeek == 0 ? 1 : daysUntilEndOfWeek + 1;
    }
}
