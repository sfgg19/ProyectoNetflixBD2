using System;
using System.Linq;
using MongoDB.Driver;
using Netflix.Modelos;

namespace Netflix.Datos
{
    public class CuentaRepositorio
    {
        private IMongoCollection<Cuenta> _coleccion;

        public CuentaRepositorio()
        {
            var db = new ConexionBD().ObtenerBaseDatos();
            _coleccion = db.GetCollection<Cuenta>("Cuentas");
        }

        public Cuenta Login(string email)
        {
            return _coleccion.Find(c => c.Email == email).FirstOrDefault();
        }

        public void ActualizarPlan(string idCuenta, string nombreNuevoPlan)
        {
            var update = Builders<Cuenta>.Update.Set(c => c.Plan.NombrePlan, nombreNuevoPlan);
            _coleccion.UpdateOne(c => c.IDCuenta == idCuenta, update);
        }

        public Cuenta ObtenerCuentaPorID(string id)
        {
            return _coleccion.Find(c => c.IDCuenta == id).FirstOrDefault();
        }
    }
}
