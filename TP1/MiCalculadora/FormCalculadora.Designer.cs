namespace MiCalculadora
{
    partial class FormCalculadora
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
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.txtNum2 = new System.Windows.Forms.TextBox();
            this.comboOperator = new System.Windows.Forms.ComboBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnToBinario = new System.Windows.Forms.Button();
            this.btnToDecimal = new System.Windows.Forms.Button();
            this.lblView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNum1
            // 
            this.txtNum1.Location = new System.Drawing.Point(35, 49);
            this.txtNum1.Name = "txtNum1";
            this.txtNum1.Size = new System.Drawing.Size(98, 20);
            this.txtNum1.TabIndex = 0;
            // 
            // txtNum2
            // 
            this.txtNum2.Location = new System.Drawing.Point(267, 49);
            this.txtNum2.Name = "txtNum2";
            this.txtNum2.Size = new System.Drawing.Size(98, 20);
            this.txtNum2.TabIndex = 1;
            // 
            // comboOperator
            // 
            this.comboOperator.FormattingEnabled = true;
            this.comboOperator.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.comboOperator.Location = new System.Drawing.Point(161, 48);
            this.comboOperator.Name = "comboOperator";
            this.comboOperator.Size = new System.Drawing.Size(67, 21);
            this.comboOperator.TabIndex = 2;
            this.comboOperator.Text = "+";
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(30, 90);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(91, 33);
            this.btnOperar.TabIndex = 3;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(149, 90);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(91, 33);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(274, 90);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(91, 33);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // btnToBinario
            // 
            this.btnToBinario.Location = new System.Drawing.Point(30, 140);
            this.btnToBinario.Name = "btnToBinario";
            this.btnToBinario.Size = new System.Drawing.Size(163, 39);
            this.btnToBinario.TabIndex = 6;
            this.btnToBinario.Text = "Convertir a Binario";
            this.btnToBinario.UseVisualStyleBackColor = true;
            this.btnToBinario.Click += new System.EventHandler(this.BtnToBinario_Click);
            // 
            // btnToDecimal
            // 
            this.btnToDecimal.Location = new System.Drawing.Point(202, 140);
            this.btnToDecimal.Name = "btnToDecimal";
            this.btnToDecimal.Size = new System.Drawing.Size(163, 39);
            this.btnToDecimal.TabIndex = 7;
            this.btnToDecimal.Text = "Convertir a Decimal";
            this.btnToDecimal.UseVisualStyleBackColor = true;
            this.btnToDecimal.Click += new System.EventHandler(this.BtnToDecimal_Click);
            // 
            // lblView
            // 
            this.lblView.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(30, 9);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(335, 34);
            this.lblView.TabIndex = 8;
            this.lblView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(395, 208);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.btnToDecimal);
            this.Controls.Add(this.btnToBinario);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.comboOperator);
            this.Controls.Add(this.txtNum2);
            this.Controls.Add(this.txtNum1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Braian Baldino del curso 2°D";
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.TextBox txtNum2;
        private System.Windows.Forms.ComboBox comboOperator;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnToBinario;
        private System.Windows.Forms.Button btnToDecimal;
        private System.Windows.Forms.Label lblView;
    }
}

