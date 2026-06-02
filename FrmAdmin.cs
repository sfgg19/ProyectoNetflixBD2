using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalCINEPOLIS
{
    public class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            this.Text = "Panel de Administración";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(20, 20, 20);
            this.ForeColor = Color.White;

            Label lblTitulo = new Label() { Text = "Administrador", Font = new Font("Arial", 16, FontStyle.Bold), Bounds = new Rectangle(120, 20, 200, 30) };

            Button btnUsuarios = new Button() { Text = "Administrar Usuarios", Bounds = new Rectangle(100, 80, 200, 40), BackColor = Color.Maroon, FlatStyle = FlatStyle.Flat };
            btnUsuarios.Click += (s, e) => { new FrmAdminUsuarios().ShowDialog(); };

            Button btnContenidos = new Button() { Text = "Administrar Películas", Bounds = new Rectangle(100, 140, 200, 40), BackColor = Color.Maroon, FlatStyle = FlatStyle.Flat };
            btnContenidos.Click += (s, e) => { new FrmAdminContenidos().ShowDialog(); };

            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnUsuarios);
            this.Controls.Add(btnContenidos);
        }
    }
}
