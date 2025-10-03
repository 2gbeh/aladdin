namespace server.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> Get([FromQuery] WeatherForecastQueryParams query, CancellationToken cancellationToken)
    {
        var query = new GetWeatherForecastsQuery(query);
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}
