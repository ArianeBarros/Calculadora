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
    public partial class FrmCalculadora : Form  
    {
        private Expressao pilha;
        //txtVisor.Text = txtVisor.Text.Length > 0 ? txtVisor.Text.Substring(0, txtVisor.Text.Length - 1) : "";

        public FrmCalculadora()
        {
            InitializeComponent();
           
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            string s = ((Button)sender).Text;

            if ((((Button)sender).Text) == "CE")
            {
                txtVisor.Text = txtVisor.Text.Length > 0 ? txtVisor.Text.Substring(0, txtVisor.Text.Length - 1) : "";
            }
            else if ((((Button)sender).Text) == "C")
            {
                txtVisor.Clear();
                txtResultado.Clear();
                lbInfixa.Text = "";
                lbPosfixa.Text = "";
            }

            else
            {
                txtVisor.Text += s;
                //se tiver um fecha parenteses sem abre
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            lbInfixa.Visible = true;
            lbPosfixa.Visible = true;
            string infixa = pilha.ParaInfixa(txtVisor.Text);            

            if (infixa == null)
            {
                MessageBox.Show("Verifique se a sequência está correta.", "Erro!");
                txtVisor.Clear();
            }               
            else
            {
                lbInfixa.Text = infixa;
                lbPosfixa.Text = pilha.ParaPosfixa(txtVisor.Text);
                txtResultado.Text = pilha.Resolver(txtVisor.Text);
            }                        
        }        

        private void txtVisor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && !pilha.SeEhSinal((e.KeyChar).ToString()))
                e.Handled = true;
        }

        private void FrmCalculadora_Load_1(object sender, EventArgs e)
        {
            pilha = new Expressao();
        }
    }
}
