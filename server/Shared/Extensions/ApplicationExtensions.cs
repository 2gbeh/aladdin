using FluentValidation;
using MediatR;
using server.Application.Common.Behaviors;
using server.Application.WeatherForecasts.Queries;

namespace server.Shared.Extensions;

/// <summary>
/// Extension methods for configuring application layer services
/// </summary>
public static class ApplicationExtensions
{
    /// <summary>
    /// Adds MediatR, FluentValidation, AutoMapper, and pipeline behaviors
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // MediatR registration - scan handlers in the Application assembly
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetWeatherForecastQueryHandler>());

        // FluentValidation - scan validators in the Application assembly
        services.AddValidatorsFromAssemblyContaining<GetWeatherForecastQueryHandler>();

        // AutoMapper - scan Profiles in the Application assembly
        services.AddAutoMapper(typeof(server.Application.Transactions.Profiles.TransactionProfile).Assembly);

        // MediatR Pipeline Behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
