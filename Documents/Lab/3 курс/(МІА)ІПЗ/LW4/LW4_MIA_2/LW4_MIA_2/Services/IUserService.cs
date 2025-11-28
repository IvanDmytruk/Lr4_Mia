using LW4_MIA_2.Models;

namespace LW4_MIA_2.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetUsersAsync(User user);
    }
}
