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
                    //  0   1   2   3    4   5   6   7   8  9  10
        string[] vetor;
                    //  A   B   C   D    E   F   G   H   I  J   K
        public Expressao()
        {
            pilha = new PilhaHerdaLista<string>();
        }

        public string ParaPosfixa(string expressaoInfixa)
        {
            string posfixa = "";
            vetor = new string[26];
            int qtd = 0;

            if (!VerificarParenteses(expressaoInfixa))
                return null;

            for (int i = 0; i < expressaoInfixa.Length; i++)
            {
                if (i < expressaoInfixa.Length && expressaoInfixa[i] >= '0' && expressaoInfixa[i] <= '9') //é número
                {
                    int posicaoInicial = i;
                    string num = "";
                    while (i + num.Length < expressaoInfixa.Length && expressaoInfixa[i] >= '0' && expressaoInfixa[i] <= '9')
                        num += expressaoInfixa[i++];

                    vetor[qtd] = num;
                    qtd++;
                    i = posicaoInicial + num.Length - 1;
                }
                else
                ,{
                    if (pilha.EstaVazia())
                        pilha.Empilhar(expressaoInfixa[i]+"");
                    else
                    { 
                        while(!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), expressaoInfixa[i] + ""))
                        {
                            vetor[qtd] = pilha.Desempilhar();
                            qtd++;
                        }
                        pilha.Empilhar(expressaoInfixa[i] + "");
                    }
                }

            }
            for(int l = qtd; !pilha.EstaVazia(); l++)
            {
               vetor[l] = pilha.Desempilhar();
                qtd++;
            }

            for (int indice = 'A'; indice - 'A' < vetor.Length; indice++) // 
            {

                if (vetor[indice - 'A'] != null) //vetor[indice- 'A'] != 0
                {
                    if(SeEhSinal(Convert.ToChar(vetor[indice - 'A'])))
                        posfixa += vetor[indice - 'A'];
                    else
                        posfixa += Convert.ToChar(indice);

                }
                   
            }

            expressaoInfixa = posfixa;

            return expressaoInfixa;
        }

        public bool SeEhSinal(char s)
        {
            bool ehsinal = false;

            if (s == '+' || s == '-' || s == '/' || s == '*' || s == '^')
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
                if (emComparacao != "(")
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
            string result = "";
            char sinal = ' ';
            double? a, b = null;
            


            //for(int i = 0; i < expressao.Length; i++)
            //{
            //    if(SeEhSinal(expressao[i]))
            //    {
            //        if (sinal == ' ')
            //        {
            //            sinal = expressao[i];
            //            pilha.Empilhar(expressao[i] + "");
            //        }                        
            //        else //vemos a preferencia
            //        {
            //            if (SeTemPreferencia(pilha.OTopo(), expressao[i] + ""))
            //            {
            //                //resolver
            //                sinal = Convert.ToChar(pilha.OTopo());
            //                if (sinal == '*')
            //                    result = "" + (a * b);
            //            }
            //            else
            //                pilha.Empilhar(expressao[i] + "");
            //        }
            //    }
            //    else
            //        while (i != expressao.Length && expressao[i] >= '0' && expressao[i] <= '9') //é número
            //        {
            //            int posicaoInicial = i;
            //            string num = "";
            //            while (i + num.Length < expressao.Length && expressao[i] >= '0' && expressao[i] <= '9')
            //                num += expressao[i++];

            //            if (a == null)
            //                a = double.Parse(num);
            //            else
            //                b = double.Parse(num);
            //        }

            //}

            return result;
        }

        public string ResolverUmaParte(double? a, double? b, char sinal)
        {
            if (a == null || b == null)
                return null;

            string result = "";





            return result;
        }

       
        public bool VerificarParenteses(string expressao) //usar no form
        {
            PilhaHerdaLista<char> parenteses = new PilhaHerdaLista<char>();

            foreach (var a in expressao)
                if (a == '(')
                    parenteses.Empilhar(a);
                else if (a == ')')
                {
                    try
                    {
                        parenteses.Desempilhar();
                    }
                    catch(Exception)
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