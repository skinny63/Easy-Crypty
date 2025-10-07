namespace EasyCrypty.Hash.Tests
{
    using System.Reflection;
    using System.Security.Cryptography;

    /// <summary>
    /// Contains unit tests for the <see cref="StringExtensions"/> class hash methods.
    /// </summary>
    public class StringExtensionsTests
    {
        /// <summary>
        /// Gets the test string used for hash validation.
        /// </summary>
        private const string TestString = "test";

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

        /// <summary>
        /// Verifies that <see cref="StringExtensions.HashWith{T}(string, T)"/> produces the expected hash output<br/>
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
        public void HashWithInstance_GenericHashAlgorithm_String_ReturnsExpectedHash(Type hashType, string expected)
        {
            var method = typeof(StringExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(method => method.Name == "HashWith")
                .SingleOrDefault(method =>
                    method.IsGenericMethodDefinition &&
                    method.GetParameters().Length == 2 &&
                    method.GetParameters()[0].ParameterType == typeof(string) &&
                    method.GetParameters()[1].ParameterType.IsGenericParameter)
                ?? throw new MissingMethodException("HashWith(string, HashAlgorithm) not found in StringExtensions.");

            using var hashAlgorithm = GetHashAlgorithm(hashType);
            var actual = (HashBytes)method.MakeGenericMethod(hashType).Invoke(null, [TestString, hashAlgorithm])!;
            Assert.Equal(expected, actual.ToString());
        }

        /// <summary>
        /// Verifies that <see cref="StringExtensions.HashWith{T}(IEnumerable{string})"/> produces the expected hash output<br/>
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
        public void HashWith_GenericHashAlgorithm_EnumerableString_ReturnsExpectedHash(Type hashType, string expected)
        {
            var method = typeof(StringExtensions).GetMethod("HashWith", [typeof(IEnumerable<string>)])
                ?? throw new MissingMethodException("HashWith(IEnumerable<string>) not found in StringExtensions.");

            var actual = (IEnumerable<HashBytes>)method.MakeGenericMethod(hashType).Invoke(null, [Enumerable.Range(1, 10).Select(_ => TestString)])!;
            Assert.All(actual, computedHash => Assert.Equal(expected, computedHash.ToString()));
        }

        /// <summary>
        /// Verifies that <see cref="StringExtensions.HashWith{T}(IEnumerable{string}, T)"/> produces the expected hash output<br/>
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
        public void HashWithInstance_GenericHashAlgorithm_EnumerableString_ReturnsExpectedHash(Type hashType, string expected)
        {
            var method = typeof(StringExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(method => method.Name == "HashWith")
                .SingleOrDefault(method =>
                    method.IsGenericMethodDefinition &&
                    method.GetParameters().Length == 2 &&
                    method.GetParameters()[0].ParameterType == typeof(IEnumerable<string>) &&
                    method.GetParameters()[1].ParameterType.IsGenericParameter)
                ?? throw new MissingMethodException("HashWith(IEnumerable<string>, HashAlgorithm) not found in StringExtensions.");

            using var hashAlgorithm = GetHashAlgorithm(hashType);
            var actual = (IEnumerable<HashBytes>)method.MakeGenericMethod(hashType).Invoke(null, [Enumerable.Range(1, 10).Select(_ => TestString), hashAlgorithm])!;
            Assert.All(actual, computedHash => Assert.Equal(expected, computedHash.ToString()));
        }

        /// <summary>
        /// Verifies that <see cref="StringExtensions.HashWith{T}(IAsyncEnumerable{string})"/> produces the expected hash output<br/>
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
        public void HashWith_GenericHashAlgorithm_AsyncEnumerableString_ReturnsExpectedHash(Type hashType, string expected)
        {
            var method = typeof(StringExtensions).GetMethod("HashWithAsync", [typeof(IAsyncEnumerable<string>)])
                ?? throw new MissingMethodException("HashWith(IAsyncEnumerable<string>) not found in StringExtensions.");

            var actual = (IAsyncEnumerable<HashBytes>)method.MakeGenericMethod(hashType).Invoke(null, [WrapListAsync(Enumerable.Range(1, 10).Select(_ => TestString))])!;
            Assert.All(actual, computedHash => Assert.Equal(expected, computedHash.ToString()));
        }

        /// <summary>
        /// Verifies that <see cref="StringExtensions.HashWith{T}(IAsyncEnumerable{string}, T)"/> produces the expected hash output<br/>
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
        public void HashWithInstance_GenericHashAlgorithm_AsyncEnumerableString_ReturnsExpectedHash(Type hashType, string expected)
        {
            var method = typeof(StringExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(method => method.Name == "HashWithAsync")
                .SingleOrDefault(method =>
                    method.IsGenericMethodDefinition &&
                    method.GetParameters().Length == 2 &&
                    method.GetParameters()[0].ParameterType == typeof(IAsyncEnumerable<string>) &&
                    method.GetParameters()[1].ParameterType.IsGenericParameter)
                ?? throw new MissingMethodException("HashWith(IAsyncEnumerable<string>, HashAlgorithm) not found in StringExtensions.");

            using var hashAlgorithm = GetHashAlgorithm(hashType);
            var actual = (IAsyncEnumerable<HashBytes>)method.MakeGenericMethod(hashType).Invoke(null, [WrapListAsync(Enumerable.Range(1, 10).Select(_ => TestString)), hashAlgorithm])!;
            Assert.All(actual, computedHash => Assert.Equal(expected, computedHash.ToString()));
        }

        /// <summary>
        /// Creates an instance of the specified <see cref="HashAlgorithm"/> implementation using its static parameterless <c>Create()</c> method.
        /// </summary>
        /// <param name="algorithmType"></param>
        /// <returns>An instance of <see cref="HashAlgorithm"/> if the static <c>Create()</c> method is available and returns a valid object.</returns>
        private static HashAlgorithm GetHashAlgorithm(Type algorithmType)
        {
            var createMethod = algorithmType.GetMethod(
                "Create",
                BindingFlags.Public | BindingFlags.Static,
                Type.DefaultBinder,
                Type.EmptyTypes,
                null
            ) ?? throw new InvalidOperationException(
                    $"No public static parameterless Create() method found for {algorithmType.FullName}.");

            if (createMethod.Invoke(null, null) is HashAlgorithm hashAlgorithm)
            {
                return hashAlgorithm;
            }

            throw new InvalidOperationException(
                    $"Failed to create an instance of {algorithmType.FullName} using the static Create() method. " +
                    "Ensure that the algorithm type provides a public parameterless Create() method and is supported by the .NET cryptography library."
                );
        }

        /// <summary>
        /// Wraps a synchronous enumerable into an asynchronous enumerable for testing purposes.
        /// </summary>
        /// <param name="items">The input items to wrap.</param>
        /// <returns>An asynchronous enumerable that yields the input items.</returns>
        private async IAsyncEnumerable<string> WrapListAsync(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                await Task.Yield(); // Simulate async
                yield return item;
            }
        }
    }
}