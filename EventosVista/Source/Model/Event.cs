using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Event
{   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    [BsonElement("title")]
    public string titulo { get; set; }

    [BsonElement("description")]
    public string descripcion { get; set; }

    [BsonElement("organizer")]
    public User organizador { get; set; }

    [BsonElement("begin_date")]
    public DateTime fecha_inicio { get; set; }

    [BsonElement("end_date")]
    public DateTime fecha_final { get; set; }

    [BsonElement("location")]
    public string lugar { get; set; }

    [BsonElement("banner")]
    public string banner { get; set; }

}