namespace server.Application.Common.Queries;

public abstract record BasePagedQuery
{
    public int? Skip { get; init; }
    public int? Take { get; init; }
    public string? SearchTerm { get; init; }
}
