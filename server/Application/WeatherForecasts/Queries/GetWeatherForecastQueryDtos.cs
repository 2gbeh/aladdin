using MediatR;
using server.Shared.Dtos;

namespace server.Application.WeatherForecasts.Queries;

public static class GetWeatherForecastQueryDtos
{
    public sealed record Request(WeatherForecastQueryParams Params) : IRequest<Response>;

    public sealed record Response(IEnumerable<WeatherForecastDto> Items);
}
