namespace server.Shared.Dtos;

public sealed record WeatherForecastDto(
    DateOnly Date,
    int Celsius,
    int Fahrenheit,
    string? Summary
);
