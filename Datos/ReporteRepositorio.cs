using System.Data;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Netflix.Datos
{
    public class ReporteRepositorio
    {
        private IMongoDatabase db;

        public ReporteRepositorio()
        {
            db = new ConexionBD().ObtenerBaseDatos();
        }

        private DataTable BsonToDataTable(System.Collections.Generic.List<BsonDocument> bsonList)
        {
            DataTable dt = new DataTable();
            if (bsonList.Count == 0) return dt;

            foreach (var element in bsonList[0].Elements)
            {
                dt.Columns.Add(element.Name);
            }

            foreach (var doc in bsonList)
            {
                DataRow row = dt.NewRow();
                foreach (var element in doc.Elements)
                {
                    row[element.Name] = element.Value.ToString();
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable ReportePeliculaMasVista() 
        { 
            var col = db.GetCollection<BsonDocument>("Interacciones_Historial");
            var pipeline = new BsonDocument[] 
            {
                BsonDocument.Parse("{ $group: { _id: '$IDContenido', TotalVistas: { $sum: 1 } } }"),
                BsonDocument.Parse("{ $sort: { TotalVistas: -1 } }")
            };
            return BsonToDataTable(col.Aggregate<BsonDocument>(pipeline).ToList());
        }

        public DataTable ReportePeliculaPorEdad() 
        { 
            var col = db.GetCollection<BsonDocument>("Interacciones_Historial");
            var pipeline = new BsonDocument[] 
            {
                BsonDocument.Parse("{ $group: { _id: '$IDPerfil', TotalVistas: { $sum: 1 } } }"),
                BsonDocument.Parse("{ $sort: { TotalVistas: -1 } }")
            };
            return BsonToDataTable(col.Aggregate<BsonDocument>(pipeline).ToList());
        }

        public DataTable ReporteGeneroFavorito() 
        { 
            // Query simple por ahora para evitar lookup complejo sin ObjectIds estandarizados
            var col = db.GetCollection<BsonDocument>("Contenidos");
            var pipeline = new BsonDocument[] 
            {
                BsonDocument.Parse("{ $unwind: '$Generos' }"),
                BsonDocument.Parse("{ $group: { _id: '$Generos', Cantidad: { $sum: 1 } } }"),
                BsonDocument.Parse("{ $sort: { Cantidad: -1 } }")
            };
            return BsonToDataTable(col.Aggregate<BsonDocument>(pipeline).ToList());
        }

        public DataTable ReporteMejorCalificada() 
        { 
            var col = db.GetCollection<BsonDocument>("Interacciones_Calificaciones");
            var pipeline = new BsonDocument[] 
            {
                BsonDocument.Parse("{ $group: { _id: '$IDContenido', PromedioEstrellas: { $avg: '$Estrellas' }, TotalVotos: { $sum: 1 } } }"),
                BsonDocument.Parse("{ $sort: { PromedioEstrellas: -1 } }")
            };
            return BsonToDataTable(col.Aggregate<BsonDocument>(pipeline).ToList());
        }

        public DataTable ReportePromedioGeneral() 
        { 
            var col = db.GetCollection<BsonDocument>("Interacciones_Calificaciones");
            var pipeline = new BsonDocument[] 
            {
                BsonDocument.Parse("{ $group: { _id: 'General', PromedioGeneral: { $avg: '$Estrellas' }, TotalCalificaciones: { $sum: 1 } } }")
            };
            return BsonToDataTable(col.Aggregate<BsonDocument>(pipeline).ToList());
        }

        public DataTable ReporteCuentasPorAno() 
        { 
            var col = db.GetCollection<BsonDocument>("Cuentas");
            var pipeline = new BsonDocument[] 
            {
                BsonDocument.Parse("{ $group: { _id: { $year: '$FechaRegistro' }, TotalCuentas: { $sum: 1 } } }"),
                BsonDocument.Parse("{ $sort: { _id: -1 } }")
            };
            return BsonToDataTable(col.Aggregate<BsonDocument>(pipeline).ToList());
        }

        public DataTable ReporteCantidadPorGenero() 
        { 
            var col = db.GetCollection<BsonDocument>("Contenidos");
            var pipeline = new BsonDocument[] 
            {
                BsonDocument.Parse("{ $unwind: '$Generos' }"),
                BsonDocument.Parse("{ $group: { _id: '$Generos', Cantidad: { $sum: 1 } } }"),
                BsonDocument.Parse("{ $sort: { Cantidad: -1 } }")
            };
            return BsonToDataTable(col.Aggregate<BsonDocument>(pipeline).ToList());
        }
    }
}
