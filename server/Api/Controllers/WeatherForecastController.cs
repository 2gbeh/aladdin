using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> Get([FromQuery] WeatherForecastQueryParams queryParams, CancellationToken cancellationToken)
    {
        var req = new GetWeatherForecastQueryDtos.Request(queryParams);
        var result = await _mediator.Send(req, cancellationToken);
        return Ok(result.Items);
    }
}
