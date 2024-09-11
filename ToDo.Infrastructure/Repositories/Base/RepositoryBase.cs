using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Infrastructure.Repositories.Base;

public class RepositoryBase<T>(ToDoDbContext context): IAsyncRepository<T> where T : class
{
    public async Task<T> AddAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }
    
    public async Task<T?> GetById(int taskId)
    {
        return await context.Set<T>().FirstOrDefaultAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
}