using System;
using System.Drawing;
using System.Windows.Forms;
using Netflix.Datos;
using Netflix.Modelos;

namespace ProyectoFinalCINEPOLIS
{
    public class FrmResenas : Form
    {
        private DataGridView dgv;
        private CalificacionRepositorio repo = new CalificacionRepositorio();
        private string idContenido;
        private Perfil perfilActual;

        public FrmResenas(string idContenido, Perfil perfil)
        {
            this.idContenido = idContenido;
            this.perfilActual = perfil;

            this.Text = "Reseñas de la Película";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = new DataGridView() { Bounds = new Rectangle(20, 20, 540, 250), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoGenerateColumns = true };
            
            Button btnEditar = new Button() { Text = "Editar Mi Reseña", Bounds = new Rectangle(20, 290, 150, 30) };
            btnEditar.Click += BtnEditar_Click;

            Button btnBorrar = new Button() { Text = "Borrar Mi Reseña", Bounds = new Rectangle(190, 290, 150, 30) };
            btnBorrar.Click += BtnBorrar_Click;

            this.Controls.Add(dgv);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnBorrar);

            CargarDatos();
        }

        private void CargarDatos()
        {
            dgv.DataSource = null;
            dgv.DataSource = repo.ObtenerPorContenido(idContenido);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                var calif = (Calificacion)dgv.SelectedRows[0].DataBoundItem;
                if(calif.IDPerfil == perfilActual.IDPerfil)
                {
                    new FrmCalificar(calif).ShowDialog();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Solo puedes editar tus propias reseñas.");
                }
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                var calif = (Calificacion)dgv.SelectedRows[0].DataBoundItem;
                if(calif.IDPerfil == perfilActual.IDPerfil)
                {
                    repo.Borrar(calif.IDCalificacion);
                    MessageBox.Show("Reseña borrada.");
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Solo puedes borrar tus propias reseñas.");
                }
            }
        }
    }
}
