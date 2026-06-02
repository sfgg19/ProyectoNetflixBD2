using System;
using System.Drawing;
using System.Windows.Forms;
using Netflix.Datos;
using Netflix.Modelos;
using System.Collections.Generic;

namespace ProyectoFinalCINEPOLIS
{
    public class FrmAdminUsuarios : Form
    {
        private DataGridView dgv;
        private CuentaRepositorio repo = new CuentaRepositorio();

        public FrmAdminUsuarios()
        {
            this.Text = "Administración de Usuarios";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = new DataGridView() { Bounds = new Rectangle(20, 20, 540, 250), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoGenerateColumns = true };
            
            Button btnCrear = new Button() { Text = "Crear", Bounds = new Rectangle(20, 290, 100, 30) };
            btnCrear.Click += (s, e) => { new FrmRegistro().ShowDialog(); CargarDatos(); };

            Button btnEditar = new Button() { Text = "Editar", Bounds = new Rectangle(130, 290, 100, 30) };
            btnEditar.Click += BtnEditar_Click;

            Button btnBorrar = new Button() { Text = "Borrar", Bounds = new Rectangle(240, 290, 100, 30) };
            btnBorrar.Click += BtnBorrar_Click;

            this.Controls.Add(dgv);
            this.Controls.Add(btnCrear);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnBorrar);

            CargarDatos();
        }

        private void CargarDatos()
        {
            var cuentas = repo.ObtenerTodas();
            dgv.DataSource = null;
            dgv.DataSource = cuentas;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                var cuenta = (Cuenta)dgv.SelectedRows[0].DataBoundItem;
                new FrmMiCuenta(cuenta).ShowDialog();
                CargarDatos();
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedRows.Count > 0)
            {
                var cuenta = (Cuenta)dgv.SelectedRows[0].DataBoundItem;
                repo.BorrarCuenta(cuenta.IDCuenta);
                MessageBox.Show("Cuenta borrada.");
                CargarDatos();
            }
        }
    }
}
