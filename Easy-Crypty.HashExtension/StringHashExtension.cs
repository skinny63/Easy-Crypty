using System.Security.Cryptography;
using System.Text;

namespace Easy_Crypty.HashExtension
{
    public static class StringHashExtension
    {
        /// <summary>
        /// get the MD5 string hash
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns></returns>
        public static string Md5Hash(this string stringToEncrypt) => Md5Hash(Encoding.UTF8.GetBytes(stringToEncrypt));

        /// <summary>
        /// get the MD5 string hash
        /// </summary>
        /// <param name="byteArrayToEncrypt">byte array to encrypt</param>
        /// <returns></returns>
        public static string Md5Hash(this byte[] byteArrayToEncrypt)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return Encoding.UTF8.GetString(md5Hash.ComputeHash(byteArrayToEncrypt));
            }
        }
    }
}
