using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCalculadora
{
    public class Expressao
    {
        //indicar caracter
        string elemento;
        int preferencia;
        public Expressao(string elemento, int preferencia)
        {
            this.elemento = elemento;
            this.preferencia = preferencia;
        }
        public string Elemento { get => elemento; set => elemento = value; }
        public int Preferencia { get => preferencia; set => preferencia = value; }
    }
}