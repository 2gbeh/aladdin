namespace server.Shared.Dtos;

public class BaseEntityDto
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class BaseEntityWithContactDto : BaseEntityDto
{
    public ContactDto? Contact { get; set; }    
}