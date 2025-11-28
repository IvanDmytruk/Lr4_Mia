using LW4_MIA_2.Models;

namespace LW4_MIA_2.Repositories
{
    public interface IRepositoriesTodo : IRepository<Todo>
    {
        Task<List<Todo>> GetTodosAsync(Todo todo);

    }
}
