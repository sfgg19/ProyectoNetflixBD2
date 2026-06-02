using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    [BsonIgnoreExtraElements]
    public class Cuenta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IDCuenta { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TarjetaEnmascarada { get; set; }

        public Plan Plan { get; set; } = new Plan();
        public List<Perfil> Perfiles { get; set; } = new List<Perfil>();
        public List<Pago> Pagos { get; set; } = new List<Pago>();
    }

    [BsonIgnoreExtraElements]
    public class Plan
    {
        public string NombrePlan { get; set; }
        public int MaxDispositivos { get; set; }
        public string Calidad { get; set; }
        public int DescargasPermitidas { get; set; }
    }
}
