using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace TestAPI.Models
{
    public class Item
    {
        [BsonId][BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string ItemName { get; set; } = null!;
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public int Control { get; set; }
        public int Loft { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
