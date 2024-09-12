using ToDo.Core.Models.Requests;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services;

public class AuthenticationService: IAuthenticationService
{
    public async Task<string> CreateToken(AuthenticationRequest request)
    {
        return "token value as string";
    }
}