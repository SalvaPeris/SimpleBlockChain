using BlockChain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Transacciones
{
    class Transferencia
    {
        public Transferencia(CadenaBloques blockChain, string direccionMinero, string direccionEnvio, string direccionRecibo, int cantidad)
        {
            blockChain.CrearTransaccion(new Transaccion(direccionEnvio, direccionRecibo, cantidad));
            Console.WriteLine("DE: {0} ............ A: {1} ........... CANTIDAD: {2} ", direccionEnvio, direccionRecibo, cantidad);
            Console.WriteLine();
            Console.WriteLine("¿Es válida?: {0}", blockChain.CadenaEsValida());
            Console.WriteLine();
            Console.WriteLine("----------------- EMPEZAMOS A MINAR ----------------- ");
            blockChain.MinarBloque(direccionMinero);
            Console.WriteLine("Balance del minero: {0}", blockChain.Balance(direccionMinero));
        }
        public static void ImprimirCadena(CadenaBloques blockChain)
        {
            Console.WriteLine("----------------- CADENA DE BLOQUES ----------------- ");
            foreach (Bloque bloque in blockChain.Cadena)
            {
                Console.WriteLine();
                Console.WriteLine("----------------- BLOQUE ----------------- ");
                Console.WriteLine("Hash: {0}", bloque.Hash);
                Console.WriteLine("Hash previo: {0}", bloque.PrevioHash);
                Console.WriteLine("----------------- TRANSACCIÓN ----------------- ");
                foreach (Transaccion transaccion in bloque.Transacciones)
                {
                    Console.WriteLine();
                    Console.WriteLine("DE: {0} ............ A: {1} ........... CANTIDAD: {2} ", transaccion.De, transaccion.A, transaccion.Cantidad);
                    Console.WriteLine();
                }
                Console.WriteLine("----------------- FIN TRANSACCIONES -----------------");
                Console.WriteLine("----------------- FIN BLOQUE ----------------- ");
            }
            Console.WriteLine("----------------- FIN CADENA DE BLOQUES ----------------- ");
        }
    }
}
