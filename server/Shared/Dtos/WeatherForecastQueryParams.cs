namespace server.Shared.Dtos;

public sealed class WeatherForecastQueryParams
{
    // Optional date filter (yyyy-MM-dd)
    public DateOnly? Date { get; set; }
}
