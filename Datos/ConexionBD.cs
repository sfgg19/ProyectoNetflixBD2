using MongoDB.Driver;

namespace Netflix.Datos
{
    public class ConexionBD
    {
        // Cadena de conexión a MongoDB local
        private readonly string cadenaConexion = "mongodb://localhost:27017";
        private readonly string nombreBaseDatos = "CinepolisDB";

        public IMongoDatabase ObtenerBaseDatos()
        {
            var cliente = new MongoClient(cadenaConexion);
            return cliente.GetDatabase(nombreBaseDatos);
        }
    }
}
