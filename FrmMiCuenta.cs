using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Netflix.Datos;
using Netflix.Modelos;

namespace ProyectoFinalCINEPOLIS
{
    public partial class FrmMiCuenta : Form
    {
        // Necesitamos el objeto Cuenta entero para saber ID y Email
        private Cuenta cuentaActual;
        private PagoRepositorio repoPagos = new PagoRepositorio();
        private CuentaRepositorio repoCuenta = new CuentaRepositorio();

        // Creamos una clasecita interna solo para llenar el ComboBox bonito
        public class ItemPlan { public string Nombre { get; set; } public string ID { get; set; } }

        public FrmMiCuenta(Cuenta cuenta)
        {
            InitializeComponent();
            this.cuentaActual = cuenta;
        }

        private void FrmMiCuenta_Load(object sender, EventArgs e)
        {
            // 1. Mostrar datos básicos
            lblEmail.Text = "Email: " + cuentaActual.Email;
            lblTarjeta.Text = "Método de Pago: " + cuentaActual.TarjetaEnmascarada;
            
            string passOculta = new string('*', cuentaActual.Password?.Length ?? 8);
            Label lblPass = new Label() { Text = "Contraseña: " + passOculta, Bounds = new Rectangle(30, 140, 300, 20), ForeColor = Color.White, Font = new Font("Arial", 9, FontStyle.Bold) };
            this.Controls.Add(lblPass);

            // 2. Mover panel de plan más abajo
            grpPlan.Location = new Point(30, 170);

            // 3. Configurar el ComboBox de Planes
            List<ItemPlan> planes = new List<ItemPlan>
            {
                new ItemPlan { Nombre = "Básico (1 Pantalla)", ID = "Básico (1 Pantalla)" },
                new ItemPlan { Nombre = "Estándar (2 Pantallas)", ID = "Estándar (2 Pantallas)" },
                new ItemPlan { Nombre = "Premium (4 Pantallas + 4K)", ID = "Premium (4 Pantallas + 4K)" }
            };

            cmbPlanes.DataSource = planes;
            cmbPlanes.DisplayMember = "Nombre";
            cmbPlanes.ValueMember = "ID";
            cmbPlanes.SelectedValue = cuentaActual.Plan.NombrePlan ?? "Básico (1 Pantalla)";

            // 4. Cargar historial de pagos
            CargarPagos();

            // 5. Botón para Editar Todos los Datos
            Button btnEditarDatos = new Button();
            btnEditarDatos.Text = "Editar Datos";
            btnEditarDatos.Bounds = new Rectangle(30, 280, 120, 30);
            btnEditarDatos.BackColor = Color.Gray;
            btnEditarDatos.ForeColor = Color.White;
            btnEditarDatos.FlatStyle = FlatStyle.Flat;
            btnEditarDatos.Click += (s, ev) => {
                Form frm = new Form() { Size = new System.Drawing.Size(350,250), Text = "Editar Datos de la Cuenta", StartPosition = FormStartPosition.CenterParent };
                
                TextBox txtEmail = new TextBox() { Bounds = new System.Drawing.Rectangle(20,20, 280,20), Text = cuentaActual.Email };
                TextBox txtPass = new TextBox() { Bounds = new System.Drawing.Rectangle(20,60, 280,20), Text = cuentaActual.Password };
                TextBox txtTarj = new TextBox() { Bounds = new System.Drawing.Rectangle(20,100, 280,20), Text = cuentaActual.TarjetaEnmascarada };
                
                Button btnSave = new Button() { Text = "Guardar", Bounds = new System.Drawing.Rectangle(100,150, 100,30), BackColor = Color.Maroon, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnSave.Click += (ss, ee) => { 
                    cuentaActual.Email = txtEmail.Text; 
                    cuentaActual.Password = txtPass.Text;
                    cuentaActual.TarjetaEnmascarada = txtTarj.Text;
                    repoCuenta.ActualizarCuenta(cuentaActual); 
                    
                    lblEmail.Text = "Email: " + cuentaActual.Email; 
                    lblPass.Text = "Contraseña: " + new string('*', cuentaActual.Password?.Length ?? 8);
                    lblTarjeta.Text = "Método de Pago: " + cuentaActual.TarjetaEnmascarada;
                    
                    frm.Close(); 
                };
                frm.Controls.Add(new Label() { Text="Email:", Bounds = new System.Drawing.Rectangle(20,0,100,20) });
                frm.Controls.Add(txtEmail);
                frm.Controls.Add(new Label() { Text="Contraseña:", Bounds = new System.Drawing.Rectangle(20,40,100,20) });
                frm.Controls.Add(txtPass);
                frm.Controls.Add(new Label() { Text="Tarjeta:", Bounds = new System.Drawing.Rectangle(20,80,100,20) });
                frm.Controls.Add(txtTarj);
                frm.Controls.Add(btnSave);
                frm.ShowDialog();
            };
            this.Controls.Add(btnEditarDatos);

            // 6. Botón Eliminar Cuenta
            Button btnEliminar = new Button();
            btnEliminar.Text = "Eliminar Cuenta";
            btnEliminar.Bounds = new Rectangle(160, 280, 120, 30);
            btnEliminar.BackColor = Color.Red;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Click += (s, ev) => {
                var confirm = MessageBox.Show("¿Estás seguro de que quieres eliminar tu cuenta permanentemente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    repoCuenta.BorrarCuenta(cuentaActual.IDCuenta);
                    MessageBox.Show("Cuenta eliminada con éxito.");
                    Application.Restart(); // Vuelve al inicio
                }
            };
            this.Controls.Add(btnEliminar);
        }

        private void CargarPagos()
        {
            List<Pago> pagos = repoPagos.ObtenerPagos(cuentaActual.IDCuenta);
            gridPagos.DataSource = null; // reset
            gridPagos.DataSource = pagos;

            // Ocultar IDs feos de manera segura
            if (gridPagos.Columns.Contains("IDPago")) gridPagos.Columns["IDPago"].Visible = false;
            if (gridPagos.Columns.Contains("IDCuenta")) gridPagos.Columns["IDCuenta"].Visible = false;

            // Ajustar grid visual
            gridPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPagos.BackgroundColor = Color.FromArgb(40, 40, 40);
            gridPagos.ForeColor = Color.Black;
        }

        private void btnCambiarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener ID del plan seleccionado
                string idNuevoPlan = cmbPlanes.SelectedValue.ToString();

                if (cuentaActual.Plan != null && idNuevoPlan == cuentaActual.Plan.NombrePlan)
                {
                    MessageBox.Show("Ya tienes este plan activo.");
                    return;
                }

                // Guardar en BD
                repoCuenta.ActualizarPlan(cuentaActual.IDCuenta, idNuevoPlan);

                // Actualizar objeto local
                if(cuentaActual.Plan == null) cuentaActual.Plan = new Plan();
                cuentaActual.Plan.NombrePlan = idNuevoPlan;

                MessageBox.Show("¡Plan actualizado correctamente! Se aplicará en tu próxima factura.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar plan: " + ex.Message);
            }
        }
    }
}
