using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Classes
{
    public class Transaccion
    {
        public string De { get; }
        public string A { get; }
        public double Cantidad { get; }
        public Transaccion(string de, string a, double cantidad)
        {
            De = de;
            A = a;
            Cantidad = cantidad;
        }
    }
}
