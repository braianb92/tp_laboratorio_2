namespace MainCorreo
{
    partial class UpdateForm
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
            this.lblPaquete = new System.Windows.Forms.Label();
            this.lblNuevaDir = new System.Windows.Forms.Label();
            this.txtNuevaDir = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPaquete
            // 
            this.lblPaquete.AutoSize = true;
            this.lblPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaquete.Location = new System.Drawing.Point(12, 9);
            this.lblPaquete.Name = "lblPaquete";
            this.lblPaquete.Size = new System.Drawing.Size(0, 13);
            this.lblPaquete.TabIndex = 0;
            // 
            // lblNuevaDir
            // 
            this.lblNuevaDir.AutoSize = true;
            this.lblNuevaDir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNuevaDir.Location = new System.Drawing.Point(12, 47);
            this.lblNuevaDir.Name = "lblNuevaDir";
            this.lblNuevaDir.Size = new System.Drawing.Size(87, 13);
            this.lblNuevaDir.TabIndex = 1;
            this.lblNuevaDir.Text = "Nueva Direccion";
            // 
            // txtNuevaDir
            // 
            this.txtNuevaDir.Location = new System.Drawing.Point(26, 73);
            this.txtNuevaDir.Name = "txtNuevaDir";
            this.txtNuevaDir.Size = new System.Drawing.Size(161, 20);
            this.txtNuevaDir.TabIndex = 2;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(227, 61);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 32);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Update";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 119);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtNuevaDir);
            this.Controls.Add(this.lblNuevaDir);
            this.Controls.Add(this.lblPaquete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "update";
            this.Load += new System.EventHandler(this.update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaquete;
        private System.Windows.Forms.Label lblNuevaDir;
        private System.Windows.Forms.TextBox txtNuevaDir;
        private System.Windows.Forms.Button btnModificar;
    }
}