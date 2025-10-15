using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using server.Application.WeatherForecasts.Queries;

namespace server.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetWeatherForecastQueryDto> GetAll(
        [FromQuery] GetWeatherForecastQuery request, 
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(request, cancellationToken);
    }
}
