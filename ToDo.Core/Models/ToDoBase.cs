namespace ToDo.Core.Models;

public class ToDoBase
{
    public string? Title { get; set; }
    public bool IsDone { get; set; } = false;
}