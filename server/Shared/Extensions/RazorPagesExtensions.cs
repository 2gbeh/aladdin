using Microsoft.AspNetCore.Mvc.Razor;
using server.Web.Common;

namespace server.Shared.Extensions;

/// <summary>
/// Extension methods for configuring Razor Pages with ViewLocationExpander
/// </summary>
public static class RazorPagesExtensions
{
    /// <summary>
    /// Adds and configures Razor Pages with custom root and ViewLocationExpander
    /// </summary>
    public static IServiceCollection AddRazorPagesWrapper(this IServiceCollection services)
    {
        services.AddRazorPages(options =>
        {
            options.RootDirectory = "/Web/Pages";
        }).AddRazorOptions(options =>
        {
            options.ViewLocationExpanders.Add(new CommonViewLocationExpander());
        });

        return services;
    }
}
