using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    public class Contenido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IDContenido { get; set; }
        
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string TipoContenido { get; set; } // 'Pelicula' o 'Serie'
        public string Director { get; set; }
        public int Anio { get; set; }
        public int Duracion { get; set; } // en minutos

        // Embebidos
        public ClasificacionEdad ClasificacionEdad { get; set; }
        public List<string> Generos { get; set; } = new List<string>();
        public List<VigenciaDerechos> Vigencias { get; set; } = new List<VigenciaDerechos>();

        // Si es serie, embebe temporadas
        public List<Temporada> Temporadas { get; set; } = new List<Temporada>();

        public override string ToString() { return Titulo; }
    }

    public class ClasificacionEdad
    {
        public string NombreClasificacion { get; set; }
    }

    public class VigenciaDerechos
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Proveedor { get; set; }
    }
}