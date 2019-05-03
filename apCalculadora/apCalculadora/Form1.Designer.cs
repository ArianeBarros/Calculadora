namespace apCalculadora
{
    partial class FrmCalculadora
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
            this.btnNove = new System.Windows.Forms.Button();
            this.btnOito = new System.Windows.Forms.Button();
            this.btnSete = new System.Windows.Forms.Button();
            this.btnSeis = new System.Windows.Forms.Button();
            this.btnCinco = new System.Windows.Forms.Button();
            this.btnUm = new System.Windows.Forms.Button();
            this.btnDois = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnIgual = new System.Windows.Forms.Button();
            this.btnQuatro = new System.Windows.Forms.Button();
            this.btnMultiplicar = new System.Windows.Forms.Button();
            this.btnAbrirP = new System.Windows.Forms.Button();
            this.btnTres = new System.Windows.Forms.Button();
            this.btnSomar = new System.Windows.Forms.Button();
            this.btnDividir = new System.Windows.Forms.Button();
            this.btnSubtrair = new System.Windows.Forms.Button();
            this.btnFecharP = new System.Windows.Forms.Button();
            this.btnVirgula = new System.Windows.Forms.Button();
            this.btnPotencia = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVisor = new System.Windows.Forms.TextBox();
            this.btnCE = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lbPosfixa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbInfixa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNove
            // 
            this.btnNove.Location = new System.Drawing.Point(142, 216);
            this.btnNove.Name = "btnNove";
            this.btnNove.Size = new System.Drawing.Size(59, 40);
            this.btnNove.TabIndex = 2;
            this.btnNove.Text = "9";
            this.btnNove.UseVisualStyleBackColor = true;
            this.btnNove.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnOito
            // 
            this.btnOito.Location = new System.Drawing.Point(77, 216);
            this.btnOito.Name = "btnOito";
            this.btnOito.Size = new System.Drawing.Size(59, 40);
            this.btnOito.TabIndex = 3;
            this.btnOito.Text = "8";
            this.btnOito.UseVisualStyleBackColor = true;
            this.btnOito.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnSete
            // 
            this.btnSete.Location = new System.Drawing.Point(12, 216);
            this.btnSete.Name = "btnSete";
            this.btnSete.Size = new System.Drawing.Size(59, 40);
            this.btnSete.TabIndex = 4;
            this.btnSete.Text = "7";
            this.btnSete.UseVisualStyleBackColor = true;
            this.btnSete.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnSeis
            // 
            this.btnSeis.Location = new System.Drawing.Point(142, 262);
            this.btnSeis.Name = "btnSeis";
            this.btnSeis.Size = new System.Drawing.Size(59, 40);
            this.btnSeis.TabIndex = 5;
            this.btnSeis.Text = "6";
            this.btnSeis.UseVisualStyleBackColor = true;
            this.btnSeis.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnCinco
            // 
            this.btnCinco.Location = new System.Drawing.Point(77, 262);
            this.btnCinco.Name = "btnCinco";
            this.btnCinco.Size = new System.Drawing.Size(59, 40);
            this.btnCinco.TabIndex = 6;
            this.btnCinco.Text = "5";
            this.btnCinco.UseVisualStyleBackColor = true;
            this.btnCinco.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnUm
            // 
            this.btnUm.Location = new System.Drawing.Point(12, 308);
            this.btnUm.Name = "btnUm";
            this.btnUm.Size = new System.Drawing.Size(59, 40);
            this.btnUm.TabIndex = 7;
            this.btnUm.Text = "1";
            this.btnUm.UseVisualStyleBackColor = true;
            this.btnUm.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnDois
            // 
            this.btnDois.Location = new System.Drawing.Point(77, 308);
            this.btnDois.Name = "btnDois";
            this.btnDois.Size = new System.Drawing.Size(59, 40);
            this.btnDois.TabIndex = 8;
            this.btnDois.Text = "2";
            this.btnDois.UseVisualStyleBackColor = true;
            this.btnDois.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(12, 354);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(189, 40);
            this.btnZero.TabIndex = 9;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnIgual
            // 
            this.btnIgual.Location = new System.Drawing.Point(272, 262);
            this.btnIgual.Name = "btnIgual";
            this.btnIgual.Size = new System.Drawing.Size(59, 132);
            this.btnIgual.TabIndex = 10;
            this.btnIgual.Text = "=";
            this.btnIgual.UseVisualStyleBackColor = true;
            this.btnIgual.Click += new System.EventHandler(this.btnIgual_Click);
            // 
            // btnQuatro
            // 
            this.btnQuatro.Location = new System.Drawing.Point(12, 262);
            this.btnQuatro.Name = "btnQuatro";
            this.btnQuatro.Size = new System.Drawing.Size(59, 40);
            this.btnQuatro.TabIndex = 11;
            this.btnQuatro.Text = "4";
            this.btnQuatro.UseVisualStyleBackColor = true;
            this.btnQuatro.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnMultiplicar
            // 
            this.btnMultiplicar.Location = new System.Drawing.Point(207, 216);
            this.btnMultiplicar.Name = "btnMultiplicar";
            this.btnMultiplicar.Size = new System.Drawing.Size(59, 40);
            this.btnMultiplicar.TabIndex = 12;
            this.btnMultiplicar.Text = "*";
            this.btnMultiplicar.UseVisualStyleBackColor = true;
            this.btnMultiplicar.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnAbrirP
            // 
            this.btnAbrirP.Location = new System.Drawing.Point(12, 170);
            this.btnAbrirP.Name = "btnAbrirP";
            this.btnAbrirP.Size = new System.Drawing.Size(59, 40);
            this.btnAbrirP.TabIndex = 13;
            this.btnAbrirP.Text = "(";
            this.btnAbrirP.UseVisualStyleBackColor = true;
            this.btnAbrirP.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnTres
            // 
            this.btnTres.Location = new System.Drawing.Point(142, 308);
            this.btnTres.Name = "btnTres";
            this.btnTres.Size = new System.Drawing.Size(59, 40);
            this.btnTres.TabIndex = 14;
            this.btnTres.Text = "3";
            this.btnTres.UseVisualStyleBackColor = true;
            this.btnTres.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnSomar
            // 
            this.btnSomar.Location = new System.Drawing.Point(207, 308);
            this.btnSomar.Name = "btnSomar";
            this.btnSomar.Size = new System.Drawing.Size(59, 40);
            this.btnSomar.TabIndex = 15;
            this.btnSomar.Text = "+";
            this.btnSomar.UseVisualStyleBackColor = true;
            this.btnSomar.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnDividir
            // 
            this.btnDividir.Location = new System.Drawing.Point(207, 170);
            this.btnDividir.Name = "btnDividir";
            this.btnDividir.Size = new System.Drawing.Size(59, 40);
            this.btnDividir.TabIndex = 16;
            this.btnDividir.Text = "/";
            this.btnDividir.UseVisualStyleBackColor = true;
            this.btnDividir.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnSubtrair
            // 
            this.btnSubtrair.Location = new System.Drawing.Point(207, 262);
            this.btnSubtrair.Name = "btnSubtrair";
            this.btnSubtrair.Size = new System.Drawing.Size(59, 40);
            this.btnSubtrair.TabIndex = 17;
            this.btnSubtrair.Text = "-";
            this.btnSubtrair.UseVisualStyleBackColor = true;
            this.btnSubtrair.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnFecharP
            // 
            this.btnFecharP.Location = new System.Drawing.Point(77, 170);
            this.btnFecharP.Name = "btnFecharP";
            this.btnFecharP.Size = new System.Drawing.Size(59, 40);
            this.btnFecharP.TabIndex = 18;
            this.btnFecharP.Text = ")";
            this.btnFecharP.UseVisualStyleBackColor = true;
            this.btnFecharP.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnVirgula
            // 
            this.btnVirgula.Location = new System.Drawing.Point(207, 352);
            this.btnVirgula.Name = "btnVirgula";
            this.btnVirgula.Size = new System.Drawing.Size(59, 40);
            this.btnVirgula.TabIndex = 19;
            this.btnVirgula.Text = ",";
            this.btnVirgula.UseVisualStyleBackColor = true;
            this.btnVirgula.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnPotencia
            // 
            this.btnPotencia.Location = new System.Drawing.Point(142, 170);
            this.btnPotencia.Name = "btnPotencia";
            this.btnPotencia.Size = new System.Drawing.Size(59, 40);
            this.btnPotencia.TabIndex = 20;
            this.btnPotencia.Text = "^";
            this.btnPotencia.UseVisualStyleBackColor = true;
            this.btnPotencia.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(272, 170);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(59, 40);
            this.btnC.TabIndex = 21;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Pósfixa: ";
            // 
            // txtVisor
            // 
            this.txtVisor.Location = new System.Drawing.Point(12, 12);
            this.txtVisor.Name = "txtVisor";
            this.txtVisor.Size = new System.Drawing.Size(319, 31);
            this.txtVisor.TabIndex = 23;
            this.txtVisor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVisor_KeyPress);
            // 
            // btnCE
            // 
            this.btnCE.Location = new System.Drawing.Point(272, 216);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(59, 40);
            this.btnCE.TabIndex = 24;
            this.btnCE.Text = "CE";
            this.btnCE.UseVisualStyleBackColor = true;
            this.btnCE.Click += new System.EventHandler(this.btnUm_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Enabled = false;
            this.txtResultado.Location = new System.Drawing.Point(12, 49);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(319, 31);
            this.txtResultado.TabIndex = 25;
            // 
            // lbPosfixa
            // 
            this.lbPosfixa.AutoSize = true;
            this.lbPosfixa.Location = new System.Drawing.Point(99, 94);
            this.lbPosfixa.Name = "lbPosfixa";
            this.lbPosfixa.Size = new System.Drawing.Size(0, 23);
            this.lbPosfixa.TabIndex = 26;
            this.lbPosfixa.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Infixa:";
            // 
            // lbInfixa
            // 
            this.lbInfixa.AutoSize = true;
            this.lbInfixa.Location = new System.Drawing.Point(99, 129);
            this.lbInfixa.Name = "lbInfixa";
            this.lbInfixa.Size = new System.Drawing.Size(69, 23);
            this.lbInfixa.TabIndex = 28;
            this.lbInfixa.Text = "label2";
            this.lbInfixa.Visible = false;
            // 
            // FrmCalculadora
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(338, 410);
            this.Controls.Add(this.lbInfixa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPosfixa);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.txtVisor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnPotencia);
            this.Controls.Add(this.btnVirgula);
            this.Controls.Add(this.btnFecharP);
            this.Controls.Add(this.btnSubtrair);
            this.Controls.Add(this.btnDividir);
            this.Controls.Add(this.btnSomar);
            this.Controls.Add(this.btnTres);
            this.Controls.Add(this.btnAbrirP);
            this.Controls.Add(this.btnMultiplicar);
            this.Controls.Add(this.btnQuatro);
            this.Controls.Add(this.btnIgual);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnDois);
            this.Controls.Add(this.btnUm);
            this.Controls.Add(this.btnCinco);
            this.Controls.Add(this.btnSeis);
            this.Controls.Add(this.btnSete);
            this.Controls.Add(this.btnOito);
            this.Controls.Add(this.btnNove);
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCalculadora";
            this.Text = "Calculadora Cientifíca";
            this.Load += new System.EventHandler(this.FrmCalculadora_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNove;
        private System.Windows.Forms.Button btnOito;
        private System.Windows.Forms.Button btnSete;
        private System.Windows.Forms.Button btnSeis;
        private System.Windows.Forms.Button btnCinco;
        private System.Windows.Forms.Button btnUm;
        private System.Windows.Forms.Button btnDois;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnIgual;
        private System.Windows.Forms.Button btnQuatro;
        private System.Windows.Forms.Button btnMultiplicar;
        private System.Windows.Forms.Button btnAbrirP;
        private System.Windows.Forms.Button btnTres;
        private System.Windows.Forms.Button btnSomar;
        private System.Windows.Forms.Button btnDividir;
        private System.Windows.Forms.Button btnSubtrair;
        private System.Windows.Forms.Button btnFecharP;
        private System.Windows.Forms.Button btnVirgula;
        private System.Windows.Forms.Button btnPotencia;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVisor;
        private System.Windows.Forms.Button btnCE;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lbPosfixa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbInfixa;
    }
}

