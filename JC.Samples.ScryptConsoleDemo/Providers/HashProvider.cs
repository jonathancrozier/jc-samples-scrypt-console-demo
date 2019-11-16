using Scrypt;

namespace JC.Samples.ScryptConsoleDemo.Providers
{
    /// <summary>
    /// Provides public hashing services.
    /// Note: Memory usage calculation = 128 * BlockSize * IterationCount * ThreadCount 
    /// e.g. 128 * 16384 * 8 * 1 = 16MB.
    /// </summary>
    public class HashProvider : IHashProvider
    {
        #region Constants

        /// <summary>
        /// Specifies the amount of memory which will be required per hash iteration, 
        /// increasing this will escalate the memory cost.
        /// (The recommended setting is 8)
        /// </summary>
        private const int BlockSize = 8;

        /// <summary>
        /// Specifies the number of hash iterations performed, 
        /// increasing this will escalate the processing time as well as the memory cost.
        /// (The recommended setting is 16384).
        /// </summary>
        private const int IterationCount = 16384;

        /// <summary>
        /// Specifies the number of parallel calculations required, 
        /// increasing this will greatly escalate the processing time as well as the memory cost.
        /// (The recommended setting is 1)
        /// </summary>
        private const int ThreadCount = 1;

        #endregion

        #region Readonlys

        private readonly ScryptEncoder _encoder;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public HashProvider()
        {
            _encoder = new ScryptEncoder(IterationCount, BlockSize, ThreadCount);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compares a plain value against a hashed value.
        /// </summary>
        /// <param name="plainValue">The plain string to compare</param>
        /// <param name="hashedValue">The hashed string to compare</param>
        /// <returns>True if the plain string when hashed matches the hashed string, otherwise false</returns>
        public bool CompareHash(string plainValue, string hashedValue) => 
            _encoder.IsValid(hashedValue) && _encoder.Compare(plainValue, hashedValue);

        /// <summary>
        /// Hashes the value provided.
        /// </summary>
        /// <param name="value">The value to hash</param>
        /// <returns>The hashed value</returns>
        public string ComputeHash(string value) => _encoder.Encode(value);

        /// <summary>
        /// Checks if a string is a valid hash.
        /// </summary>
        /// <param name="hashedValue">The hashed value to check for validity</param>
        /// <returns>True if the string is a valid hash, otherwise false</returns>
        public bool ValidateHash(string hashedValue) => _encoder.IsValid(hashedValue);

        #endregion
    }
}