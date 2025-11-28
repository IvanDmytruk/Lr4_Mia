using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LW4_MIA_2.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("FullName")]
        public string FullName { get; set; } = string.Empty;

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        // Нові поля для auth
        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; } = string.Empty;

        [BsonElement("Role")]
        public string Role { get; set; } = "User";

        [BsonElement("RefreshToken")]
        public string? RefreshToken { get; set; }

        [BsonElement("RefreshTokenExpiryTime")]
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(FullName) &&
                   !string.IsNullOrWhiteSpace(Email);
        }
    }
}
