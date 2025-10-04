using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Application.WeatherForecasts.Queries;
using server.Shared.Dtos;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Authorization;

namespace server.Api.Controllers;

/// <summary>
/// Provides weather forecast endpoints.
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ApiExplorerSettings(GroupName = "v1")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get weather forecasts, optionally filtered by date.
    /// </summary>
    /// <param name="queryParams">Query parameters for filtering forecasts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of weather forecasts.</returns>
    [HttpGet]
    [AllowAnonymous]
    [OpenApiOperation(Summary = "Get weather forecasts", Description = "Returns forecast items filtered by date if provided.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WeatherForecastDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> Get([FromQuery] WeatherForecastQueryParams queryParams, CancellationToken cancellationToken)
    {
        var req = new GetWeatherForecastQueryDtos.Request(queryParams);
        var result = await _mediator.Send(req, cancellationToken);
        return Ok(result.Items);
    }
}
