using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Models.Requests;
using ToDo.Services.Interfaces;

namespace ToDo.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController: ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateToken([FromServices] IAuthenticationService authenticationService, [FromBody] AuthenticationRequest request)
    {
        var token = await authenticationService.CreateToken(request);
        return CreatedAtAction(nameof(CreateToken), token);
    }
    
}