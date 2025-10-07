using System.Security.Cryptography;
using System.Text;

namespace EasyCrypty.Hash
{
    /// <summary>
    /// Extension methods for string hashing using various algorithms.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Computes the hash of the specified string using the given hash algorithm type.
        /// </summary>
        /// <typeparam name="THashAlgorithm">The type of hash algorithm to use.</typeparam>
        /// <param name="source">The input string to hash.</param>
        /// <returns>
        /// A byte array containing the computed hash of the input string.
        /// </returns>
        public static HashBytes HashWith<THashAlgorithm>(this string source)
            where THashAlgorithm : HashAlgorithm
        {
            using var hashAlgorithm = HashAlgorithmHelper.Create<THashAlgorithm>();
            return source.HashWith(hashAlgorithm);
        }

        /// <summary>
        /// Computes the hash of the specified string using the provided hash algorithm instance.
        /// </summary>
        /// <typeparam name="THashAlgorithm">The type of hash algorithm.</typeparam>
        /// <param name="source">The input string to hash.</param>
        /// <param name="hashAlgorithm">The hash algorithm instance to use.</param>
        /// <returns>
        /// A byte array containing the computed hash of the input string.
        /// </returns>
        public static HashBytes HashWith<THashAlgorithm>(this string source, THashAlgorithm hashAlgorithm)
            where THashAlgorithm : HashAlgorithm
        {
            return new(hashAlgorithm.ComputeHash(Convert(source)));
        }

        /// <summary>
        /// Computes the hashes of a collection of strings using the specified hash algorithm type.
        /// </summary>
        /// <typeparam name="THashAlgorithm">The type of hash algorithm.</typeparam>
        /// <param name="sources">The input string enumerables to hash.</param>
        /// <returns>
        /// An enumerable of byte arrays, each containing the computed hash of the corresponding input string.
        /// </returns>
        public static IEnumerable<HashBytes> HashWith<THashAlgorithm>(this IEnumerable<string> sources)
            where THashAlgorithm : HashAlgorithm
        {
            using var hashAlgorithm = HashAlgorithmHelper.Create<THashAlgorithm>();

            foreach (var source in sources)
            {
                yield return source.HashWith<THashAlgorithm>(hashAlgorithm);
            }
        }

        /// <summary>
        /// Computes the hashes of a collection of strings using the provided hash algorithm instance.
        /// </summary>
        /// <typeparam name="THashAlgorithm">The type of hash algorithm.</typeparam>
        /// <param name="sources">The input string enumerables to hash.</param>
        /// <param name="hashAlgorithm">The hash algorithm instance to use.</param>
        /// <returns>
        /// An enumerable of byte arrays, each containing the computed hash of the corresponding input string.
        /// </returns>
        public static IEnumerable<HashBytes> HashWith<THashAlgorithm>(this IEnumerable<string> sources, THashAlgorithm hashAlgorithm)
            where THashAlgorithm : HashAlgorithm
        {
            foreach (var source in sources)
            {
                yield return source.HashWith<THashAlgorithm>(hashAlgorithm);
            }
        }

        /// <summary>
        /// Computes the hashes of an asynchronous collection of strings using the specified hash algorithm type.
        /// </summary>
        /// <typeparam name="THashAlgorithm">The type of hash algorithm.</typeparam>
        /// <param name="sources">The input string enumerables to hash.</param>
        /// <returns>
        /// An asynchronous enumerable of byte arrays, each containing the computed hash of the corresponding input string.
        /// </returns>
        public static async IAsyncEnumerable<HashBytes> HashWithAsync<THashAlgorithm>(this IAsyncEnumerable<string> sources)
            where THashAlgorithm : HashAlgorithm
        {
            using var hashAlgorithm = HashAlgorithmHelper.Create<THashAlgorithm>();

            await foreach (var source in sources)
            {
                yield return source.HashWith<THashAlgorithm>(hashAlgorithm);
            }
        }

        /// <summary>
        /// Computes the hashes of an asynchronous collection of strings using the provided hash algorithm instance.
        /// </summary>
        /// <typeparam name="THashAlgorithm">The type of hash algorithm.</typeparam>
        /// <param name="sources">The input string enumerables to hash.</param>
        /// <param name="hashAlgorithm">The hash algorithm instance to use.</param>
        /// <returns>
        /// An asynchronous enumerable of byte arrays, each containing the computed hash of the corresponding input string.
        /// </returns>
        public static async IAsyncEnumerable<HashBytes> HashWithAsync<THashAlgorithm>(this IAsyncEnumerable<string> sources, THashAlgorithm hashAlgorithm)
            where THashAlgorithm : HashAlgorithm
        {
            await foreach (var source in sources)
            {
                yield return source.HashWith<THashAlgorithm>(hashAlgorithm);
            }
        }

        /// <summary>
        /// Converts the specified string to a byte array using the default encoding.
        /// </summary>
        /// <param name="source">The string to convert.</param>
        /// <returns>
        /// A byte array representing the input string.
        /// </returns>
        private static byte[] Convert(string source) => Encoding.Default.GetBytes(source);
    }
}
