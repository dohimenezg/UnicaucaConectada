using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    [BsonElement("name")]
    public string nombre { get; set; }

    [BsonElement("username")]
    public string nombre_usuario { get; set; }

    [BsonElement("password")]
    public string contrasena { get; set; }

    [BsonElement("email")]
    public string correo { get; set; }
}