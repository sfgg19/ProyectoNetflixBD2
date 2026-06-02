using System;
using MongoDB.Driver;
using Netflix.Modelos;

namespace Netflix.Datos
{
    public class CalificacionRepositorio
    {
        private IMongoCollection<Calificacion> _coleccion;

        public CalificacionRepositorio()
        {
            var db = new ConexionBD().ObtenerBaseDatos();
            _coleccion = db.GetCollection<Calificacion>("Interacciones_Calificaciones");
        }

        public void Guardar(Calificacion calif)
        {
            calif.FechaCalificacion = DateTime.Now;
            _coleccion.InsertOne(calif);
        }

        public System.Collections.Generic.List<Calificacion> ObtenerPorContenido(string idContenido)
        {
            return _coleccion.Find(c => c.IDContenido == idContenido).ToList();
        }

        public void Actualizar(Calificacion calif)
        {
            calif.FechaCalificacion = DateTime.Now;
            _coleccion.ReplaceOne(c => c.IDCalificacion == calif.IDCalificacion, calif);
        }

        public void Borrar(string id)
        {
            _coleccion.DeleteOne(c => c.IDCalificacion == id);
        }
    }
}
