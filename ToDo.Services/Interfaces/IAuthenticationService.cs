using ToDo.Core.Models.Requests;

namespace ToDo.Services.Interfaces;

public interface IAuthenticationService
{
    /// <summary>
    /// Create token for username
    /// </summary>
    /// <param name="request"></param>
    /// <returns>token value as string</returns>
    Task<string> CreateToken(AuthenticationRequest request);

    /// <summary>
    /// Get User Views allowed
    /// </summary>
    /// <returns></returns>
    Task<IList<string>> GetUserViews();
}