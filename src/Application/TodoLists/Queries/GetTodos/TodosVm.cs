namespace Todo_App.Application.TodoLists.Queries.GetTodos;

public class TodosVm
{
    public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

    public IList<BackgroundColourDto> Colours { get; set; } = new List<BackgroundColourDto>();

    public IList<TodoListDto> Lists { get; set; } = new List<TodoListDto>();
}
