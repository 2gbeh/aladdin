using MediatR;
using server.Application.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace server.Application.WeatherForecasts.Queries;

public sealed class GetWeatherForecastQueryDto : List<WeatherForecastDto>
{
}

public sealed record GetWeatherForecastQuery(
    [DataType(DataType.Date)]
    DateOnly? Date = null
) : IRequest<GetWeatherForecastQueryDto>;


public interface IGetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, GetWeatherForecastQueryDto> { }