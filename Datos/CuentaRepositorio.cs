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

        public Cuenta Login(string email, string password)
        {
            return _coleccion.Find(c => c.Email == email && c.Password == password).FirstOrDefault();
        }

        public Cuenta ObtenerCuentaPorEmail(string email)
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

        public void CrearCuenta(Cuenta cuenta)
        {
            cuenta.FechaRegistro = DateTime.Now;
            _coleccion.InsertOne(cuenta);
        }

        public System.Collections.Generic.List<Cuenta> ObtenerTodas()
        {
            return _coleccion.Find(new MongoDB.Bson.BsonDocument()).ToList();
        }

        public void ActualizarCuenta(Cuenta cuenta)
        {
            _coleccion.ReplaceOne(c => c.IDCuenta == cuenta.IDCuenta, cuenta);
        }

        public void BorrarCuenta(string id)
        {
            _coleccion.DeleteOne(c => c.IDCuenta == id);
        }
    }
}
