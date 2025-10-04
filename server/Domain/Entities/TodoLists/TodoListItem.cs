using System.Collections.Generic;
using server.Domain.Common;
using server.Shared.ValueObjects;

namespace server.Domain.Entities;

public class TodoListItem : BaseEntity
{
    // Required descriptive name of the bill
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // JSON string representing an array of (starttime, endtime) tuples, e.g. [["08:00","09:30"],["13:15","14:00"]]
    public string? TimePeriodJson { get; set; }

    public Guid TodoListId { get; set; }
    public TodoList? TodoList { get; set; }
}