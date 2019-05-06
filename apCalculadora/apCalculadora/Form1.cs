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
        //private PilhaHerdaLista<double> pilha;
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
            //string[] texto = new string[26];
            //int qtd = 0;
            //for(int k = 0; k < txtVisor.Text.Length; k++)
            //{
            //    texto[k] = txtVisor.Text.Substring(k, 1);
            //    qtd++;
            //}
            //string[] vetor = new string[txtVisor.Text.Length];

            //for (int i = 0; i < qtd; i++)
            //{            
            //    if (texto[i].Equals("0") && texto[i].Equals("9")) //Se o caractere atual for número
            //    {
            //        if (i != 0 && texto[i - 1].Equals("0") && texto[i - 1].Equals("9"))
            //        {//Se o dado anterior também for um número
            //            vetor[i] = texto[i] + texto[i - 1] + "";
            //        }
            //        else
            //            vetor[i] = texto[i] + "";
            //    }
            //    else
            //    {
            //        if (texto[i].Equals("A") && texto[i].Equals("Z"))  //Se o caractere atual for letra
            //            MessageBox.Show("Erro");
            //        else //É um sinal
            //        {
            //            vetor[i] = texto[i] + "";
            //        }

            //    }
            //}

            lbInfixa.Visible = true;
            
            string infixa = pilha.ParaInfixa(txtVisor.Text);
            

            if (infixa == null)
            {
                MessageBox.Show("Verifique se a sequência está correta.", "Erro!");
                txtVisor.Clear();
            }               
            else
            {
                lbInfixa.Text = infixa;
                lbPosfixa.Visible = true;
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
