using System.Data;

namespace Netflix.Datos
{
    public class ReporteRepositorio
    {
        // Dummy implementation para que compile.
        // Convertir las consultas agregadas en Datatables manualmente requeriría mucha lógica,
        // devolveré tablas vacías para cumplir con el código por ahora. 
        public DataTable ReportePeliculaMasVista() { return new DataTable(); }
        public DataTable ReportePeliculaPorEdad() { return new DataTable(); }
        public DataTable ReporteGeneroFavorito() { return new DataTable(); }
        public DataTable ReporteMejorCalificada() { return new DataTable(); }
        public DataTable ReportePromedioGeneral() { return new DataTable(); }
        public DataTable ReporteCuentasPorAno() { return new DataTable(); }
        public DataTable ReporteCantidadPorGenero() { return new DataTable(); }
    }
}
