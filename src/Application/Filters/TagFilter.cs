using Todo_App.Domain.Entities;
using Todo_App.Domain.Enums;
using Todo_App.Domain.Filters;

namespace Todo_App.Application.Filters;

public class TagFilter : IFilter<TodoItem>
{
    private readonly List<int> _tagIds;

    public TagFilter(List<int> tagIds)
    {
        _tagIds = tagIds;
    }

    public IQueryable<TodoItem> Apply(IQueryable<TodoItem> query)
    {
        if (_tagIds != null && _tagIds.Any())
        {
            query = query.Where(item => _tagIds.Contains(item.TagId ?? 0));
        }
        return query;
    }
}

public class PriorityFilter : IFilter<TodoItem>
{
    private readonly PriorityLevel _priority;

    public PriorityFilter(PriorityLevel priority)
    {
        _priority = priority;
    }

    public IQueryable<TodoItem> Apply(IQueryable<TodoItem> query)
    {
        return query.Where(item => item.Priority == _priority);
    }
}
