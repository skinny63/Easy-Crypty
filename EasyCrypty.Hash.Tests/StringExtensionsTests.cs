namespace EasyCrypty.Hash.Tests
{
    using System.Security.Cryptography;

    /// <summary>
    /// Contains unit tests for the <see cref="StringExtensions"/> class hash methods.
    /// </summary>
    public class StringExtensionsTests
    {
        /// <summary>
        /// Gets the test string used for hash validation.
        /// </summary>
        private static string TestString => "test";

        /// <summary>
        /// Verifies that <see cref="StringExtensions.HashWith{T}(string)"/> produces the expected hash output<br/>
        /// for various hash algorithms and a fixed input string.
        /// </summary>
        /// <param name="hashType">The type of the hash algorithm to use.</param>
        /// <param name="expected">The expected hash value as a hexadecimal string.</param>
        [Theory]
        [InlineData(typeof(MD5), "098F6BCD4621D373CADE4E832627B4F6")]
        [InlineData(typeof(SHA1), "A94A8FE5CCB19BA61C4C0873D391E987982FBBD3")]
        [InlineData(typeof(SHA256), "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08")]
        [InlineData(typeof(SHA384), "768412320F7B0AA5812FCE428DC4706B3CAE50E02A64CAA16A782249BFE8EFC4B7EF1CCB126255D196047DFEDF17A0A9")]
        [InlineData(typeof(SHA512), "EE26B0DD4AF7E749AA1A8EE3C10AE9923F618980772E473F8819A5D4940E0DB27AC185F8A0E1D5F84F88BC887FD67B143732C304CC5FA9AD8E6F57F50028A8FF")]
        public void HashWith_GenericHashAlgorithm_String_ReturnsExpectedHash(Type hashType, string expected)
        {
            var method = typeof(StringExtensions).GetMethod("HashWith", [typeof(string)])
                ?? throw new MissingMethodException("HashWith(string) not found in StringExtensions.");

            var actual = (HashBytes)method.MakeGenericMethod(hashType).Invoke(null, [TestString])!;

            Assert.Equal(expected, actual.ToString());
        }
    }
}