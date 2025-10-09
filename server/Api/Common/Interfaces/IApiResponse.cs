namespace server.Api.Common.Interfaces;

public sealed record IApiResponse<T>(
    T Result,
    bool Success = true,
    string? Message = null,
    string? ErrorCode = null
);
