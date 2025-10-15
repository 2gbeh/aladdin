namespace server.Application.Common.Dtos;

public class WeatherForecastDto
{
    public DateOnly Date { get; init; }
    public int Celsius { get; init; }
    public int Fahrenheit { get; init; }
    public string? Summary { get; init; }
}
