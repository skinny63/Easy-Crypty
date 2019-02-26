using System;
using System.Security.Cryptography;
using System.Text;
using Blake2Sharp;

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
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                foreach (var encryptedByte in md5Hash.ComputeHash(byteArrayToEncrypt))
                    sBuilder.Append(encryptedByte.ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
