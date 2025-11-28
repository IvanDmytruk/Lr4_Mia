using LW4_MIA_2.Models;

namespace LW4_MIA_2.Repositories
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        (string token, DateTime expires) CreateRefreshTokenWithExpiry(int refreshDays);
    }
}
