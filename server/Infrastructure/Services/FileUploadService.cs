namespace server.Infrastructure.Services;

public class FileUploadOptions
{
    public long MaxSizeInBytes { get; set; } = 20 * 1024 * 1024; // default 20 MB
    public string[] AllowedTypes { get; set; } = new[] { "image/png", "image/jpeg", "application/pdf" };
}

public class FileUploadService : IFileUploadService
{
    private readonly FileUploadOptions _options;

    public FileService(IOptions<FileUploadOptions> options)
    {
        _options = options.Value;
    }

    public async Task<string> UploadAsync(FileUpload file, CancellationToken ct)
    {
        // validate size
        if (file.Size > _options.MaxSizeInBytes)
            throw new InvalidOperationException("File too large");

        // persist to storage
        var path = Path.Combine("uploads", file.Name);
        await File.WriteAllBytesAsync(path, file.Content, ct);

        return path;
    }

    public Task DeleteAsync(string url, CancellationToken ct)
    {
        if (File.Exists(url))
            File.Delete(url);
        return Task.CompletedTask;
    }
}


