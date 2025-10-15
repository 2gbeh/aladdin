namespace server.Domain.Entities;

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int Celsius { get; set; }
    public string? Summary { get; set; }

    public int Fahrenheit => 32 + (int)(Celsius / 0.5556);
}
