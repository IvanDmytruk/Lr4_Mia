namespace LW4_MIA_2.DTO
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int AccessTokenExpiryMinutes { get; set; }
        public int RefreshTokenExpiryDays { get; set; }
        public double AccessTokenExpirationMinutes { get; internal set; }
        public char[] Secret { get; internal set; }
    }
}
