using MediatR;
using server.Domain.Entities;

namespace server.Application.WeatherForecasts.Queries;

public sealed record GetWeatherForecastQuery(DateOnly? Date) : IRequest<IEnumerable<WeatherForecast>>;

public sealed class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var result = Enumerable.Range(1, 30).Select(index =>
            new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            )
        );

        if (request.Date.HasValue)
        {
            result = result.Where(x => x.Date == request.Date.Value);
        }

        return Task.FromResult(result);
    }
}
