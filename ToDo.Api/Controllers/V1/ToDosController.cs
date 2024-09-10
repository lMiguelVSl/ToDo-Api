using Microsoft.AspNetCore.Mvc;
using Models = ToDo.Core.Models;

namespace ToDo.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class ToDosController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Models.ToDo todo)
    {
        //todo: add return from service
        return CreatedAtAction(nameof(Get), new Models.ToDo());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Models.ToDo todo)
    {
        return Ok(true);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(true);
    }
}