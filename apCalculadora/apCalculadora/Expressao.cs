using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCalculadora
{
    public class Expressao
    {
        PilhaHerdaLista<string> pilha;
        string[] vetInfixo;
        //  0   1   2   3    4   5   6   7   8  9  10
        string[] vetorPosfixo;
        //  A   B   C   D    E   F   G   H   I  J   K

        int qtd = 0;
        public Expressao()
        {
            vetInfixo = new string[26];
            pilha = new PilhaHerdaLista<string>();
        }

        public string ParaPosfixa(string expressaoInfixa)
        {
            string posfixa = "";

            if (!VerificarParenteses(expressaoInfixa))
                return null;

            char letra = 'A';

            for (int indice = 0; indice < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice]) || vetInfixo[indice] == "@")
                {
                    while(!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice]))
                    {
                        posfixa += pilha.Desempilhar();
                    }
                    pilha.Empilhar(vetInfixo[indice]);                    
                }                  
                else
                {
                    posfixa += letra;
                    letra++;
                }
                  
            }

            for (int l = qtd; !pilha.EstaVazia(); l++)
            {
                posfixa += pilha.Desempilhar();
            }

            return posfixa;
        }

        public string ParaInfixa(string expressaoInfixa)
        {
            string infixa = "";
            qtd = 0;

            if (expressaoInfixa[0] == '-')
            {
                vetInfixo[qtd] = "@";
                qtd++;
            }                

            for (int i = qtd; i < expressaoInfixa.Length; i++)
            {
                if (!SeEhSinal(expressaoInfixa[i] + "")) //é número
                {
                    int posicaoInicial = i;
                    string num = "";
                    while (posicaoInicial + num.Length < expressaoInfixa.Length && !SeEhSinal(expressaoInfixa[i] + ""))
                        num += expressaoInfixa[i++];

                    vetInfixo[qtd] = num;
                    qtd++;
                    i = posicaoInicial + num.Length - 1;
                }
                else
                {
                    vetInfixo[qtd] = expressaoInfixa[i] + "";
                    qtd++;
                }
            }

            char letra = 'A';
            for (int indice = 0; indice  < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice]))
                    infixa += vetInfixo[indice];
                else
                {
                    infixa += letra;
                    letra++;
                }
                   
            }            

            return infixa;
        }
        

        public bool SeEhSinal(string s)
            {
            bool ehsinal = false;

            if (s == "+" || s == "-" || s == "/" || s == "*" || s == "^" || s == "(" || s == ")")
                ehsinal = true;

            return ehsinal;
        }

        public bool SeTemPreferencia(string empilhado, string emComparacao)
        {
            if (empilhado == emComparacao)
                return false;

            if (empilhado == ")")
                return false;

            if (empilhado == "(")
            {
                if (emComparacao != ")")
                    return true;
                return false;
            }

            if (empilhado == "^")
            {
                if (emComparacao == "(")
                    return false;
                return true;
            }

            if (empilhado == "*" || empilhado == "/")
            {
                if (emComparacao == "(" || emComparacao == "^")
                    return false;

                return true;
            }

            if (empilhado == "+" || empilhado == "-")
            {
                if (emComparacao == "+" || emComparacao == "-" || emComparacao == ")")
                    return true;
                return false;
            }
            return false;
        }

        public string Resolver(string expressao)
        {
            PilhaHerdaLista<string> pilhaResult = new PilhaHerdaLista<string>();

            if (!VerificarParenteses(expressao))
                return null;

            for (int indice = 0; indice  < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice] + ""))
                {
                    while(!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice] + ""))
                    {
                        double b = double.Parse(pilhaResult.Desempilhar());
                        double a = double.Parse(pilhaResult.Desempilhar());
                        string sinal = pilha.Desempilhar();

                        pilhaResult.Empilhar(SubExpressao(a,b,Convert.ToChar(sinal)));
                    }
                    pilha.Empilhar(vetInfixo[indice] + "");
                }
                else                    
                {
                    pilhaResult.Empilhar(vetInfixo[indice]);
                }                   
            }

            while(!pilha.EstaVazia())
            {
                double b = double.Parse(pilhaResult.Desempilhar());
                double a = double.Parse(pilhaResult.Desempilhar());
                string sinal = pilha.Desempilhar();

                pilhaResult.Empilhar(SubExpressao(a, b,Convert.ToChar(sinal)));
            }
            
            return pilhaResult.Desempilhar();
        }

        public string SubExpressao(double op1, double op2, char sinal)
        {
            switch (sinal)
            {
                case '+': return (op1 + op2).ToString();
                case '-': return (op1 - op2).ToString();
                case '*': return (op1 * op2).ToString();
                case '/': return (op1 / op2).ToString();
                case '^': return (Math.Pow(op1, op2)).ToString();
                default: return null;
            }
        }

        public bool VerificarParenteses(string expressao) //usar no form
        {
            PilhaHerdaLista<string> parenteses = new PilhaHerdaLista<string>();

            foreach (var a in expressao)
                if (a == '(')
                    parenteses.Empilhar(a + "");
                else if (a == ')')
                {
                    try
                    {
                        parenteses.Desempilhar();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            if (!parenteses.EstaVazia())
                return false;

            return true;
        }
    }
}