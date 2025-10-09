using FluentValidation;
using MediatR;
using server.Application.Common.Behaviors;

namespace server.Shared.Extensions;

/// <summary>
/// Marker class to identify the Application assembly for service registration
/// </summary>
public class ApplicationAssemblyMarker { }

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
        var applicationAssembly = typeof(ApplicationAssemblyMarker).Assembly;

        // MediatR registration - scan handlers in the Application assembly
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

        // FluentValidation - scan validators in the Application assembly
        services.AddValidatorsFromAssembly(applicationAssembly);

        // AutoMapper - scan Profiles in the Application assembly
        services.AddAutoMapper(applicationAssembly);

        // MediatR Pipeline Behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
