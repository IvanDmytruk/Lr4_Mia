using LW4_MIA_2.DTO;
using LW4_MIA_2.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LW4_MIA_2.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMongoCollection<User> _users;
        private readonly JwtSettings _jwt;

        public AuthService(IOptions<JwtSettings> jwt, IMongoDatabase db)
        {
            _jwt = jwt.Value;
            _users = db.GetCollection<User>("Users");
        }

        public async Task<User?> RegisterAsync(RegisterRequest request)
        {
            if (await _users.Find(u => u.Email == request.Email).FirstOrDefaultAsync() != null)
                return null; // користувач вже існує

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"
            };

            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _users.Find(u => u.Email == request.Email).FirstOrDefaultAsync();
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return null;

            var accessToken = GenerateToken(user, _jwt.AccessTokenExpiryMinutes);
            var refreshToken = GenerateToken(user, _jwt.RefreshTokenExpiryDays * 24 * 60);

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpires = DateTime.UtcNow.AddMinutes(_jwt.AccessTokenExpiryMinutes),
                RefreshTokenExpires = DateTime.UtcNow.AddDays(_jwt.RefreshTokenExpiryDays)
            };
        }

        public Task<AuthResponse?> RefreshTokenAsync(TokenRefreshRequest request)
        {
            // Тимчасово – тут можна додати перевірку refreshToken
            return Task.FromResult<AuthResponse?>(null);
        }

        private string GenerateToken(User user, int expiryMinutes)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
