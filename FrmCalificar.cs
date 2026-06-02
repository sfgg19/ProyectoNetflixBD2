using System;
using System.Windows.Forms;
using Netflix.Datos;
using Netflix.Modelos;

namespace ProyectoFinalCINEPOLIS
{
    public partial class FrmCalificar : Form
    {
        private string idContenido;
        private string idPerfil;
        private CalificacionRepositorio repo = new CalificacionRepositorio();
        private Calificacion calificacionExistente;

        // Constructor que recibe QUÉ y QUIÉN califica
        public FrmCalificar(string idContenido, string idPerfil)
        {
            InitializeComponent();
            this.idContenido = idContenido;
            this.idPerfil = idPerfil;
        }

        public FrmCalificar(Calificacion calif)
        {
            InitializeComponent();
            this.calificacionExistente = calif;
            this.idContenido = calif.IDContenido;
            this.idPerfil = calif.IDPerfil;
            
            this.Load += (s, e) => {
                nudEstrellas.Value = calif.Estrellas;
                txtComentario.Text = calif.Comentario;
            };
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (calificacionExistente == null)
                {
                    Calificacion nuevaCalif = new Calificacion();
                    nuevaCalif.IDContenido = this.idContenido;
                    nuevaCalif.IDPerfil = this.idPerfil;
                    nuevaCalif.Estrellas = (int)nudEstrellas.Value;
                    nuevaCalif.Comentario = txtComentario.Text;
                    nuevaCalif.FechaCalificacion = DateTime.Now;

                    repo.Guardar(nuevaCalif);
                    MessageBox.Show("¡Gracias por tu calificación!");
                }
                else
                {
                    calificacionExistente.Estrellas = (int)nudEstrellas.Value;
                    calificacionExistente.Comentario = txtComentario.Text;
                    repo.Actualizar(calificacionExistente);
                    MessageBox.Show("Calificación actualizada.");
                }

                this.Close(); // Cerrar la ventanita
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
    }
}
