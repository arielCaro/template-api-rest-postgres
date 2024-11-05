using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template.api.postgres.common
{
    public static class Security
    {
        /// <summary>
        /// Método que encripta una cadena de texto.
        /// </summary>
        /// <param name="_cadenaAencriptar">texto a encriptar</param>
        /// <returns>Retorna un string</returns>
        public static string Encrypt(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// <summary>
        /// Método que desencripta cadena de texto encriptado.
        /// </summary>
        /// <param name="_cadenaAdesencriptar">Cadena de texto encriptado.</param>
        /// <returns>Retorna un string.</returns>
        public static string Decrypt(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
