using System.Reflection;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;

namespace ToDo.Api.Startup;

public static class InstallServices
{
    public static IServiceCollection AddApplicationServices(this  IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IToDoService, ToDoService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        return services;
    }
}