namespace ProyectoFinalCINEPOLIS
{
    partial class FrmCalificar
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
            this.lblEstrellas = new System.Windows.Forms.Label();
            this.nudEstrellas = new System.Windows.Forms.NumericUpDown();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstrellas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Sans Serif Collection", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(205, 72);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "¿Qué te pareció?";
            // 
            // lblEstrellas
            // 
            this.lblEstrellas.AutoSize = true;
            this.lblEstrellas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstrellas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEstrellas.Location = new System.Drawing.Point(20, 50);
            this.lblEstrellas.Name = "lblEstrellas";
            this.lblEstrellas.Size = new System.Drawing.Size(107, 16);
            this.lblEstrellas.TabIndex = 1;
            this.lblEstrellas.Text = "Estrellas (1-5):";
            // 
            // nudEstrellas
            // 
            this.nudEstrellas.Location = new System.Drawing.Point(20, 80);
            this.nudEstrellas.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudEstrellas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstrellas.Name = "nudEstrellas";
            this.nudEstrellas.Size = new System.Drawing.Size(120, 20);
            this.nudEstrellas.TabIndex = 2;
            this.nudEstrellas.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Sans Serif Collection", 8.150943F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblComentario.Location = new System.Drawing.Point(20, 120);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(137, 41);
            this.lblComentario.TabIndex = 3;
            this.lblComentario.Text = "Escribe tu opinión:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(20, 150);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(340, 80);
            this.txtComentario.TabIndex = 4;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Red;
            this.btnEnviar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEnviar.Font = new System.Drawing.Font("Sans Serif Collection", 8.150943F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEnviar.Location = new System.Drawing.Point(0, 419);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(384, 40);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "ENVIAR CALIFICACIÓN";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // FrmCalificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(384, 459);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.nudEstrellas);
            this.Controls.Add(this.lblEstrellas);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCalificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calificar Contenido";
            ((System.ComponentModel.ISupportInitialize)(this.nudEstrellas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstrellas;
        private System.Windows.Forms.NumericUpDown nudEstrellas;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnEnviar;
    }
}