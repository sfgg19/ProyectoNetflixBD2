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
    public partial class FrmPrincipal : Form
    {
        private Perfil perfilActual;
        private ContenidoRepositorio repo = new ContenidoRepositorio();

        // Constructor que recibe el perfil desde la ventana anterior
        public FrmPrincipal(Perfil perfil)
        {
            InitializeComponent();
            this.perfilActual = perfil;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (perfilActual != null)
                lblUsuario.Text = "👤 " + perfilActual.NombrePerfil;

            // Botón Cerrar Sesión
            Button btnCerrarSesion = new Button();
            btnCerrarSesion.Text = "CERRAR SESIÓN";
            btnCerrarSesion.Bounds = new Rectangle(510, 19, 115, 23);
            btnCerrarSesion.BackColor = Color.Gray;
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold);
            btnCerrarSesion.Click += (s, ev) => {
                Application.Restart();
            };
            pnlSuperior.Controls.Add(btnCerrarSesion);

            // Cargamos las listas al iniciar
            CargarInicio();
        }

        private void CargarInicio()
        {
            pnlContenedor.Controls.Clear();

            // 1. FILA DE ESTRENOS (Top 10 más nuevos)
            List<Contenido> estrenos = repo.ObtenerEstrenos();
            CrearSeccionHorizontal("🔥 Nuevos Lanzamientos", estrenos);

            // 2. FILA DE TODO EL CATÁLOGO
            List<Contenido> todo = repo.ObtenerTodo();
            CrearSeccionHorizontal("📺 Catálogo Completo", todo);
        }

        // --- MÉTODO MAESTRO PARA CREAR FILAS ---
        private void CrearSeccionHorizontal(string tituloSeccion, List<Contenido> listaContenidos)
        {
            // A. TÍTULO DE LA SECCIÓN
            Label lbl = new Label();
            lbl.Text = tituloSeccion;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Arial", 14, FontStyle.Bold);
            lbl.AutoSize = true;
            // IMPORTANTE: Usamos Margin para separar, no coordenadas X,Y
            lbl.Margin = new Padding(20, 20, 0, 5);

            pnlContenedor.Controls.Add(lbl);

            // B. EL CARRUSEL HORIZONTAL
            FlowLayoutPanel panelFila = new FlowLayoutPanel();
            panelFila.FlowDirection = FlowDirection.LeftToRight; // Pone las pelis de lado
            panelFila.WrapContents = false; // No salta de línea
            panelFila.AutoScroll = true;    // Permite scroll horizontal
            panelFila.BackColor = Color.Transparent;

            // Ancho dinámico: El ancho del contenedor padre menos 40px de margen
            panelFila.Width = pnlContenedor.Width - 40;
            panelFila.Height = 220; // Altura suficiente para el botón

            // C. LOS BOTONES (PÓSTERS)
            foreach (Contenido c in listaContenidos)
            {
                Button btn = new Button();
                // Mostramos Título y Año
                btn.Text = c.Titulo + "\n(" + c.Anio + ")";
                btn.Size = new Size(130, 180); // Tamaño del póster
                btn.FlatStyle = FlatStyle.Flat;
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.Font = new Font("Arial", 9, FontStyle.Bold);
                btn.Margin = new Padding(5); // Separación entre pósters

                // Color rojo para Series, Gris para Pelis (Estilo visual)
                if (c.TipoContenido == "Serie")
                    btn.BackColor = Color.Maroon;
                else
                    btn.BackColor = Color.FromArgb(64, 64, 64);

                // Guardamos el objeto Contenido en el botón (Tag) para saber cuál es
                btn.Tag = c;
                btn.Click += BtnContenido_Click;

                panelFila.Controls.Add(btn);
            }

            pnlContenedor.Controls.Add(panelFila);
        }

        // Evento Click en una película
        private void BtnContenido_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Contenido c = (Contenido)btn.Tag;

            // Abrimos el detalle pasando el contenido y el perfil
            FrmDetalleContenido detalle = new FrmDetalleContenido(c, perfilActual);
            detalle.ShowDialog();
        }

        // Evento Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                pnlContenedor.Controls.Clear();
                List<Contenido> resultados = repo.Buscar(texto);
                CrearSeccionHorizontal("🔎 Resultados para: " + texto, resultados);
            }
            else
            {
                CargarInicio(); // Si está vacío, recargamos el inicio
            }
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el repositorio
            CuentaRepositorio repo = new CuentaRepositorio();

            // 2. Buscamos la cuenta completa usando el ID del perfil actual
            // (Asumimos que ya creaste el método ObtenerCuentaPorID en el repositorio)
            Cuenta cuentaRecuperada = repo.ObtenerCuentaPorID(perfilActual.IDCuenta);

            if (cuentaRecuperada != null)
            {
                // 3. Abrimos el formulario de Mi Cuenta
                FrmMiCuenta frm = new FrmMiCuenta(cuentaRecuperada);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: No se pudo recuperar la información de la cuenta.");
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.ShowDialog();
        }
    }
}
