using Microsoft.EntityFrameworkCore;
using ToDo.Core.Persistence;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Infrastructure.Repositories.Base;

public class RepositoryBase<T>(DbContext context): IAsyncRepository<T> where T : class
{
    public async Task<T> AddAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
}