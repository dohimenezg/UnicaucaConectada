using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace EventosVista.Source.Model
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Titulo { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Descripcion { get; set; } = string.Empty;

        [BsonElement("organizer")]
        public User? Organizador { get; set; }

        [BsonElement("begin_date")]
        public DateTime FechaInicio { get; set; }

        [BsonElement("end_date")]
        public DateTime FechaFinal { get; set; }

        [BsonElement("location")]
        public string Lugar { get; set; } = string.Empty;

        [BsonElement("banner")]
        public string Banner { get; set; } = string.Empty;

    }
}
