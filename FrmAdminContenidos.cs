using System;
using System.Drawing;
using System.Windows.Forms;
using Netflix.Datos;
using Netflix.Modelos;

namespace ProyectoFinalCINEPOLIS
{
    public class FrmAdminContenidos : Form
    {
        private DataGridView dgv;
        private ContenidoRepositorio repo = new ContenidoRepositorio();

        public FrmAdminContenidos()
        {
            this.Text = "Administración de Películas/Series";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = new DataGridView() { Bounds = new Rectangle(20, 20, 740, 350), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            
            Button btnCrear = new Button() { Text = "Crear", Bounds = new Rectangle(20, 390, 100, 30) };
            btnCrear.Click += (s, e) => { new FrmEditarContenido(null).ShowDialog(); CargarDatos(); };

            Button btnEditar = new Button() { Text = "Editar", Bounds = new Rectangle(130, 390, 100, 30) };
            btnEditar.Click += BtnEditar_Click;

            Button btnBorrar = new Button() { Text = "Borrar", Bounds = new Rectangle(240, 390, 100, 30) };
            btnBorrar.Click += BtnBorrar_Click;

            this.Controls.Add(dgv);
            this.Controls.Add(btnCrear);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnBorrar);

            CargarDatos();
        }

        private void CargarDatos()
        {
            dgv.DataSource = null;
            dgv.DataSource = repo.ObtenerTodo();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                var cont = (Contenido)dgv.SelectedRows[0].DataBoundItem;
                new FrmEditarContenido(cont).ShowDialog();
                CargarDatos();
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                var cont = (Contenido)dgv.SelectedRows[0].DataBoundItem;
                repo.Borrar(cont.IDContenido);
                MessageBox.Show("Contenido borrado.");
                CargarDatos();
            }
        }
    }
}
