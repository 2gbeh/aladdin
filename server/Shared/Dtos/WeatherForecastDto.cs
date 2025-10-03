namespace server.Shared.Dtos;

public sealed record WeatherForecastDto(
    DateOnly Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary
);
