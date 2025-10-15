namespace server.Application.Common.Dtos;

public class EntityDto: IdentifierDto
{
    public DateTime? CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }
}