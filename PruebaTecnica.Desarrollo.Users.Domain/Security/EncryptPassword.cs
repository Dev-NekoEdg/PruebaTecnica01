namespace PruebaTecnica.Desarrollo.Users.Domain.Security
{
    using System.Security.Cryptography;
    using System.Text;

    internal class EncryptPassword
    {
        /// <summary>
        /// Encripta el texto en SHA 256.
        /// </summary>
        /// <param name="text">Texto que se require encriptar.</param>
        /// <returns>String texto encriptado en SHA 256.</returns>
        public static string Encrypt256(string text)
        {

            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(text));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

            return sb.ToString();
        }
    }
}
