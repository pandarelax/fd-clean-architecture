namespace Todo_App.Domain.Filters;

public interface IFilter<T>
{
    IQueryable<T> Apply(IQueryable<T> query);
}
