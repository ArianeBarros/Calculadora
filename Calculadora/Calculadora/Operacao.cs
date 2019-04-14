using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Operacao
    {
        char operador;
        int prioridade;
        int operadorA, operadorB;
        
        public Operacao(string infixa)
        {
            this.operador = infixa[1];
            this.operadorA = infixa[0];
            this.operadorB = infixa[2];
        }

        public char Operador
        {
            get => operador;
          //  set => operador = value;
        }

        public int Prioridade
        {
            get => prioridade;
            set => prioridade = value;
        }
        public int OperadorA
        {
            get => operadorA;
            set => operadorA = value;
        }

        public int OperadorB
        {
            get => operadorB;
            set => operadorB = value;
        }

        public double Operar(char sinal)
        {
            double result = 0;

            

            return result;
        }
    }
}
