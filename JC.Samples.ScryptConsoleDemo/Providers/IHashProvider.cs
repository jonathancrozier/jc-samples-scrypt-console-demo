namespace JC.Samples.ScryptConsoleDemo.Providers
{
    /// <summary>
    /// Interface for hashing service providers.
    /// </summary>
    public interface IHashProvider
    {
        /// Compares a plain value against a hashed value.
        /// </summary>
        /// <param name="plainValue">The plain string to compare</param>
        /// <param name="hashedValue">The hashed string to compare</param>
        /// <returns>True if the plain string when hashed matches the hashed string, otherwise false</returns>
        bool CompareHash(string plainValue, string hashedValue);

        /// <summary>
        /// Hashes the value provided.
        /// </summary>
        /// <param name="value">The value to hash</param>
        /// <returns>The hashed value</returns>
        string ComputeHash(string value);

        /// <summary>
        /// Checks if a string is a valid hash.
        /// </summary>
        /// <param name="hashedValue">The hashed value to check for validity</param>
        /// <returns>True if the string is a valid hash, otherwise false</returns>
        bool ValidateHash(string hashedValue);
    }
}