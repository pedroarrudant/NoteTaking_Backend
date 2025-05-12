using Application.Shared.Models;

namespace Application.Shared.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string tableName);
        Task<T?> GetByIdAsync(string tableName, object id);
        Task<int> InsertAsync(string tableName, T entity);
        Task<int> InsertAsync(string tableName, NoteModel entity);
        Task<int> UpdateAsync(string tableName, T entity, object id);
        Task<NoteModel> UpdateAsync(string tableName, NoteModel entity);
        Task<int> DeleteAsync(string tableName, object id);
    }
}
