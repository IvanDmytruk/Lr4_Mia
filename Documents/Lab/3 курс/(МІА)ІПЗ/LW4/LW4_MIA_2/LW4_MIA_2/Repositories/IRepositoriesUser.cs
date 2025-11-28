using LW4_MIA_2.Models;

namespace LW4_MIA_2.Repositories
{
    public interface IRepositoriesUser : IRepository<User>
    {
        Task<List<User>> GetUsersAsync(User user);
    }
}
