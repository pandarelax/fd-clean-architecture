
namespace Todo_App.Domain.Entities;

public class Tag : BaseAuditableEntity
{
    public string? Name { get; set; }

    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
