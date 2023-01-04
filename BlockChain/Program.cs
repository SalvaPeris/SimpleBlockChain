using BlockChain.Classes;
using BlockChain.Transacciones;
using System;
using System.Collections.Generic;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            const string direccionMinero = "minero";
            const string direccionUserA = "Usuario1";
            const string direccionUserB = "Usuario2";

            CadenaBloques blockChain = new CadenaBloques(dificultadMinado: 2, premioMinado: 10);
            Console.WriteLine("----------------- TRANSFERENCIA 1 -----------------");
            Console.WriteLine();
            _ = new Transferencia(blockChain, direccionMinero, direccionUserA, direccionUserB, 200);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------- TRANSFERENCIA 2 -----------------");
            Console.WriteLine();
            _ = new Transferencia(blockChain, direccionMinero, direccionUserB, direccionUserA, 10);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------- TRANSFERENCIA 3 -----------------");
            Console.WriteLine();
            _ = new Transferencia(blockChain, direccionMinero, direccionUserA, direccionUserB, 5);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Transferencia.ImprimirCadena(blockChain);
            Console.WriteLine();
            Console.WriteLine("HACKEANDO LA CADENA DE BLOQUES...");
            blockChain.Cadena[1].Transacciones = new List<Transaccion> { new Transaccion(direccionUserA, direccionMinero, 150) };
            Console.WriteLine("¿Es Válida?: {0}", blockChain.CadenaEsValida());
        }
    }
}
