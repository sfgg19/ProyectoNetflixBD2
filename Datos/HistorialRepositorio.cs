using System;
using MongoDB.Driver;
using Netflix.Modelos;

namespace Netflix.Datos
{
    public class HistorialRepositorio
    {
        private IMongoCollection<Historial> _coleccion;

        public HistorialRepositorio()
        {
            var db = new ConexionBD().ObtenerBaseDatos();
            _coleccion = db.GetCollection<Historial>("Interacciones_Historial");
        }

        public void RegistrarVisualizacion(Historial historial)
        {
            historial.FechaVisualizacion = DateTime.Now;
            _coleccion.InsertOne(historial);
        }
    }
}
