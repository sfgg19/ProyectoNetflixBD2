using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    public class Calificacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IDCalificacion { get; set; }

        public string IDPerfil { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string IDContenido { get; set; }

        public int Estrellas { get; set; } // Valor del 1 al 5
        public string Comentario { get; set; }
        public DateTime FechaCalificacion { get; set; }
    }
}
