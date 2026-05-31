using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Netflix.Modelos;

namespace Netflix.Datos
{
    public class PagoRepositorio
    {
        private IMongoCollection<Cuenta> _coleccion;

        public PagoRepositorio()
        {
            var db = new ConexionBD().ObtenerBaseDatos();
            _coleccion = db.GetCollection<Cuenta>("Cuentas");
        }

        public List<Pago> ObtenerPagos(string idCuenta)
        {
            var cuenta = _coleccion.Find(c => c.IDCuenta == idCuenta).FirstOrDefault();
            if (cuenta != null && cuenta.Pagos != null)
            {
                return cuenta.Pagos.OrderByDescending(p => p.FechaPago).ToList();
            }
            return new List<Pago>();
        }
    }
}
