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
        private Expressao pilha; //Declaração de uma pilha
      
        public FrmCalculadora()
        {
            InitializeComponent();
           
        }
        private void btnUm_Click(object sender, EventArgs e) //Método chamado sempre que um botão da calculadora for selecionado
        {
            string s = ((Button)sender).Text; //Variável local que recebe qual foi o botão selecionado pelo usuário

            if ((((Button)sender).Text) == "CE")
            { //Caso o botão selecionado seja CE, retiramos o último elemento da sequencia
                txtVisor.Text = txtVisor.Text.Length > 0 ? txtVisor.Text.Substring(0, txtVisor.Text.Length - 1) : "";
            }
            else if ((((Button)sender).Text) == "C")
            { //Caso o botão selecionado seja C, apagamos toda a sequencia escrita no txtVisor
                txtVisor.Clear();
                txtResultado.Clear();
                lbInfixa.Text = "";
                lbPosfixa.Text = "";
            }
            else
                txtVisor.Text += s; //Caso o botão selecionado não seja 'CE' ou 'C', acrescentamos o simbolo escolhido na sequencia
        }

        private void btnIgual_Click(object sender, EventArgs e) //Método chamado quando o usuário seleciona o btnIgual
        {
            //lbInfixa.Visible = true;
            //lbPosfixa.Visible = true;
            //string infixa = pilha.ParaInfixa(txtVisor.Text); 
            string texto = txtVisor.Text; //DEclaração da variável local responsável por guardar o valor da sequência digitada pelo usuário

            lbInfixa.Visible = true;  //Código que torna o label que exibirá a sequência infixa visível
            
            string infixa = pilha.ParaInfixa(texto);   //Transforma a sequência digitada pelo usuário, de números para letras, com cada letra representando um número escolhido         


            if (infixa == null) //Caso a sequência digitada esteja desordenada, com parênteses a mais ou a menos
            {
                MessageBox.Show("Verifique se a sequência está correta.", "Erro!"); //Caso a sequência seja inválida, o método retornará null
                txtVisor.Clear(); //Código que apaga a sequência errada digitada pelo usuário, deixando o txtVisor livre para uma nova sequência
                txtResultado.Clear();
                lbInfixa.Text = "";
                lbPosfixa.Text = "";
            }               
            else 
            {
                lbInfixa.Text = infixa; //Caso a sequência seja válida, atribuimos ao lbInfixa o  valor da sequência infixa, na qual cada número é substituido por uma letra
                lbPosfixa.Visible = true; //Código que torna o label que exibirá a sequência posfixa visível
                lbPosfixa.Text = pilha.ParaPosfixa(texto); //Atribuimos ao lbPosfixa o  valor da sequência posfixa, a qual(baseada no vetor infixo) retorna uma sequência posfixa, onde os números são também substituidos por letras
                txtResultado.Text = pilha.Resolver(texto); //Atribuimos ao txtResultado o valor do resultado da conta da sequência dada 
            }                        
        }        

        private void txtVisor_KeyPress(object sender, KeyPressEventArgs e)//Método chamado sempre que o usuário pressiona alguma tecla do teclado
        {//Como estamos lidando com uma sequência matemática, nela não podem existir algarismos que não sejam ou letra ou sinal
            if (!(Char.IsNumber(e.KeyChar)) && !pilha.SeEhSinal((e.KeyChar).ToString())) //Código que verifica a natureza do char digitado(se é número, letra, sinal ou outro símbolo)
                e.Handled = true; //Caso o caractere seja válido, ele pode ser escrito na tela; caso contrário, ele não é exibido
        }

        private void FrmCalculadora_Load_1(object sender, EventArgs e)
        {
            pilha = new Expressao(); //Instanciamos uma pilha
        }
    }
}
