using ToDo.Core.Models;
using ToDo.Core.Models.Requests;
using ToDo.Core.Models.Responses;
using Entities_ToDo = ToDo.Core.Entities.ToDo;
namespace ToDo.Services.Interfaces;

public interface IToDoService
{
    /// <summary>
    /// Create a new To-Do
    /// </summary>
    /// <param name="task"></param>
    /// <returns>Returns the To-Do created</returns>
    Task<ToDoResponse> Create(ToDoCreateRequest task);
    /// <summary>
    /// Get All To-Do
    /// </summary>
    /// <returns>A List with all To-Do</returns>
    Task<IList<ToDoResponse>> GetAll();
    /// <summary>
    /// Update an existing To-Do
    /// </summary>
    /// <param name="task"></param>
    /// <returns>The task updated</returns>
    Task<ToDoResponse> Update(ToDoRequest task);
    /// <summary>
    /// Delete a task created before
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns>An string with the operations result</returns>
    Task<string> Delete(int taskId);
}