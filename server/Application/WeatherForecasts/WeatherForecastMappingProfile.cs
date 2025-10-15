using AutoMapper;
using server.Domain.Entities;
using server.Application.Common.Dtos;

namespace server.Application.WeatherForecasts;

public class WeatherForecastMappingProfile : Profile
{
    public WeatherForecastMappingProfile()
    {
        CreateMap<WeatherForecast, WeatherForecastDto>();
    }
}
