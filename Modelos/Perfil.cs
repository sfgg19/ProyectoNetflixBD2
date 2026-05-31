using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    public class Perfil
    {
        public string IDPerfil { get; set; }
        public string IDCuenta { get; set; }
        public string NombrePerfil { get; set; }
        public int Edad { get; set; }
    }
}
