namespace server.Shared.Dtos;

// Binds from query string automatically when used with [FromQuery]
public sealed class WeatherForecastQueryParams
{
    // e.g., /weather-forecast?date=2025-10-05
    public DateOnly? Date { get; set; }
}
