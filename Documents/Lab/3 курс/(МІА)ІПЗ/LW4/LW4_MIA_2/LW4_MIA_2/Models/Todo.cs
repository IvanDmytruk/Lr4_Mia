using LW4_MIA_2.Enum;
using LW4_MIA_2.Models;
using MongoDB.Bson.Serialization.Attributes;
namespace LW4_MIA_2.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] 
        public string? Id { get; set; }
        [BsonElement("Name")] 
        public string Name { get; set; } = string.Empty; 
        [BsonElement("IsComplete")]
        public bool IsComplete { get; set; }
        [BsonElement("Day")]
        public EnumDay Day { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}
