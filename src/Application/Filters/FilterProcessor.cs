using Todo_App.Domain.Filters;

namespace Todo_App.Application.Filters;

public class FilterProcessor<T>
{
    private readonly List<IFilter<T>> _filters;

    public FilterProcessor()
    {
        _filters = new List<IFilter<T>>();
    }

    public void AddFilter(IFilter<T> filter)
    {
        _filters.Add(filter);
    }

    public IQueryable<T> ApplyFilters(IQueryable<T> query)
    {
        foreach (var filter in _filters)
        {
            query = filter.Apply(query);
        }
        return query;
    }
}
