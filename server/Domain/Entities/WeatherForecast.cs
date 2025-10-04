namespace server.Domain.Entities;

public record WeatherForecast(
    DateOnly Date, 
    int Celsius, 
    string? Summary
)
{
    public int Fahrenheit => 32 + (int)(Celsius / 0.5556);
}
