using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo_App.Application.Common.Interfaces;
using Todo_App.Domain.Enums;

namespace Todo_App.Application.TodoLists.Queries.GetTodos;

public record GetTodosQuery(IList<int>? TagIds) : IRequest<TodosVm>;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var todoListsQuery = _context.TodoLists
            .AsNoTracking()
            .Include(tl => tl.Items)
            .ThenInclude(ti => ti.Tag)
            .AsQueryable();

        var filteredTodoLists = await todoListsQuery
            .Select(tl => new TodoListDto
            {
                Id = tl.Id,
                Title = tl.Title,
                Items = tl.Items
                    .Where(ti => request.TagIds == null || !request.TagIds.Any() || request.TagIds.Contains(ti.TagId ?? 0))
                    .Select(ti => new TodoItemDto
                    {
                        Id = ti.Id,
                        Title = ti.Title,
                        Note = ti.Note,
                        TagId = ti.TagId,
                        ListId = ti.ListId,
                        Done = ti.Done,
                    })
                    .ToList()
            })
            .OrderBy(tl => tl.Title)
            .ToListAsync(cancellationToken);

        return new TodosVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList(),

            Tags = await _context.Tags
                .AsNoTracking()
                .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken),

            Lists = filteredTodoLists
        };
    }
}
