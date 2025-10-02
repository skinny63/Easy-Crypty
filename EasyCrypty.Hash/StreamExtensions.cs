namespace EasyCrypty.Hash
{
    using System.Security.Cryptography;

    /// <summary>
    /// Provides extension methods for computing hash values from streams.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Computes the hash value of the stream using the specified hash algorithm type.
        /// </summary>
        /// <typeparam name="THashAlgorithm">
        /// The type of <see cref="HashAlgorithm"/> to use for hashing.
        /// </typeparam>
        /// <param name="stream">
        /// The input stream to compute the hash from.
        /// </param>
        /// <returns>
        /// A <see cref="HashBytes"/> instance containing the computed hash value.
        /// </returns>
        public static HashBytes HashWith<THashAlgorithm>(this Stream stream)
            where THashAlgorithm : HashAlgorithm
        {
            using var hashAlgorithm = HashAlgorithmHelper.Create<THashAlgorithm>();
            return stream.HashWith(hashAlgorithm);
        }

        /// <summary>
        /// Computes the hash value of the stream using the provided hash algorithm instance.
        /// </summary>
        /// <typeparam name="THashAlgorithm">
        /// The type of <see cref="HashAlgorithm"/> used for hashing.
        /// </typeparam>
        /// <param name="stream">
        /// The input stream to compute the hash from.
        /// </param>
        /// <param name="hashAlgorithm">
        /// The hash algorithm instance to use for computing the hash.
        /// </param>
        /// <returns>
        /// A <see cref="HashBytes"/> instance containing the computed hash value.
        /// </returns>
        public static HashBytes HashWith<THashAlgorithm>(this Stream stream, THashAlgorithm hashAlgorithm)
            where THashAlgorithm : HashAlgorithm
        {
            return new(hashAlgorithm.ComputeHash(stream));
        }
    }
}
