namespace EasyCrypty.Hash
{
    /// <summary>
    /// Represents a byte array specifically for hash values, with a custom string representation.
    /// </summary>
    public class HashBytes
    {
        private readonly byte[] _bytes;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBytes"/> class with the specified byte array.
        /// </summary>
        /// <param name="bytes">The byte array representing the hash value.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="bytes"/> is null.</exception>
        public HashBytes(byte[] bytes)
        {
            _bytes = bytes ?? throw new ArgumentNullException(nameof(bytes));
        }

        /// <summary>
        /// Returns a hexadecimal string representation of the hash value.
        /// </summary>
        /// <returns>
        /// A lowercase hexadecimal string without separators representing the hash value.
        /// </returns>
        public override string ToString() => BitConverter.ToString(_bytes).Replace("-", "");

        /// <summary>
        /// Returns the underlying byte array of the hash value.
        /// </summary>
        /// <returns>
        /// The byte array representing the hash value.
        /// </returns>
        public byte[] ToByteArray() => _bytes;
    }
}