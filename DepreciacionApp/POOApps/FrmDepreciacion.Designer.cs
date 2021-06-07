namespace POOApps
{
    partial class FrmDepreciacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMetodos = new System.Windows.Forms.ComboBox();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.dgvDepreciacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepreciacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Metodo de depreciacion: ";
            // 
            // cmbMetodos
            // 
            this.cmbMetodos.FormattingEnabled = true;
            this.cmbMetodos.Location = new System.Drawing.Point(286, 6);
            this.cmbMetodos.Name = "cmbMetodos";
            this.cmbMetodos.Size = new System.Drawing.Size(185, 21);
            this.cmbMetodos.TabIndex = 1;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(12, 33);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(547, 20);
            this.txtBuscador.TabIndex = 2;
            // 
            // dgvDepreciacion
            // 
            this.dgvDepreciacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepreciacion.Location = new System.Drawing.Point(12, 59);
            this.dgvDepreciacion.Name = "dgvDepreciacion";
            this.dgvDepreciacion.Size = new System.Drawing.Size(547, 379);
            this.dgvDepreciacion.TabIndex = 3;
            // 
            // FrmDepreciacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 450);
            this.Controls.Add(this.dgvDepreciacion);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.cmbMetodos);
            this.Controls.Add(this.label1);
            this.Name = "FrmDepreciacion";
            this.Text = "FrmDepreciacion";
            this.Load += new System.EventHandler(this.FrmDepreciacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepreciacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMetodos;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.DataGridView dgvDepreciacion;
    }
}