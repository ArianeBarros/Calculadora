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
        //txtVisor.Text = txtVisor.Text.Length > 0 ? txtVisor.Text.Substring(0, txtVisor.Text.Length - 1) : "";
        public frmCalculadora()
        {
            InitializeComponent();
            pilha = new PilhaHerdaLista<double>(); ;
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
            string[] vetor = null;
            int cont = 0;

            while (cont <= texto.Length)
                foreach (var a in texto)
                    vetor[cont] = a + "";

            SepararExpressao(vetor);

            txtVisor.Clear();
        }

        public void SepararExpressao(string[] vetor)
        {
            Pilha pilha = null;

            if (!EstaEmOrdem(vetor))
                return;

            for (int b = 0; b < vetor.Length; b++)
                if (char.Parse(vetor[b]) >= '0' && char.Parse(vetor[b]) <= '9') //Se o caractere atual for número
                {
                    if (vetor[b - 1] != null && char.Parse(vetor[b - 1]) >= '0' && char.Parse(vetor[b - 1]) <= '9')
                    {
                        pilha.ExcluirTopo();
                        pilha.InserirNoTopo(vetor[b - 1] + vetor[b], "número");
                    }                      
                    else
                        pilha.InserirNoTopo(vetor[b], "número");
                }
                else
                    if(char.Parse(vetor[b]) >= 'A' && char.Parse(vetor[b]) <= 'Z')  //Se o caractere atual for sinal
                         MessageBox.Show("Erro");
                else //É um sinal
                    pilha.InserirNoTopo(vetor[b] , "sinal");

        }

        public bool EstaEmOrdem(string[] vetor)
        {

        }
    }
}
