using LW4_MIA_2.Enum;
using MongoDB.Bson.Serialization.Attributes;
namespace LW4_MIA_2.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; } = string.Empty;
        [BsonElement("Description")]
        public string? Description { get; set; }
        [BsonElement("Type")]
        public EnumCategory Type { get; set; }

        public List<string> Validate()
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(Title)) errors.Add("Title не може бути порожнім.");
            if (Title.Length < 2) errors.Add("Title має містити щонайменше 2 символи.");
            return errors;
        }
    }
}
