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

                // 3. Botón Añadir Perfil
                if(listaPerfiles.Count < 5)
                {
                    Button btnAdd = new Button();
                    btnAdd.Text = "+ Añadir Perfil";
                    btnAdd.Size = new Size(150, 150);
                    btnAdd.BackColor = Color.Maroon;
                    btnAdd.ForeColor = Color.White;
                    btnAdd.FlatStyle = FlatStyle.Flat;
                    btnAdd.Font = new Font("Arial", 12, FontStyle.Bold);
                    btnAdd.Margin = new Padding(20);
                    btnAdd.Click += BtnAdd_Click;
                    flowLayoutPanel1.Controls.Add(btnAdd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar perfiles: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new Form() { Size = new Size(300, 200), Text = "Nuevo Perfil", StartPosition = FormStartPosition.CenterParent };
            
            Label lblNom = new Label() { Text = "Nombre:", Bounds = new Rectangle(20,20, 100, 20) };
            TextBox txtNom = new TextBox() { Bounds = new Rectangle(20,40, 240, 20) };

            Label lblEdad = new Label() { Text = "Edad:", Bounds = new Rectangle(20,70, 100, 20) };
            NumericUpDown nudEdad = new NumericUpDown() { Bounds = new Rectangle(20,90, 100, 20), Minimum = 1, Maximum = 100, Value = 18 };

            Button btnGuardar = new Button() { Text = "Guardar", Bounds = new Rectangle(100, 120, 100, 30), BackColor = Color.Maroon, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += (s, ev) => {
                if(string.IsNullOrEmpty(txtNom.Text)) return;
                
                Perfil nuevo = new Perfil();
                nuevo.IDCuenta = idCuentaActual;
                nuevo.NombrePerfil = txtNom.Text;
                nuevo.Edad = (int)nudEdad.Value;

                // Generar un ID de perfil
                nuevo.IDPerfil = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

                PerfilRepositorio repo = new PerfilRepositorio();
                repo.CrearPerfil(nuevo);

                frm.Close();
                CargarPerfiles(); // Recargar grilla
            };

            frm.Controls.Add(lblNom);
            frm.Controls.Add(txtNom);
            frm.Controls.Add(lblEdad);
            frm.Controls.Add(nudEdad);
            frm.Controls.Add(btnGuardar);
            frm.ShowDialog();
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
