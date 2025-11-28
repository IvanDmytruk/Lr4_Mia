using LW4_MIA_2.Models;

namespace LW4_MIA_2.Services
{
    public interface ITodoServices
    {
       public Task<List<Todo>> GetTodosAsync(Todo todo);
    }
}
