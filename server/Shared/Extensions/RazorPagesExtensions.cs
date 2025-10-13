using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;

namespace server.Shared.Extensions;

/// <summary>
/// Extension methods for configuring Razor Pages
/// </summary>
public static class RazorPagesExtensions
{
    /// <summary>
    /// Adds and configures Razor Pages with custom root and auto-discovery of Web/Common folders
    /// </summary>
    public static IServiceCollection AddCustomRazorPages(this IServiceCollection services, IWebHostEnvironment environment)
    {
        // Add Razor Pages with custom root
        var razorPagesBuilder = services.AddRazorPages()
            .WithRazorPagesRoot("/Web/Pages");

        #if DEBUG
                // Enable hot reload for Razor views in development
                // Note: Extension method may show IntelliSense error but compiles correctly
        #pragma warning disable CS1061
                razorPagesBuilder.AddRazorRuntimeCompilation(options =>
                {
                    options.FileProviders.Add(new PhysicalFileProvider(
                        Path.Combine(environment.ContentRootPath, "Web", "Common")));
                });
        #pragma warning restore CS1061
        #endif

        // Auto-discover all folders under /Web/Common
        services.Configure<RazorViewEngineOptions>(options =>
        {
            var commonRoot = Path.Combine(environment.ContentRootPath, "Web", "Common");

            if (Directory.Exists(commonRoot))
            {
                foreach (var dir in Directory.GetDirectories(commonRoot, "*", SearchOption.AllDirectories))
                {
                    var relativePath = dir.Replace(environment.ContentRootPath, string.Empty)
                                          .Replace("\\", "/");
                    options.ViewLocationFormats.Add($"{relativePath}/{{0}}.cshtml");
                }

                options.ViewLocationFormats.Add("/Web/Common/{0}.cshtml");
            }
        });

        return services;
    }
}
