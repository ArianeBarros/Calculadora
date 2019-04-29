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
        double[] vetor;
                    //  A   B   C   D    E   F   G   H   I  J   K
        public Expressao()
        {
            pilha = new PilhaHerdaLista<string>();
        }

        public string ParaPosfixa(string expressaoInfixa)
        {
            string posfixa = "";
            vetor = new double[26];
            int qtd = 0;
            int contSeNegativo = 0;

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

                    vetor[qtd] = double.Parse(num);
                    qtd++;
                    i = posicaoInicial + num.Length - 1;

                    contSeNegativo = 0;
                }
                else
                {
                    contSeNegativo++;
                    if (contSeNegativo == 2)
                    {
                        if(expressaoInfixa[i] == '+' || expressaoInfixa[i] == '-')
                        {
                            vetor[qtd] = '@';
                            qtd++;
                        }                             
                        else
                            if (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), expressaoInfixa[i] + ""))//Verifica se oq está empilhado tem preferencia
                            {
                                char sinal = Convert.ToChar(pilha.Desempilhar());
                                if (expressaoInfixa[i] != ')' && expressaoInfixa[i] != '(')
                                {
                                    pilha.Empilhar(expressaoInfixa[i] + "");
                                    pilha.Empilhar(sinal + "");
                                }
                            }
                            else
                            {
                                pilha.Empilhar(expressaoInfixa[i] + "");
                            }
                        contSeNegativo = 0;
                    }
                    else
                    {
                        if (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), expressaoInfixa[i] + ""))//Verifica se oq está empilhado tem preferencia
                        {
                            char sinal = Convert.ToChar(pilha.Desempilhar());
                            if (expressaoInfixa[i] != ')' && expressaoInfixa[i] != '(')
                            {
                                pilha.Empilhar(expressaoInfixa[i] + "");
                                pilha.Empilhar(sinal + "");
                            }
                        }
                        else
                        {
                            pilha.Empilhar(expressaoInfixa[i] + "");
                        }                       
                    }                   
                }                   
            }

            for (int indice = 'A'; indice - 'A' < vetor.Length; indice++) // 
            {
                if (vetor[indice - 'A'] != 0 && vetor[indice - 'A'] != 64) //vetor[indice- 'A'] != 0
                    posfixa += Convert.ToChar(indice); // + pilha.Desempilhar()
                else
                    if (vetor[indice - 'A'] == '@')
                    {
                        posfixa += "@";
                         
                    }                         
                else if(!pilha.EstaVazia())
                      posfixa += pilha.Desempilhar();                    
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
            
            for(int i = 0; i < vetor.Length && expressao.Length != 0; i++)
            {
                if(vetor[i] != '@' && vetor[i + 1] != '@')
                {
                    a = vetor[i];
                    b = vetor[i++];
                    sinal = '';
                    if(ResolverUmaParte(a, b, sinal) != null)

                }
                  
            }

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