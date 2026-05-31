namespace ProyectoFinalCINEPOLIS
{
    partial class FrmMiCuenta
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.grpPlan = new System.Windows.Forms.GroupBox();
            this.btnCambiarPlan = new System.Windows.Forms.Button();
            this.cmbPlanes = new System.Windows.Forms.ComboBox();
            this.lblPlanActual = new System.Windows.Forms.Label();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.gridPagos = new System.Windows.Forms.DataGridView();
            this.grpPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagos)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(354, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mi Cuenta y Facturación";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEmail.Location = new System.Drawing.Point(30, 80);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(66, 16);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email: ...";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarjeta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTarjeta.Location = new System.Drawing.Point(30, 110);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(77, 16);
            this.lblTarjeta.TabIndex = 2;
            this.lblTarjeta.Text = "Tarjeta: ...";
            // 
            // grpPlan
            // 
            this.grpPlan.Controls.Add(this.btnCambiarPlan);
            this.grpPlan.Controls.Add(this.cmbPlanes);
            this.grpPlan.Controls.Add(this.lblPlanActual);
            this.grpPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpPlan.Location = new System.Drawing.Point(30, 150);
            this.grpPlan.Name = "grpPlan";
            this.grpPlan.Size = new System.Drawing.Size(300, 100);
            this.grpPlan.TabIndex = 3;
            this.grpPlan.TabStop = false;
            this.grpPlan.Text = "Detalles del Plan";
            // 
            // btnCambiarPlan
            // 
            this.btnCambiarPlan.BackColor = System.Drawing.Color.Red;
            this.btnCambiarPlan.Location = new System.Drawing.Point(105, 60);
            this.btnCambiarPlan.Name = "btnCambiarPlan";
            this.btnCambiarPlan.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarPlan.TabIndex = 2;
            this.btnCambiarPlan.Text = "Cambiar Plan";
            this.btnCambiarPlan.UseVisualStyleBackColor = false;
            this.btnCambiarPlan.Click += new System.EventHandler(this.btnCambiarPlan_Click);
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.FormattingEnabled = true;
            this.cmbPlanes.Items.AddRange(new object[] {
            "Básico",
            "Estándar",
            "Premium"});
            this.cmbPlanes.Location = new System.Drawing.Point(105, 25);
            this.cmbPlanes.Name = "cmbPlanes";
            this.cmbPlanes.Size = new System.Drawing.Size(189, 24);
            this.cmbPlanes.TabIndex = 1;
            // 
            // lblPlanActual
            // 
            this.lblPlanActual.AutoSize = true;
            this.lblPlanActual.Location = new System.Drawing.Point(15, 30);
            this.lblPlanActual.Name = "lblPlanActual";
            this.lblPlanActual.Size = new System.Drawing.Size(89, 16);
            this.lblPlanActual.TabIndex = 0;
            this.lblPlanActual.Text = "Plan Actual:";
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHistorial.Location = new System.Drawing.Point(400, 80);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(136, 16);
            this.lblHistorial.TabIndex = 4;
            this.lblHistorial.Text = "Historial de Pagos";
            // 
            // gridPagos
            // 
            this.gridPagos.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPagos.Location = new System.Drawing.Point(400, 110);
            this.gridPagos.Name = "gridPagos";
            this.gridPagos.RowHeadersWidth = 45;
            this.gridPagos.Size = new System.Drawing.Size(350, 300);
            this.gridPagos.TabIndex = 5;
            // 
            // FrmMiCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 459);
            this.Controls.Add(this.gridPagos);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.grpPlan);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmMiCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmMiCuenta";
            this.Load += new System.EventHandler(this.FrmMiCuenta_Load);
            this.grpPlan.ResumeLayout(false);
            this.grpPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.GroupBox grpPlan;
        private System.Windows.Forms.Button btnCambiarPlan;
        private System.Windows.Forms.ComboBox cmbPlanes;
        private System.Windows.Forms.Label lblPlanActual;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView gridPagos;
    }
}