using LW4_MIA_2.Models;
using LW4_MIA_2.Repositories;

namespace LW4_MIA_2.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoriesUser _users;
        public UserService(IRepositoriesUser users)
        {
            _users = users;
        }

        public async Task<List<User>> GetUsersAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (!user.Validate())
                throw new ArgumentException("Невірні дані користувача.");

            return await _users.GetUsersAsync(user);
        }
    }
}
