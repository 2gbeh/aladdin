using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using server.Api.Common.Conventions;
using server.Api.Common.Transformers;

namespace server.Shared.Extensions;

/// <summary>
/// Extension methods for configuring MVC controllers
/// </summary>
public static class ControllerExtensions
{
    /// <summary>
    /// Adds and configures MVC controllers with API conventions
    /// </summary>
    public static IServiceCollection AddApiControllers(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            // /api prefix for all attribute-routed controllers
            options.Conventions.Insert(0, new GlobalRoutePrefixConvention(new RouteAttribute("api")));

            // hyphenate [controller] and [action] tokens: WeatherForecast -> weather-forecast
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        });

        return services;
    }
}
