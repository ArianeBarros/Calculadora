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
        char elemento;
        int preferencia;
        public Expressao(char elemento, int preferencia)
        {
            this.elemento = elemento;
            this.preferencia = preferencia;
        }
    }
}
