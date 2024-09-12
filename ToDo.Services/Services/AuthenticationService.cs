using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDo.Core.Entities;
using ToDo.Core.Models.Requests;
using ToDo.Infrastructure.Repositories.Interfaces;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services;

public class AuthenticationService(IAuthenticationRepository authenticationRepository, IMapper mapper, IConfiguration configuration)
    : IAuthenticationService
{
    private readonly string _secretKey = configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException();
    private readonly string _issuer = configuration["Jwt:Issuer"] ?? throw new InvalidOperationException();
    private readonly string _audience = configuration["Jwt:Audience"] ?? throw new InvalidOperationException();

    public async Task<string> CreateToken(AuthenticationRequest request)
    {
        var authRequest = mapper.Map<Authentication>(request);
        var jwt = CreateJwtToken(request.UserName, _secretKey);
        authRequest.AuthenticationToken = jwt;
        var token = await authenticationRepository.AddAsync(authRequest);
        return token.AuthenticationToken;
    }

    public async Task<IList<string>> GetUserViews()
    {
        return new[] { "/Home", "/", "/", "/" };
    }

    private string CreateJwtToken(string userName, string secretKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(hmac.Key),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Issuer = _issuer,
            Audience = _audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}