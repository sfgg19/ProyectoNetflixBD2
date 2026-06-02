using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    [BsonIgnoreExtraElements]
    public class Episodio
    {
        public string IDEpisodio { get; set; }
        public int NumeroEpisodio { get; set; }
        public string TituloEpisodio { get; set; }
        public string Resumen { get; set; }
        public int Duracion { get; set; }
    }
}