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
        int[] vetor;
                    //  A   B   C   D    E   F   G   H   I  J   K
        public Expressao()
        {
            pilha = new PilhaHerdaLista<string>();
        }

        public string ParaPosfixa(string expressaoInfixa)
        {
            char sinal = ' ';
            string posfixa = "";
            vetor = new int[26];

            if (!VerificarParenteses(expressaoInfixa))
                return null;

            for(int i = 0; i < expressaoInfixa.Length; i++)
            {
                if(expressaoInfixa[i] >= '0' && expressaoInfixa[i] <= '9') //é número
                {
                    int posicaoInicial = i;
                    string num = "";
                    while (i + num.Length < expressaoInfixa.Length && expressaoInfixa[i] >= '0' && expressaoInfixa[i] <= '9')
                        num += expressaoInfixa[i++];

                    vetor[i] += int.Parse(num);
                    i = posicaoInicial + num.Length;
                }
                while (expressaoInfixa[i] >= '0' && expressaoInfixa[i] <= '9') //é número
                {
                    vetor[i] += expressaoInfixa[i];
                    i++;
                }
                if(SeEhSinal(expressaoInfixa[i])) //é sinal
                {
                    if (SeTemPreferencia(pilha.OTopo(), expressaoInfixa[i] + "") && !pilha.EstaVazia())//Verifica se oq está empilhado tem preferencia
                    {
                        sinal = Convert.ToChar(pilha.Desempilhar());
                    }
                    else
                    {
                        pilha.Empilhar(expressaoInfixa[i] + "");
                    }
                }                
            }

            for(int indice = 0; indice < vetor.Length; indice++)
            {
                posfixa += (indice + 'A') + pilha.Desempilhar();
            }

            return posfixa;
        }

        public bool SeEhSinal(char s)
        {
            bool ehsinal = false;

            if (s == '+' || s == '-' || s == '/' || s == '*' || s == '^')
                ehsinal = true;

            return ehsinal;
        }

        //public string ParaPosfixa(string expressaoInfixa)
        //{
        //    string posfixa = "";
        //    string sinal = "";
        //    string aux = expressaoInfixa;


        //    foreach (var a in expressaoInfixa)
        //    {
        //        if (a >= '0' && a <= '9')
        //        {
        //            if (sinal == "") //se for for 
        //                posfixa += a;
        //            else
        //            {//1 + 12

        //                if(expressaoInfixa.Length - posfixa.Length > 2) //a sequencia nao acabou
        //                {
        //                    posfixa += a;
        //                }                         
        //                else
        //                {
        //                    posfixa += a;
        //                    while (!pilha.EstaVazia())
        //                        posfixa += pilha.Desempilhar();
        //                    sinal = "";
        //                }                        
        //            }
        //        }
        //        else 
        //            {
        //                if (a == '+' || a == '-' || a == '/' || a == '*' || a == '^' || a == ',') //É sinal
        //                {
        //                    if (a == ',')
        //                        posfixa += a + "";
        //                    else
        //                    {
        //                        sinal = a + "";

        //                        if (pilha.EstaVazia())
        //                            pilha.Empilhar(a + "");
        //                        else
        //                        {
        //                            if (SeTemPreferencia(pilha.OTopo(), a + ""))//Verifica se oq está empilhado tem preferencia
        //                            {
        //                                sinal = pilha.Desempilhar();
        //                            }
        //                            else
        //                            {
        //                                pilha.Empilhar(a + "");
        //                            }
        //                        }                                                               
        //                    }
        //                }
        //        }
        //    }
        //    return posfixa;
        //}

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

            return false;//ou n seiii
        }
               
        public string Resolver(string expressao)
        {
            string result = "";
            //string aux = ParaPosfixa(expressao);

            //string operadorA = "";
            //string operadorB = "";
            //string sinal = "";

            //string[] vetAux = aux.Split();

            //string posfixa = this.ToString();
            //string operadorA = "";
            //string operadorB = "";
            //string sinal = "";

            //for(int i = 0; i < posfixa.Length; i++)
            //{
            //    if (posfixa[i] >= '0' && posfixa[i] <= '9')//Se for número
            //        if (operadorA == "")
            //        {
            //            operadorA = posfixa[i] + "";
            //            pilha.Empilhar(operadorA);
            //        }                        
            //        else
            //        {
            //            if (sinal == "") //não achamos um sinal ainda
            //            {
            //                operadorA += posfixa[i];
            //                pilha.Desempilhar();
            //                pilha.Empilhar(operadorA);
            //            }                           
            //            else //já achamos um sinal, portanto o próximo valor será o operador B
            //            {
            //                if (operadorB == "")
            //                {
            //                    operadorB = posfixa[i] + "";
            //                    pilha.Empilhar(operadorB);
            //                }                             
            //                else
            //                {
            //                    operadorB += posfixa[i] + "";
            //                    pilha.Desempilhar();
            //                    pilha.Empilhar(operadorB);
            //                    pilha.Empilhar(sinal);

            //                    sinal = pilha.Desempilhar();
            //                    operadorB = pilha.Desempilhar();
            //                    operadorA = pilha.Desempilhar();

            //                    pilha.Empilhar(ResolverUmaOperacao(operadorA, operadorB, sinal));
            //                }                               
            //            }
            //        }
            //    else
            //        if (!(posfixa[i] >= 'A') && !(posfixa[i] <= 'Z')) //se for sinal
            //        {
            //            if (sinal == "")
            //            {
            //                if(sinal == ",")
            //                    operadorA += ",";
            //                else
            //                    sinal = posfixa[i] + "";
            //            }
            //            else
            //            {
            //               //uee
            //            }                            
            //        }               
            //}

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