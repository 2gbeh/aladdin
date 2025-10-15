using server.Domain.ValueObjects;

namespace server.Application.Common.Contracts;

public interface FileUploadServiceContract
{
    Task<string> UploadAsync(FileValueObject vo, CancellationToken ct);

    Task DeleteAsync(string url, CancellationToken ct);
}
