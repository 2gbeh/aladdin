using AutoMapper;
using server.Domain.Entities;
using server.Shared.Utilities;

namespace server.Application.WeatherForecasts.Queries;

public sealed class GetWeatherForecastQueryHandler : IGetWeatherForecastQueryHandler
{
    private readonly IMapper _mapper;

    public GetWeatherForecastQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<GetWeatherForecastQueryDto> Handle(GetWeatherForecastQuery req, CancellationToken ct)
    {
        var forecasts = GenerateForecasts();

        if (req.Date.HasValue)
        {
            forecasts = forecasts.Where(w => w.Date == req.Date.Value);
        }

        var result = _mapper.Map<GetWeatherForecastQueryDto>(forecasts);
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

            return new WeatherForecast { Date = date, Celsius = celsius, Summary = summary };
        });
    }

}
