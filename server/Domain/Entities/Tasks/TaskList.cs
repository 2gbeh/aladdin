using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class TaskList : BaseEntity
{
    // Required descriptive name of the bill
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}