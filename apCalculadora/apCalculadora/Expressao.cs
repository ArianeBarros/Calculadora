using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCalculadora
{
    public class Expressao
    {
        //Arrumar ordenar(), resover(), comentar e fazer relatorio
        /*
        Função da classeeee
        */
        PilhaHerdaLista<string> pilha;
        string[] vetInfixo;
        //  0   1   2   3    4   5   6   7   8  9  10
        string[] vetorPosfixo;
        //  A   B   C   D    E   F   G   H   I  J   K

        int qtd = 0;
        public Expressao()
        string[] vetInfixo;  //Declaração do vetor infixo, que deve ser global porque é usado em mais de um método
        string[] vetorPosfixo;  //Declaração do vetor infixo, que deve ser global porque é usado em mais de um método

        int qtd = 0;//Variável que guarda a quantidade de valores que são guardados no vetor infixo. Não pode ser local, pois usamos seu valor em quase todos os métodos, já que os vetores usados têm um tamanho de 26 posições. 
        public Expressao() //Construtor padrão da classe Expressao
        {
            vetInfixo = new string[26];
            vetorPosfixo = new string[26];
            pilha = new PilhaHerdaLista<string>();
            vetInfixo = new string[26]; //Instanciação do vetor infixo
            vetorPosfixo = new string[26]; //Instanciação do vetor infixo
            pilha = new PilhaHerdaLista<string>(); //Instanciação da pilha
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
                    if (vetInfixo[indice] == ")")
                    {
                        var aux = pilha.Desempilhar();
                        if (vetInfixo[indice] != ")" && vetInfixo[indice] != "(")
                        while (pilha.OTopo() != "(")
                        {
                            var aux = pilha.Desempilhar();
                            posfixa += aux;
                        vetorPosfixo[indice] = aux;
                    }
                    pilha.Empilhar(vetInfixo[indice]);
                    else
                    {
                        while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice]))
                        {
                            var aux = pilha.Desempilhar();
                            if (vetInfixo[indice] != "(")
                                posfixa += aux;

                            vetorPosfixo[a] = aux;
                            a++;
                        }

                        pilha.Empilhar(vetInfixo[indice]);
                    }

                }
                else
                {
                    posfixa += letra;
                    letra++;
                    vetorPosfixo[indice] = vetInfixo[indice];                                    
                    vetorPosfixo[a] = vetInfixo[indice];
                    a++;
                }
            }

            for (int l = qtd; !pilha.EstaVazia(); l++)
            {
                var aux = pilha.Desempilhar();
                posfixa += aux;
                vetorPosfixo[l] = aux;
                vetorPosfixo[a] = aux;
                a++;
            }

            return posfixa;
            
        }




        public string ParaInfixa(string expressaoInfixa)
        {
            string infixa = "";
            string infixa = ""; //Variável local que retorna a sequência infixa, com seus números trocados por letras
            qtd = 0;

           expressaoInfixa = Ordenar(expressaoInfixa);
            expressaoInfixa = Ordenar(expressaoInfixa);

            if (!VerificarParenteses(expressaoInfixa))
            if (!VerificarParenteses(expressaoInfixa)) //Verificação da ordem dos parenteses, caso estaja desordenada, não convertemos a expressao, retornamos null, assim uma mensagem de erro é exibida para o usuário
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
            //else
            //    if (expressaoInfixa[0] == '+')
            //    {
            //        //faz alguma coisa
            //    }

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
            for (int indice = 0; indice < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice]))
                {
                    if(vetInfixo[indice] != ")" && vetInfixo[indice] != "(")
                      infixa += vetInfixo[indice];
                }                    
                    if (vetInfixo[indice] != ")" && vetInfixo[indice] != "(")
                        infixa += vetInfixo[indice];
                }
                else
                {
                    infixa += letra;
                    letra++;
                }
                   
            }            

            }

            return infixa;
        }
        


        //public string ParaPosfixa(string expressaoInfixa)  //Função ParaPosfixa(), que recebe como parâmetro a sequência digitada pelo usuário
        //{
        //    string[] vetorPosfixo = new string[26]; //Declaração e instanciação do vetor posfixo, que não precisa ser global

        //    string posfixa = ""; //Variável local que retorna a sequência posfixa, com seus números trocados por letras
        //    int a = 0;

        //    //Não precisamos fazer a verificação da ordem dos parenteses aqui, pois já verificamos isso no método ParaInfixa(), chamado antes
        //    //if (!VerificarParenteses(expressaoInfixa)) 
        //    //    return null;

        //    if (expressaoInfixa[0] == '-') //Verifica se o primeiro caractere é um sinal negativo, caso seja, acrescentamos um @ na sequencia, que irá representa-lo na exibição
        //    {
        //        posfixa += "@";
        //        vetorPosfixo[a] = "@";
        //        a++;
        //    }

        //    char letra = 'A'; //char responsável por representar o número da posição atual, que começa 65, número que quando convertido representa a letra 'A'

        //    for (int indice = a; indice < qtd; indice++) //Loop que percorre cada posição ocupada no vetor, para substituirmos os números por letras
        //    {
        //        if (SeEhSinal(vetInfixo[indice])) //Caso a posição atual guarde um sinal
        //        {
        //            while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice]))
        //            {
        //                var aux = pilha.Desempilhar();
        //                if (vetInfixo[indice] != ")" && vetInfixo[indice] != "(")
        //                    posfixa += aux;
        //                vetorPosfixo[indice] = aux;
        //            }
        //            pilha.Empilhar(vetInfixo[indice]);
        //        }
        //        else //Caso a posição atual não guarde um sinal, guarda uma letra, portanto concatenamos seu valor à string posfixa
        //        {
        //            posfixa += letra; //Concatenação da letra correspondente ao valor atual
        //            letra++;//Adicionamos 1 na variável letra, assim ela representará a próxima letra do alfabeto
        //            vetorPosfixo[indice] = vetInfixo[indice];
        //        }
        //    }

        //    //Loop usado, por exemplo, quando uma sequencia tem apenas uma operação a ser feita(ou seja, tem apenas um sinal)
        //    for (int l = qtd; !pilha.EstaVazia(); l++) //Enquanto existir um sinal na pilha, não terminamos de converter a sequencia, portanto não saimos do loop
        //    {
        //        var aux = pilha.Desempilhar();
        //        posfixa += aux;
        //        vetorPosfixo[l] = aux;
        //    }

        //    return posfixa;             
        //}       

        public bool SeEhSinal(string s)
            {
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

        public string Resolver(string expressao)
        public string Resolver(string expressaoPos)
        {
            PilhaHerdaLista<string> pilhaResult = new PilhaHerdaLista<string>();

            if (!VerificarParenteses(expressao))
                return null;

            for (int indice = 0; indice < qtd; indice++)
            {
                if (SeEhSinal(vetInfixo[indice] + ""))
                if (SeEhSinal(vetorPosfixo[indice] + ""))
                {
                    while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice] + ""))
                    while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetorPosfixo[indice] + ""))
                    {
                        string sinal = pilha.Desempilhar();
                        double b = double.Parse(pilhaResult.Desempilhar());
                        

                        if (sinal != "@")
                        {
                            if (sinal != ")" && sinal != "(")
                            {
                                double a = double.Parse(pilhaResult.Desempilhar());
                                double a = double.Parse(pilhaResult.Desempilhar());// erro
                                pilhaResult.Empilhar(SubExpressao(a, b, Convert.ToChar(sinal)));
                            }                           
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
                    pilha.Empilhar(vetorPosfixo[indice] + "");
                }
                else
                {
                    pilhaResult.Empilhar(vetInfixo[indice]);
                    pilhaResult.Empilhar(vetorPosfixo[indice]);
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

        //public string Resolver(string expressao)
        //{
        //    PilhaHerdaLista<string> pilhaResult = new PilhaHerdaLista<string>();

        //    if (!VerificarParenteses(expressao))
        //        return null;

        //    for (int indice = 0; indice < qtd; indice++)
        //    {
        //        if (SeEhSinal(vetInfixo[indice] + ""))
        //        {
        //            while (!pilha.EstaVazia() && SeTemPreferencia(pilha.OTopo(), vetInfixo[indice] + ""))
        //            {
        //                string sinal = pilha.Desempilhar();
        //                double b = double.Parse(pilhaResult.Desempilhar());

        //                if (sinal != "@")
        //                {
        //                    if (sinal != ")" && sinal != "(")
        //                    {
        //                        double a = double.Parse(pilhaResult.Desempilhar());// erro
        //                        pilhaResult.Empilhar(SubExpressao(a, b, Convert.ToChar(sinal)));
        //                    }                           
        //                }
        //                else
        //                {
        //                    if (sinal == "@")
        //                    {
        //                        double result = -b;
        //                        pilhaResult.Empilhar(result + "");
        //                    }
        //                }

        //            }
        //            pilha.Empilhar(vetInfixo[indice] + "");
        //        }
        //        else
        //        {
        //            pilhaResult.Empilhar(vetInfixo[indice]);
        //        }
        //    }

        //    while (!pilha.EstaVazia())
        //    {
        //        string sinal = pilha.Desempilhar();
        //        double b = double.Parse(pilhaResult.Desempilhar());

        //        if (sinal != "@")
        //        {
        //            double a = double.Parse(pilhaResult.Desempilhar());
        //            pilhaResult.Empilhar(SubExpressao(a, b, Convert.ToChar(sinal)));
        //        }
        //        else
        //        {
        //            if (sinal == "@")
        //            {
        //                double result = -b;
        //                pilhaResult.Empilhar(result + "");
        //            }
        //        }
        //    }

        //    return pilhaResult.Desempilhar();
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

        public string Ordenar(string exp)  //ARRUMAR
        public string Ordenar(string exp)
        {
            string ordenada = exp;
            for(int i = 0; i < exp.Length; i++)
            for (int i = 1; i < exp.Length; i++)
            {
                if(SeEhSinal(exp[i] + ""))
                if (SeEhSinal(exp[i] + ""))
                {
                    if(SeEhSinal(exp[i - 1] + ""))
                    if (SeEhSinal(exp[i - 1] + ""))
                    if(i > 0 && SeEhSinal(exp[i - 1] + ""))
                    {
                        if(exp[i - 1] == exp[i])
                        if (exp[i - 1] == exp[i])
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
                            if (exp[i - 1] != ')' && exp[i - 1] != '(' && exp[i] != ')' && exp[i] != '(')//tem erro na sequencia
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
        public bool VerificarParenteses(string expressao) //Método bool que verifica se os parenteses de uma sequencia estão ordenados
        {
            PilhaHerdaLista<string> parenteses = new PilhaHerdaLista<string>();
            PilhaHerdaLista<string> parenteses = new PilhaHerdaLista<string>(); //instanciação da pilha parenteses, que, como o nome informa, nunca guardará algo que não seja abre ou fecha parenteses

            foreach (var a in expressao)
                if (a == '(')
                    parenteses.Empilhar(a + "");
                else if (a == ')')
            foreach (var a in expressao) //Percorre caractere por caractere da string passada por parâmetro
                if (a == '(')  //Verifica se o caractere atual é um abre parenteses; se não for, lemos o próximo caractere
                    parenteses.Empilhar(a + ""); //Empilhamos o abre parenteses sempre que o achamos
                else if (a == ')') //Verifica se o caractere atual é um fecha parenteses; se não for, lemos o próximo caractere
                {
                    try
                    {
                        parenteses.Desempilhar();
                        parenteses.Desempilhar(); //Caso consiga desempilhar, significa que a pilha não está vazia, logo sabemos que tem um abre parenteses referente ao fecha parenteses lido nessa posiçao da string, portanto está em ordem, e continuamos a percorre-la
                    }
                    catch (Exception)
                    catch (Exception) //Se tentarmos desempilhar algo de uma pilha vazia, uma exceção é lançada
                    {
                        return false;
                        return false;  //Caso não consiga desempilhar um fecha parenteses referente à um abre parenteses, a sequencia não está ordenada, portanto retornamos false
                    }
                }
            if (!parenteses.EstaVazia())
                return false;
            if (!parenteses.EstaVazia()) //Se a pilha parenteses não estiver vazia, então a sequencia fornecida por parametro tem mais fecha parenteses do que abre parenteses, portanto não está ordenada
                return false; //Retornamos false se a sequencia não está ordenada

            return true;
            return true;  //Retornamos true se a sequencia está ordenada
        }
    }
}