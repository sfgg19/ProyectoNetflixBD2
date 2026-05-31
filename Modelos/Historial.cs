using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    public class Historial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IDHistorial { get; set; }
        
        // Referencia a Perfil y Contenido
        public string IDPerfil { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string IDContenido { get; set; }
        
        public string IDEpisodio { get; set; } // Puede ser nulo
        public DateTime FechaVisualizacion { get; set; }
        public int Progreso { get; set; } // Porcentaje visto
    }
}