using server.Domain.ValueObjects;

namespace server.Infrastructure.Services.FileUploadService;

public interface IFileUploadService
{
    Task<string> UploadAsync(FileValueObject vo, CancellationToken ct);

    Task DeleteAsync(string url, CancellationToken ct);
}
