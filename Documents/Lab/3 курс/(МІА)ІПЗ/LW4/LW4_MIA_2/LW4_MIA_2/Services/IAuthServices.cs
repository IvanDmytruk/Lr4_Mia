using LW4_MIA_2.DTO;
using LW4_MIA_2.Models;
using System.Threading.Tasks;

namespace LW4_MIA_2.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(RegisterRequest request);
        Task<AuthResponse?> LoginAsync(LoginRequest request);
        Task<AuthResponse?> RefreshTokenAsync(TokenRefreshRequest request);
    }
}
