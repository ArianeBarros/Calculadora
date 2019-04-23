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
        public Expressao()
        {
            pilha = new PilhaHerdaLista<string>();
        }

        public string ParaPosfixa(string str)
        {
            string posfixa = "";
            string infixa = str;
            string operadorA = "";
            string operadorB = "";
            string sinal = "";

            for (int i = 0; i < infixa.Length; i++)
            {
                if (infixa[i] >= '0' && infixa[i] <= '9')//Se for número
                    if (operadorA == "")
                    {
                        operadorA = infixa[i] + "";
                        posfixa += operadorA;
                    }
                    else
                    {
                        if (sinal == "") //não achamos um sinal ainda
                        {
                            operadorA += infixa[i];
                            posfixa = posfixa.Split(posfixa[i--])[0];
                            posfixa += operadorA;
                        }
                        else //já achamos um sinal, portanto o próximo valor será o operador B
                        {
                            if (operadorB == "")
                            {
                                operadorB = infixa[i] + "";
                                posfixa += operadorB;
                            }
                            else
                            {
                                operadorB += infixa[i] + "";
                                posfixa = posfixa.Split(posfixa[i--])[0];
                                posfixa += operadorB + sinal;
                            }
                        }
                    }
                else
                    if (posfixa[i] >= 'A' && posfixa[i] <= 'Z') //se for sinal
                    {
                    //ueee
                    }
                else
                    if (sinal == "")
                    {
                        if (sinal == ",")
                            operadorA += ",";
                        else
                            sinal = posfixa[i] + "";
                    }
                    else
                    {
                        //uee
                    }
                    // }
            }
            return posfixa;
        }
        public void Resolver()
        {
            string posfixa = this.ToString();
            string operadorA = "";
            string operadorB = "";
            string sinal = "";

            for(int i = 0; i < posfixa.Length; i++)
            {
                if (posfixa[i] >= '0' && posfixa[i] <= '9')//Se for número
                    if (operadorA == "")
                    {
                        operadorA = posfixa[i] + "";
                        pilha.Empilhar(operadorA);
                    }                        
                    else
                    {
                        if (sinal == "") //não achamos um sinal ainda
                        {
                            operadorA += posfixa[i];
                            pilha.Desempilhar();
                            pilha.Empilhar(operadorA);
                        }                           
                        else //já achamos um sinal, portanto o próximo valor será o operador B
                        {
                            if (operadorB == "")
                            {
                                operadorB = posfixa[i] + "";
                                pilha.Empilhar(operadorB);
                            }                             
                            else
                            {
                                operadorB += posfixa[i] + "";
                                pilha.Desempilhar();
                                pilha.Empilhar(operadorB);
                                pilha.Empilhar(sinal);

                                sinal = pilha.Desempilhar();
                                operadorB = pilha.Desempilhar();
                                operadorA = pilha.Desempilhar();

                                pilha.Empilhar(ResolverUmaOperacao(operadorA, operadorB, sinal));
                            }                               
                        }
                    }
                else
                    if (!(posfixa[i] >= 'A') && !(posfixa[i] <= 'Z')) //se for sinal
                    {
                        if (sinal == "")
                        {
                            if(sinal == ",")
                                operadorA += ",";
                            else
                                sinal = posfixa[i] + "";
                        }
                        else
                        {
                           //uee
                        }                            
                    }               
            }
        }

        public string ResolverUmaOperacao(string a, string b,string s)
        {
            double? re = null;

            //re = a + s + b;

            if (s == "+")
                re = double.Parse(a) + double.Parse(b);
            else
            {
                if(s == "-")
                    re = double.Parse(a) - double.Parse(b);
                else
                {
                    if(s == "/")
                        re = double.Parse(a) / double.Parse(b);
                    else
                    {
                        if(s == "*")
                            re = double.Parse(a) * double.Parse(b);
                        else
                        {
                            if (s == "^")
                            {
                                double v = double.Parse(a);
                                v = Math.Exp(double.Parse(b));
                                re = v;
                            }                            
                        }
                    }
                }
            }

            return re + "";
        }

        public bool EstaEmOrdem(PilhaHerdaLista<string> pilha) //Verificar se não tem sinal seguido de sinal e se todos os parênteses foram abertos e fechados igualmente
        {
            bool estaOrdenada = false;

            return estaOrdenada;
        }        
    }
}