using System;
using System.Drawing;
using System.Windows.Forms;
using Netflix.Datos;
using Netflix.Modelos;
using System.Collections.Generic;

namespace ProyectoFinalCINEPOLIS
{
    public class FrmEditarContenido : Form
    {
        private TextBox txtTitulo, txtResumen, txtDirector, txtAnio, txtDuracion, txtTipo;
        private Contenido contenidoActual;
        private ContenidoRepositorio repo = new ContenidoRepositorio();

        public FrmEditarContenido(Contenido cont)
        {
            contenidoActual = cont;
            this.Text = cont == null ? "Nuevo Contenido" : "Editar Contenido";
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            txtTitulo = CrearCampo("Título:", 20, 20);
            txtResumen = CrearCampo("Resumen:", 20, 70);
            txtDirector = CrearCampo("Director:", 20, 120);
            txtAnio = CrearCampo("Año:", 20, 170);
            txtDuracion = CrearCampo("Duración (min):", 20, 220);
            txtTipo = CrearCampo("Tipo (Pelicula/Serie):", 20, 270);

            if(cont != null)
            {
                txtTitulo.Text = cont.Titulo;
                txtResumen.Text = cont.Resumen;
                txtDirector.Text = cont.Director;
                txtAnio.Text = cont.Anio.ToString();
                txtDuracion.Text = cont.Duracion.ToString();
                txtTipo.Text = cont.TipoContenido;
            }

            Button btnGuardar = new Button() { Text = "Guardar", Bounds = new Rectangle(100, 350, 150, 35) };
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);
        }

        private TextBox CrearCampo(string labelTxt, int x, int y)
        {
            Label lbl = new Label() { Text = labelTxt, Bounds = new Rectangle(x, y, 150, 20) };
            TextBox txt = new TextBox() { Bounds = new Rectangle(x, y + 20, 300, 20) };
            this.Controls.Add(lbl);
            this.Controls.Add(txt);
            return txt;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool esNuevo = contenidoActual == null;
            if (esNuevo) contenidoActual = new Contenido();

            contenidoActual.Titulo = txtTitulo.Text;
            contenidoActual.Resumen = txtResumen.Text;
            contenidoActual.Director = txtDirector.Text;
            contenidoActual.TipoContenido = txtTipo.Text;
            int.TryParse(txtAnio.Text, out int anio);
            int.TryParse(txtDuracion.Text, out int dur);
            contenidoActual.Anio = anio;
            contenidoActual.Duracion = dur;

            if (contenidoActual.Generos == null) contenidoActual.Generos = new List<string> { "Drama" };
            if (contenidoActual.ClasificacionEdad == null) contenidoActual.ClasificacionEdad = new Netflix.Modelos.ClasificacionEdad { NombreClasificacion = "PG-13" };

            if (esNuevo) repo.Crear(contenidoActual);
            else repo.Actualizar(contenidoActual);

            MessageBox.Show("Guardado exitosamente.");
            this.Close();
        }
    }
}
