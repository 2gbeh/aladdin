namespace server.Domain.ValueObjects;

public sealed class FileValueObjectOptions
{
    public long MaxSizeInBytes { get; init; } = 20 * 1024 * 1024; // 20 MB default
    public string[] AllowedTypes { get; init; } = new[] { "image/png", "image/jpeg", "application/pdf" };
}
