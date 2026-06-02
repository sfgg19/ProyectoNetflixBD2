using System;
using System.Drawing;
using System.Windows.Forms;
using Netflix.Datos;
using Netflix.Modelos;
using System.Collections.Generic;

namespace ProyectoFinalCINEPOLIS
{
    public class FrmRegistro : Form
    {
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtTarjeta;
        private ComboBox cmbPlanes;
        private TextBox txtNombrePerfil;
        private NumericUpDown nudEdad;
        private Button btnRegistrar;

        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Registro de Nueva Cuenta";
            this.Size = new Size(450, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(20, 20, 20);
            this.ForeColor = Color.White;

            Label lblTitulo = new Label() { Text = "Crear Cuenta", Font = new Font("Arial", 16, FontStyle.Bold), Bounds = new Rectangle(140, 20, 200, 30) };
            
            Label lblEmail = new Label() { Text = "Email:", Bounds = new Rectangle(50, 70, 100, 20) };
            txtEmail = new TextBox() { Bounds = new Rectangle(50, 90, 330, 20) };

            Label lblPass = new Label() { Text = "Contraseña:", Bounds = new Rectangle(50, 120, 100, 20) };
            txtPassword = new TextBox() { Bounds = new Rectangle(50, 140, 330, 20), UseSystemPasswordChar = true };

            Label lblTarjeta = new Label() { Text = "Tarjeta (16 dígitos):", Bounds = new Rectangle(50, 170, 150, 20) };
            txtTarjeta = new TextBox() { Bounds = new Rectangle(50, 190, 330, 20) };

            Label lblPlan = new Label() { Text = "Plan:", Bounds = new Rectangle(50, 220, 100, 20) };
            cmbPlanes = new ComboBox() { Bounds = new Rectangle(50, 240, 330, 20), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbPlanes.Items.AddRange(new string[] { "Básico (1 Pantalla)", "Estándar (2 Pantallas)", "Premium (4 Pantallas + 4K)" });
            cmbPlanes.SelectedIndex = 0;

            Label lblPerfil = new Label() { Text = "Nombre del Perfil Principal:", Bounds = new Rectangle(50, 280, 200, 20) };
            txtNombrePerfil = new TextBox() { Bounds = new Rectangle(50, 300, 330, 20) };

            Label lblEdad = new Label() { Text = "Edad:", Bounds = new Rectangle(50, 330, 100, 20) };
            nudEdad = new NumericUpDown() { Bounds = new Rectangle(50, 350, 100, 20), Minimum = 1, Maximum = 100, Value = 18 };

            btnRegistrar = new Button() { Text = "Registrar Cuenta", Bounds = new Rectangle(130, 420, 180, 35), BackColor = Color.Maroon, FlatStyle = FlatStyle.Flat };
            btnRegistrar.Click += BtnRegistrar_Click;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblTarjeta);
            this.Controls.Add(txtTarjeta);
            this.Controls.Add(lblPlan);
            this.Controls.Add(cmbPlanes);
            this.Controls.Add(lblPerfil);
            this.Controls.Add(txtNombrePerfil);
            this.Controls.Add(lblEdad);
            this.Controls.Add(nudEdad);
            this.Controls.Add(btnRegistrar);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string tarjeta = txtTarjeta.Text.Trim();
            string planSelect = cmbPlanes.SelectedItem.ToString();
            string nombre = txtNombrePerfil.Text.Trim();
            int edad = (int)nudEdad.Value;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(tarjeta) || string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Llena todos los campos.");
                return;
            }

            CuentaRepositorio repo = new CuentaRepositorio();
            if(repo.ObtenerCuentaPorEmail(email) != null)
            {
                MessageBox.Show("El correo ya está registrado.");
                return;
            }

            Cuenta nuevaCuenta = new Cuenta();
            nuevaCuenta.Email = email;
            nuevaCuenta.Password = pass;
            nuevaCuenta.TarjetaEnmascarada = "****-****-****-" + (tarjeta.Length >= 4 ? tarjeta.Substring(tarjeta.Length - 4) : "0000");
            
            Plan p = new Plan();
            if(planSelect.Contains("Premium")) { p.NombrePlan = "Premium"; p.MaxDispositivos = 4; }
            else if (planSelect.Contains("Estándar")) { p.NombrePlan = "Estándar"; p.MaxDispositivos = 2; }
            else { p.NombrePlan = "Básico"; p.MaxDispositivos = 1; }

            nuevaCuenta.Plan = p;
            nuevaCuenta.Perfiles = new List<Perfil>();
            nuevaCuenta.Perfiles.Add(new Perfil() { NombrePerfil = nombre, Edad = edad });
            
            nuevaCuenta.Pagos = new List<Pago>();
            nuevaCuenta.Pagos.Add(new Pago() { 
                IDPago = MongoDB.Bson.ObjectId.GenerateNewId().ToString(), 
                FechaPago = DateTime.Now, 
                Monto = 15.99m, 
                MetodoPago = "Tarjeta" 
            });

            repo.CrearCuenta(nuevaCuenta);

            MessageBox.Show("Cuenta registrada exitosamente. Ya puedes iniciar sesión.");
            this.Close();
        }
    }
}
