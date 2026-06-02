using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Netflix.Modelos;

namespace Netflix.Datos
{
    public class ContenidoRepositorio
    {
        private IMongoCollection<Contenido> _coleccion;

        public ContenidoRepositorio()
        {
            var db = new ConexionBD().ObtenerBaseDatos();
            _coleccion = db.GetCollection<Contenido>("Contenidos");
        }

        public List<Contenido> ObtenerEstrenos()
        {
            return _coleccion.Find(new BsonDocument()).SortByDescending(c => c.Anio).Limit(10).ToList();
        }

        public List<Contenido> Buscar(string texto)
        {
            var filter = Builders<Contenido>.Filter.Or(
                Builders<Contenido>.Filter.Regex(c => c.Titulo, new BsonRegularExpression(texto, "i")),
                Builders<Contenido>.Filter.Regex(c => c.Director, new BsonRegularExpression(texto, "i"))
            );
            return _coleccion.Find(filter).ToList();
        }

        public List<Contenido> ObtenerTodo()
        {
            return _coleccion.Find(new BsonDocument()).ToList();
        }

        public void Crear(Contenido contenido)
        {
            _coleccion.InsertOne(contenido);
        }

        public void Actualizar(Contenido contenido)
        {
            _coleccion.ReplaceOne(c => c.IDContenido == contenido.IDContenido, contenido);
        }

        public void Borrar(string id)
        {
            _coleccion.DeleteOne(c => c.IDContenido == id);
        }
    }
}
