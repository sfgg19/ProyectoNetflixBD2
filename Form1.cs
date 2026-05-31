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

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, introduce tu email o número de teléfono.", "Netflix", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CuentaRepositorio repo = new CuentaRepositorio();
                Cuenta cuenta = repo.Login(email);

                if (cuenta != null)
                {
                    MessageBox.Show($"Bienvenido a Netflix. ID de Cuenta: {cuenta.IDCuenta}", "Sesión Iniciada");

                    // AQUÍ LUEGO ABRIREMOS LA SELECCIÓN DE PERFIL
                    // FrmSeleccionPerfil frm = new FrmSeleccionPerfil(cuenta.IDCuenta);
                    // frm.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("No podemos encontrar una cuenta con esta dirección de email.", "Netflix", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                if (cuenta != null)
                {
                    // PASAMOS EL ID DE LA CUENTA
                    FrmSeleccionPerfil formPerfil = new FrmSeleccionPerfil(cuenta.IDCuenta);
                    formPerfil.Show();
                    this.Hide();
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
