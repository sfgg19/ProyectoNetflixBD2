using System;
using System.Data;
using System.Windows.Forms;
using Netflix.Datos;

namespace ProyectoFinalCINEPOLIS
{
    public partial class FrmReportes : Form
    {
        private ReporteRepositorio repo = new ReporteRepositorio();

        public FrmReportes()
        {
            InitializeComponent();
        }

        // Consulta 1
        private void btnMasVistas_Click(object sender, EventArgs e)
        {
            lblDesc.Text = "Reporte: Película más vista (General)";
            gridDatos.DataSource = repo.ReportePeliculaMasVista();
        }

        // Consulta 2 (Por Edad)
        private void btnPorEdad_Click(object sender, EventArgs e)
        {
            lblDesc.Text = "Reporte: Película más vista por Edad";
            gridDatos.DataSource = repo.ReportePeliculaPorEdad();
        }

        // Consulta 3 (Género Favorito)
        private void btnGeneroFav_Click(object sender, EventArgs e)
        {
            lblDesc.Text = "Reporte: Género favorito por usuario";
            gridDatos.DataSource = repo.ReporteGeneroFavorito();
        }

        // Consulta 4 (Mejor Calificada)
        private void btnMejorCalif_Click(object sender, EventArgs e)
        {
            lblDesc.Text = "Reporte: Película mejor calificada";
            gridDatos.DataSource = repo.ReporteMejorCalificada();
        }

        // Consulta 5 (Promedios)
        private void btnPromedios_Click(object sender, EventArgs e)
        {
            lblDesc.Text = "Reporte: Calificaciones promedio de todo el catálogo";
            gridDatos.DataSource = repo.ReportePromedioGeneral();
        }

        // Consulta 6 (Contratos)
        private void btnContratos_Click(object sender, EventArgs e)
        {
            lblDesc.Text = "Reporte: Crecimiento de contratos por año";
            gridDatos.DataSource = repo.ReporteCuentasPorAno();
        }

        // Consulta 7 (Pelis por Género)
        private void btnGeneros_Click(object sender, EventArgs e)
        {
            lblDesc.Text = "Reporte: Cantidad de películas por género";
            gridDatos.DataSource = repo.ReporteCantidadPorGenero();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
