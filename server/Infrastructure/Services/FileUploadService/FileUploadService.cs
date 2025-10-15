using Microsoft.Extensions.Options;
using server.Domain.ValueObjects;

namespace server.Infrastructure.Services.FileUploadService;

public class FileUploadOptions
{
    public long MaxSizeInBytes { get; set; } = 20 * 1024 * 1024; // default 20 MB
    public string[] AllowedTypes { get; set; } = new[] { "image/png", "image/jpeg", "application/pdf" };
}

public class FileUploadService : IFileUploadService
{
    private readonly FileUploadOptions _options;

    public FileUploadService(IOptions<FileUploadOptions> options)
    {
        _options = options.Value;
    }

    public Task<string> UploadAsync(FileValueObject vo, CancellationToken ct)
    {
        // In this minimal implementation, we assume the file is already uploaded elsewhere
        // and FileValueObject contains validated metadata. Return the URL as-is.
        // You can replace this with real storage logic later (e.g., local disk, S3, Azure Blob).
        return Task.FromResult(vo.Url);
    }

    public Task DeleteAsync(string url, CancellationToken ct)
    {
        // If using local storage, you could resolve the path and delete it.
        // For remote storage, call the provider SDK here.
        return Task.CompletedTask;
    }
}


