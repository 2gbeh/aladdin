using server.Domain.ValueObjects;

namespace server.Application.Common.Dtos;

public class ContactDto : EntityDto
{
    public string? ImageUrl { get; init; }
    public string Name { get; init; } = "";
    public string? BusinessName { get; init; }
    public TelephoneValueObject? Telephone { get; init; }
}

public class ContactEntityDto : ContactDto
{
    public IEnumerable<TransactionDto>? Transactions { get; init; }
}