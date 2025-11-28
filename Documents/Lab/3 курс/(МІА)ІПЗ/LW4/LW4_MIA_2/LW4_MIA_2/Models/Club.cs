using MongoDB.Bson.Serialization.Attributes;
namespace LW4_MIA_2.Models
{
    public class Club
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Departament")]
        public string Departament { get; set; } = string.Empty;
        [BsonElement("Adressa")]
        public string Adressa { get; set; } = string.Empty;
        [BsonElement("Owner")]
        public string Owner { get; set; } = string.Empty;
        [BsonElement("Contacts")]
        public string Contacts { get; set; } = string.Empty;
        [BsonElement("MountlyPayment")]
        public double MountlyPayment { get; set; }
        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Departament)
                && !string.IsNullOrWhiteSpace(Adressa)
                && MountlyPayment >= 0;
        }
    }
}
