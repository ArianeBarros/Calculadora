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

        public string ParaPosfixa(string expressaoInfixa)
        {
            string posfixa = "";
            int cont = 2;
            string sinal = "";
                        
                foreach (var a in expressaoInfixa)
                {
                    if (a >= '0' && a <= '9')
                    {
                        if (cont % 2 == 0 && sinal == "") //se for for 
                            posfixa += a;
                        else
                        {
                            posfixa += a + sinal;
                            sinal = "";
                        }
                    }
                    else
                    {
                        if (a == '+' || a == '-' || a == '/' || a == '*' || a == '^') //É sinal
                        {
                             sinal = a + "";

                            if(pilha.EstaVazia())
                                 pilha.Empilhar(a + "");

                            if(SeTemPreferencia(pilha.OTopo(), a + ""))//Verifica se oq está empilhado tem preferencia
                            {
                                  posfixa += pilha.Desempilhar(); 
                            }
                            pilha.Empilhar(a + "");
                        }
                    }

                }

                return posfixa;
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

            if(empilhado == "*" || empilhado == "/")
            {
                if (emComparacao == "(" || emComparacao == "^")
                    return false;

                return true;
            }

            if(empilhado == "+" || empilhado == "-")
            {
                if (emComparacao == "+" || emComparacao == "-" || emComparacao == ")")
                    return true;

                return false;
            }

            return false;//ou n seiii
        }

        //public string ParaPosfixa(string expressaoInteira)
        //{
        //    string pos = "";
        //    char ultimoCaractere = ' ';
        //    int contSinal = 0;
        //    int qtdCarac = 0;

        //    while(qtdCarac != expressaoInteira.Length)
        //    {
        //        while (contSinal != 2)
        //        {
        //            foreach (var c in expressaoInteira)
        //            {
        //                if (c == '+' || c == '-' || c == '/' || c == '*' || c == '^')
        //                    contSinal++;
        //                else
        //                    ultimoCaractere = c;

        //                qtdCarac++;
        //            }                       
        //        }
        //        string aux = expressaoInteira.Split(ultimoCaractere)[0];
        //        pos += UmaParteParaPosfixa(aux);
        //    }         

        //    return pos;
        //}

        //public string UmaParteParaPosfixa(string str)
        //{
        //    string posfixa = "";
        //    string operadorA = "";
        //    string operadorB = "";
        //    string sinal = "";

        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        if (str[i] >= '0' && str[i] <= '9')//Se for número
        //        { 
        //            if (operadorA == "")
        //            {
        //                operadorA = str[i] + "";
        //                posfixa += operadorA;
        //            }
        //            else
        //            {
        //                if (sinal == "") //não achamos um sinal ainda
        //                {
        //                    posfixa = "";
        //                    operadorA += str[i] + "";
        //                    posfixa += operadorA;
        //                }
        //                else //já achamos um sinal, portanto o próximo valor será o operador B
        //                {
        //                    if(sinal == ",")
        //                    {
        //                        operadorA += str[i] + "";
        //                        posfixa = operadorA;
        //                        sinal = "";
        //                    }

        //                    if (i < str.Length - 1)
        //                    {
        //                        if (operadorB == "")
        //                            operadorB = str[i] + "";
        //                        else
        //                        {
        //                            posfixa = operadorA;
        //                            operadorB += str[i] + "";
        //                        }
        //                        posfixa += operadorB;
        //                    }
        //                    else //a sequencia string vai acabar
        //                    {
        //                        if (operadorB == "")
        //                            operadorB = str[i] + "";
        //                        else
        //                        {
        //                            posfixa = operadorA;
        //                            operadorB += str[i] + "";
        //                        }
        //                        posfixa += operadorB + sinal;
        //                        operadorA = "";
        //                        operadorB = "";
        //                        sinal = "";
        //                    }
        //                }
        //            }
        //        }
        //        else
        //            if (str[i] >= 'A' && str[i] <= 'Z') //se não for sinal
        //            {
        //                //ueee
        //            }
        //            else
        //                if (sinal == "")
        //                {
        //                    if (sinal == ",")
        //                    {
        //                        operadorA += ",";
        //                        posfixa += ",";
        //                    }                                
        //                    else
        //                        sinal = str[i] + "";
        //                }
        //                else //outra sequencia vai começar
        //                {
        //                    if (operadorB == "")
        //                        operadorB = "0";
                                                       
        //                    posfixa += operadorB + sinal;
        //                    operadorA = "";
        //                    operadorB = "";
        //                    sinal = "";
        //                }
        //    }

        //    return posfixa;
        //}
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

        //public string ResolverUmaOperacao(string a, string b,string s)
        //{
            //double? re = null;

            ////re = a + s + b;

            //if (s == "+")
            //    re = double.Parse(a) + double.Parse(b);
            //else
            //{
            //    if(s == "-")
            //        re = double.Parse(a) - double.Parse(b);
            //    else
            //    {
            //        if(s == "/")
            //            re = double.Parse(a) / double.Parse(b);
            //        else
            //        {
            //            if(s == "*")
            //                re = double.Parse(a) * double.Parse(b);
            //            else
            //            {
            //                if (s == "^")
            //                {
            //                    double v = double.Parse(a);
            //                    v = Math.Exp(double.Parse(b));
            //                    re = v;
            //                }                            
            //            }
            //        }
            //    }
            //}

            //return re + "";
        //}

        public bool EstaEmOrdem(PilhaHerdaLista<string> pilha) //Verificar se não tem sinal seguido de sinal e se todos os parênteses foram abertos e fechados igualmente
        {
            bool estaOrdenada = false;

            return estaOrdenada;
        }        
    }
}