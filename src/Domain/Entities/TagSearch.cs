
namespace Todo_App.Domain.Entities;

public class TagSearch : BaseAuditableEntity
{
    public string? Name { get; set; }

    public int SearchCount { get; set; }
}
