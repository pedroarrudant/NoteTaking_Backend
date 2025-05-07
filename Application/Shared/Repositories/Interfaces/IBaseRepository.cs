namespace Application.Shared.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string tableName);
        Task<T?> GetByIdAsync(string tableName, object id);
        Task<int> InsertAsync(string tableName, T entity);
        Task<int> UpdateAsync(string tableName, T entity, object id);
        Task<int> DeleteAsync(string tableName, object id);
    }
}
