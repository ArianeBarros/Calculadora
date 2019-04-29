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
            }

            else
            {
                txtVisor.Text += s;
                //se tiver um fecha parenteses sem abre
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        { 
            string texto = txtVisor.Text;
            string[] vetor = new string[txtVisor.Text.Length];
            
            for (int i = 0; i < texto.Length; i++)
            {            
                if (texto[i] >= '0' && texto[i] <= '9') //Se o caractere atual for número
                {
                    if (i != 0 && texto[i - 1] >= '0' && texto[i - 1] <= '9')
                    {//Se o dado anterior também for um número
                        vetor[i] = texto[i] + texto[i - 1] + "";
                    }
                    else
                        vetor[i] = texto[i] + "";
                }
                else
                {
                    if (texto[i] >= 'A' && texto[i] <= 'Z')  //Se o caractere atual for letra
                        MessageBox.Show("Erro");
                    else //É um sinal
                    {
                        vetor[i] = texto[i] + "";
                    }
                       
                }
            }

            lbSequencia.Text = pilha.ParaPosfixa(texto);
                       
            txtResultado.Text = pilha.Resolver(pilha.ParaPosfixa(texto));          
        }        

        private void txtVisor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && !pilha.SeEhSinal(Convert.ToChar(e.KeyChar)))
                e.Handled = true;
        }

        private void FrmCalculadora_Load_1(object sender, EventArgs e)
        {
            pilha = new Expressao();
        }
    }
}
