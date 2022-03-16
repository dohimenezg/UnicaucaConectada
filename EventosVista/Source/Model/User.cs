using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventosVista.Source.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Nombre { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Nombre_Usuario { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Contrasena { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Correo { get; set; } = string.Empty;
    }
}
