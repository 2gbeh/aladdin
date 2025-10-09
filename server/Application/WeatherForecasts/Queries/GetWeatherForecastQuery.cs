using MediatR;
using server.Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace server.Application.WeatherForecasts.Queries;

public sealed record GetWeatherForecastQuery(
    [DataType(DataType.Date)]
    DateOnly? Date = null
) : IRequest<IEnumerable<WeatherForecastDto>>;
