using Netflix;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private TextBox txtPassword;

        private void Form1_Load(object sender, EventArgs e)
        {
            Label lblPass = new Label();
            lblPass.Text = "Contraseña:";
            lblPass.Bounds = new Rectangle(textBox1.Location.X, textBox1.Location.Y + 35, 100, 20);
            lblPass.ForeColor = Color.White;
            lblPass.BackColor = Color.Transparent;
            textBox1.Parent.Controls.Add(lblPass);

            txtPassword = new TextBox();
            txtPassword.Bounds = new Rectangle(textBox1.Location.X, textBox1.Location.Y + 55, textBox1.Width, 20);
            txtPassword.UseSystemPasswordChar = true;
            textBox1.Parent.Controls.Add(txtPassword);

            // Mover el botón Iniciar Sesión más abajo
            button1.Location = new Point(button1.Location.X, txtPassword.Location.Y + 40);

            // Centrar los dos botones (Registrarse y Admin)
            int totalWidth = 210;
            int startX = (textBox1.Parent.Width - totalWidth) / 2;

            Button btnRegistrar = new Button();
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.Bounds = new Rectangle(startX, button1.Location.Y + 50, 100, 30);
            btnRegistrar.BackColor = Color.Gray;
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Click += (s, ev) => { new FrmRegistro().ShowDialog(); };
            textBox1.Parent.Controls.Add(btnRegistrar);

            Button btnAdmin = new Button();
            btnAdmin.Text = "Admin";
            btnAdmin.Bounds = new Rectangle(startX + 110, button1.Location.Y + 50, 100, 30);
            btnAdmin.BackColor = Color.DarkRed;
            btnAdmin.ForeColor = Color.White;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Click += (s, ev) => 
            { 
                if (textBox1.Text.Trim() == "admin@cinepolis.com" && txtPassword.Text.Trim() == "admin123")
                {
                    new FrmAdmin().ShowDialog(); 
                }
                else
                {
                    MessageBox.Show("Acceso no autorizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            textBox1.Parent.Controls.Add(btnAdmin);

            // Expandir el contenedor negro si es necesario para que todo quepa
            textBox1.Parent.Height = btnAdmin.Location.Y + 60;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, introduce tu email y contraseña.", "Netflix", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CuentaRepositorio repo = new CuentaRepositorio();
                Cuenta cuenta = repo.Login(email, pass);

                if (cuenta != null)
                {
                    MessageBox.Show($"Bienvenido a Netflix. ID de Cuenta: {cuenta.IDCuenta}", "Sesión Iniciada");
                    FrmSeleccionPerfil formPerfil = new FrmSeleccionPerfil(cuenta.IDCuenta);
                    formPerfil.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas o la cuenta no existe.", "Netflix", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
