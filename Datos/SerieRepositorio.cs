using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Netflix.Modelos;

namespace Netflix.Datos
{
    public class SerieRepositorio
    {
        private IMongoCollection<Contenido> _coleccion;

        public SerieRepositorio()
        {
            var db = new ConexionBD().ObtenerBaseDatos();
            _coleccion = db.GetCollection<Contenido>("Contenidos");
        }

        public string ObtenerIdSerie(string idContenido)
        {
            return idContenido; // En MongoDB el Contenido de tipo Serie es el que embebe todo, es el mismo ID
        }

        public List<Temporada> ObtenerTemporadas(string idSerie)
        {
            var serie = _coleccion.Find(c => c.IDContenido == idSerie).FirstOrDefault();
            if (serie != null && serie.Temporadas != null)
            {
                return serie.Temporadas.OrderBy(t => t.NumeroTemporada).ToList();
            }
            return new List<Temporada>();
        }

        // Ya no necesitamos esto en el repositorio porque Temporada ya incluye Episodios embebidos
        // pero lo mantenemos para no romper la UI.
        public List<Episodio> ObtenerEpisodios(string idSerie, string idTemporada)
        {
            var serie = _coleccion.Find(c => c.IDContenido == idSerie).FirstOrDefault();
            if (serie != null && serie.Temporadas != null)
            {
                var temp = serie.Temporadas.FirstOrDefault(t => t.IDTemporada == idTemporada);
                if (temp != null && temp.Episodios != null)
                {
                    return temp.Episodios.OrderBy(e => e.NumeroEpisodio).ToList();
                }
            }
            return new List<Episodio>();
        }
        
        // Versión antigua para compatibilidad UI (si es que pasaban el IDTemporada int en lugar del string)
        public List<Episodio> ObtenerEpisodios(string idTemporada)
        {
            return new List<Episodio>(); // Deprecated, requeriría buscar la temporada en todos los contenidos
        }
    }
}
