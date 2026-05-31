using System.Collections.Generic;
using MongoDB.Driver;
using Netflix.Modelos;

namespace Netflix.Datos
{
    public class PerfilRepositorio
    {
        private IMongoCollection<Cuenta> _coleccion;

        public PerfilRepositorio()
        {
            var db = new ConexionBD().ObtenerBaseDatos();
            _coleccion = db.GetCollection<Cuenta>("Cuentas");
        }

        public List<Perfil> ObtenerPerfiles(string idCuenta)
        {
            var cuenta = _coleccion.Find(c => c.IDCuenta == idCuenta).FirstOrDefault();
            if (cuenta != null && cuenta.Perfiles != null)
            {
                foreach(var p in cuenta.Perfiles) p.IDCuenta = idCuenta;
                return cuenta.Perfiles;
            }
            return new List<Perfil>();
        }
    }
}
