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
            vetorPosfixo = new string[26];
            pilha = new PilhaHerdaLista<string>();
        }

        public string ParaPosfixa(string expressaoInfixa)
        {
            string posfixa = "";
            int a = 0;

            if (!VerificarParenteses(expressaoInfixa))
                return null;

            if (expressaoInfixa[0] == '-')
            {
                posfixa += "@";
                vetorPosfixo[a] = "@";
                a++;
            }

            char letra = 'A';

            for (int indice = a; indice < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice]))
                {
                    while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice]))
                    {
                        var aux = pilha.Desempilhar();
                        if (vetInfixo[indice] != ")" && vetInfixo[indice] != "(")
                            posfixa += aux;
                        vetorPosfixo[indice] = aux;
                    }
                    pilha.Empilhar(vetInfixo[indice]);
                }
                else
                {
                    posfixa += letra;
                    letra++;
                    vetorPosfixo[indice] = vetInfixo[indice];                                    
                }
            }

            for (int l = qtd; !pilha.EstaVazia(); l++)
            {
                var aux = pilha.Desempilhar();
                posfixa += aux;
                vetorPosfixo[l] = aux;
            }

            return posfixa;
            
        }


        public string ParaInfixa(string expressaoInfixa)
        {
            string infixa = "";
            qtd = 0;

           expressaoInfixa = Ordenar(expressaoInfixa);

            if (!VerificarParenteses(expressaoInfixa))
                return null;

            if (expressaoInfixa[0] == '-')
            {
                vetInfixo[qtd] = "@";
                qtd++;
            }
            else
                if (expressaoInfixa[0] == '+')
            {
                //faz alguma coisa
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
                {
                    if(vetInfixo[indice] != ")" && vetInfixo[indice] != "(")
                      infixa += vetInfixo[indice];
                }                    
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

            if (s == "+" || s == "-" || s == "/" || s == "*" || s == "^" || s == "(" || s == ")" || s == "@")
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
            return true;
        }

        public string Resolver(string expressao)
        {
            PilhaHerdaLista<string> pilhaResult = new PilhaHerdaLista<string>();

            if (!VerificarParenteses(expressao))
                return null;

            for (int indice = 0; indice < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice] + ""))
                {
                    while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice] + ""))
                    {
                        string sinal = pilha.Desempilhar();
                        double b = double.Parse(pilhaResult.Desempilhar());
                        
                        if (sinal != "@")
                        {
                            if (sinal != ")" && sinal != "(")
                            {
                                double a = double.Parse(pilhaResult.Desempilhar());
                                pilhaResult.Empilhar(SubExpressao(a, b, Convert.ToChar(sinal)));
                            }                           
                        }
                        else
                        {
                            if (sinal == "@")
                            {
                                double result = -b;
                                pilhaResult.Empilhar(result + "");
                            }
                        }
                        
                    }
                    pilha.Empilhar(vetInfixo[indice] + "");
                }
                else
                {
                    pilhaResult.Empilhar(vetInfixo[indice]);
                }
            }

            while (!pilha.EstaVazia())
            {
                string sinal = pilha.Desempilhar();
                double b = double.Parse(pilhaResult.Desempilhar());

                if (sinal != "@")
                {
                    double a = double.Parse(pilhaResult.Desempilhar());
                    pilhaResult.Empilhar(SubExpressao(a, b, Convert.ToChar(sinal)));
                }
                else
                {
                    if (sinal == "@")
                    {
                        double result = -b;
                        pilhaResult.Empilhar(result + "");
                    }
                }
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

        public string Ordenar(string exp)  //ARRUMAR
        {
            string ordenada = exp;
            for(int i = 0; i < exp.Length; i++)
            {
                if(SeEhSinal(exp[i] + ""))
                {
                    if(SeEhSinal(exp[i - 1] + ""))
                    {
                        if(exp[i - 1] == exp[i])
                        {
                            string[] aux = exp.Split(exp[i - 1]);
                            exp = exp.Split(exp[i])[0] + "(" + exp.Split(exp[i])[1] + ")";
                        }
                        else
                            if(exp[i - 1] != ')' && exp[i - 1] != '(' && exp[i] != ')' && exp[i] != '(')//tem erro na sequencia
                            {
                                string aux = ordenada.Substring(i);
                                ordenada = ordenada.Split(exp[i])[0] + "(" + aux + ")";
                            }
                    }
                }
            }

            return ordenada;
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