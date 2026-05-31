using System;
using System.Windows.Forms;
using Netflix.Datos;
using Netflix.Modelos;

namespace ProyectoFinalCINEPOLIS
{
    public partial class FrmReproductor : Form
    {
        private Contenido contenidoPelicula;
        private Episodio episodioSerie;
        private Perfil perfilActual;
        private int progresoActual = 0; // 0 a 100
        private HistorialRepositorio repoHistorial = new HistorialRepositorio();

        // CONSTRUCTOR 1: Para Películas
        public FrmReproductor(Contenido contenido, Perfil perfil)
        {
            InitializeComponent();
            this.contenidoPelicula = contenido;
            this.perfilActual = perfil;
            lblTitulo.Text = "Reproduciendo: " + contenido.Titulo;
        }

        // CONSTRUCTOR 2: Para Episodios de Serie
        public FrmReproductor(Episodio episodio, Perfil perfil)
        {
            InitializeComponent();
            this.episodioSerie = episodio;
            this.perfilActual = perfil;
            lblTitulo.Text = "Viendo: " + episodio.TituloEpisodio;
        }

        private void FrmReproductor_Load(object sender, EventArgs e)
        {
            timerSimulacion.Start(); // Iniciar simulación
        }

        // Simulación: La barra avanza cada segundo
        private void timerSimulacion_Tick(object sender, EventArgs e)
        {
            progresoActual += 5; // Avanza rápido para probar (5% por segundo)

            if (progresoActual > 100) progresoActual = 100;

            barraProgreso.Value = progresoActual;
            lblEstado.Text = $"Reproduciendo... {progresoActual}%";

            if (progresoActual == 100)
            {
                timerSimulacion.Stop();
                lblEstado.Text = "Fin de la reproducción.";
                MessageBox.Show("Fin del contenido.");
                this.Close(); // Cerrar automático al terminar
            }
        }

        // Botón X para salir manualmente
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // EVENTO IMPORTANTE: Al cerrar la ventana (por X o por fin) guardamos en BD
        private void FrmReproductor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Historial h = new Historial();
                h.IDPerfil = perfilActual.IDPerfil;
                h.Progreso = progresoActual;
                h.FechaVisualizacion = DateTime.Now;

                // Definir si guardamos IDContenido (Peli) o IDEpisodio (Serie)
                if (contenidoPelicula != null)
                {
                    h.IDContenido = contenidoPelicula.IDContenido;
                    h.IDEpisodio = null;
                }
                else if (episodioSerie != null)
                {
                    h.IDContenido = null; // En tu BD, si es episodio, contenido debe ser NULL
                    h.IDEpisodio = episodioSerie.IDEpisodio;
                }

                repoHistorial.RegistrarVisualizacion(h);
                // MessageBox.Show("Progreso guardado correctamente."); // Opcional
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar historial: " + ex.Message);
            }
        }
    }
}
