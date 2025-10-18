namespace Automata
{
    partial class IngresoCaracteres
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
            this.btnInicio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstGrupo = new System.Windows.Forms.ComboBox();
            this.txtChar1 = new System.Windows.Forms.TextBox();
            this.txtChar2 = new System.Windows.Forms.TextBox();
            this.txtChar3 = new System.Windows.Forms.TextBox();
            this.txtChar4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(120, 279);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(75, 23);
            this.btnInicio.TabIndex = 5;
            this.btnInicio.Text = "Iniciar";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingresa 4 Caracteres y Selecciona el Grupo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Caracter 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Caracter 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Caracter 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Caracter 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Grupo";
            // 
            // lstGrupo
            // 
            this.lstGrupo.FormattingEnabled = true;
            this.lstGrupo.Items.AddRange(new object[] {
            "Digitos",
            "Vocales",
            "Letras"});
            this.lstGrupo.Location = new System.Drawing.Point(120, 223);
            this.lstGrupo.Name = "lstGrupo";
            this.lstGrupo.Size = new System.Drawing.Size(121, 21);
            this.lstGrupo.TabIndex = 4;
            // 
            // txtChar1
            // 
            this.txtChar1.Location = new System.Drawing.Point(120, 63);
            this.txtChar1.Name = "txtChar1";
            this.txtChar1.Size = new System.Drawing.Size(121, 20);
            this.txtChar1.TabIndex = 0;
            this.txtChar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChar1_KeyPress);
            // 
            // txtChar2
            // 
            this.txtChar2.Location = new System.Drawing.Point(120, 102);
            this.txtChar2.Name = "txtChar2";
            this.txtChar2.Size = new System.Drawing.Size(121, 20);
            this.txtChar2.TabIndex = 1;
            this.txtChar2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChar2_KeyPress);
            // 
            // txtChar3
            // 
            this.txtChar3.Location = new System.Drawing.Point(120, 147);
            this.txtChar3.Name = "txtChar3";
            this.txtChar3.Size = new System.Drawing.Size(121, 20);
            this.txtChar3.TabIndex = 2;
            this.txtChar3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChar3_KeyPress);
            // 
            // txtChar4
            // 
            this.txtChar4.Location = new System.Drawing.Point(120, 185);
            this.txtChar4.Name = "txtChar4";
            this.txtChar4.Size = new System.Drawing.Size(121, 20);
            this.txtChar4.TabIndex = 3;
            this.txtChar4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChar4_KeyPress);
            // 
            // IngresoCaracteres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 330);
            this.Controls.Add(this.txtChar4);
            this.Controls.Add(this.txtChar3);
            this.Controls.Add(this.txtChar2);
            this.Controls.Add(this.txtChar1);
            this.Controls.Add(this.lstGrupo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInicio);
            this.MaximizeBox = false;
            this.Name = "IngresoCaracteres";
            this.Text = "IngresoCaracteres";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IngresoCaracteres_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox lstGrupo;
        private System.Windows.Forms.TextBox txtChar1;
        private System.Windows.Forms.TextBox txtChar2;
        private System.Windows.Forms.TextBox txtChar3;
        private System.Windows.Forms.TextBox txtChar4;
    }
}