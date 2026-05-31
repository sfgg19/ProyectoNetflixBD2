using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Netflix.Modelos
{
    public class Pago
    {
        public string IDPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
