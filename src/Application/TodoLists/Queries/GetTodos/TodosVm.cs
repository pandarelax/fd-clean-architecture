﻿namespace Todo_App.Application.TodoLists.Queries.GetTodos;

public class TodosVm
{
    public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

    public IList<TagDto> Tags { get; set; } = new List<TagDto>();

    public IList<TodoListDto> Lists { get; set; } = new List<TodoListDto>();
}
