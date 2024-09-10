using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Persistence;
using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Repositories.Base;

namespace ToDo.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
        );

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        //services.AddScoped<IToDoRepository, ToDoRepository>();

        return services;
    }
}