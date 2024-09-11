using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories.Base;
using ToDo.Infrastructure.Repositories.Implementations;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoDbContext>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IToDoRepository, ToDoRepository>();

        return services;
    }
}