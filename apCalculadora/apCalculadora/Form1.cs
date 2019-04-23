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
        //PilhaHerdaLista<Dado>, IStack<Dado>
        //                             where Dado : IComparable<Dado>
    {
        private PilhaHerdaLista<string> pilha;
        //private PilhaHerdaLista<double> pilha;
        //txtVisor.Text = txtVisor.Text.Length > 0 ? txtVisor.Text.Substring(0, txtVisor.Text.Length - 1) : "";
        public FrmCalculadora()
        {
            InitializeComponent();
            pilha = new PilhaHerdaLista<string>(); 
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
            txtResultado.Text = ResolverExpressao();
        }

        public void SepararExpressao(string[] vetor)
        {     
            for (int b = 0; b < vetor.Length; b++)
                if (char.Parse(vetor[b]) >= '0' && char.Parse(vetor[b]) <= '9') //Se o caractere atual for número
                {
                    if (vetor[b - 1] != null && char.Parse(vetor[b - 1]) >= '0' && char.Parse(vetor[b - 1]) <= '9')
                    {//Se o dado anterior taambém for um número
                       pilha.Desempilhar();
                       pilha.Empilhar(vetor[b - 1] + vetor[b]);
                    }                      
                    else
                        pilha.Empilhar(vetor[b]); //pilha.Empilhar(vetor[b], "número");
                }
                else
                    if(char.Parse(vetor[b]) >= 'A' && char.Parse(vetor[b]) <= 'Z')  //Se o caractere atual for sinal
                         MessageBox.Show("Erro");
                    else //É um sinal
                        pilha.Empilhar(vetor[b]);

            //A variavel "pilha" tem a sequencia infixa, escrita pelo usuário
            //Chamamos o método ParaPosfixa() para gerarmos a sequencia posfixa da expressao dada
            pilha.ParaPosfixa();
            lbSequencia.Text = Posfixa();
        }

        public string Posfixa()
        {//Método que retorna a sequencia posfixa em forma de string
            string posfixa = "";

            PilhaHerdaLista<string> copy = pilha;

            while(!copy.EstaVazia())  //Obtem a sequencia posfixa ao contrário
                posfixa += copy.Desempilhar() + "";

            //while (!copy.EstaVazia()) //Obtem a sequencia posfixa na ordem certa
            //    posfixa += copy.Desempilhar() + "";

            return posfixa;
        }

        public string ResolverExpressao()  //Aqui, a variavel pilha já está com a sequencia posfixa ao contrario, portanto podemos resolver a expressão
        {
            double? result = null;

            if (!pilha.EstaEmOrdem(pilha))
                return "Expressão incompleta!";

            while(!pilha.EstaVazia())
            {
                string a = pilha.Desempilhar();
                string b = pilha.Desempilhar();
                string sinal = pilha.Desempilhar();
                
                //if(sinal.ToString() == ")" || sinal == "(")

                result = double.Parse(a) + sinal + double.Parse(b);
                
                pilha.Empilhar(result + "");
            }

            return result + "";
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
