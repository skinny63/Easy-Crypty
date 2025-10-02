namespace EasyCrypty.Hash
{
    using System;
    using System.Security.Cryptography;
    using System.Reflection;

    /// <summary>
    /// Extension methods for creating instances of hash algorithms using reflection.
    /// </summary>
    public static class HashAlgorithmHelper
    {
        /// <summary>
        /// Creates an instance of the specified <see cref="HashAlgorithm"/> implementation using its static parameterless <c>Create()</c> method.
        /// </summary>
        /// <typeparam name="THashAlgorithm">The type of hash algorithm to create.</typeparam>
        /// <returns>
        /// An instance of <typeparamref name="THashAlgorithm"/> if the static <c>Create()</c> method is available and returns a valid object.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the static <c>Create()</c> method is not found, not public, or does not return a valid instance of <typeparamref name="THashAlgorithm"/>.
        /// </exception>
        public static THashAlgorithm Create<THashAlgorithm>()
            where THashAlgorithm : HashAlgorithm
        {
            var createMethod = typeof(THashAlgorithm).GetMethod(
                "Create",
                BindingFlags.Public | BindingFlags.Static,
                Type.DefaultBinder,
                Type.EmptyTypes,
                null
            ) ?? throw new InvalidOperationException(
                    $"No public static parameterless Create() method found for {typeof(THashAlgorithm).FullName}."
                );

            if (createMethod.Invoke(null, null) is THashAlgorithm hashAlgorithm)
            {
                return hashAlgorithm;
            }

            throw new InvalidOperationException(
                    $"Failed to create an instance of {typeof(THashAlgorithm).FullName} using the static Create() method. " +
                    "Ensure that the algorithm type provides a public parameterless Create() method and is supported by the .NET cryptography library."
                );
        }
    }
}