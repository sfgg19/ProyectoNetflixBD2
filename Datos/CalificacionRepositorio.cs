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
    }
}
