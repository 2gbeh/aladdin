using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using server.Application.WeatherForecasts.Queries;
using server.Shared.Dtos;

namespace server.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IEnumerable<WeatherForecastDto>> GetAll(
        [FromQuery] GetWeatherForecastQuery request, 
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(request, cancellationToken);
    }
}
