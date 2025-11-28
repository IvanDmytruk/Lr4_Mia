using LW4_MIA_2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LW4_MIA_2.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}