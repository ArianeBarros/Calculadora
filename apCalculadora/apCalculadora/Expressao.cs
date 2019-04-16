using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCalculadora
{
    public class Expressao
    {
        public static readonly bool[,] precedenciasDeSinais =
                                        {
                                            { false, false, false, false, false, false, true  },
                                            { false, true,  true,  true,  true,  true,  true  },
                                            { false, false, true,  true,  true,  true,  true  },
                                            { false, false, true,  true,  true,  true,  true  },
                                            { false, false, false, false, true,  true,  true  },
                                            { false, false, false, false, true,  true,  true  },
                                            { false, false, false, false, false, false, false }
                                        };

        public static readonly char[] sinais = { '(', '^', '*', '/', '+', '-', ')' };
        private String sentenca;
        private Dictionary<char, double> dicionario;
        public string Sentenca
        {
            get => sentenca;
        }
        public Dictionary<char, double> Dicionario
        {
            get => dicionario;
        }
        public Expressao(string s, Dictionary<char, double> d)
        {
            sentenca = s;
            dicionario = d;
        }

        public static Expressao Dicionarizar(string sentenca)
        {
            Dictionary<char, double> d = new Dictionary<char, double>();
            StringBuilder novaExpressao = new StringBuilder(sentenca);
            for(int i = 0; i < novaExpressao.Length; i ++)
                if(!isOperador(novaExpressao[i]))
                {
                    //Se não é um operador, é um número, assim, pegamos seu início e vamos o percorrendo até achar o proximo operador, ou o final da string
                    //Após isso, sabemos seu tamanho, então fazemos um substring e o convertemos para double.
                    string numero = "";
                    int indexInicio = i;

                    while (indexInicio + numero.Length < novaExpressao.Length && !isOperador(novaExpressao[indexInicio + numero.Length]))
                        numero += novaExpressao[indexInicio + numero.Length];

                    double chave = Convert.ToDouble(numero);

                    novaExpressao.Remove(indexInicio, numero.Length);
                    d.Add(char.ConvertFromUtf32(65 + d.Count)[0], chave);

                    novaExpressao.Insert(indexInicio, char.ConvertFromUtf32(65 + d.Count - 1));

                    i = indexInicio;
                }

            return new Expressao(novaExpressao.ToString(), d);
        }

        public static Expressao TraduzirParaPosfixa(Expressao sInfixa)
        {
            String infixa = sInfixa.sentenca;
            String posfixa = "";
            PilhaHerdaLista<char> p = new PilhaHerdaLista<char>();

            for(int i = 0; i<infixa.Length; i++)
            {
                bool unario = false;

                if(isOperador(infixa[i]))
                {
                    if(infixa[i] == '-')
                        if(i == 0|| infixa[i-1] == '(')
                        {
                            p.Empilhar('@');
                            unario = true;
                        }
                    if(!unario)
                    {
                        bool parar = false;
                        while(!parar && Precedencia(p.OTopo(),infixa[i]) && !p.EstaVazia())
                        {
                            char opMaiorPrec = p.OTopo();
                            if (opMaiorPrec == '(')
                                parar = true;
                            else
                            {
                                posfixa += opMaiorPrec;
                                p.Desempilhar();
                            }
                        }
                        if (infixa[i] != ')')
                            p.Empilhar(infixa[i]);
                        else
                            p.Desempilhar();
                    }
                }
                while (!p.EstaVazia())
                {
                    char opMaiorPrec = p.Desempilhar();
                    if (opMaiorPrec != '(')
                        posfixa += opMaiorPrec;
                }
            }

            return new Expressao(posfixa, sInfixa.dicionario);
        }

        //public static double ResolverPosfixa(Expressao sPosfixa)
        //{

        //}

        private static double SubExpressao(double operando1, double operando2, char sinal)
        {
            switch(sinal)
            {
                case '+': return operando1 + operando2;
                case '-': return operando1 - operando2;
                case '*': return operando1 * operando2;
                case '/': return operando1 / operando2;
                case '^': return Math.Pow(operando1, operando2);
                default: return 0; // Retorno padrão, apenas para satisfazer o compilador 
            }
        }

        private static bool isOperador(char c)
        {
            foreach (char sinal in sinais)
                if (c == sinal)
                    return true;
            return false;
        }

        private static bool Precedencia(char c1, char c2)
        {
            if (c1 == '@' || c2 == '@')
                return true;

            int indiceC1 = Array.FindIndex(sinais, x => x == c1),
                indiceC2 = Array.FindIndex(sinais, y => y == c2);

            if (indiceC1 < 0 || indiceC2 < 0)
                throw new ArgumentException("Sinal não existente");

            return precedenciasDeSinais[indiceC1, indiceC2];
        }
    }
}
