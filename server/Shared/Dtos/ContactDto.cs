using server.Shared.ValueObjects;

namespace server.Shared.Dtos;

public class ContactDto
{
    public string? ImageUrl { get; set; }
    public string Name { get; set; } = "";
    public string? BusinessName { get; set; }
    public TelephoneValueObject? Telephone { get; set; }
}

public class ContactEntityDto : BaseEntityDto
{
public string? ImageUrl { get; set; }
    public string Name { get; set; } = "";
    public string? BusinessName { get; set; }
    public TelephoneValueObject? Telephone { get; set; }
}


public class ContactSummaryDto
{
    Guid Id { get; set; }
    public string? ImageUrl { get; set; }
    public string Name { get; set; } = "";
    public string? BusinessName { get; set; }
}