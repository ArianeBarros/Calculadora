﻿using System;
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
        string[] vetor;
        //  A   B   C   D    E   F   G   H   I  J   K
        public Expressao()
        {
            vetInfixo = new string[26];
            pilha = new PilhaHerdaLista<string>();
        }

        public string ParaPosfixa(string expressaoInfixa)
        {
            string posfixa = "";
            vetor = new string[26];
            int qtd = 0;

            if (!VerificarParenteses(expressaoInfixa))
                return null;

            if (expressaoInfixa[0] == '-')
            {
                vetor[qtd] = "@";
                qtd++;
            }

            for (int i = 0; i < expressaoInfixa.Length; i++)
            {
                if (!SeEhSinal(expressaoInfixa[i])) //é número
                {
                    int posicaoInicial = i;
                    string num = "";
                    while (i + num.Length < expressaoInfixa.Length && !SeEhSinal(expressaoInfixa[i]))
                        num += expressaoInfixa[i++];

                    vetor[qtd] = num;
                    qtd++;
                    i = posicaoInicial + num.Length - 1;
                }
                else
                {                    
                    while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), expressaoInfixa[i] + ""))
                    {
                        vetor[qtd] = pilha.Desempilhar();
                        qtd++;
                    }
                    pilha.Empilhar(expressaoInfixa[i] + "");
                }
            }
            for (int l = qtd; !pilha.EstaVazia(); l++)
            {
                vetor[l] = pilha.Desempilhar();
                qtd++;
            }

            for (int indice = 'A'; indice - 'A' < qtd; indice++)
            {
                //if (vetor[indice - 'A'] != null)
                //{
                    if (SeEhSinal(Convert.ToChar(vetor[indice - 'A'])) || vetor[indice -'A'] == "@")
                        posfixa += vetor[indice - 'A'];
                    else
                        posfixa+= Convert.ToChar(indice);
               // }
            }
            //string a = "";
            //expressaoInfixa = posfixa;
            //for (int l = 0; l < qtd; l++)
            //{
            //    a += expressaoInfixa[l];
            //}
            return posfixa;

            //string[] posfixa = new string[26];
            //vetor = new string[26];
            //int qtd = 0;

            //if (!VerificarParenteses(expressaoInfixa))
            //    return null;

            //for (int i = 0; i < qtdinfos; i++)
            //{
            //    if (i < qtdinfos && expressaoInfixa[i].CompareTo("0") >= 0 && expressaoInfixa[i].CompareTo("9") <= 0) //é número
            //    {
            //        int posicaoInicial = i;
            //        string num = "";
            //        while (i + num.Length < qtdinfos && expressaoInfixa[i].CompareTo("0") >= 0 && expressaoInfixa[i].CompareTo("9") <= 0)
            //            num += expressaoInfixa[i++];

            //        vetor[qtd] = num;
            //        qtd++;
            //        i = posicaoInicial + num.Length - 1;
            //    }
            //    else
            //    {
            //        while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), expressaoInfixa[i] + ""))
            //        {
            //            vetor[qtd] = pilha.Desempilhar();
            //            qtd++;
            //        }
            //        pilha.Empilhar(expressaoInfixa[i] + ""); // +* -
            //    }

            //}
            //for (int l = qtd; !pilha.EstaVazia(); l++)
            //{
            //    vetor[l] = pilha.Desempilhar();
            //    qtd++;
            //}
            //int k = 0;
            //int w = 0; //contador pra o vetor de números
            //for (int indice = 'A'; indice - 'A' < qtdinfos; indice++)
            //{
            //    if (vetor[indice - 'A'] != null)
            //    {
            //        if (SeEhSinal(Convert.ToChar(vetor[indice - 'A'])))
            //            posfixa[k] += vetor[indice - 'A'];
            //        else
            //        {

            //            nume[w] = posfixa[k];
            //            w++;
            //            posfixa[k] += Convert.ToChar(indice);
            //        }

            //        k++;

            //    }

            //}
            //string a = "";
            //expressaoInfixa = posfixa;
            //for (int l = 0; l < qtd; l++)
            //{
            //    a += expressaoInfixa[l];
            //}
            //return a;
        }

        public string ParaInfixa(string expressaoInfixa)
        {
            string infixa = "";
            int qtd = 0;
            int a = 0;

            if (expressaoInfixa[0] == '-')
            {
                a++;
                infixa += "@";
            }                

            for (int i = a; i < expressaoInfixa.Length; i++)
            {
                if (!SeEhSinal(expressaoInfixa[i])) //é número
                {
                    int posicaoInicial = i;
                    string num = "";
                    while (i + num.Length < expressaoInfixa.Length && !SeEhSinal(expressaoInfixa[i]))
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

            for (int indice = 'A'; indice - 'A' < qtd; indice++)
            {
                if (SeEhSinal(Convert.ToChar(vetInfixo[indice - 'A'])))
                    infixa += vetInfixo[indice - 'A'];
                else
                    infixa += Convert.ToChar(indice);
            }

            return infixa;
        }

        //public string ParaInfixa(string[] expressaoInfixa, int qtdinfos)
        //{
        //    string[] infixa = new string[26];
        //    int k = 0;

        //    for (int indice = 'A'; indice - 'A' < qtdinfos; indice++)
        //    {
        //        if (vetor[indice - 'A'] != null)
        //        {
        //            infixa[k] += vetor[indice - 'A'];
        //            infixa[k] += Convert.ToChar(indice);

        //            k++;
        //        }
        //    }
        //    string a = "";
        //    expressaoInfixa = infixa;
        //    for (int l = 0; l < qtdinfos; l++)
        //    {
        //        a += expressaoInfixa[l];
        //    }
        //    return a;
        //}

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
            PilhaHerdaLista<string> pilhaResult = new PilhaHerdaLista<string>();

            if (!VerificarParenteses(expressao))
                return null;

            for (int indice = 'A'; indice - 'A' < expressao.Length; indice++)
            {
                if (SeEhSinal(Convert.ToChar(vetInfixo[indice - 'A'])))
                {
                    while(!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice - 'A']))
                    {
                        double a = double.Parse(pilhaResult.Desempilhar());
                        double b = double.Parse(pilhaResult.Desempilhar());
                        string sinal = pilha.Desempilhar();

                        pilhaResult.Empilhar(ResolverOperacao(a,b,sinal));
                    }
                    pilha.Empilhar(vetInfixo[indice - 'A']);
                }
                else
                    pilhaResult.Empilhar(vetInfixo[indice - 'A']);
            }
            
            return pilhaResult.Desempilhar();
        }

        public string ResolverOperacao(double a, double b, string s)
        {
            string result = "";

            return result;
        }

        //public string Resolver(string expressaoPosfixa)
        //{
        //    string posfixa = expressaoPosfixa;
        //    PilhaHerdaLista<string> p = new PilhaHerdaLista<string>();
        //    double resultado = 0;
        //    int k = 0;

        //    for (int i = 0; i < posfixa.Length; i++)
        //    {
        //        if (!SeEhSinal(posfixa[i]))
        //        {
        //            if (posfixa[i] == '@')
        //                p.Empilhar((double.Parse(p.Desempilhar()) * -1).ToString());
        //            else
        //                p.Empilhar(nume[k]);
        //            k++;
        //        }
        //        else
        //        {
        //            double operando1 = double.Parse(p.Desempilhar());
        //            double operando2 = double.Parse(p.Desempilhar());

        //            p.Empilhar(SubExpressao(operando1, operando2, posfixa[i]));
        //        }
        //    }
        //    return p.Desempilhar();
        //}

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
        //string result = "";
        //char sinal = ' ';
        //double? a, b = null;

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

        // return result;


        public string ResolverUmaParte(double? a, double? b, char sinal)
        {
            if (a == null || b == null)
                return null;

            string result = "";
            return result;
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