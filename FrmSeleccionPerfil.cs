using Netflix.Datos;
using Netflix.Modelos;
using ProyectoFinalCINEPOLIS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Netflix
{
    public partial class FrmSeleccionPerfil : Form
    {
        // Variable para guardar quién es el dueño de la cuenta
        private string idCuentaActual;

        // CONSTRUCTOR ESPECIAL: Exige que le pasen el IDCuenta al abrirse
        public FrmSeleccionPerfil(string idCuentaRecibido)
        {
            InitializeComponent();
            this.idCuentaActual = idCuentaRecibido;
        }

        private void FrmSeleccionPerfil_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
        }

        private void CargarPerfiles()
        {
            try
            {
                // 1. Buscamos los perfiles en la BD
                PerfilRepositorio repo = new PerfilRepositorio();
                List<Perfil> listaPerfiles = repo.ObtenerPerfiles(idCuentaActual);

                // Limpiamos el panel por si acaso
                flowLayoutPanel1.Controls.Clear();

                // 2. Por cada perfil, creamos un botón "Mágico"
                foreach (Perfil perfil in listaPerfiles)
                {
                    Button btnPerfil = new Button();

                    // --- ESTILO VISUAL DEL BOTÓN ---
                    btnPerfil.Text = perfil.NombrePerfil;
                    btnPerfil.Size = new Size(150, 150); // Cuadrado de 150x150
                    btnPerfil.BackColor = Color.FromArgb(64, 64, 64); // Gris oscuro
                    btnPerfil.ForeColor = Color.White; // Letra blanca
                    btnPerfil.FlatStyle = FlatStyle.Flat;
                    btnPerfil.Font = new Font("Arial", 14, FontStyle.Bold);
                    btnPerfil.Margin = new Padding(20); // Espacio entre botones

                    // --- TRUCO IMPORTANTE ---
                    // Guardamos el objeto 'perfil' entero DENTRO del botón.
                    // Así, cuando le den click, sabremos ID, Nombre y Edad.
                    btnPerfil.Tag = perfil;

                    // Asignamos el evento Click
                    btnPerfil.Click += BtnPerfil_Click;

                    // Lo agregamos al panel
                    flowLayoutPanel1.Controls.Add(btnPerfil);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar perfiles: " + ex.Message);
            }
        }

        // Este evento se ejecuta al dar click en CUALQUIERA de los botones creados
        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Perfil perfil = (Perfil)btn.Tag;

            FrmPrincipal principal = new FrmPrincipal(perfil);
            principal.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
