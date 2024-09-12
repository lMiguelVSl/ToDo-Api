using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Models.Requests;
using ToDo.Services.Interfaces;
using Entities_ToDo = ToDo.Core.Entities.ToDo;

namespace ToDo.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class ToDosController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IToDoService toDoService)
    {
        return Ok(await toDoService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromServices] IToDoService toDoService, [FromBody] ToDoCreateRequest todo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        return CreatedAtAction(nameof(Post), await toDoService.Create(todo));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromServices] IToDoService toDoService, [FromBody] ToDoRequest todo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        return Ok(await toDoService.Update(todo));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromServices] IToDoService toDoService, [FromQuery] int taskId)
    {
        var test = await toDoService.Delete(taskId);
        return Ok(true);
    }
}