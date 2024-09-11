using AutoMapper;
using ToDoModel = ToDo.Core.Entities.ToDo;
using ToDo.Core.Models.Requests;
using ToDo.Core.Models.Responses;
using ToDo.Infrastructure.Repositories.Interfaces;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services;

public class ToDoService(IToDoRepository toDoRepository, IMapper mapper) : IToDoService
{
    public async Task<ToDoResponse> Create(ToDoRequest toDo)
    {
        var createRequest = mapper.Map<ToDoModel>(toDo);
        return mapper.Map<ToDoResponse>(await toDoRepository.AddAsync(createRequest));
    }

    public async Task<IList<ToDoResponse>> GetAll() => mapper.Map<List<ToDoResponse>>(await toDoRepository.GetAllAsync());

    public async Task<ToDoResponse> Update(ToDoRequest toDo)
    {
        var taskToUpdate = await ValidateRequest(toDo.Id);
        return mapper.Map<ToDoResponse>(await toDoRepository.UpdateAsync(taskToUpdate));
    }

    public async Task<string> Delete(int taskId)
    {
        var taskToDelete = await ValidateRequest(taskId);
        
        var value = await toDoRepository.DeleteAsync(taskToDelete);
        return value > 0 ? $"Delete Success: {value}" : throw new Exception("The car could not be added");
    }

    private async Task<ToDoModel> ValidateRequest(int taskId)
    {
        var taskToDelete = await toDoRepository.GetById(taskId);
        if (taskToDelete == null) throw new Exception("The task does not exist");
        return taskToDelete;
    }
}