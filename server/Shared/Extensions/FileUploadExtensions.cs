using server.Infrastructure.Services.FileUploadService;

namespace server.Shared.Extensions;

/// <summary>
/// Extension methods for configuring file upload services
/// </summary>
public static class FileUploadExtensions
{
    /// <summary>
    /// Adds file upload services and configuration
    /// </summary>
    public static IServiceCollection AddFileUploadServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FileUploadOptions>(configuration.GetSection("FileUpload"));
        services.AddScoped<IFileUploadService, FileUploadService>();

        return services;
    }
}
