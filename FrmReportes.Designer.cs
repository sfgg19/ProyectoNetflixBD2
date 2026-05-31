namespace ProyectoFinalCINEPOLIS
{
    partial class FrmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            this.gridDatos = new System.Windows.Forms.DataGridView();
            this.btnMasVistas = new System.Windows.Forms.Button();
            this.btnPorEdad = new System.Windows.Forms.Button();
            this.btnPromedios = new System.Windows.Forms.Button();
            this.btnMejorCalif = new System.Windows.Forms.Button();
            this.btnGeneroFav = new System.Windows.Forms.Button();
            this.btnGeneros = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.69811F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(441, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTES Y ESTADÍSTICAS";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnContratos);
            this.pnlMenu.Controls.Add(this.btnGeneros);
            this.pnlMenu.Controls.Add(this.btnGeneroFav);
            this.pnlMenu.Controls.Add(this.btnMejorCalif);
            this.pnlMenu.Controls.Add(this.btnPromedios);
            this.pnlMenu.Controls.Add(this.btnPorEdad);
            this.pnlMenu.Controls.Add(this.btnMasVistas);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 33);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 526);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.Controls.Add(this.gridDatos);
            this.pnlCuerpo.Controls.Add(this.lblDesc);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(220, 33);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(764, 526);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDesc.Location = new System.Drawing.Point(0, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(171, 16);
            this.lblDesc.TabIndex = 0;
            this.lblDesc.Text = "Selecciona un reporte...";
            // 
            // gridDatos
            // 
            this.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDatos.Location = new System.Drawing.Point(0, 16);
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.RowHeadersWidth = 45;
            this.gridDatos.Size = new System.Drawing.Size(764, 510);
            this.gridDatos.TabIndex = 1;
            // 
            // btnMasVistas
            // 
            this.btnMasVistas.Location = new System.Drawing.Point(37, 16);
            this.btnMasVistas.Name = "btnMasVistas";
            this.btnMasVistas.Size = new System.Drawing.Size(126, 23);
            this.btnMasVistas.TabIndex = 0;
            this.btnMasVistas.Text = "1. Película Más Vista";
            this.btnMasVistas.UseVisualStyleBackColor = true;
            this.btnMasVistas.Click += new System.EventHandler(this.btnMasVistas_Click);
            // 
            // btnPorEdad
            // 
            this.btnPorEdad.Location = new System.Drawing.Point(37, 54);
            this.btnPorEdad.Name = "btnPorEdad";
            this.btnPorEdad.Size = new System.Drawing.Size(126, 23);
            this.btnPorEdad.TabIndex = 1;
            this.btnPorEdad.Text = "2. Más Vistas por Edad";
            this.btnPorEdad.UseVisualStyleBackColor = true;
            this.btnPorEdad.Click += new System.EventHandler(this.btnMasVistas_Click);
            // 
            // btnPromedios
            // 
            this.btnPromedios.Location = new System.Drawing.Point(37, 173);
            this.btnPromedios.Name = "btnPromedios";
            this.btnPromedios.Size = new System.Drawing.Size(126, 23);
            this.btnPromedios.TabIndex = 2;
            this.btnPromedios.Text = "5. Promedio General";
            this.btnPromedios.UseVisualStyleBackColor = true;
            this.btnPromedios.Click += new System.EventHandler(this.btnPromedios_Click);
            // 
            // btnMejorCalif
            // 
            this.btnMejorCalif.Location = new System.Drawing.Point(37, 133);
            this.btnMejorCalif.Name = "btnMejorCalif";
            this.btnMejorCalif.Size = new System.Drawing.Size(126, 23);
            this.btnMejorCalif.TabIndex = 3;
            this.btnMejorCalif.Text = "4. Mejor Calificada";
            this.btnMejorCalif.UseVisualStyleBackColor = true;
            this.btnMejorCalif.Click += new System.EventHandler(this.btnMejorCalif_Click);
            // 
            // btnGeneroFav
            // 
            this.btnGeneroFav.Location = new System.Drawing.Point(37, 94);
            this.btnGeneroFav.Name = "btnGeneroFav";
            this.btnGeneroFav.Size = new System.Drawing.Size(126, 23);
            this.btnGeneroFav.TabIndex = 4;
            this.btnGeneroFav.Text = "3. Género Favorito";
            this.btnGeneroFav.UseVisualStyleBackColor = true;
            this.btnGeneroFav.Click += new System.EventHandler(this.btnGeneroFav_Click);
            // 
            // btnGeneros
            // 
            this.btnGeneros.Location = new System.Drawing.Point(37, 252);
            this.btnGeneros.Name = "btnGeneros";
            this.btnGeneros.Size = new System.Drawing.Size(126, 23);
            this.btnGeneros.TabIndex = 5;
            this.btnGeneros.Text = "7. Pelis por Género";
            this.btnGeneros.UseVisualStyleBackColor = true;
            this.btnGeneros.Click += new System.EventHandler(this.btnGeneros_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Location = new System.Drawing.Point(37, 211);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(126, 23);
            this.btnContratos.TabIndex = 6;
            this.btnContratos.Text = "6. Nuevos Contratos";
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(984, 559);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.Button btnGeneros;
        private System.Windows.Forms.Button btnGeneroFav;
        private System.Windows.Forms.Button btnMejorCalif;
        private System.Windows.Forms.Button btnPromedios;
        private System.Windows.Forms.Button btnPorEdad;
        private System.Windows.Forms.Button btnMasVistas;
    }
}