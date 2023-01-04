using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Classes
{
    public class CadenaBloques
    {
        private readonly int _dificultadMinado;
        private readonly double _premioMinado;
        private List<Transaccion> _transaccionesPendientes;
        public List<Bloque> Cadena { get; set; }
        public CadenaBloques(int dificultadMinado, int premioMinado)
        {
            _dificultadMinado = dificultadMinado;
            _premioMinado = premioMinado;
            _transaccionesPendientes = new List<Transaccion>();
            Cadena = new List<Bloque> { CrearBloqueGenesis() };
        }
        public void CrearTransaccion(Transaccion transaccion)
        {
            _transaccionesPendientes.Add(transaccion);
        }
        public void MinarBloque(string direccionMinero)
        {
            Transaccion transaccionPremioMinado = new(null, direccionMinero, _premioMinado);
            _transaccionesPendientes.Add(transaccionPremioMinado);
            Bloque bloque = new(DateTime.Now, _transaccionesPendientes);
            Console.WriteLine();
            bloque.MinarBloque(_dificultadMinado);
            bloque.PrevioHash = Cadena.Last().Hash;
            Cadena.Add(bloque);
            Console.WriteLine("HASH ANTERIOR = {0}", bloque.PrevioHash);
            Console.WriteLine();
            Console.WriteLine("HASH ACTUAL = {0}", bloque.Hash);
            _transaccionesPendientes = new List<Transaccion>();
        }
        public bool CadenaEsValida()
        {
            for (int i = 1; i < Cadena.Count; i++)
            {
                Bloque previoBloque = Cadena[i - 1];
                Bloque bloqueActual = Cadena[i];
                if (bloqueActual.Hash != bloqueActual.CrearHash())
                    return false;
                if (bloqueActual.PrevioHash != previoBloque.Hash)
                    return false;
            }
            return true;
        }
        public double Balance(string address)
        {
            double balance = 0;
            foreach (Bloque bloque in Cadena)
            {
                foreach (Transaccion transaccion in bloque.Transacciones)
                {
                    if (transaccion.De == address)
                    {
                        balance -= transaccion.Cantidad;
                    }
                    if (transaccion.A == address)
                    {
                        balance += transaccion.Cantidad;
                    }
                }
            }
            return balance;
        }
        private static Bloque CrearBloqueGenesis()
        {
            List<Transaccion> transacciones = new() { new Transaccion("", "", 0) };
            return new Bloque(DateTime.Now, transacciones, "0");
        }
    }
}
