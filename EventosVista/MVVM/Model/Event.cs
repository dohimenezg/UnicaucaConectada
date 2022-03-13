using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Event
{   
    public Event(string titulo, string descripcion, DateTime fecha_inicio, DateTime fecha_final, User currentUser)
    {
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.fecha_inicio = fecha_inicio;
        this.fecha_final = fecha_final;
        this.organizador = currentUser;
    }
    
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
    public byte[] banner { get; set; }

}