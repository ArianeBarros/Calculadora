using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCalculadora
{
    public class Expressao
    {
        /*
        Função da classeeee
        */
        PilhaHerdaLista<string> pilha;

        string[] vetInfixo;  //Declaração do vetor infixo, que deve ser global porque é usado em mais de um método
        string[] vetorPosfixo;  //Declaração do vetor infixo, que deve ser global porque é usado em mais de um método
        int qtdParenteses = 0;

        int qtd = 0;//Variável que guarda a quantidade de valores que são guardados no vetor infixo. Não pode ser local, pois usamos seu valor em quase todos os métodos, já que os vetores usados têm um tamanho de 26 posições. 
        public Expressao() //Construtor padrão da classe Expressao
        {
            vetInfixo = new string[26]; //Instanciação do vetor infixo
            vetorPosfixo = new string[26]; //Instanciação do vetor infixo
            pilha = new PilhaHerdaLista<string>(); //Instanciação da pilha
        }
        public string ParaPosfixa(string expressaoInfixa)
        {
            string posfixa = "";
            int a = 0;

            if (expressaoInfixa[0] == '-')
                posfixa += "s";

            char letra = 'A';

            for (int indice = a; indice < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice]))
                {
                    if (indice != 0 || vetInfixo[indice] == "(")
                    {
                        if (vetInfixo[indice] == ")")
                        {
                            while (pilha.OTopo() != "(")
                            {
                                var aux = pilha.Desempilhar();
                                posfixa += aux;
                                vetorPosfixo[a] = aux;
                                a++;
                            }
                            pilha.Desempilhar();
                        }
                        else
                        {
                            while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice]))
                            {
                                var aux = pilha.Desempilhar();
                                if (vetInfixo[indice] != "(")
                                {
                                    posfixa += aux;
                                    vetorPosfixo[a] = aux;
                                    a++;
                                }
                            }
                            pilha.Empilhar(vetInfixo[indice]);
                        }
                    }
                }
                else
                {
                    if (posfixa != "" && indice == 1)
                    {
                        posfixa = letra + "-";
                        vetorPosfixo[a] = vetInfixo[indice];
                        vetorPosfixo[++a] = "@";
                        letra++;
                        a++;
                    }
                    else
                    {
                        posfixa += letra;
                        letra++;
                        vetorPosfixo[a] = vetInfixo[indice];
                        a++;

                    }

                }
            }

            for (int l = qtd; !pilha.EstaVazia(); l++)
            {
                var aux = pilha.Desempilhar();
                if (aux != "(")
                {
                    posfixa += aux;
                    vetorPosfixo[a] = aux;
                    a++;
                }

            }
            qtd = qtd - qtdParenteses; //Diminuimos 2 na variavel qtd porque os dois parenteses lidos não foram adicionados no vetorPosfixo, que será usado no método Resolver(), portanto deve estar com sua qtd atualizada

            return posfixa;
        }
        public string ParaInfixa(string expressaoInfixa)
        {
            string infixa = ""; //Variável local que retorna a sequência infixa, com seus números trocados por letras
            qtd = 0;

            expressaoInfixa = Ordenar(expressaoInfixa);

            if (!VerificarParenteses(expressaoInfixa)) //Verificação da ordem dos parenteses, caso estaja desordenada, não convertemos a expressao, retornamos null, assim uma mensagem de erro é exibida para o usuário
                return null;


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
            for (int indice = 0; indice < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice]))
                {
                    if(vetInfixo[indice] == "@")
                        infixa += '-';
                    else if (vetInfixo[indice] != ")" && vetInfixo[indice] != "(")
                        infixa += vetInfixo[indice];
                    else
                        qtdParenteses++;
                }
                else
                {
                    infixa += letra;
                    letra++;
                }
            }
            return infixa;
        }

        public string Resolver(string expressaoPos)//73+2*
        {
            PilhaHerdaLista<string> pilhaResult = new PilhaHerdaLista<string>();

            for (int indice = 0; indice < qtd; indice++)
            {
                if (SeEhSinal(vetorPosfixo[indice] + ""))
                {
                    string sinal = vetorPosfixo[indice];
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
                else
                {
                    pilhaResult.Empilhar(vetorPosfixo[indice]);
                }
            }
            return pilhaResult.Desempilhar();
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
            if (empilhado == ")")
                return false;

            if (empilhado == "(")
            {
                if (emComparacao == ")")
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

        public string Ordenar(string exp)
        {
            string ordenada = exp;
            for (int i = 1; i < exp.Length; i++)
            {
                if (SeEhSinal(exp[i] + "") && SeEhSinal(exp[i - 1] + ""))
                
            }
            return ordenada;
        }

        public bool VerificarParenteses(string expressao) //Método bool que verifica se os parenteses de uma sequencia estão ordenados
        {
            PilhaHerdaLista<string> parenteses = new PilhaHerdaLista<string>(); //instanciação da pilha parenteses, que, como o nome informa, nunca guardará algo que não seja abre ou fecha parenteses

            foreach (var a in expressao) //Percorre caractere por caractere da string passada por parâmetro
                if (a == '(')  //Verifica se o caractere atual é um abre parenteses; se não for, lemos o próximo caractere
                    parenteses.Empilhar(a + ""); //Empilhamos o abre parenteses sempre que o achamos
                else if (a == ')') //Verifica se o caractere atual é um fecha parenteses; se não for, lemos o próximo caractere
                {
                    try
                    {
                        parenteses.Desempilhar(); //Caso consiga desempilhar, significa que a pilha não está vazia, logo sabemos que tem um abre parenteses referente ao fecha parenteses lido nessa posiçao da string, portanto está em ordem, e continuamos a percorre-la
                    }
                    catch (Exception) //Se tentarmos desempilhar algo de uma pilha vazia, uma exceção é lançada
                    {
                        return false;  //Caso não consiga desempilhar um fecha parenteses referente à um abre parenteses, a sequencia não está ordenada, portanto retornamos false
                    }
                }
            if (!parenteses.EstaVazia()) //Se a pilha parenteses não estiver vazia, então a sequencia fornecida por parametro tem mais fecha parenteses do que abre parenteses, portanto não está ordenada
                return false; //Retornamos false se a sequencia não está ordenada

            return true;  //Retornamos true se a sequencia está ordenada
        }

        public void Resetar()
        {
            for (int i = 0; !pilha.EstaVazia() && i < qtd; i++)
            {
                pilha.Desempilhar();
                vetInfixo[i] = null;
                vetorPosfixo[i] = null;
            }
            qtdParenteses = 0;
            qtd = 0;
        }
    }
}