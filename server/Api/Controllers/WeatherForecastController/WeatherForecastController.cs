using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Application.WeatherForecasts.Queries;
using server.Domain.Entities;
using System;

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
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get([FromQuery] DateOnly? date, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetWeatherForecastQuery(date), cancellationToken);
        return Ok(result);
    }
}
