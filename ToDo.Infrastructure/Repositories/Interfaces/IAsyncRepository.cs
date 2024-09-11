namespace ToDo.Infrastructure.Repositories.Interfaces;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetById(int taskId);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
}