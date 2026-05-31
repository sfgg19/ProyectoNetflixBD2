using Netflix.Datos;
using Netflix.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalCINEPOLIS
{
    public partial class FrmDetalleContenido : Form
    {
        private Contenido contenidoActual;
        private Perfil perfilActual;
        private SerieRepositorio repoSerie = new SerieRepositorio();

        public FrmDetalleContenido(Contenido contenido, Perfil perfil)
        {
            InitializeComponent();
            this.contenidoActual = contenido;
            this.perfilActual = perfil;
        }

        private void FrmDetalleContenido_Load(object sender, EventArgs e)
        {
            // 1. Cargar datos generales
            lblTitulo.Text = contenidoActual.Titulo;
            lblSinopsis.Text = contenidoActual.Resumen;
            lblInfo.Text = $"{contenidoActual.Anio} | {contenidoActual.Director} | Tipo: {contenidoActual.TipoContenido}";

            // 2. Lógica Serie vs Película
            if (contenidoActual.TipoContenido == "Serie")
            {
                pnlSeries.Visible = true;
                CargarTemporadas();
                // Conectar el evento al ComboBox (lo hacemos por código para asegurar)
                cmbTemporadas.SelectedIndexChanged += cmbTemporadas_SelectedIndexChanged;
            }
            else // Película o Documental
            {
                pnlSeries.Visible = false;
                btnReproducir.Text = $"▶ REPRODUCIR ({contenidoActual.Duracion} min)";
            }
        }

        // --- LÓGICA DE SERIE ---

        private void CargarTemporadas()
        {
            string idSerie = repoSerie.ObtenerIdSerie(contenidoActual.IDContenido);

            if (!string.IsNullOrEmpty(idSerie))
            {
                List<Temporada> temporadas = repoSerie.ObtenerTemporadas(idSerie);

                cmbTemporadas.DataSource = temporadas;
                cmbTemporadas.DisplayMember = "ToString"; // Usará el override en Temporada.cs
                cmbTemporadas.ValueMember = "IDTemporada";

                // Seleccionar la primera temporada y forzar la carga de episodios
                if (temporadas.Count > 0)
                {
                    cmbTemporadas.SelectedIndex = 0;
                }
            }
        }

        private void cmbTemporadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTemporadas.SelectedItem is Temporada tempSeleccionada)
            {
                CargarEpisodios(tempSeleccionada.IDTemporada);
            }
        }

        private void CargarEpisodios(string idTemporada)
        {
            List<Episodio> episodios = repoSerie.ObtenerEpisodios(contenidoActual.IDContenido, idTemporada);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = episodios;

            // Ajustar la visibilidad de las columnas
            if (dataGridView1.Columns.Contains("IDEpisodio")) dataGridView1.Columns["IDEpisodio"].Visible = false;
            if (dataGridView1.Columns.Contains("IDTemporada")) dataGridView1.Columns["IDTemporada"].Visible = false;

            // Opcional: renombrar columnas
            if (dataGridView1.Columns.Contains("NumeroEpisodio")) dataGridView1.Columns["NumeroEpisodio"].HeaderText = "No.";
            if (dataGridView1.Columns.Contains("TituloEpisodio")) dataGridView1.Columns["TituloEpisodio"].HeaderText = "Título del Episodio";
        }

        // --- EVENTO DE REPRODUCCIÓN ---
        private void btnReproducir_Click(object sender, EventArgs e)
        {
            // CASO 1: Es una SERIE (Panel de series visible)
            if (contenidoActual.TipoContenido == "Serie")
            {
                // Verificar si seleccionó un episodio de la tabla
                if (dataGridView1.CurrentRow != null)
                {
                    // Recuperar el objeto Episodio de la fila seleccionada
                    Episodio epi = (Episodio)dataGridView1.CurrentRow.DataBoundItem;

                    FrmReproductor player = new FrmReproductor(epi, perfilActual);
                    player.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecciona un episodio de la lista primero.");
                }
            }
            // CASO 2: Es una PELÍCULA
            else
            {
                FrmReproductor player = new FrmReproductor(contenidoActual, perfilActual);
                player.ShowDialog();
            }
        }

        // Agrega esto para calmar al diseñador
        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            // No hace nada, solo existe para que no de error
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            FrmCalificar frm = new FrmCalificar(contenidoActual.IDContenido, perfilActual.IDPerfil);
            frm.ShowDialog();
        }
    }
}
