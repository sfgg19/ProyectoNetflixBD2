using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    public class Temporada
    {
        public string IDTemporada { get; set; }
        public int NumeroTemporada { get; set; }
        public string ResumenTemporada { get; set; }
        
        public List<Episodio> Episodios { get; set; } = new List<Episodio>();

        public override string ToString() { return "Temporada " + NumeroTemporada; }
    }
}
