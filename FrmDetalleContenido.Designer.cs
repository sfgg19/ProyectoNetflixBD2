namespace ProyectoFinalCINEPOLIS
{
    partial class FrmDetalleContenido
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.btnMiLista = new System.Windows.Forms.Button();
            this.btnReproducir = new System.Windows.Forms.Button();
            this.lblSinopsis = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlSeries = new System.Windows.Forms.Panel();
            this.lblEtiquetaTemporada = new System.Windows.Forms.Label();
            this.cmbTemporadas = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlInfo.SuspendLayout();
            this.pnlSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.cmbTemporadas);
            this.pnlInfo.Controls.Add(this.lblEtiquetaTemporada);
            this.pnlInfo.Controls.Add(this.btnCalificar);
            this.pnlInfo.Controls.Add(this.btnMiLista);
            this.pnlInfo.Controls.Add(this.btnReproducir);
            this.pnlInfo.Controls.Add(this.lblSinopsis);
            this.pnlInfo.Controls.Add(this.lblInfo);
            this.pnlInfo.Controls.Add(this.lblTitulo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(884, 333);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInfo_Paint);
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(211, 253);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(75, 23);
            this.btnCalificar.TabIndex = 4;
            this.btnCalificar.Text = "⭐ Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click);
            // 
            // btnMiLista
            // 
            this.btnMiLista.Location = new System.Drawing.Point(102, 253);
            this.btnMiLista.Name = "btnMiLista";
            this.btnMiLista.Size = new System.Drawing.Size(92, 23);
            this.btnMiLista.TabIndex = 3;
            this.btnMiLista.Text = "Agregar a Lista";
            this.btnMiLista.UseVisualStyleBackColor = true;
            // 
            // btnReproducir
            // 
            this.btnReproducir.Location = new System.Drawing.Point(12, 253);
            this.btnReproducir.Name = "btnReproducir";
            this.btnReproducir.Size = new System.Drawing.Size(75, 23);
            this.btnReproducir.TabIndex = 1;
            this.btnReproducir.Text = "REPRO";
            this.btnReproducir.UseVisualStyleBackColor = true;
            this.btnReproducir.Click += new System.EventHandler(this.btnReproducir_Click);
            // 
            // lblSinopsis
            // 
            this.lblSinopsis.BackColor = System.Drawing.Color.White;
            this.lblSinopsis.Location = new System.Drawing.Point(12, 205);
            this.lblSinopsis.Name = "lblSinopsis";
            this.lblSinopsis.Size = new System.Drawing.Size(286, 34);
            this.lblSinopsis.TabIndex = 2;
            this.lblSinopsis.Text = "label1";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Gray;
            this.lblInfo.Font = new System.Drawing.Font("Sans Serif Collection", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(12, 143);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(62, 51);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "INFO";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Font = new System.Drawing.Font("Sans Serif Collection", 19.69811F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 32);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(148, 99);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "TITULO";
            // 
            // pnlSeries
            // 
            this.pnlSeries.Controls.Add(this.dataGridView1);
            this.pnlSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeries.Location = new System.Drawing.Point(0, 333);
            this.pnlSeries.Name = "pnlSeries";
            this.pnlSeries.Size = new System.Drawing.Size(884, 226);
            this.pnlSeries.TabIndex = 1;
            // 
            // lblEtiquetaTemporada
            // 
            this.lblEtiquetaTemporada.AutoSize = true;
            this.lblEtiquetaTemporada.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEtiquetaTemporada.Location = new System.Drawing.Point(12, 312);
            this.lblEtiquetaTemporada.Name = "lblEtiquetaTemporada";
            this.lblEtiquetaTemporada.Size = new System.Drawing.Size(75, 13);
            this.lblEtiquetaTemporada.TabIndex = 0;
            this.lblEtiquetaTemporada.Text = "TEMPORADA";
            // 
            // cmbTemporadas
            // 
            this.cmbTemporadas.FormattingEnabled = true;
            this.cmbTemporadas.Location = new System.Drawing.Point(102, 306);
            this.cmbTemporadas.Name = "cmbTemporadas";
            this.cmbTemporadas.Size = new System.Drawing.Size(144, 21);
            this.cmbTemporadas.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.Size = new System.Drawing.Size(884, 226);
            this.dataGridView1.TabIndex = 2;
            // 
            // FrmDetalleContenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(884, 559);
            this.Controls.Add(this.pnlSeries);
            this.Controls.Add(this.pnlInfo);
            this.Name = "FrmDetalleContenido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmDetalleContenido";
            this.Load += new System.EventHandler(this.FrmDetalleContenido_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlSeries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSinopsis;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnReproducir;
        private System.Windows.Forms.Panel pnlSeries;
        private System.Windows.Forms.Label lblEtiquetaTemporada;
        private System.Windows.Forms.ComboBox cmbTemporadas;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.Button btnMiLista;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}