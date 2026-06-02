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

            // Crear botón Ver Reseñas dinámicamente
            Button btnVerResenas = new Button();
            btnVerResenas.Text = "Ver Reseñas";
            btnVerResenas.Bounds = new Rectangle(btnCalificar.Location.X + 150, btnCalificar.Location.Y, 120, btnCalificar.Height);
            btnVerResenas.BackColor = Color.Gray;
            btnVerResenas.ForeColor = Color.White;
            btnVerResenas.FlatStyle = FlatStyle.Flat;
            btnVerResenas.Click += (s, ev) => { new FrmResenas(contenidoActual.IDContenido, perfilActual).ShowDialog(); };
            btnCalificar.Parent.Controls.Add(btnVerResenas);
        }

        // --- LÓGICA DE SERIE ---

        public class EpisodioGridItem
        {
            public int Temp { get; set; }
            public int No { get; set; }
            public string Titulo { get; set; }
            public int Duracion { get; set; }
            [Browsable(false)]
            public Episodio ObjetoOriginal { get; set; }
        }

        private void CargarTemporadas()
        {
            string idSerie = repoSerie.ObtenerIdSerie(contenidoActual.IDContenido);

            if (!string.IsNullOrEmpty(idSerie))
            {
                List<Temporada> temporadas = repoSerie.ObtenerTemporadas(idSerie);

                // Ocultar ComboBox de temporadas
                cmbTemporadas.Visible = false;
                Label lblTemp = (Label)pnlSeries.Controls.Cast<Control>().FirstOrDefault(c => c.Text == "Temporada:");
                if(lblTemp != null) lblTemp.Visible = false;

                List<EpisodioGridItem> listaPlana = new List<EpisodioGridItem>();

                foreach (var temp in temporadas)
                {
                    List<Episodio> episodios = repoSerie.ObtenerEpisodios(contenidoActual.IDContenido, temp.IDTemporada);
                    foreach(var epi in episodios)
                    {
                        listaPlana.Add(new EpisodioGridItem {
                            Temp = temp.NumeroTemporada,
                            No = epi.NumeroEpisodio,
                            Titulo = epi.TituloEpisodio,
                            Duracion = epi.Duracion,
                            ObjetoOriginal = epi
                        });
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaPlana;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void cmbTemporadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ya no se usa
        }

        private void CargarEpisodios(string idTemporada)
        {
            // Ya no se usa individualmente
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
                    // Recuperar el objeto de la fila seleccionada
                    EpisodioGridItem item = (EpisodioGridItem)dataGridView1.CurrentRow.DataBoundItem;

                    FrmReproductor player = new FrmReproductor(item.ObjetoOriginal, perfilActual);
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
