using System;
using System.Security;

namespace GenericEnv
{
    /// <summary>
    /// Generic <seealso cref="Environment"/> class.
    /// </summary>
    public static class GenericEnvironment
    {
        /// <summary>
        /// Generic <seealso cref="Environment.GetEnvironmentVariable"/>.<para></para>
        /// Throw <see cref="ArgumentNullException"/> when <paramref name="name"/> is null.<para></para>
        /// Throw <see cref="InvalidOperationException"/> when cannot find environment variable by <paramref name="name"/>.<para></para>
        /// Throw <see cref="InvalidCastException"/> when <typeparamref name="TType"/> is nullable.<para></para>
        /// Throw <see cref="FormatException"/> when cannot convert environment variable to <typeparamref name="TType"/>.<para></para>
        /// Throw <see cref="SecurityException"/> when a security error is detected.<para></para>
        /// Throw <see cref="OverflowException"/> when an arithmetic, casting, or conversion operation in a checked context results in an overflow.<para></para>
        /// </summary>
        /// <typeparam name="TType">Type of environment variable value.</typeparam>
        /// <param name="name">Name of environment variable</param>
        /// <returns>Return <typeparamref name="TType"/> value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="SecurityException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static TType GetEnvironmentVariable<TType>(string name)
        {
            string environmentVariable = Environment.GetEnvironmentVariable(name);
            if (environmentVariable == null)
            {
                throw new InvalidOperationException($"Cannot find environment variable by name: \"{name}\".");
            }
            return (TType)Convert.ChangeType(environmentVariable, typeof(TType));
        }
    }
}
