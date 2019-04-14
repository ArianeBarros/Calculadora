namespace Calculadora
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIgual = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVisor = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtErro = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIgual
            // 
            this.btnIgual.Location = new System.Drawing.Point(88, 285);
            this.btnIgual.Name = "btnIgual";
            this.btnIgual.Size = new System.Drawing.Size(26, 23);
            this.btnIgual.TabIndex = 0;
            this.btnIgual.Text = "=";
            this.btnIgual.UseVisualStyleBackColor = true;
            this.btnIgual.Click += new System.EventHandler(this.btnIgual_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtResultado);
            this.panel1.Controls.Add(this.txtVisor);
            this.panel1.Controls.Add(this.btnIgual);
            this.panel1.Location = new System.Drawing.Point(83, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 335);
            this.panel1.TabIndex = 1;
            // 
            // txtVisor
            // 
            this.txtVisor.Enabled = false;
            this.txtVisor.Location = new System.Drawing.Point(4, 19);
            this.txtVisor.Name = "txtVisor";
            this.txtVisor.Size = new System.Drawing.Size(293, 20);
            this.txtVisor.TabIndex = 1;
            // 
            // txtResultado
            // 
            this.txtResultado.Enabled = false;
            this.txtResultado.Location = new System.Drawing.Point(4, 46);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(293, 20);
            this.txtResultado.TabIndex = 2;
            // 
            // txtErro
            // 
            this.txtErro.Enabled = false;
            this.txtErro.Location = new System.Drawing.Point(-3, 412);
            this.txtErro.Name = "txtErro";
            this.txtErro.Size = new System.Drawing.Size(811, 20);
            this.txtErro.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 433);
            this.Controls.Add(this.txtErro);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIgual;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.TextBox txtVisor;
        private System.Windows.Forms.TextBox txtErro;
    }
}

