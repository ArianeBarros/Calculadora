using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apCalculadora
{
    public partial class frmCalculadora : Form
    {
        private PilhaHerdaLista<double> pilha;
        public frmCalculadora()
        {
            InitializeComponent();
            pilha = new PilhaHerdaLista<double>(); ;
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            //string num = "1";
            txtVisor.Text += "1";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "3";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "6";
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "7";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "8";
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "9";
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            txtVisor.Text += ",";
            btnVirgula.Enabled = false;
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "+";
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "-";
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "*";
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "/";
        }

        private void btnPotencia_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "^";
        }

        private void btnFecharP_Click(object sender, EventArgs e)
        {
            txtVisor.Text += ")";
        }

        private void btnAbrirP_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "(";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text.Length > 0 ? txtVisor.Text.Substring(0, txtVisor.Text.Length - 1) : "";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtVisor.Text += "0";
        }
    }
}
