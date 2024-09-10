namespace ToDo.Core.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}