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

        /// <summary>
        /// Try get environment variable (generic <seealso cref="Environment.GetEnvironmentVariable"/>).<para></para>
        /// [<see langword="true"/>, <paramref name="value"/>=<typeparamref name="TType"/>] when environment variable was found.<para></para>
        /// [<see langword="false"/>, <paramref name="value"/>=<see langword="default"/>(<typeparamref name="TType"/>)] when <paramref name="name"/> is <see langword="null"/>.<para></para>
        /// [<see langword="false"/>, <paramref name="value"/>=<see langword="default"/>(<typeparamref name="TType"/>)] when environment variable wasn't found.<para></para>
        /// [<see langword="false"/>, <paramref name="value"/>=<see langword="default"/>(<typeparamref name="TType"/>)] when cannot convert environment variable to <typeparamref name="TType"/>.<para></para>
        /// [<see langword="false"/>, <paramref name="value"/>=<see langword="default"/>(<typeparamref name="TType"/>)] when a security error is detected.<para></para>
        /// [<see langword="false"/>, <paramref name="value"/>=<see langword="default"/>(<typeparamref name="TType"/>)] when an arithmetic, casting, or conversion operation in a checked context results in an overflow.<para></para>
        /// </summary>
        /// <typeparam name="TType">Type of environment variable value.</typeparam>
        /// <param name="name">Name of environment variable.</param>
        /// <param name="value">Environment variable value.</param>
        /// <returns><see langword="true"/> if environment variable was gotten by <paramref name="name"/>; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetEnvironmentVariable<TType>(string name, out TType value)
        {
            value = default;
            if (name == null)
            {
                return false;
            }
            string environmentVariable = Environment.GetEnvironmentVariable(name);
            if (environmentVariable == null)
            {
                return false;
            }
            try
            {
                Type t = Nullable.GetUnderlyingType(typeof(TType)) ?? typeof(TType);
                value = (TType)Convert.ChangeType(environmentVariable, t);
                return true;
            }
            catch (Exception ex) when (
                ex is FormatException ||
                ex is SecurityException ||
                ex is OverflowException)
            {
                return false;
            }
        }
    }
}
