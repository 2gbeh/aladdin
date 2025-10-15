

namespace server.Domain.Entities;

public class TodoList : BaseEntity
{
    // Required descriptive name of the bill
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public ICollection<TodoListItem> Items { get; set; } = new List<TodoListItem>();
}