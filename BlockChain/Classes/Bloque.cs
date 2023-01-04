using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Classes
{
    public class Bloque
    {
        private readonly DateTime _timeStamp;
        private long _nonce;
        public string PrevioHash { get; set; }
        public List<Transaccion> Transacciones { get; set; }

        public string Hash { get; private set; }

        public Bloque(DateTime timeStamp, List<Transaccion> transacciones, string previoHash = "")
        {
            _timeStamp = timeStamp;
            _nonce = 0;
            Transacciones = transacciones;
            PrevioHash = previoHash;
            Hash = CrearHash();
        }
        public void MinarBloque(int DificultadMinado)
        {
            string hashValidationTemplate = new String('0', DificultadMinado);

            while (Hash.Substring(0, DificultadMinado) != hashValidationTemplate)
            {
                _nonce++;
                Hash = CrearHash();
            }
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine(" Bloque con HASH = {0} minado correctamente!  ", Hash);
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        }

        public string CrearHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawDato = PrevioHash + _timeStamp + Transacciones + _nonce;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawDato));
                return Encoding.Default.GetString(bytes);
            }
        }
    }
}
