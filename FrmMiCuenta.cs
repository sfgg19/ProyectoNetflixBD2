using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

            // 2. Configurar el ComboBox de Planes
            List<ItemPlan> planes = new List<ItemPlan>
            {
                new ItemPlan { Nombre = "Básico (1 Pantalla)", ID = "Básico (1 Pantalla)" },
                new ItemPlan { Nombre = "Estándar (2 Pantallas)", ID = "Estándar (2 Pantallas)" },
                new ItemPlan { Nombre = "Premium (4 Pantallas + 4K)", ID = "Premium (4 Pantallas + 4K)" }
            };

            cmbPlanes.DataSource = planes;
            cmbPlanes.DisplayMember = "Nombre";
            cmbPlanes.ValueMember = "ID";

            // Seleccionar el plan que el usuario ya tiene
            cmbPlanes.SelectedValue = cuentaActual.Plan.NombrePlan ?? "Básico (1 Pantalla)";

            // 3. Cargar historial de pagos
            CargarPagos();
        }

        private void CargarPagos()
        {
            List<Pago> pagos = repoPagos.ObtenerPagos(cuentaActual.IDCuenta);
            gridPagos.DataSource = pagos;

            // Ocultar IDs feos
            if (gridPagos.Columns["IDPago"] != null) gridPagos.Columns["IDPago"].Visible = false;
            if (gridPagos.Columns["IDCuenta"] != null) gridPagos.Columns["IDCuenta"].Visible = false;
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
