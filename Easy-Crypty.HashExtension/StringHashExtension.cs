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
        /// <param name="byteArrayToEncrypt">bByte array to encrypt</param>
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

        /// <summary>
        /// get the Blake2b-512 encrypt
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns></returns>
        public static string Blake2b_512Hash(this string stringToEncrypt) => Blake2b_512Hash(Encoding.UTF8.GetBytes(stringToEncrypt));

        /// <summary>
        /// get the Blake2b-512 encrypt
        /// </summary>
        /// <param name="byteArrayToEncrypt">Byte array to encrypt</param>
        /// <returns></returns>
        public static string Blake2b_512Hash(this byte[] byteArrayToEncrypt)
        {
            StringBuilder sBuilder = new StringBuilder();

            foreach (var encryptedByte in Blake2B.ComputeHash(byteArrayToEncrypt))
                sBuilder.Append(encryptedByte.ToString("x2"));
            
            return sBuilder.ToString();
        }

        /// <summary>
        /// get the Sha1 encrypt
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns></returns>
        public static string Sha1Hash(this string stringToEncrypt) => Sha1Hash(Encoding.UTF8.GetBytes(stringToEncrypt));

        /// <summary>
        /// get the Sha1 encrypt
        /// </summary>
        /// <param name="byteArrayToEncrypt">Byte array to encrypt</param>
        /// <returns></returns>
        public static string Sha1Hash(this byte[] byteArrayToEncrypt)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (SHA1 sha1Hash = SHA1.Create())
            {
                foreach (var encryptedByte in sha1Hash.ComputeHash(byteArrayToEncrypt))
                    sBuilder.Append(encryptedByte.ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// get the Sha256 encrypt
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns></returns>
        public static string Sha256Hash(this string stringToEncrypt) => Sha256Hash(Encoding.UTF8.GetBytes(stringToEncrypt));

        /// <summary>
        /// get the Sha256 encrypt
        /// </summary>
        /// <param name="byteArrayToEncrypt">Byte array to encrypt</param>
        /// <returns></returns>
        public static string Sha256Hash(this byte[] byteArrayToEncrypt)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (SHA256 sha1Hash = SHA256.Create())
            {
                foreach (var encryptedByte in sha1Hash.ComputeHash(byteArrayToEncrypt))
                    sBuilder.Append(encryptedByte.ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// get the Sha384 encrypt
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns></returns>
        public static string Sha384Hash(this string stringToEncrypt) => Sha384Hash(Encoding.UTF8.GetBytes(stringToEncrypt));

        /// <summary>
        /// get the Sha384 encrypt
        /// </summary>
        /// <param name="byteArrayToEncrypt">Byte array to encrypt</param>
        /// <returns></returns>
        public static string Sha384Hash(this byte[] byteArrayToEncrypt)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (SHA384 sha1Hash = SHA384.Create())
            {
                foreach (var encryptedByte in sha1Hash.ComputeHash(byteArrayToEncrypt))
                    sBuilder.Append(encryptedByte.ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// get the Sha512 encrypt
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns></returns>
        public static string Sha512Hash(this string stringToEncrypt) => Sha512Hash(Encoding.UTF8.GetBytes(stringToEncrypt));

        /// <summary>
        /// get the Sha512 encrypt
        /// </summary>
        /// <param name="byteArrayToEncrypt">Byte array to encrypt</param>
        /// <returns></returns>
        public static string Sha512Hash(this byte[] byteArrayToEncrypt)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (SHA512 sha1Hash = SHA512.Create())
            {
                foreach (var encryptedByte in sha1Hash.ComputeHash(byteArrayToEncrypt))
                    sBuilder.Append(encryptedByte.ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
